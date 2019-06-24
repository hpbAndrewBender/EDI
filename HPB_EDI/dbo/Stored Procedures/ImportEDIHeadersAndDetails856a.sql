CREATE PROCEDURE [dbo].[ImportEDIHeadersAndDetails856a]
AS
BEGIN
	DECLARE @EDINumber VARCHAR(3) = '856'

	DECLARE @Inserted TABLE (
								 IID INT
								,PurchaseOrderNumber VARCHAR(15)
							)
	DECLARE @POs TABLE (
							OrdID INT
							,PONumber VARCHAR(50)
							,ShipToLoc VARCHAR(50)
							,ShipToSAN VARCHAR(50)
							,BillToLoc VARCHAR(50)
							,BillToSAN VARCHAR(50)
							,ShipFromLoc VARCHAR(50)
							,ShipFromSAN VARCHAR(50)
							,ControlNumberGroup VARCHAR(50)
							,ControlNumberTransaction VARCHAR(50)
						)

	DECLARE @HL TABLE		(
								 IID INT IDENTITY(1,1)
								,EDIFileID INT
								,ControlNumberGroup VARCHAR(50)
								,ControlNumberTransaction VARCHAR(50)
								,HierarchicalLevelCode VARCHAR(10)
								,HierarchicalParentIDNumber INT
								,RangeStart INT
							)

	declare @lin table (
							 LinID int
							,EDIFileId Int
							,ControlNumberGroup varchar(50)
							,ControlNumberTransaction varchar(50)
							,psq varchar(50)
							,ps varchar(50)
							,LineNumber int
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
		SELECT ranges.[EDIFileId],gs.[Date], gs.[ApplicationSenderCode], gs.[ApplicationReceiverCode], isa.[InterchangeControlNumber], gs.[VersionRelIndIDCode]
		FROM (	SELECT DISTINCT [EDIFileId]
				FROM  [HPB_EDI].[dbo].[vuImportEDI_Unprocessed_TransactionRanges]
				WHERE [EDIType]=@EDINumber) ranges
			INNER JOIN [importx12].[TagISA] isa
				ON isa.[EDIFileId]=ranges.[EDIFileId]
			INNER JOIN [importx12].[TagGS] gs
				ON gs.[EDIFileId]=ranges.[EDIFileId]

	INSERT INTO @HL (EDIFileID, ControlNumberGroup, ControlNumberTransaction, HierarchicalLevelCode, HierarchicalParentIDNumber, RangeStart)
		SELECT hl.[EDIFileId], hl.[ControlNumberGroup], hl.[ControlNumberTransaction], hl.[HierarchicalLevelCode], hl.[HierarchicalParentIDNumber], MIN(hl.[LineNumber]) AS RangeStart
		FROM [importx12].[TagHL] hl
			INNER JOIN @AppCodes ac
				ON ac.[EDIFileID]=hl.[EDIFileId]
		GROUP BY hl.[EDIFileId], hl.[ControlNumberGroup], hl.[ControlNumberTransaction], hl.[HierarchicalLevelCode], hl.[HierarchicalParentIDNumber]

	insert into @POs (OrdID,PONumber,ShipToLoc ,ShipToSAN ,BillToLoc ,BillToSAN ,ShipFromLoc ,ShipFromSAN, ControlNumberGroup, ControlNumberTransaction)
		select hdr.OrdID, hdr.PONumber,ShipToLoc, ShipToSAN, BillToLoc, BillToSAN, ShipFromLoc, ShipFromSAN, prf.ControlNumberGroup, prf.ControlNumberTransaction
		from [850_PO_Hdr] hdr
			inner join importx12.TagPRF prf
				on prf.PurchaseOrderNumber = hdr.PONumber
			inner join @AppCodes ac
				on prf.EDIFileId = ac.EDIFileID


	insert into @lin (LinID,EDIFileId, ControlNumberGroup, ControlNumberTransaction, psq, ps, LineNumber)
		select LINId, EDIFileId, ControlNumberGroup,ControlNumberTransaction, psq, ps, LineNumber
		from 
		(select LINId, lin1.EDIFileId, LineNumber, ControlNumberGroup,ControlNumberTransaction, ProductServiceIDQualifier_01 as psq, ProductServiceID_01 as ps
		from importx12.[TagLIN]	 lin1
			inner join @AppCodes ac
				on  lin1.EDIFileID=ac.EDIFileID
		where ProductServiceIDQualifier_01 = 'en' and ProductServiceID_01 is not null
		union
		select LINId, lin2.EDIFileId, LineNumber, ControlNumberGroup,ControlNumberTransaction, ProductServiceIDQualifier_02 as psq, ProductServiceID_02 as ps
		from importx12.TagLIN lin2
			inner join @AppCodes ac
				on  lin2.EDIFileID=ac.EDIFileID
		where ProductServiceIDQualifier_02 = 'en' and ProductServiceID_02 is not null ) x
		group by LINId, EDIFileId, ControlNumberGroup,ControlNumberTransaction, psq, ps, LineNumber
		order by ControlNumberGroup, ControlNumberTransaction, ps

	--INSERT INTO [856_Asn_Hdr_temp] (ShipID,PONumber,ASNNo,IssueDate,VendorID,ReferenceNo,ShipToLoc,ShipToSAN,BillToLoc,BillToSAN,ShipFromLoc,ShipFromSAN,Carrier,TotalLines,TotalQty,CurrencyCode,InsertDateTime,Processed,ProcessedDateTime,ASNACKSent,ASNAckNo,GSNo)
	--OUTPUT INSERTED.ShipID, INSERTED.PONumber INTO @Inserted (IID, PurchaseOrderNumber) 
		SELECT	 
				 bsn.[ShipmentIdentification] AS ASNNo
				,prf.[PurchaseOrderNumber] AS PONumber
				,CASE WHEN dtm.[Date] LIKE '20%'	
					THEN ISNULL(dtm.[Date],'')
					ELSE ISNULL(dtm.[Century],'')+ISNULL(dtm.[Date],'')
				 END AS IssueDate
				,vsc.[VendorID]
				,ac.ICN AS ReferenceNo
				,hdr.[ShipToLoc]
				,hdr.[ShipToSAN]
				,hdr.[BillToLoc]
				,hdr.[BillToSAN]
				,hdr.[ShipFromLoc]
				,hdr.[ShipFromSAN]
				,td5.Routing AS Carrier
				,ctt.NumberOfLineItems AS TotalLines
				,ISNULL(ctt.HashTotal,-1) AS TotalQty
				,NULL AS CurrencyCode
				,NULL AS InsertDateTime
				,NULL AS Processed
				,NULL AS ProcessedDateTime
				,NULL AS ASNACKSent
				,NULL AS ASNAckNo
				,bsn.ControlNumberGroup AS GSNo
				,'##'
				,*
		FROM vuImportEDI_Unprocessed_TransactionRanges ranges
			INNER JOIN @AppCodes ac
				ON ranges.EDIFileId = ac.EDIFileID
			INNER JOIN Vendor_SAN_Codes vsc
				ON ac.SC=vsc.SanCode
			INNER JOIN [importx12].[TagBSN] bsn
				ON bsn.EDIFileId = ac.EDIFileID
				AND bsn.[ControlNumberTransaction]=ranges.[TransactionSetControlNumber]
					and bsn.LineNumber between ranges.RangeStart+1 and ranges.RangeEnd-1
			LEFT JOIN @HL hlO
				on hlO.HierarchicalLevelCode='O'
					AND hlO.EDIFileId = bsn.EDIFileId
					AND hlO.ControlNumberTransaction = bsn.ControlNumberTransaction
					AND hlO.ControlNumberGroup = bsn.ControlNumberGroup
			LEFT JOIN [importx12].[tagPRF] prf
				ON prf.EDIFileId = bsn.EDIFileId
					AND prf.ControlNumberTransaction = bsn.ControlNumberTransaction
					and prf.ControlNumberGroup = bsn.ControlNumberGroup
					and prf.LineNumber > hlo.RangeStart
			INNER JOIN @POs hdr
				ON hdr.PONumber = prf.PurchaseOrderNumber
			LEFT JOIN @HL hlS
				on hlS.HierarchicalLevelCode = 'S'
					AND hlS.EDIFileId = bsn.EDIFileId
					AND hlS.ControlNumberTransaction = bsn.ControlNumberTransaction
					AND hlS.ControlNumberGroup = bsn.ControlNumberGroup
			LEFT JOIN importx12.TagTD1 td1
				on td1.EDIFileId = bsn.EDIFileId
					and td1.ControlNumberTransaction = bsn.ControlNumberTransaction
					and td1.ControlNumberGroup = bsn.ControlNumberGroup
			LEFT JOIN importx12.TagTD5 td5
				on td5.EDIFileId = bsn.EDIFileId
					and td5.ControlNumberTransaction = bsn.ControlNumberTransaction
					and td5.ControlNumberGroup = bsn.ControlNumberGroup
			LEFT JOIN importx12.TagDTM dtm
				on dtm.EDIFileId = bsn.EDIFileId
					and dtm.ControlNumberTransaction = bsn.ControlNumberTransaction
					and dtm.ControlNumberGroup = bsn.ControlNumberGroup
					and dtm.DateTimeQualifier = '011' -- shipped
			LEFT JOIN importx12.TagCTT ctt
				ON ctt.EDIFileId = bsn.EDIFileId
					AND ctt.ControlNumberTransaction= bsn.ControlNumberTransaction
					and ctt.ControlNumberGroup = bsn.ControlNumberGroup
		WHERE ranges.EDIType = @EDINumber
	order by  bsn.ShipmentIdentification,prf.PurchaseOrderNumber

	--INSERT INTO [856_Asn_Dtl_temp] (ShipID,[LineNo],ItemIDCode,ItemIdentifier,ItemDesc,ShipQty,PackageNo,TrackingNo)
		--SELECT	 ii.IID AS ShipID
		select bsn.ShipmentIdentification
				,RIGHT('00000' + CAST(ROW_NUMBER() OVER (PARTITION BY bsn.ShipmentIdentification ORDER BY bsn.LineNumber) AS VARCHAR(5)),5) AS [LineNo]
				,loop_I.psq AS ItemIDCode
				,loop_I.ps AS ItemIdentifier
				,NULL AS ItemDesc
				,loop_I.NumberOfUnitsShipped AS ShipQty
				,loop_p.MarksAndNumbers_01 AS PackageNo
				,loop_P.MarksAndNumbers_02 AS TrackingNo
				,'##'
				,*
		FROM vuImportEDI_Unprocessed_TransactionRanges ranges
			INNER JOIN @AppCodes ac
				ON ranges.EDIFileId = ac.EDIFileID
			INNER JOIN Vendor_SAN_Codes vsc
				ON ac.SC=vsc.SanCode
			INNER JOIN [importx12].[TagBSN] bsn
				ON bsn.EDIFileId = ac.EDIFileID
				AND bsn.[ControlNumberTransaction]=ranges.[TransactionSetControlNumber]
					and bsn.LineNumber between ranges.RangeStart+1 and ranges.RangeEnd-1
			INNER JOIN @POs hdr
				ON bsn.ControlNumberGroup = hdr.ControlNumberGroup
					AND bsn.ControlNumberTransaction = hdr.ControlNumberTransaction
			LEFT JOIN (
						select hlO.*
							,prf.LineNumber
							,prf.PurchaseOrderNumber
							,hdr.BillToLoc
							,hdr.BillToSAN
							,hdr.OrdID
							,hdr.ShipFromLoc
							,hdr.ShipFromSAN
							,hdr.ShipToLoc
							,hdr.ShipToSAN
						from @hl hlO
							LEFT JOIN [importx12].[TagPRF] prf
							ON prf.EDIFileId = hlO.EDIFileId
								AND prf.ControlNumberTransaction = hlO.ControlNumberTransaction
								and prf.ControlNumberGroup = hlO.ControlNumberGroup
								and prf.LineNumber > hlo.RangeStart
							INNER JOIN [HPB_EDI].[dbo].[850_PO_Hdr] hdr
							ON hdr.PONumber = prf.PurchaseOrderNumber
						where hLo.HierarchicalLevelCode = 'O'
			) loop_O
				ON loop_O.EDIFileId = bsn.EDIFileId
					AND loop_O.ControlNumberGroup = bsn.ControlNumberGroup
					and (loop_O.ControlNumberTransaction = ranges.TransactionSetControlNumber
						and loop_O.LineNumber between ranges.RangeStart+1 and ranges.RangeEnd-1)			
			LEFT JOIN (	select hlP.*
								,man.MANId
								,man.LineNumber
								,man.MarksAndNumbers_01
								,man.MarksAndNumbers_02
								,man.MarksAndNumbersQualifier_01
								,man.MarksAndNumbersQualifier_02
						from @HL hlP
							left join importx12.TagMAN man
								on man.EDIFileID=hlp.EDIFileId
									and hlP.ControlNumberGroup = man.ControlNumberGroup
									and man.LineNumber > hlp.RangeStart 
									and hlp.ControlNumberTransaction=man.ControlNumberTransaction
						where hlp.HierarchicalLevelCode='P') loop_p
				on loop_p.EDIFileID = bsn.EDIFileId
					and loop_p.ControlNumberGroup = bsn.ControlNumberGroup
					and (loop_p.ControlNumberTransaction = ranges.TransactionSetControlNumber
						and loop_p.LineNumber between ranges.RangeStart+1 and ranges.RangeEnd-1)
			LEFT JOIN (	select hlI.*
								,lini.LinID
								,lini.LineNumber
								,lini.ps
								,lini.psq
								,sn1I.SN1Id
								,sn1i.NumberOfUnitsShipped
								,sn1i.QuantityOrdered
								,sn1i.QuantityShippedToDate
						from @HL hlI
							left join @lin linI
								on linI.EDIFileID =hli.EDIFileID
									and linI.ControlNumberGroup = hlI.ControlNumberGroup
									and linI.LineNumber > hli.RangeStart
							left join importx12.TagSN1 sn1I
								on sn1I.EDIFileId = hli.ediFileId
									and sn1I.ControlNumberGroup=hli.ControlNumberGroup
									and sn1I.LineNumber > hli.RangeStart
									and sn1I.ControlNumberTransaction=hli.ControlNumberTransaction
						where hlI.HierarchicalLevelCode = 'i' ) loop_I
					on loop_I.EDIFileID = bsn.EDIFileId
						and loop_i.ControlNumberGroup=bsn.ControlNumberGroup
						and (loop_i.ControlNumberTransaction=ranges.TransactionSetControlNumber
							and loop_i.LineNumber between ranges.RangeStart+1 and ranges.RangeEnd-1)									
	WHERE ranges.EDIType = @EDINumber
	order by bsn.ShipmentIdentification
END