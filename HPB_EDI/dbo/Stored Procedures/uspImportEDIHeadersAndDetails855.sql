CREATE  PROCEDURE [dbo].[uspImportEDIHeadersAndDetails855]
AS
BEGIN
	DECLARE @EDINumber VARCHAR(3) = '855'

	DECLARE @Inserted TABLE (
								 IID INT
								,PurchaseOrderNumber VARCHAR(15)
							)


	DECLARE @AppCodes TABLE (
								 EDIFileID INT
								,DTM VARCHAR(10)
								,SC VARCHAR(50)
								,RC VARCHAR(50)
								,ICN VARCHAR(50)
								,VER VARCHAR(25)
							)

	INSERT INTO @AppCodes(EDIFileID, DTM, SC, RC, ICN, VER)
		SELECT ranges.EDIFileId, gs.[Date], gs.ApplicationSenderCode, gs.ApplicationReceiverCode, isa.InterchangeControlNumber, gs.VersionRelIndIDCode
		from (	SELECT DISTINCT EDIFileId
				FROM  vuImportEDI_Unprocessed_TransactionRanges
				WHERE EDIType = @EDINumber) ranges
			INNER JOIN importx12.TagISA isa
				ON isa.EDIFileId = ranges.EDIFileId
			INNER JOIN importx12.TagGS gs
				ON gs.EDIFileId = ranges.EDIFileId

	INSERT INTO [temp_855_Ack_Hdr] (PONumber,IssueDate,VendorID,ReferenceNo,ShipToLoc,ShipToSAN,BillToLoc,BillToSAN,ShipFromLoc,ShipFromSAN,TotalLines,TotalQty,CurrencyCode,InsertDateTime,Processed,ProcessedDateTime,ResponseACKSent,ResponseAckNo,GSNo)
	OUTPUT INSERTED.AckID, INSERTED.PONumber INTO @Inserted (IID, PurchaseOrderNumber) 
		SELECT	 bak.PurchaseOrderNumber AS PONumber
				,bak.Date_01 AS [IssueDate]
				,vsc.VendorID AS [VendorID]
				,ac.ICN AS [RefrenceNo]
				,hdr.[ShipToLoc]
				,hdr.[ShipToSAN]
				,hdr.[BillToLoc]
				,hdr.[BillToSAN]
				,hdr.[ShipFromLoc]
				,hdr.[ShipFromSAN]				
				,ctt.NumberOfLineItems AS [TotalLines]
				,ctt.HashTotal AS [TotalQty]
				,NULL AS [CurrencyCode]
				,GETDATE() AS [InsertDateTime]
				,0 AS [Processed]
				,NULL AS [ProcessedDateTime]
				,0 AS [ResponseACKSent]
				,NULL AS [ResponseAckNo]
				,bak.ControlNumberGroup AS [GSNo]
		FROM vuImportEDI_Unprocessed_TransactionRanges ranges
			INNER JOIN @AppCodes ac
				ON ranges.EDIFileId = ac.EDIFileID
			INNER JOIN Vendor_SAN_Codes vsc
				ON ac.SC=vsc.SanCode
			INNER JOIN [importx12].[TagBAK] bak
				ON ranges.EDIFileID = bak.EDIFileID
					AND bak.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
					AND ranges.[TransactionSetControlNumber] = bak.[ControlNumberTransaction]
			INNER JOIN [HPB_EDI].[dbo].[850_PO_Hdr] hdr
				ON hdr.[PONumber]= bak.[PurchaseOrderNumber]
			LEFT JOIN [importx12].[TagCTT] ctt
				ON ctt.EDIFileId = bak.EDIFileId
					AND ctt.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND ctt.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND ctt.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
	WHERE ranges.EDIType = @EDINumber
	ORDER BY  bak.PurchaseOrderNumber

	INSERT INTO [temp_855_Ack_Dtl] (AckID,[LineNo],LineStatusCode,ItemStatusCode,UOM,OrdQty,ShipQty,CanceledQty,BackOrdQty,UnitPrice,PriceCode,CurrencyCode,ItemIDCode,ItemIdentifier,ItemDesc) --,EDIFileID,EDILineNumber)
		SELECT   ii.IID AS ACKID
				,RIGHT('00000' + CAST(ROW_NUMBER() OVER (PARTITION BY bak.purchaseordernumber order by bak.linenumber) AS VARCHAR(5)),5) AS [LineNo]
				,ack.LineItemStatusCode AS LineStatusCode
				,ack.IndustryCode AS ItemStatusCode
				,ack.UnitOrBasisForMeasurementCode AS UOM
				,hdr.TotalQty AS OrdQty
				,CASE when orderstatus.QualifierStatusType IN ('Accepted - Partial','Accepted - Shipping','Complete')
					THEN ack.Quantity
					ELSE 0
				 END AS ShipQty
				,CASE WHEN orderstatus.QualifierStatusType IN ('Canceled - Not Shipped','Deleted - Not Shipped','Forwarded - Not Shipped','Hold - Not Shipped','Out:NotPublished - Not Shipped','Out:Print - Not Shipped','Out:Stock - Not Shipped','Rejected - Not Shipped')
					then ack.Quantity
					else 0
				 END AS CanceledQty
				,CASE WHEN orderstatus.QualifierStatusType IN ('BackOrdered - Not Shipping')
					THEN ack.Quantity
					ELSE 0
				 END AS BackOrdQty
				,po1.UnitPrice AS UnitPrice
				,po1.BasisOfUnitPriceCode AS PriceCode
				,NULL AS CurrencyCode
				,po1.ProductServiceIDQualifier_04 AS ItemIDCode
				,po1.ProductServiceID_04 AS ItemIdentifier
				,pid.Description AS ItemDesc
				--,ac.EDIFileID AS EDIFileID
		FROM vuImportEDI_Unprocessed_TransactionRanges ranges
			INNER JOIN @AppCodes ac
				ON ranges.EDIFileId = ac.EDIFileID
			INNER JOIN Vendor_SAN_Codes vsc
				ON ac.SC=vsc.SanCode
			INNER JOIN [importx12].[TagBAK] bak
				ON ranges.EDIFileID = bak.EDIFileID
					AND bak.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
					AND ranges.[TransactionSetControlNumber] = bak.[ControlNumberTransaction]
			INNER JOIN @Inserted ii
				ON ii.[PurchaseOrderNumber]=bak.[PurchaseOrderNumber]
			INNER JOIN [HPB_EDI].[dbo].[850_PO_Hdr] hdr
				ON hdr.[PONumber]= bak.[PurchaseOrderNumber]
			LEFT JOIN [importx12].[TagCUR] cur
				ON  cur.[EDIFileId] = bak.[EDIFileId]
					AND cur.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND cur.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (cur.[ControlNumberTransaction] = ranges.[TransactionSetControlNumber] 
						AND cur.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
						AND cur.[LineNumber] > bak.[LineNumber]
						AND cur.[LineNumber]-bak.[LineNumber] = 1)
			LEFT JOIN [importx12].[TagDTM] dtm
				ON dtm.[EDIFileId] = bak.[EDIFileId]
					AND dtm.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND dtm.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (dtm.[ControlNumberTransaction] = ranges.[TransactionSetControlNumber]
						AND dtm.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
						AND dtm.[LineNumber] > COALESCE(cur.[LineNumber], bak.[LineNumber])
						AND dtm.[LineNumber] - COALESCE(cur.[LineNumber], bak.[LineNumber]) BETWEEN 1 AND 10)
			LEFT JOIN [importx12].[TagN1] n1
				ON n1.[EDIFileId] = bak.[EDIFileId]
					AND n1.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND n1.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (n1.[ControlNumberTransaction] = ranges.[TransactionSetControlNumber]
						AND n1.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
						AND n1.[LineNumber] > COALESCE(dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND n1.[LineNumber] - COALESCE(dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) =1)
			LEFT JOIN [importx12].[TagPO1] po1
				ON po1.[EDIFileId] = bak.[EDIFileId]
					AND po1.[ControlNumberGroup] = bak.[ControlNumberGroup] 
					AND po1.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (po1.[ControlNumberTransaction] = ranges.[TransactionSetControlNumber]
						AND po1.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
						AND po1.[LineNumber] > COALESCE(n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND po1.[LineNumber] - COALESCE(n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) BETWEEN  1 AND 2 )
			LEFT JOIN [importx12].[TagCTP] ctp
				ON ctp.[EDIFileId] = bak.[EDIFileId] 
					AND ctp.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND ctp.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (ctp.[ControlNumberTransaction] = ranges.[TransactionSetControlNumber]
						AND ctp.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
						AND ctp.[LineNumber] > COALESCE(po1.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND ctp.[LineNumber] - COALESCE(po1.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) >= 1 )
			LEFT JOIN [importx12].[TagPID] pid
				ON pid.[EDIFileId] = bak.[EDIFileId] 
					AND pid.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND pid.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (pid.[ControlNumberTransaction] = ranges.[TransactionSetControlNumber]
						AND pid.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
						AND pid.[LineNumber] > COALESCE(ctp.[LineNumber], po1.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND pid.[LineNumber] - COALESCE(ctp.[LineNumber], po1.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) = 1 )
			LEFT JOIN [importx12].[TagACK] ack
				ON ack.[EDIFileId] = bak.[EDIFileId] 
					AND ack.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND ack.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (ack.[ControlNumberTransaction] = ranges.[TransactionSetControlNumber]
						AND ack.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
						AND ack.[LineNumber] > COALESCE(pid.[LineNumber], ctp.[LineNumber], po1.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND ack.[LineNumber] - COALESCE(pid.[LineNumber], ctp.[LineNumber], po1.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) = 1 )
			LEFT JOIN [importx12].[TagSCH] sch
				ON sch.[EDIFileId] = bak.[EDIFileId] 
					AND sch.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND sch.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (sch.[ControlNumberTransaction] = ranges.[TransactionSetControlNumber]
						AND sch.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
						AND sch.[LineNumber] > COALESCE(ack.[LineNumber], pid.[LineNumber], ctp.[LineNumber], po1.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND sch.[LineNumber] - COALESCE(ack.[LineNumber], pid.[LineNumber], ctp.[LineNumber], po1.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) = 1 )
			LEFT JOIN (	select q.QualifierCode, QualifierDescription, QualifierStatusType, QualifierStatusActive
						from importx12.EDIQualifierTypes qt
							inner join [importx12].[EDIQualifiers] q
								on q.QualifierTypeID = qt.QualifierTypeID
							left  join [importX12].[EDIQualifierShippingStatuses] qss
								on q.qualifierid=qss.QualifierID
							left join [importx12].[EDIQualifierShippingStatusTypes] sst
								on sst.QualifierShippingStatusTypeID = qss.QualifierShippingStatusTypesID
						where qt.QualifierType = 'industry code') orderstatus
				on orderstatus.QualifierCode = rtrim(ack.IndustryCode)

	WHERE ranges.EDIType = @EDINumber
	ORDER BY bak.PurchaseOrderNumber
END