CREATE  PROCEDURE [dbo].[uspImportEDIHeadersAndDetails856]
AS
BEGIN

	DECLARE @EDINumber VARCHAR(3) = '856'

	DECLARE @Inserted TABLE (
								 [UID] INT
								,[PurchaseOrderNumber] VARCHAR(15)
							)

	DECLARE @AppCodes TABLE (
								 [EDIFileID] INT
								,[DTM] VARCHAR(10)
								,[SC] VARCHAR(50)
								,[RC] VARCHAR(50)
								,[ICN] VARCHAR(50)
								,[VER] VARCHAR(25)
							)

	DECLARE @HL TABLE		(
								 [UID] INT IDENTITY(1,1)
								,[EDIFileID] INT
								,[ControlNumberGroup] VARCHAR(50)
								,[ControlNumberTransaction] VARCHAR(50)
								,[HierarchicalLevelCode] VARCHAR(10)
								,[HierarchicalParentIDNumber] INT
								,[RangeStart] INT
							)

	INSERT INTO @AppCodes([EDIFileID],[DTM],[SC],[RC],[ICN],[VER])
		SELECT ranges.[EDIFileId],gs.[Date],gs.[ApplicationSenderCode],gs.[ApplicationReceiverCode],isa.[InterchangeControlNumber],gs.[VersionRelIndIDCode]
		FROM (	SELECT DISTINCT [EDIFileId]
				FROM  [HPB_EDI].[dbo].[vuImportEDI_Unprocessed_TransactionRanges]
				WHERE [EDIType]=@EDINumber) ranges
			INNER JOIN [HPB_EDI].[dbo].[importEDI_ISA] isa
				ON isa.[EDIFileId]=ranges.[EDIFileId]
			INNER JOIN [HPB_EDI].[dbo].[importEDI_GS] gs
				ON gs.[EDIFileId]=ranges.[EDIFileId]

	INSERT INTO @HL ([EDIFileID],[ControlNumberGroup],[ControlNumberTransaction],[HierarchicalLevelCode],[HierarchicalParentIDNumber],[RangeStart])
		SELECT hl.[EDIFileId], hl.[ControlNumberGroup], hl.[ControlNumberTransaction], hl.[HierarchicalLevelCode], hl.[HierarchicalParentIDNumber], MIN(hl.[LineNumber]) AS RangeStart
		FROM [HPB_EDI].[dbo].[importEDI_HL] hl
			INNER JOIN @AppCodes ac
				ON ac.[EDIFileID]=hl.[EDIFileId]
		GROUP BY hl.[EDIFileId], hl.[ControlNumberGroup], hl.[ControlNumberTransaction], hl.[HierarchicalLevelCode], hl.[HierarchicalParentIDNumber]

	INSERT INTO [temp_856_Asn_Hdr] ([ShipID],[PONumber],[ASNNo],[IssueDate],[VendorID],[ReferenceNo],[ShipToLoc],[ShipToSAN],[BillToLoc],[BillToSAN],[ShipFromLoc]
								   ,[ShipFromSAN],[Carrier],[TotalLines],[TotalQty],[CurrencyCode],[InsertDateTime],[Processed],[ProcessedDateTime],[ASNACKSent],[ASNAckNo],[GSNo])
	OUTPUT INSERTED.[ShipID], INSERTED.[PONumber] INTO @Inserted ([UID],[PurchaseOrderNumber]) 
		SELECT	null as shipid 
				,loop_o.[PurchaseOrderNumber] AS PONumber
				,bsn.[ShipmentIdentification] AS ASNNo
				,CASE WHEN loop_s.[Date] LIKE '20%'	
					THEN loop_s.[Date]
					ELSE loop_s.[Century]+loop_s.[Date]
				 END AS IssueDate
				,vsc.[VendorID]
				,ac.ICN AS ReferenceNo
				,hdr.[ShipToLoc]
				,hdr.[ShipToSAN]
				,hdr.[BillToLoc]
				,hdr.[BillToSAN]
				,hdr.[ShipFromLoc]
				,hdr.[ShipFromSAN]
				,loop_s.[Routing] AS Carrier
				,ctt.[NumberOfLineItems] AS TotalLines
				,ISNULL(ctt.HashTotal,-1) AS TotalQty
				,NULL AS CurrencyCode
				,NULL AS InsertDateTime
				,NULL AS Processed
				,NULL AS ProcessedDateTime
				,NULL AS ASNACKSent
				,NULL AS ASNAckNo
				,bsn.[ControlNumberGroup] AS GSNo
		FROM [HPB_EDI].[dbo].[importEDI_BSN] bsn		
			INNER JOIN [HPB_EDI].[dbo].[vuImportEDI_Unprocessed_TransactionRanges] ranges
				ON bsn.[EDIFileId]=ranges.[EDIFileId]
					AND ranges.[RangeStart]=bsn.[LineNumber]-1
					AND ranges.[TransactionSetControlNumber]=bsn.[ControlNumberTransaction]
					AND ranges.[EDIType]=@EDINumber 
			INNER JOIN @AppCodes ac
				ON ac.[EDIFileID]=bsn.[EDIFileId]
			INNER JOIN [HPB_EDI].[dbo].[Vendor_SAN_Codes] vsc
				ON ac.[SC]=vsc.[SANCode]
			INNER JOIN (
							SELECT	 hlO.[ControlNumberGroup],hlO.[ControlNumberTransaction],hlO.[EDIFileID],hlO.[HierarchicalLevelCode],hlO.[HierarchicalParentIDNumber]
									,hlO.[UID],hlO.[RangeStart]
									,prf.[AssignedIdentification],prf.[ContractNumber],prf.[Date], prf.[LineNumber] AS prf_linenumber, prf.[PRFId], prf.[PurchaseOrderNumber]
									,prf.[PurchaseOrderTypeCode], prf.[ReleaseNumber]
							FROM (	SELECT * FROM @HL  WHERE [HierarchicalLevelCode]='O' AND [HierarchicalParentIDNumber]=1) hlO
								LEFT JOIN [HPB_EDI].[dbo].[importEDI_PRF] prf
									ON prf.[EDIFileId]=hlO.[EDIFileID]
										AND prf.[ControlNumberGroup]=hlO.[ControlNumberGroup]
										AND prf.[ControlNumberTransaction]=hlO.[ControlNumberTransaction]
										AND prf.[LineNumber] > hlO.[RangeStart]
						) loop_o
				ON loop_o.[EDIFileID]=bsn.[EDIFileId]
					AND loop_o.[ControlNumberGroup]=bsn.[ControlNumberGroup]
					AND loop_o.[ControlNumberTransaction]=bsn.[ControlNumberTransaction]
			INNER JOIN [HPB_EDI].[dbo].[850_PO_Hdr] hdr
				ON hdr.[PONumber]=loop_o.[PurchaseOrderNumber]
			LEFT JOIN (SELECT	 hlS.[EDIFileID],hlS.[ControlNumberGroup],hlS.[ControlNumberTransaction],hlS.[HierarchicalLevelCode],hlS.[HierarchicalParentIDNumber],hlS.[RangeStart]
								,hlS.[UID]
								,td1.[CommodityCode],td1.[CommodityCodeQualifier],td1.[LadingDescription],td1.[LadingQuantity],td1.[LineNumber] AS td1_linenumber
								,td1.[PackagingCode],td1.[TD1Id],td1.[UnitOrBasisForMeasurementCode],td1.[Weight],td1.[WeightQualifier]
								,td5.[IdentificationCode],td5.[IdentificationCodeQualifier],td5.[LineNumber] AS td5_linenumber, td5.[Routing], td5.[RoutingSequenceCode]
								,td5.[ServiceLevelCode],td5.[TD5Id]
								,ref.[LineNumber] AS ref_linenumber,ref.[ReferenceIdentification],ref.[ReferenceIdentificationQualifier],ref.[REFId]
								,dtm.[Century],dtm.[Date],dtm.[DateTimeQualifier],dtm.[DTMId],dtm.[LineNumber] AS dtm_linenumber
						FROM (	SELECT * FROM @HL WHERE [HierarchicalLevelCode]='S' AND [HierarchicalParentIDNumber]=1 ) hlS
							LEFT JOIN [HPB_EDI].[dbo].[importEDI_TD1] td1
								ON td1.EDIFileId = hls.EDIFileID
									AND td1.[ControlNumberGroup]=hls.[ControlNumberGroup]
									AND td1.[ControlNumberTransaction]=hls.ControlNumberTransaction
									AND td1.[LineNumber] > hls.RangeStart
							LEFT JOIN [HPB_EDI].[dbo].[importEDI_TD5] td5
								ON td5.[EDIFileId]=hls.[EDIFileID]
									AND td5.[ControlNumberGroup]=hls.[ControlNumberGroup]
									AND td5.[ControlNumberTransaction]=hls.[ControlNumberTransaction]
									AND td5.[LineNumber] > COALESCE(td1.[LineNumber], hls.[RangeStart])
							LEFT JOIN [HPB_EDI].[dbo].[importEDI_REF] ref
								ON ref.[EDIFileId]=hls.[EDIFileID]
									AND ref.[ControlNumberGroup]=hls.[ControlNumberGroup]
									AND ref.[ControlNumberTransaction]=hls.[ControlNumberTransaction]
									AND ref.[LineNumber] > COALESCE(td5.[linenumber], td1.[linenumber], hls.[RangeStart])
									AND ref.[ReferenceIdentificationQualifier]='CN'
							LEFT JOIN [HPB_EDI].[dbo].[importEDI_DTM] dtm									
								ON dtm.EDIFileId = hls.EDIFileID
									AND dtm.[DateTimeQualifier]='011' -- shipping
									AND dtm.[ControlNumberGroup]=hls.[ControlNumberGroup]
									AND dtm.[ControlNumberTransaction]=hls.[ControlNumberTransaction]
									AND dtm.[LineNumber] > COALESCE(ref.[linenumber], td5.[linenumber], td1.[linenumber], hls.[RangeStart])
							) loop_s
				ON loop_s.[EDIFileID]=bsn.[EDIFileId]
					AND loop_s.[ControlNumberGroup]=bsn.[ControlNumberGroup]
					AND loop_s.[ControlNumberTransaction]=bsn.[ControlNumberTransaction]
			LEFT JOIN [HPB_EDI].[dbo].[importEDI_CTT] ctt
				ON ctt.[EDIFileId]=bsn.[EDIFileId]
					AND ctt.[ControlNumberGroup]=bsn.[ControlNumberGroup]
					AND ctt.[ControlNumberTransaction]=bsn.[ControlNumberTransaction]
					AND ctt.[LineNumber] BETWEEN ranges.[RangeStart]+1 AND ranges.[RangeEnd]-1
			ORDER BY bsn.[ShipmentIdentification], loop_o.[PurchaseOrderNumber]

	INSERT INTO [temp_856_Asn_Dtl] (ShipID,[LineNo],ItemIDCode,ItemIdentifier,ItemDesc,ShipQty,PackageNo,TrackingNo)
		SELECT	 null --ii.IID AS ShipID
				,RIGHT('00000' + CAST(ROW_NUMBER() OVER (PARTITION BY bsn.ShipmentIdentification ORDER BY bsn.LineNumber) AS VARCHAR(5)),5) AS [LineNo]
				,loop_i.ProductServiceIDQualifier AS ItemIDCode
				,loop_i.ProductServiceID AS ItemIdentifier
				,NULL AS ItemDesc
				,loop_I.NumberOfUnitsShipped AS ShipQty
				,loop_p.MarksAndNumbers_01 AS PackageNo
				,COALESCE(loop_s.ReferenceIdentification,loop_p.MarksAndNumbers_02) AS TrackingNo
				--,'####bsn', bsn.*
				--,'ranges', ranges.*
				--,'ac', ac.*
				--,'vsc', vsc.*
				--,'loopo', loop_o.*
				--,'hdr',hdr.*
				--,'loops', loop_s.*
				--,'loopp', loop_p.*
				--,'loopi', loop_i.*
		FROM [HPB_EDI].[dbo].[importEDI_BSN] bsn		
			INNER JOIN [HPB_EDI].[dbo].[vuImportEDI_Unprocessed_TransactionRanges] ranges
				ON bsn.[EDIFileId]=ranges.[EDIFileId]
					AND ranges.[RangeStart]=bsn.[LineNumber]-1
					AND ranges.[TransactionSetControlNumber]=bsn.[ControlNumberTransaction]
					AND ranges.[EDIType]=@EDINumber 
			INNER JOIN @AppCodes ac
				ON ac.[EDIFileID]=bsn.[EDIFileId]
			INNER JOIN [HPB_EDI].[dbo].[Vendor_SAN_Codes] vsc
				ON ac.[SC]=vsc.[SANCode]
			INNER JOIN (
							SELECT	 hlO.[ControlNumberGroup],hlO.[ControlNumberTransaction],hlO.[EDIFileID],prf.[PurchaseOrderNumber] 
							FROM (SELECT * FROM @HL WHERE [HierarchicalLevelCode]='O') hlO
								INNER JOIN [HPB_EDI].[dbo].[importEDI_PRF] prf
									ON prf.[EDIFileId]=hlO.[EDIFileID]
										AND prf.[ControlNumberGroup]=hlO.[ControlNumberGroup]
										AND prf.[ControlNumberTransaction]=hlO.[ControlNumberTransaction]
										AND prf.[LineNumber] = hlO.[RangeStart]+1
						) loop_o
				ON loop_o.[EDIFileID]=bsn.[EDIFileId]
					AND loop_o.[ControlNumberGroup]=bsn.[ControlNumberGroup]
					AND loop_o.[ControlNumberTransaction]=bsn.[ControlNumberTransaction]
			INNER JOIN [HPB_EDI].[dbo].[850_PO_Hdr] hdr
				ON hdr.[PONumber]=loop_o.[PurchaseOrderNumber]

			LEFT JOIN (
							SELECT	 hlS.[ControlNumberGroup],hlS.[ControlNumberTransaction],hlS.[EDIFileID],hlS.[HierarchicalLevelCode],hlS.[HierarchicalParentIDNumber]
									,hlS.[UID],hlS.[RangeStart]
									,ref.ReferenceIdentification
							FROM  (SELECT * FROM @HL WHERE [HierarchicalLevelCode]='S') hlS
								LEFT JOIN importEDI_TD1 td1
									ON td1.EDIFileId = hls.EDIFileID
										AND td1.ControlNumberGroup = hlS.ControlNumberGroup
										AND td1.ControlNumberTransaction = hlS.ControlNumberTransaction
										AND td1.LineNumber > hls.RangeStart
								LEFT JOIN importEDI_TD5 td5
									ON td5.EDIFileId = hls.EDIFileID
										AND td5.ControlNumberGroup = hlS.ControlNumberGroup
										AND td5.ControlNumberTransaction = hlS.ControlNumberTransaction
										AND td5.LineNumber = (COALESCE(td1.LineNumber,hlS.RangeStart)+1)
								LEFT JOIN (select r.*
											from importEDI_REF r
												inner join @AppCodes ac
													on r.EDIFileId = ac.EDIFileID
											where ReferenceIdentificationQualifier = 'CN'
											) ref 
									ON ref.EDIFileId = hls.EDIFileID
										AND ref.ControlNumberGroup = hlS.ControlNumberGroup
										AND ref.ControlNumberTransaction = hlS.ControlNumberTransaction
										AND (ref.LineNumber - COALESCE(td5.LineNumber, td1.LineNumber,hlS.RangeStart) <=2)
					  ) loop_s
				ON loop_s.[EDIFileID]= bsn.[EDIFileId]
					AND loop_s.[ControlNumberGroup]=bsn.[ControlNumberGroup]
					AND loop_s.[ControlNumberTransaction]=bsn.[ControlNumberTransaction]
			LEFT JOIN (
							SELECT	 hlP.[ControlNumberGroup],hlP.[ControlNumberTransaction],hlP.[EDIFileID],hlP.[HierarchicalLevelCode],hlP.[HierarchicalParentIDNumber]
									,hlP.[UID],hlP.[RangeStart]
									,mea.[CompositeUnitOfMeasure],mea.[LineNumber] AS mea_LineNumber,mea.[MEAId],mea.[MeasurementQualifier],mea.[MeasurementReferenceIDCode]
									,mea.[MeasurementValue]
									,man.[LineNumber] AS man_LineNumber,man.[MarksAndNumbers_01],man.[MarksAndNumbers_02],man.[MarksAndNumbersQualifier_01],man.[MarksAndNumbersQualifier_02]
							FROM (SELECT * FROM @HL WHERE [HierarchicalLevelCode]='P') hlP
								LEFT JOIN [HPB_EDI].[dbo].[importEDI_REF] ref
									ON ref.[EDIFileId]=hlP.[EDIFileID]
										AND ref.[ControlNumberGroup]=hlP.[ControlNumberGroup]
										AND ref.[ControlNumberTransaction]=hlp.[ControlNumberTransaction]
										AND ref.[LineNumber] = hlp.[RangeStart]+1								
								LEFT JOIN [HPB_EDI].[dbo].[importEDI_MEA] mea
									ON mea.[EDIFileId]=hlP.[EDIFileID]
										AND mea.[ControlNumberGroup]=hlP.[ControlNumberGroup]
										AND mea.[ControlNumberTransaction]=hlp.[ControlNumberTransaction]
										AND (mea.[LineNumber] > hlp.[RangeStart] and mea.linenumber = (COALESCE(ref.LineNumber,hlP.RangeStart)+1))
								LEFT JOIN [HPB_EDI].[dbo].[importEDI_MAN] man
									ON man.[EDIFileId]=hlP.[EDIFileID]
										AND man.[ControlNumberGroup]=hlP.[ControlNumberGroup]
										AND man.[ControlNumberTransaction]=hlp.[ControlNumberTransaction]
										AND (man.[LineNumber] > hlp.[RangeStart] and man.linenumber = (COALESCE(mea.LineNumber,ref.LineNumber,hlP.RangeStart) + 1))
						) loop_p
				ON loop_p.[EDIFileID]= bsn.[EDIFileId]
					AND loop_p.[ControlNumberGroup]=bsn.[ControlNumberGroup]
					AND loop_p.[ControlNumberTransaction]=bsn.[ControlNumberTransaction]
			LEFT JOIN (
							SELECT	 hlI.[ControlNumberGroup],hlI.[ControlNumberTransaction],hlI.[EDIFileID],hlI.[HierarchicalLevelCode],hlI.[HierarchicalParentIDNumber]
									,hlI.[UID],hlI.[RangeStart]
									,lin.AssignedIdentification as lin_AssignedIdentification, lin.LineNumber as lin_LineNumber, lin.LINId, lin.ProductServiceID,lin.ProductServiceIDQualifier
									,sn1.AssignedIdentification as sn1_AssigneedIdentification,sn1.NumberOfUnitsShipped,sn1.QuantityOrdered, sn1.QuantityShippedToDate, sn1.SN1Id
									,sn1.UnitOrBasisForMeasurementCode_01, sn1.UnitOrBasisForMeasurementCode_02
									--,mea.CompositeUnitOfMeasure,mea.LineNumber as mea_LineNumber,mea.MEAId,mea.MeasurementQualifier,mea.MeasurementReferenceIDCode,mea.MeasurementValue
									--,cur.CURId,cur.CurrencyCode,cur.EntityIdentifierCode,cur.LineNumber as cur_LineNumber
							FROM (SELECT * FROM @HL WHERE [HierarchicalLevelCode]='I') hlI 
								LEFT JOIN (
											SELECT lin_01.linid, lin_01.EDIFileId, lin_01.LineNumber, lin_01.ControlNumberGroup, lin_01.ControlNumberTransaction, lin_01.AssignedIdentification, lin_01.ProductServiceIDQualifier_01 as ProductServiceIDQualifier, lin_01.ProductServiceID_01 as ProductServiceID
											FROM importEDI_LIN  lin_01
												INNER JOIN @AppCodes ac
													ON lin_01.EDIFileId = ac.EDIFileID
											WHERE ProductServiceIDQualifier_01=  'EN'
											UNION
											SELECt lin_02.linid, lin_02.EDIFileId, lin_02.LineNumber, lin_02.ControlNumberGroup, lin_02.ControlNumberTransaction, lin_02.AssignedIdentification, lin_02.ProductServiceIDQualifier_02 as ProductServiceIDQualifier, lin_02.ProductServiceID_02 as ProductServiceID
											FROM importEDI_LIN  lin_02
												INNER JOIN @AppCodes ac
													ON lin_02.EDIFileId = ac.EDIFileID
											WHERE ProductServiceIDQualifier_02=  'EN'
										  ) lin
									ON lin.[EDIFileId]=hlI.[EDIFileID]
										AND lin.[ControlNumberGroup]=hlI.[ControlNumberGroup]
										AND lin.[ControlNumberTransaction]=hlI.[ControlNumberTransaction]
										AND lin.[LineNumber] = hlI.[RangeStart]+1
								LEFT JOIN [HPB_EDI].[dbo].[importEDI_SN1] sn1
									ON sn1.[EDIFileId]=hlI.[EDIFileID]
										AND sn1.[ControlNumberGroup]=hlI.[ControlNumberGroup]
										AND sn1.[ControlNumberTransaction]=hlI.[ControlNumberTransaction]
										AND (sn1.[LineNumber] > hlI.[RangeStart] AND sn1.LineNumber = lin.LineNumber+1)
					  ) loop_i
				ON loop_i.[EDIFileID]=bsn.[EDIFileId]
					AND loop_i.[ControlNumberGroup]=bsn.[ControlNumberGroup]
					AND loop_i.[ControlNumberTransaction]=bsn.[ControlNumberTransaction]
					and loop_i.lin_LineNumber between ranges.RangeStart+1 and ranges.RangeEnd-1
			ORDER BY bsn.ShipmentIdentification, bsn.ControlNumberGroup, bsn.ControlNumberTransaction
END