CREATE PROCEDURE [dbo].[uspImportEDIHeadersAndDetails810]
AS
BEGIN
	DECLARE @EDINumber VARCHAR(3) = '810'

	DECLARE @Inserted TABLE (
								 IID INT
								,PurchaseOrderNumber VARCHAR(15)
								,InvoiceNumber VARCHAR(15)
							)

	DECLARE @AppCodes TABLE (
								 EDIFileID	INT
								,DTM		VARCHAR(10)
								,SC			VARCHAR(50)
								,RC			VARCHAR(50)
								,ICN		VARCHAR(50)
								,VER		VARCHAR(25)
							)

	INSERT INTO @AppCodes([EDIFileID], [DTM], [SC], [RC], [ICN], [VER])
		SELECT ranges.[EDIFileId], gs.[Date], gs.[ApplicationSenderCode], gs.[ApplicationReceiverCode], isa.[InterchangeControlNumber], gs.[VersionRelIndIDCode]
		FROM (	SELECT DISTINCT [EDIFileId]
				FROM  [HPB_EDI].[dbo].[vuImportEDI_Unprocessed_TransactionRanges]
				WHERE [EDIType] = @EDINumber) ranges
			INNER JOIN [HPB_EDI].[dbo].[importEDI_ISA] isa
				ON isa.[EDIFileId]=ranges.[EDIFileId]
			INNER JOIN [HPB_EDI].[dbo].[importEDI_GS] gs
				ON gs.[EDIFileId]=ranges.[EDIFileId]

	INSERT INTO [HPB_EDI].[dbo].[temp_810_Inv_Hdr] ([InvoiceNo],[IssueDate],[VendorID],[PONumber],[ReferenceNo],[ShipToLoc],[ShipToSAN],[BillToLoc],[BillToSAN],[ShipFromLoc],[ShipFromSAN],[TotalLines]
												,[TotalQty],[TotalPayable],[CurrencyCode],[InsertDateTime],[Processed],[ProcessedDateTime],[InvoiceACKSent],[InvoiceAckNo],[GSNo])
	OUTPUT INSERTED.InvoiceID, INSERTED.PONumber, INSERTED.InvoiceNo INTO @Inserted (IID, PurchaseOrderNumber, InvoiceNumber) 
		SELECT   big.[InvoiceNumber] AS [InvoiceNo]
				,big.Date_01 AS [IssueDate]
				,vsc.[VendorID] 
				,big.[PurchaseOrderNumber] AS [PONumber]
				,ac.ICN AS [ReferenceNo]
				,hdr.[ShipToLoc]
				,hdr.[ShipToSAN]
				,hdr.[BillToLoc]
				,hdr.[BillToSAN]
				,hdr.[ShipFromLoc]
				,hdr.[ShipFromSAN]
				,ctt.NumberOfLineItems AS [TotalLines]
				,ctt.HashTotal AS [TotalQty]
				,CAST(CAST(tds.Amount_01 AS FLOAT)/100 AS VARCHAR(25))AS [TotalPayable]
				,cur.CurrencyCode AS [CurrencyCode]
				,GETDATE() AS [InsertDateTime]
				,0 AS [Processed]
				,NULL AS [ProcessedDateTime]
				,0 AS [InvoiceACKSent]
				,0 AS [InvoiceACKNo]
				,big.ControlNumberGroup AS [GSNo]		
		FROM [HPB_EDI].[dbo].[vuImportEDI_Unprocessed_TransactionRanges] ranges
			INNER JOIN @AppCodes ac
				ON ranges.[EDIFileId]= ac.[EDIFileID]
			INNER JOIN [HPB_EDI].[dbo].[Vendor_SAN_Codes] vsc
				ON ac.[SC]=vsc.[SANCode]
			INNER JOIN [HPB_EDI].[dbo].[importEDI_BIG] big
				ON ranges.[EDIFileId]=big.[EDIFileId]
					AND big.[ControlNumberTransaction]=ranges.[TransactionSetControlNumber]
			INNER JOIN [HPB_EDI].[dbo].[850_PO_Hdr] hdr
				ON hdr.[PONumber]= big.[PurchaseOrderNumber]
			LEFT JOIN [HPB_EDI].[dbo].[importEDI_CUR] cur
				ON cur.EDIFileId = big.EDIFileId
					AND cur.ControlNumberGroup = big.ControlNumberGroup
					AND cur.ControlNumberTransaction = big.ControlNumberTransaction
					AND (cur.ControlNumberTransaction = ranges.TransactionSetControlNumber
						AND cur.LineNumber BETWEEN ranges.RangeStart+1 AND ranges.RangeEnd-1
						AND cur.LineNumber > big.LineNumber
						AND cur.LineNumber - big.LineNumber = 1)
			LEFT JOIN [HPB_EDI].[dbo].[importEDI_N1] n1
				ON n1.EDIFileId = big.EDIFileId
					AND n1.ControlNumberGroup = big.ControlNumberGroup
					AND n1.ControlNumberTransaction = big.ControlNumberTransaction
					AND (n1.ControlNumberTransaction = ranges.TransactionSetControlNumber
						AND n1.LineNumber BETWEEN ranges.RangeStart+1 AND ranges.RangeEnd-1
						AND n1.LineNumber > COALESCE(cur.LineNumber, big.LineNumber)
						AND n1.LineNumber - COALESCE(cur.LineNumber, big.LineNumber) BETWEEN 1 AND 2)		
			LEFT JOIN [HPB_EDI].[dbo].[importEDI_TDS] tds
				ON tds.EDIFileId = big.EDIFileId
					AND tds.ControlNumberGroup = big.ControlNumberGroup
					AND tds.ControlNumberTransaction = big.ControlNumberTransaction
					AND (tds.ControlNumberTransaction = ranges.TransactionSetControlNumber
						AND tds.LineNumber BETWEEN ranges.RangeStart+1 AND ranges.RangeEnd-1
						AND tds.LineNumber > COALESCE(n1.LineNumber, big.LineNumber))
						--AND tds.LineNumber - COALESCE(n1.LineNumber, big.LineNumber) <=2)
			LEFT JOIN [HPB_EDI].[dbo].[importEDI_CTT] ctt
				ON ctt.[EDIFileId]=big.[EDIFileId]
					AND ctt.[ControlNumberGroup]=big.[ControlNumberGroup]
					AND ctt.[ControlNumberTransaction]=big.[ControlNumberTransaction]
					AND (ctt.LineNumber BETWEEN ranges.RangeStart+1 AND ranges.RangeEnd-1
						AND ctt.LineNumber > COALESCE(tds.LineNumber, n1.LineNumber, cur.LineNumber, big.LineNumber)
						)

	WHERE ranges.EDIType = @EDINumber
	ORDER BY big.InvoiceNumber

	INSERT INTO [temp_810_Inv_Dtl] ([InvoiceID],[LineNo],[ItemIDCode],[ItemIdentifier],[ItemDesc],[InvoiceQty],[UnitPrice],[DiscountPrice],[DiscountCode],[DiscountPct],[RetailPrice])
		SELECT   ii.IID AS [InvoiceID]
				,RIGHT('00000' + LTRIM(RTRIM(CAST(ROW_NUMBER() OVER(PARTITION BY big.InvoiceNumber ORDER BY big.LineNumber) AS VARCHAR(10)))),5) AS [LineNo]
				,it1.ProductServiceIDQualifier_01 AS [ItemIDCode]
				,it1.ProductServiceID_01 AS [ItemIdentifier]
				,'' AS [ItemDesc]
				,it1.QuantityInvoiced AS [InvoiceQty]
				,it1.UnitPrice AS [UnitPrice]
				,'' AS [DiscountPrice]
				,ctp.PriceMultiplierQualifier AS [DiscountCode]
				,ctp.Multiplier AS [DiscountPercent]
				,ctp.UnitPrice AS [RetailPrice]
		FROM [HPB_EDI].[dbo].[vuImportEDI_Unprocessed_TransactionRanges] ranges
			INNER JOIN @AppCodes ac
				ON ac.[EDIFileID]=ranges.[EDIFileId]
			INNER JOIN [HPB_EDI].[dbo].[importEDI_BIG] big
				ON big.[EDIFileId]=ranges.[EDIFileId]
					AND big.[ControlNumberTransaction]=ranges.[TransactionSetControlNumber]
			INNER JOIN @Inserted ii
				ON ii.[PurchaseOrderNumber]=big.[PurchaseOrderNumber]
					AND ii.[InvoiceNumber]=big.[InvoiceNumber]
			INNER JOIN [HPB_EDI].[dbo].[Vendor_SAN_Codes] vsc
				ON vsc.[SANCode]=ac.[SC]
			INNER JOIN [HPB_EDI].[dbo].[850_PO_Hdr] hdr
				ON hdr.[PONumber]=big.[PurchaseOrderNumber]
			LEFT JOIN [importEDI_CUR] cur
				ON cur.EDIFileId = big.EDIFileId
					AND cur.ControlNumberGroup = big.ControlNumberGroup
					AND cur.ControlNumberTransaction = big.ControlNumberTransaction
					AND (cur.ControlNumberTransaction = ranges.TransactionSetControlNumber
						AND cur.LineNumber BETWEEN ranges.RangeStart+1 AND ranges.RangeEnd-1
						AND cur.LineNumber > big.LineNumber
						AND cur.LineNumber - big.LineNumber = 1)
			LEFT JOIN [importEDI_N1] n1
				ON n1.EDIFileId = big.EDIFileId
					AND n1.ControlNumberGroup = big.ControlNumberGroup
					AND n1.ControlNumberTransaction = big.ControlNumberTransaction
					AND (n1.ControlNumberTransaction = ranges.TransactionSetControlNumber
						AND n1.LineNumber BETWEEN ranges.RangeStart+1 AND ranges.RangeEnd-1
						AND n1.LineNumber > COALESCE(cur.LineNumber, big.LineNumber)
						AND n1.LineNumber - COALESCE(cur.LineNumber, big.LineNumber) <= 2)			
			LEFT JOIN [importEDI_ITD] itd
				ON itd.EDIFileId = big.EDIFileId
					AND itd.ControlNumberGroup = big.ControlNumberGroup
					AND itd.ControlNumberTransaction = big.ControlNumberTransaction
					AND (itd.ControlNumberTransaction = ranges.TransactionSetControlNumber
						AND itd.LineNumber BETWEEN ranges.RangeStart+1 AND ranges.RangeEnd-1
						AND itd.LineNumber > COALESCE(n1.LineNumber, cur.LineNumber)
						AND itd.LineNumber - COALESCE(n1.LineNumber, cur.LineNumber) < 2)
			LEFT JOIN [importEDI_DTM] dtm
				ON itd.EDIFileId = big.EDIFileId
					AND dtm.ControlNumberGroup = big.ControlNumberGroup
					AND dtm.ControlNumberTransaction = big.ControlNumberTransaction
					AND (dtm.ControlNumberTransaction = ranges.TransactionSetControlNumber
						AND dtm.LineNumber BETWEEN ranges.RangeStart+1 AND ranges.RangeEnd-1
						AND dtm.LineNumber > COALESCE(itd.LineNumber, n1.LineNumber)
						AND dtm.LineNumber - COALESCE(itd.LineNumber, n1.LineNumber) < 2)
			LEFT JOIN [HPB_EDI].[dbo].[importEDI_IT1] it1
				ON it1.EDIFileId = big.EDIFileId
					AND it1.ControlNumberGroup = big.ControlNumberGroup
					AND it1.ControlNumberTransaction = big.ControlNumberTransaction
					AND (it1.ControlNumberTransaction = ranges.TransactionSetControlNumber
						AND it1.LineNumber BETWEEN ranges.RangeStart+1 AND ranges.RangeEnd-1
						AND it1.LineNumber > big.LineNumber
						AND it1.LineNumber - big.LineNumber >=1)
			LEFT JOIN [HPB_EDI].[dbo].[importEDI_CTP] ctp
				ON it1.EDIFileId = big.EDIFileId
					AND ctp.ControlNumberGroup = big.ControlNumberGroup
					AND ctp.ControlNumberTransaction = big.ControlNumberTransaction
					AND (ctp.ControlNumberTransaction = ranges.TransactionSetControlNumber
						AND ctp.LineNumber BETWEEN ranges.RangeStart+1 AND ranges.RangeEnd-1
						AND ctp.LineNumber > COALESCE(it1.LineNumber, big.LineNumber)
						AND ctp.LineNumber - COALESCE(it1.LineNumber, big.LineNumber) < 2)		
	WHERE ranges.EDIType = @EDINumber
	order by big.InvoiceNumber
END