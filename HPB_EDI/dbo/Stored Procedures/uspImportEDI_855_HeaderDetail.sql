
CREATE PROCEDURE [dbo].[uspImportEDI_855_HeaderDetail]
AS
BEGIN
	DECLARE @AppCodes TABLE (
								 FID INT
								,DTM VARCHAR(10)
								,SC VARCHAR(50)
								,RC VARCHAR(50)
								,ICN VARCHAR(50)
								,VER VARCHAR(25)
							)

	INSERT INTO @AppCodes(FID, DTM, SC, RC, ICN, VER)
		SELECT segs.EDIFileId, gs.[Date], gs.ApplicationSenderCode, gs.ApplicationReceiverCode, isa.InterchangeControlNumber, gs.VersionRelIndIDCode
		from (	SELECT DISTINCT EDIFileId
				FROM  vuImportEDI_Unprocessed_TransactionRanges
				WHERE EDIType = '855') segs
			INNER JOIN importEDI_ISA isa
				ON isa.EDIFileId = segs.EDIFileId
			INNER JOIN importEDI_GS gs
				ON gs.EDIFileId = segs.EDIFileId

	SELECT * FROM @AppCodes


	DECLARE @InsertedItems TABLE (
									ID BIGINT NOT NULL,
									PONumber VARCHAR(25)
								  )
	

		
--	INSERT INTO SummaryEDI_855 ( BAKId ,EDIFileID ,BAK_LineNumber ,BAK_ControlNumberGroup ,BAK_ControlNumberTransaction ,BAK_TransactionSetPurposeCode ,BAK_AcknowledgmentType
--								,BAK_PurchaseOrderNumber,BAK_Date_01 ,BAK_ReleaseNumber ,BAK_RequestReferenceNumber ,BAK_ContractNumber ,BAK_Date_02 
--								,PO1Id ,PO1_LineNumber ,PO1_ControlNumberGroup ,PO1_ControlNumberTransaction ,PO1_AssignedIdentification ,PO1_QuantityOrdered ,PO1_UnitOrBasisForMeasurementCode 
--								,PO1_UnitPrice ,PO1_BasisOfUnitPriceCode,PO1_ProductServiceIDQualifier_01,PO1_ProductServiceID_01 ,PO1_ProductServiceIDQualifier_02 ,PO1_ProductServiceID_02 
--								,PO1_ProductServiceIDQualifier_03 ,PO1_ProductServiceID_03 ,PO1_ProductServiceIDQualifier_04 ,PO1_ProductServiceID_04 
--								,CTPID ,CTP_LineNumber ,CTP_ControlNumberGroup ,CTP_ControlNumberTransaction ,CTP_PriceIdentifierCode ,CTP_UnitPrice ,CTP_Quantity ,CTP_CompositeUnitOfMeasure 
--								,CTP_PriceMultiplerQualifier ,CTP_Multiplier 
--								,ACKId ,ACK_LineNumber ,ACK_ControlNumberGroup ,ACK_ControlNumberTransaction ,ACK_LineItemStatusCode ,ACK_Quantity ,ACK_UnitOrBasisForMeasurementCode 
--								,ACK_DateTimeQualifier,ACK_Date ,ACK_ProductServiceIDQualifier_01 ,ACK_ProductServiceID_01 ,ACK_ProductServiceIDQualifier_02 ,ACK_ProductServiceID_02 
--								,ACK_ProductServiceIDQualifier_03 	,ACK_ProductServiceID_03 ,ACK_IndustryCode )
--		SELECT	 bak.BAKId, bak.EDIFileId, bak.LineNumber, bak.ControlNumberGroup, bak.ControlNumberTransaction, bak.TransactionSetPurposeCode, bak.AcknowledgmentType
--				,bak.PurchaseOrderNumber,bak.Date_01, bak.ReleaseNumber, bak.RequestReferenceNumber, bak.ContractNumber, bak.Date_02
--				,po1.PO1Id, po1.LineNumber, po1.ControlNumberGroup, po1.ControlNumberTransaction, po1.AssignedIdentification, po1.QuantityOrdered, po1.UnitOrBasisForMeasurementCode
--				,po1.UnitPrice, po1.BasisOfUnitPriceCode,po1.ProductServiceIDQualifier_01, po1.ProductServiceID_01, po1.ProductServiceIDQualifier_02, po1.ProductServiceID_02
--				,po1.ProductServiceIDQualifier_03, po1.ProductServiceID_03,po1.ProductServiceIDQualifier_04, po1.ProductServiceID_04
--				,ctp.CTPId, ctp.LineNumber, ctp.ControlNumberGroup, ctp.ControlNumberTransaction, ctp.PriceIdentifierCode, ctp.UnitPrice, ctp.Quantity, ctp.CompositeUnitOfMeasure
--				,ctp.PriceMultiplierQualifier, ctp.Multiplier
--				,ack.ACKId, ack.LineNumber, ack.ControlNumberGroup,ack.ControlNumberTransaction, ack.LineItemStatusCode, ack.Quantity, ack.UnitOrBasisForMeasurementCode
--				,ack.DateTimeQualifier, ack.[Date], ack.ProductServiceIDQualifier_01, ack.ProductServiceID_01, ack.ProductServiceIDQualifier_02, ack.ProductServiceID_02
--				,ack.ProductServiceIDQualifier_03, ack.ProductServiceID_03, ack.IndustryCode	
		SELECT bak.*
				,cur.*
				,dtm.*
				,n1.*
				,n2.*
				,n3.*
				,n4.*
				,po1.*
				,ctp.*
				,pid.*
				,ack.*
				,sch.*
		FROM [importEDI_BAK] bak		
			INNER JOIN vuImportEDI_Unprocessed_TransactionRanges segs
				ON bak.[EDIFileId] = segs.[EDIFileID]
					AND segs.[RangeStart] = bak.[LineNumber]-1
					AND segs.[TransactionSetControlNumber] = bak.[ControlNumberTransaction]
			LEFT JOIN [importEDI_CUR] cur
				ON  cur.[EDIFileId] = bak.[EDIFileId]
					AND cur.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND cur.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (cur.[ControlNumberTransaction] = segs.[TransactionSetControlNumber] 
						AND cur.[LineNumber] BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND cur.[LineNumber] > bak.[LineNumber]
						AND cur.[LineNumber]-bak.[LineNumber] = 1)
			LEFT JOIN [importEDI_DTM] dtm
				ON dtm.[EDIFileId] = bak.[EDIFileId]
					AND dtm.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND dtm.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (dtm.[ControlNumberTransaction] = segs.[TransactionSetControlNumber]
						AND dtm.[LineNumber] BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND dtm.[LineNumber] > COALESCE(cur.[LineNumber], bak.[LineNumber])
						AND dtm.[LineNumber] - COALESCE(cur.[LineNumber], bak.[LineNumber]) BETWEEN 1 AND 10)
			LEFT JOIN [importEDI_N1] n1
				ON n1.[EDIFileId] = bak.[EDIFileId]
					AND n1.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND n1.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (n1.[ControlNumberTransaction] = segs.[TransactionSetControlNumber]
						AND n1.[LineNumber] BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND n1.[LineNumber] > COALESCE(dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND n1.[LineNumber] - COALESCE(dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) =1)
			LEFT JOIN [importEDI_N2] n2
				ON n2.[EDIFileId] = bak.[EDIFileId]
					AND n2.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND n2.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (n2.[ControlNumberTransaction] = segs.[TransactionSetControlNumber]
						AND n2.[LineNumber] BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND n2.[LineNumber] > COALESCE(n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND n2.[LineNumber] - COALESCE(n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) BETWEEN 1 AND 2)
			LEFT JOIN [importEDI_N3] n3
				ON n2.[EDIFileId] = bak.[EDIFileId]
					AND n3.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND n3.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (n3.[ControlNumberTransaction] = segs.[TransactionSetControlNumber]
						AND n3.[LineNumber] BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND n3.[LineNumber] > COALESCE(n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND n3.[LineNumber] - COALESCE(n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) BETWEEN 1 AND 2)
			LEFT JOIN [importEDI_N4] n4
				ON n2.[EDIFileId] = bak.[EDIFileId]
					AND n4.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND n4.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (n3.[ControlNumberTransaction] = segs.[TransactionSetControlNumber]
						AND n4.[LineNumber] BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND n4.[LineNumber] > COALESCE(n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND n4.[LineNumber] - COALESCE(n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) = 1 )
			LEFT JOIN [importEDI_PO1] po1
				ON po1.[EDIFileId] = bak.[EDIFileId]
					AND po1.[ControlNumberGroup] = bak.[ControlNumberGroup] 
					AND po1.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (po1.[ControlNumberTransaction] = segs.[TransactionSetControlNumber]
						AND po1.[LineNumber] BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND po1.[LineNumber] > COALESCE(n4.[LineNumber], n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND po1.[LineNumber] - COALESCE(n4.[LineNumber],n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) BETWEEN  1 AND 2 )
			LEFT JOIN [importEDI_CTP] ctp
				ON ctp.[EDIFileId] = bak.[EDIFileId] 
					AND ctp.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND ctp.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (ctp.[ControlNumberTransaction] = segs.[TransactionSetControlNumber]
						AND ctp.[LineNumber] BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND ctp.[LineNumber] > COALESCE(po1.[LineNumber], n4.[LineNumber], n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND ctp.[LineNumber] - COALESCE(po1.[LineNumber], n4.[LineNumber],n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) >= 1 )
			LEFT JOIN [importEDI_PID] pid
				ON pid.[EDIFileId] = bak.[EDIFileId] 
					AND pid.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND pid.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (pid.[ControlNumberTransaction] = segs.[TransactionSetControlNumber]
						AND pid.[LineNumber] BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND pid.[LineNumber] > COALESCE(ctp.[LineNumber], po1.[LineNumber], n4.[LineNumber], n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND pid.[LineNumber] - COALESCE(ctp.[LineNumber], po1.[LineNumber], n4.[LineNumber],n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) = 1 )
			LEFT JOIN [importEDI_ACK] ack
				ON ack.[EDIFileId] = bak.[EDIFileId] 
					AND ack.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND ack.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (ack.[ControlNumberTransaction] = segs.[TransactionSetControlNumber]
						AND ack.[LineNumber] BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND ack.[LineNumber] > COALESCE(pid.[LineNumber], ctp.[LineNumber], po1.[LineNumber], n4.[LineNumber], n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND ack.[LineNumber] - COALESCE(pid.[LineNumber], ctp.[LineNumber], po1.[LineNumber], n4.[LineNumber],n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) = 1 )
			LEFT JOIN [importEDI_SCH] sch
				ON sch.[EDIFileId] = bak.[EDIFileId] 
					AND sch.[ControlNumberGroup] = bak.[ControlNumberGroup]
					AND sch.[ControlNumberTransaction] = bak.[ControlNumberTransaction]
					AND (sch.[ControlNumberTransaction] = segs.[TransactionSetControlNumber]
						AND sch.[LineNumber] BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND sch.[LineNumber] > COALESCE(ack.[LineNumber], pid.[LineNumber], ctp.[LineNumber], po1.[LineNumber], n4.[LineNumber], n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber])
						AND sch.[LineNumber] - COALESCE(ack.[LineNumber], pid.[LineNumber], ctp.[LineNumber], po1.[LineNumber], n4.[LineNumber],n3.[LineNumber], n2.[LineNumber], n1.[LineNumber], dtm.[LineNumber],cur.[LineNumber], bak.[LineNumber]) = 1 )
	WHERE segs.EDIType = '855'
	ORDER BY bak.LineNumber, cur.LineNumber, dtm.LineNumber, n1.LineNumber, n2.LineNumber, n3.LineNumber, n4.LineNumber, po1.LineNumber, ctp.LineNumber, pid.LineNumber, ack.LineNumber, sch.LineNumber

	/*
	;WITH ACKHeader AS
	(
		select	 c.[BAK_PurchaseOrderNumber]
				,hdr.[ShipToLoc]
				,hdr.[ShipToSAN]
				,hdr.[BillToLoc]
				,hdr.[BillToSAN]
				,hdr.[ShipFromLoc]
				,hdr.[ShipFromSAN]
				,CAST(c.[ACK_Quantity] AS DECIMAL) AS Quantity
				,c.[BAK_ControlNumberTransaction]
				,c.[BAK_ControlNumberGroup]
				,hdr.[TotalQty]
		FROM SummaryEDI_855 c
			LEFT JOIN dbo.[850_PO_Hdr] hdr
				ON hdr.PONumber = c.bak_PurchaseOrderNumber
		WHERE c.EDIFileId=3
	)
	,Summary as
	(
		SELECT	 w.[BAK_PurchaseOrderNumber]
				,SUM(w.[Quantity]) AS SumQuantity
				,COUNT(1) AS LineCount
		FROM ACKHeader w
		GROUP BY w.[BAK_PurchaseOrderNumber]
	)
	,y as
	(
		SELECT	 hdr.[BAK_PurchaseOrderNumber]
				,vsc.[VendorID]
				,hdr.[ShipToLoc]
				,hdr.[ShipToSAN]
				,hdr.[BillToLoc]
				,hdr.[BillToSAN]
				,hdr.[ShipFromLoc]
				,hdr.[ShipFromSAN]
				,smy.[SumQuantity] AS Quantity
				,hdr.[BAK_ControlNumberTransaction]
				,hdr.[BAK_ControlNumberGroup]
				,hdr.[TotalQty]
				,smy.[LineCount]
		FROM ACKHeader hdr
			INNER JOIN Summary smy
				ON hdr.[BAK_PurchaseOrderNumber] = smy.[BAK_PurchaseOrderNumber]
			INNER JOIN dbo.[Vendor_SAN_Codes] vsc
				ON vsc.[SANCode] = @asc
	)
	,z  as
	(
		SELECT	 [BAK_PurchaseOrderNumber] AS PONumber
				,@dtm AS IssueDate
				,[VendorID]
				,@ref AS ReferenceNo
				,[ShipToLoc]
				,[ShipToSAN]
				,[BillToLoc]
				,[BillToSAN]
				,[ShipFromLoc]
				,[ShipFromSAN]
				,[Quantity]
				,y.[BAK_ControlNumberTransaction]
				,y.[BAK_ControlNumberGroup]
				,[TotalQty]
				,[LineCount]
		FROM y
		GROUP BY [BAK_PurchaseOrderNumber], [VendorID], [ShipToLoc], [ShipToSAN], [BillToLoc], [BillToSAN], [ShipFromLoc], [ShipFromSAN], [Quantity], [BAK_ControlNumberTransaction], [BAK_ControlNumberGroup], [TotalQty], [LineCount]
	)
	--INSERT INTO HPB_EDI..[855_Ack_Hdr] ( PONumber ,IssueDate ,VendorID ,ReferenceNo ,ShipToLoc ,ShipToSAN ,BillToLoc ,BillToSAN ,ShipFromLoc ,ShipFromSAN ,TotalLines ,TotalQty ,CurrencyCode ,InsertDateTime ,Processed ,ProcessedDateTime ,ResponseACKSent ,ResponseAckNo ,GSNo , ErrorStatus)
	--	OUTPUT inserted.AckID, inserted.PONumber into @InsertedItems
	
		SELECT	 [PONumber]
				,[VendorID]
				,[ShipToLoc]
				,[ShipToSAN]
				,[BillToLoc]
				,[BillToSAN]
				,[ShipFromLoc]
				,[ShipFromSAN]
				,[Quantity]
				,[BAK_ControlNumberTransaction]
				,[BAK_ControlNumberGroup]
				, [TotalQty]
				, [LineCount]
				,CASE WHEN z.LineCount != ctt.NumberOfLineItems THEN 'Lines ' ELSE '' END +
	 			 CASE WHEN z.Quantity != ctt.HashTotal THEN 'Counts ' ELSE '' END  AS ErrorStatus
	 FROM Z
		LEFT JOIN [importEDI_CTT] ctt
			ON ctt.[ControlNumberGroup]=z.[bak_ControlNumberGroup]
				AND ctt.[ControlNumberTransaction]= z.[bak_ControlNumberTransaction]
	ORDER BY z.PONumber


	-- select top 500 * from [855_ack_dtl] where ackid=17759
	;WITH ACKDetail AS
	(
	SELECT		 c.EDIFileID
			,-1 AS AckID
			,c.PO1_AssignedIdentification AS [LineNo]
			,c.ACK_LineItemStatusCode AS [LineStatusCode]
			,c.ACK_IndustryCode AS ItemStatusCode
			,c.PO1_UnitOrBasisForMeasurementCode AS UOM
			,c.PO1_QuantityOrdered AS OrdQty
			,c.ACK_Quantity 
			,0 as ShipQty
			,CASE WHEN c.ACK_IndustryCode IN (	SELECT q.QualifierCode
												FROM importEDIQualifierShippingStatusTypes sst
													INNER JOIN importEDIQualifierShippingStatuses qss
														ON qss.QualifierShippingStatusTypesID = sst.QualifierShippingStatusTypeID
													INNER JOIN importEDIQualifiers q
														ON q.QualifierID = qss.QualifierID
												WHERE sst.QualifierStatusType = 'Backordered - Not Shipping')
					THEN 0
					ELSE -1 -- p.CAnQty
			 END AS CanQty
			,CASE WHEN c.ACK_IndustryCode IN (	SELECT q.QualifierCode
												FROM importEDIQualifierShippingStatusTypes sst
													INNER JOIN importEDIQualifierShippingStatuses qss
														ON qss.QualifierShippingStatusTypesID = sst.QualifierShippingStatusTypeID
													INNER JOIN importEDIQualifiers q
														ON q.QualifierID = qss.QualifierID
												WHERE sst.QualifierStatusType = 'Backordered - Not Shipping')
					THEN -1 --p.CanQty
					ELSE -2 -- p.BakQty
			 END AS BAKQty
			,c.PO1_UnitPrice AS UnitPrice
			,c.PO1_BasisOfUnitPriceCode AS PriceCode
			,null as CurrencyCode
			,c.PO1_ProductServiceIDQualifier_04 AS ItemIDCode
			,c.PO1_ProductServiceID_04 as ItemIdentifier
			,ltrim(rtrim(ISNULL(PO1_ProductServiceID_03,'') + '-' + ISNULL(PO1_ProductServiceID_02,'')))as ItemDesc
			,c.BAK_Date_01 AS [@IssueDate]
		    ,c.BAK_PurchaseOrderNumber AS [@FilePO]

		FROM SummaryEDI_855 c
			INNER JOIN importEDIFiles f
				ON c.EDIFileID = f.EDIFileId
					AND f.EDITypeId in (5,6)
					AND f.Processed = 0
--			INNER JOIN @InsertedItems i
--				ON i.PONumber = c.BAK_PurchaseOrderNumber

	)
	select *
	from ACKDetail
	*/
END