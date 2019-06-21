CREATE PROCEDURE [dbo].[uspImportEDI_856_HeaderDetail]
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
				WHERE EDIType = '856') segs
			INNER JOIN importEDI_ISA isa
				ON isa.EDIFileId = segs.EDIFileId
			INNER JOIN importEDI_GS gs
				ON gs.EDIFileId = segs.EDIFileId

	SELECT * FROM @AppCodes


	SELECT	 bsn.*
	FROM importEDI_BSN bsn
		INNER JOIN vuImportEDI_Unprocessed_TransactionRanges segs
			ON bsn.EDIFileId = segs.EDIFileID
				AND segs.[RangeStart] = bsn.LineNumber-1
				AND segs.TransactionSetControlNumber = bsn.ControlNumberTransaction


	IF EXISTS(	SELECT HierarchicalLevelCode
				FROM importEDIFiles f
					INNER JOIN importEDITypes t
						ON f.EDITypeId = t.EDITypeId
							AND EDIType = '856'
							AND f.Processed = 0
					INNER JOIN importEDI_HL hl
						ON hl.EDIFileId = f.EDIFileId
							AND hl.HierarchicalLevelCode = 'S'
				GROUP BY HierarchicalLevelCode )
	BEGIN
		-- INSERT INTO SummaryEDI_856_S
			SELECT	 bsn.BSNId, bsn.LineNumber, bsn.ShipmentIdentification, bsn.[Date], bsn.[Time]
					,hls.*
					,td1.*
					,td5.*
					,ref.*
					,dtm.*
			FROM importEDI_BSN bsn
				INNER JOIN vuImportEDI_Unprocessed_TransactionRanges segs
					ON bsn.EDIFileId = segs.EDIFileID
						AND segs.[RangeStart] = bsn.LineNumber-1
						AND segs.TransactionSetControlNumber = bsn.ControlNumberTransaction
				LEFT JOIN importedi_hl hls
					ON hls.EDIFileId = bsn.EDIFileId
						AND hls.HierarchicalLevelCode = 'S'
						AND hls.ControlNumberGroup = bsn.ControlNumberGroup
						AND hls.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (hls.ControlNumberTransaction = segs.TransactionSetControlNumber 
							AND hls.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							AND hls.LineNumber > bsn.LineNumber)
				LEFT JOIN importEDI_TD1 td1
					ON td1.EDIFileId = bsn.EdiFileId
						AND td1.ControlNumberGroup = bsn.ControlNumberGroup
						AND td1.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (td1.ControlNumberTransaction = segs.TransactionSetControlNumber 
								AND td1.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
								AND td1.LineNumber > COALESCE(hls.LineNumber,bsn.LineNumber)
								AND td1.LineNumber - COALESCE(hls.LineNumber,bsn.LineNumber) BETWEEN 1 AND 20)
				LEFT JOIN importEDI_TD5 td5
					ON td5.EDIFileId = bsn.EDIFileID
						AND td5.ControlNumberGroup = bsn.ControlNumberGroup
						AND td5.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (td5.ControlNumberTransaction = segs.TransactionSetControlNumber 
							AND td5.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							AND td5.LineNumber > COALESCE(td1.LineNumber, hls.LineNumber, bsn.LineNumber)
							AND td5.LineNumber - COALESCE(td1.LineNumber, hls.LineNumber, bsn.LineNumber) BETWEEN 1 AND 12)
				LEFT JOIN importEDI_REF ref
					ON ref.EDIFileId = bsn.EDIFileId
						AND ref.ControlNumberGroup = bsn.ControlNumberGroup
						AND ref.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (ref.ControlNumberTransaction = segs.TransactionSetControlNumber 
							 AND ref.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							 AND ref.LineNumber > COALESCE(td5.LineNumber, td1.LineNumber, hls.LineNumber, bsn.LineNumber)
							 AND ref.LineNumber - COALESCE(td5.LineNumber, td1.LineNumber, hls.LineNumber, bsn.LineNumber) >= 1)
				LEFT JOIN importEDI_DTM dtm
					ON dtm.EDIFileId = bsn.EDIFileId
						AND dtm.ControlNumberGroup = bsn.ControlNumberGroup
						AND dtm.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND(dtm.ControlNumberTransaction = segs.TransactionSetControlNumber
							AND dtm.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							AND dtm.LineNumber > COALESCE(ref.LineNumber, td5.LineNumber, td1.LineNumber, hls.LineNumber, bsn.LineNumber)
							AND dtm.LineNumber - COALESCE(ref.LineNumber, td5.LineNumber, td1.LineNumber, hls.LineNumber, bsn.LineNumber) BETWEEN 1 AND 10)
						ORDER BY bsn.LineNumber, hls.LineNumber, td1.LineNumber, td5.LineNumber, ref.LineNumber, dtm.LineNumber
	END

	--INSERT INTO SummaryEDI_856_N
		SELECT	 bsn.BSNId, bsn.LineNumber, bsn.ShipmentIdentification, bsn.[Date], bsn.[Time]
				,n1.*
				,n2.*
				,n3.*
				,n4.*
		FROM importEDI_BSN bsn
			INNER JOIN vuImportEDI_Unprocessed_TransactionRanges segs
				ON bsn.EDIFileId = segs.EDIFileID
					AND segs.[RangeStart] = bsn.LineNumber-1
					AND segs.TransactionSetControlNumber = bsn.ControlNumberTransaction
			LEFT JOIN importEDI_n1 n1
				ON n1.EDIFileId = bsn.EDIFileId
					AND n1.ControlNumberGroup = bsn.ControlNumberGroup 
					AND n1.ControlNumberTransaction = bsn.ControlNumberTransaction
					AND(n1.ControlNumberTransaction = segs.TransactionSetControlNumber
						AND n1.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND n1.LineNumber > bsn.LineNumber
						AND n1.LineNumber-bsn.LineNumber >=1 )
			LEFT JOIN importEDI_n2 n2
				ON n2.EDIFileId = bsn.EDIFileId
					AND n2.ControlNumberGroup = bsn.ControlNumberGroup 
					AND n2.ControlNumberTransaction = bsn.ControlNumberTransaction
					AND(n2.ControlNumberTransaction = segs.TransactionSetControlNumber
						AND n2.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND n2.LineNumber > COALESCE(n1.LineNumber,bsn.LineNumber)
						AND n2.LineNumber - COALESCE(n1.LineNumber,bsn.LineNumber) BETWEEN 1 AND 2)
			LEFT JOIN importEDI_n3 n3
				ON n3.EDIFileId = bsn.EDIFileId
					AND n3.ControlNumberGroup = bsn.ControlNumberGroup 
					AND n3.ControlNumberTransaction = bsn.ControlNumberTransaction
					AND(n3.ControlNumberTransaction = segs.TransactionSetControlNumber
						AND n3.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND n3.LineNumber > COALESCE(n2.LineNumber, n1.LineNumber,bsn.LineNumber)
						AND n3.LineNumber - COALESCE(n2.LineNumber, n1.LineNumber,bsn.LineNumber) BETWEEN 1 AND 2)
			LEFT JOIN importEDI_n4 n4
				ON n4.EDIFileId = bsn.EDIFileId
					AND n4.ControlNumberGroup = bsn.ControlNumberGroup 
					AND n4.ControlNumberTransaction = bsn.ControlNumberTransaction
					AND(n4.ControlNumberTransaction = segs.TransactionSetControlNumber
						AND n4.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
						AND n4.LineNumber > COALESCE(n3.LineNumber, n2.LineNumber, n1.LineNumber,bsn.LineNumber)
						AND n4.LineNumber - COALESCE(n3.LineNumber, n2.LineNumber, n1.LineNumber,bsn.LineNumber) = 1)
		ORDER BY bsn.LineNumber, n1.LineNumber, n2.LineNumber, n3.LineNumber, n4.LineNumber

	IF EXISTS(	SELECT HierarchicalLevelCode
				FROM importEDIFiles f
					INNER JOIN importEDITypes t
						ON f.EDITypeId = t.EDITypeId
							AND EDIType = '856'
							AND f.Processed = 0
					INNER JOIN importEDI_HL hl
						ON hl.EDIFileId = f.EDIFileId
							AND hl.HierarchicalLevelCode = 'O'
				GROUP BY HierarchicalLevelCode )
	BEGIN
		--insert into SummaryEDI_856_O
			SELECT	 bsn.BSNId, bsn.LineNumber, bsn.ShipmentIdentification, bsn.[Date], bsn.[Time]
					,hlo.*
					,prf.*
			FROM importEDI_BSN bsn
				INNER JOIN vuImportEDI_Unprocessed_TransactionRanges segs
					ON bsn.EDIFileId = segs.EDIFileID
						AND segs.[RangeStart] = bsn.LineNumber-1
						AND segs.TransactionSetControlNumber = bsn.ControlNumberTransaction
				LEFT JOIN importedi_hl hlo
					ON hlo.EDIFileId = bsn.EDIFileId
						AND hlo.HierarchicalLevelCode = 'O'
						AND hlo.ControlNumberGroup = bsn.ControlNumberGroup
						AND hlo.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (hlo.ControlNumberTransaction = segs.TransactionSetControlNumber 
							AND hlo.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							 AND hlo.LineNumber > bsn.LineNumber)
				LEFT JOIN importEDI_PRF prf
					ON prf.EDIFileId = bsn.EDIFileId
						AND prf.ControlNumberGroup = hlo.ControlNumberGroup
						AND prf.ControlNumberTransaction = hlo.ControlNumberTransaction
						AND (prf.ControlNumberTransaction = segs.TransactionSetControlNumber 
								AND prf.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
								AND prf.LineNumber > COALESCE(hlo.LineNumber,bsn.LineNumber)
								AND prf.LineNumber - COALESCE(hlo.LineNumber,bsn.LineNumber) BETWEEN 1 AND 20)			
				ORDER BY bsn.LineNumber, hlo.LineNumber, prf.LineNumber
	END

	IF EXISTS(	SELECT HierarchicalLevelCode
				FROM importEDIFiles f
					INNER JOIN importEDITypes t
						ON f.EDITypeId = t.EDITypeId
							AND EDIType = '856'
							AND f.Processed = 0
					INNER JOIN importEDI_HL hl
						ON hl.EDIFileId = f.EDIFileId
							AND hl.HierarchicalLevelCode = 'T'
				GROUP BY HierarchicalLevelCode )
	BEGIN
		--INSERT INTO SummaryEDI_856_T
			SELECT	 bsn.BSNId, bsn.LineNumber, bsn.ShipmentIdentification, bsn.[Date], bsn.[Time]
					,hlt.*
					,pal.*
			FROM importEDI_BSN bsn
				INNER JOIN vuImportEDI_Unprocessed_TransactionRanges segs
					ON bsn.EDIFileId = segs.EDIFileID
						AND segs.[RangeStart] = bsn.LineNumber-1
						AND segs.TransactionSetControlNumber = bsn.ControlNumberTransaction
				LEFT JOIN importedi_hl hlt
					ON hlt.EDIFileId = bsn.EDIFileId
						AND hlt.HierarchicalLevelCode = 'T'
						AND hlt.ControlNumberGroup = bsn.ControlNumberGroup
						AND hlt.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (hlt.ControlNumberTransaction = segs.TransactionSetControlNumber 
							AND hlt.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							AND hlt.LineNumber > bsn.LineNumber)
				LEFT JOIN importEDI_PAL pal
					ON pal.EDIFileId = bsn.EDIFileId
						AND pal.ControlNumberGroup = hlt.ControlNumberGroup
						AND pal.ControlNumberTransaction = hlt.ControlNumberTransaction
						AND (pal.ControlNumberTransaction = segs.TransactionSetControlNumber 
								AND pal.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
								AND pal.LineNumber > COALESCE(hlt.LineNumber,bsn.LineNumber)
								AND pal.LineNumber - COALESCE(hlt.LineNumber,bsn.LineNumber) =1)
				LEFT JOIN importEDI_man manp
					ON pal.EDIFileId = bsn.EDIFileId
						AND manp.ControlNumberGroup = hlt.ControlNumberGroup
						AND manp.ControlNumberTransaction = hlt.ControlNumberTransaction
						AND (pal.ControlNumberTransaction = segs.TransactionSetControlNumber 
								AND manp.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
								AND manp.LineNumber > COALESCE(pal.LineNumber, hlt.LineNumber,bsn.LineNumber)
								AND manp.LineNumber - COALESCE(pal.LineNumber, hlt.LineNumber,bsn.LineNumber) =1)


			ORDER BY bsn.LineNumber, hlt.LineNumber, pal.LineNumber
	END

	IF EXISTS(	SELECT HierarchicalLevelCode
				FROM importEDIFiles f
					INNER JOIN importEDITypes t
						ON f.EDITypeId = t.EDITypeId
							AND EDIType = '856'
							AND f.Processed = 0
					INNER JOIN importEDI_HL hl
						ON hl.EDIFileId = f.EDIFileId
							AND hl.HierarchicalLevelCode = 'P'
				GROUP BY HierarchicalLevelCode )
	BEGIN
		--insert into SummaryEDI_856_P
			SELECT	 bsn.BSNId, bsn.LineNumber, bsn.ShipmentIdentification, bsn.[Date], bsn.[Time]
					,hlp.*
					,meap.*
					,man.*
			FROM importEDI_BSN bsn
				INNER JOIN vuImportEDI_Unprocessed_TransactionRanges segs
					ON bsn.EDIFileId = segs.EDIFileID
						AND segs.[RangeStart] = bsn.LineNumber-1
						AND segs.TransactionSetControlNumber = bsn.ControlNumberTransaction
				LEFT JOIN importedi_hl hlp
					ON hlp.EDIFileId = bsn.EDIFileId
						AND hlp.HierarchicalLevelCode = 'P'
						AND hlp.ControlNumberGroup = bsn.ControlNumberGroup
						AND hlp.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (hlp.ControlNumberTransaction = segs.TransactionSetControlNumber 
							AND hlp.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							AND hlp.LineNumber > bsn.LineNumber)
				LEFT JOIN importEDI_MEA meap
					ON meap.EDIFileId = bsn.EDIFileId
						AND meap.ControlNumberGroup = bsn.ControlNumberGroup
						AND meap.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (meap.ControlNumberTransaction = segs.TransactionSetControlNumber 
								AND meap.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
								AND meap.LineNumber > COALESCE(hlp.LineNumber,bsn.LineNumber)
								AND meap.LineNumber - COALESCE(hlp.LineNumber,bsn.LineNumber) = 1 )
				LEFT JOIN importEDI_MAN man
					ON man.EDIFileId = bsn.EDIFileId
						AND man.ControlNumberGroup = bsn.ControlNumberGroup
						AND man.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (man.ControlNumberTransaction = segs.TransactionSetControlNumber 
								AND man.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
								AND man.LineNumber > COALESCE(meap.LineNumber, hlp.LineNumber,bsn.LineNumber)
								AND man.LineNumber - COALESCE(meap.LineNumber, hlp.LineNumber,bsn.LineNumber) BETWEEN 1 AND 40)
				ORDER BY bsn.LineNumber, hlp.LineNumber, meap.LineNumber, man.LineNumber
	END

	IF EXISTS(	SELECT HierarchicalLevelCode
				FROM importEDIFiles f
					INNER JOIN importEDITypes t
						ON f.EDITypeId = t.EDITypeId
							AND EDIType = '856'
							AND f.Processed = 0
					INNER JOIN importEDI_HL hl
						ON hl.EDIFileId = f.EDIFileId
							AND hl.HierarchicalLevelCode = 'I'
				GROUP BY HierarchicalLevelCode )
	BEGIN
		--insert into SummaryEDI_856_I
			SELECT	 bsn.BSNId, bsn.LineNumber, bsn.ShipmentIdentification, bsn.[Date], bsn.[Time]
					,hli.*
					,lin.*
					,sn1.*
					,meai.*
					,cur.* 
			FROM importEDI_BSN bsn
				INNER JOIN vuImportEDI_Unprocessed_TransactionRanges segs
					ON bsn.EDIFileId = segs.EDIFileID
						AND segs.[RangeStart] = bsn.LineNumber-1
						AND segs.TransactionSetControlNumber = bsn.ControlNumberTransaction
				LEFT JOIN importedi_hl hli
					ON hli.EDIFileId = bsn.EDIFileId
						AND hli.HierarchicalLevelCode = 'I'
						AND hli.ControlNumberGroup = bsn.ControlNumberGroup
						AND hli.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (hli.ControlNumberTransaction = segs.TransactionSetControlNumber 
							AND hli.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							AND hli.LineNumber > bsn.LineNumber)
				LEFT JOIN importEDI_LIN lin
					ON lin.EDIFileId = bsn.EDIFileId
						AND lin.ControlNumberGroup = bsn.ControlNumberGroup
						AND lin.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (lin.ControlNumberTransaction = segs.TransactionSetControlNumber 
							AND lin.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							AND lin.LineNumber > COALESCE(hli.LineNumber, bsn.LineNumber)
							AND lin.LineNumber - COALESCE(hli.LineNumber,bsn.LineNumber)= 1)
				LEFT JOIN importEDI_SN1 sn1
					ON lin.EDIFileId = bsn.EDIFileId
						AND sn1.ControlNumberGroup = bsn.ControlNumberGroup
						AND sn1.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (sn1.ControlNumberTransaction = segs.TransactionSetControlNumber 
							AND sn1.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							AND sn1.LineNumber > COALESCE(lin.LineNumber, hli.LineNumber, bsn.LineNumber)
							AND sn1.LineNumber - COALESCE(lin.LineNumber, hli.LineNumber,bsn.LineNumber)= 1)
				LEFT JOIN importEDI_MEA meai
					ON meai.EDIFileId = bsn.EDIFileId
						AND meai.ControlNumberGroup = bsn.ControlNumberGroup
						AND meai.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (meai.ControlNumberTransaction = segs.TransactionSetControlNumber 
							AND meai.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							AND meai.LineNumber > COALESCE(sn1.LineNumber, lin.LineNumber, hli.LineNumber, bsn.LineNumber)
							AND meai.LineNumber - COALESCE(sn1.LineNumber,  hli.LineNumber,bsn.LineNumber) BETWEEN 1 AND 40)
				LEFT JOIN importEDI_CUR cur
					ON cur.EDIFileId = bsn.EDIFileId
						AND cur.ControlNumberGroup = bsn.ControlNumberGroup
						AND cur.ControlNumberTransaction = bsn.ControlNumberTransaction
						AND (cur.ControlNumberTransaction = segs.TransactionSetControlNumber 
							AND cur.LineNumber BETWEEN segs.[RangeStart]+1 AND segs.[RangeEnd]-1
							AND cur.LineNumber > COALESCE(meai.LineNumber, sn1.LineNumber, lin.LineNumber, hli.LineNumber, bsn.LineNumber)
							AND cur.LineNumber - COALESCE(meai.LineNumber, sn1.LineNumber,  hli.LineNumber,bsn.LineNumber) >= 1)
			ORDER BY bsn.LineNumber, hli.LineNumber, lin.LineNumber, sn1.LineNumber, meai.LineNumber, cur.LineNumber
	END
END