
CREATE PROCEDURE [dbo].[uspImportEDI_810_HeaderDetail]
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
				WHERE EDIType = '810') segs
			INNER JOIN importEDI_ISA isa
				ON isa.EDIFileId = segs.EDIFileId
			INNER JOIN importEDI_GS gs
				ON gs.EDIFileId = segs.EDIFileId

	SELECT * FROM @AppCodes

	SELECT	 big.*
			,cur.*
			,n1.*
			,n2.*
			,n3.*
			,n4.*
			,itd.*
			,dtm.*
			,it1.*
			,ctp.*
			,pid.*
			,sac.*
			,tds.*
			,txi.*
	FROM [importEDI_BIG] big
		INNER JOIN vuImportEDI_Unprocessed_TransactionRanges segs
			ON segs.EDIFileID = big.EDIFileId
				AND segs.TransactionSetControlNumber = big.ControlNumberTransaction
		LEFT JOIN [importEDI_CUR] cur
			ON cur.EDIFileId = big.EDIFileId
				AND cur.ControlNumberGroup = big.ControlNumberGroup
				AND cur.ControlNumberTransaction = big.ControlNumberTransaction
				AND (cur.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND cur.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND cur.LineNumber > big.LineNumber
					AND cur.LineNumber - big.LineNumber = 1)
		LEFT JOIN [importEDI_N1] n1
			ON n1.EDIFileId = big.EDIFileId
				AND n1.ControlNumberGroup = big.ControlNumberGroup
				AND n1.ControlNumberTransaction = big.ControlNumberTransaction
				AND (n1.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND n1.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND n1.LineNumber > COALESCE(cur.LineNumber, big.LineNumber)
					AND n1.LineNumber - COALESCE(cur.LineNumber, big.LineNumber) BETWEEN 1 AND 2)
		LEFT JOIN [importEDI_N2] n2
			ON n2.EDIFileId = big.EDIFileId
				AND n2.ControlNumberGroup = big.ControlNumberGroup
				AND n2.ControlNumberTransaction = big.ControlNumberTransaction
				AND (n2.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND n2.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND n2.LineNumber > COALESCE(n1.LineNumber, cur.LineNumber, big.LineNumber)
					AND n2.LineNumber - COALESCE(n1.LineNumber, cur.LineNumber, big.LineNumber) BETWEEN 1 AND 2)
		LEFT JOIN [importEDI_N3] n3
			ON n3.EDIFileId = big.EDIFileId
				AND n3.ControlNumberGroup = big.ControlNumberGroup
				AND n3.ControlNumberTransaction = big.ControlNumberTransaction
				AND (n3.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND n3.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND n3.LineNumber > COALESCE(n2.LineNumber, n1.LineNumber, cur.LineNumber, big.LineNumber)
					AND n3.LineNumber - COALESCE(n2.LineNumber, n1.LineNumber, cur.LineNumber, big.LineNumber) BETWEEN 1 AND 2)
		LEFT JOIN [importEDI_N4] n4
			ON n4.EDIFileId = big.EDIFileId
				AND n4.ControlNumberGroup = big.ControlNumberGroup
				AND n4.ControlNumberTransaction = big.ControlNumberTransaction
				AND (n4.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND n4.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND n4.LineNumber > COALESCE(n3.LineNumber, n2.LineNumber, n1.LineNumber, cur.LineNumber, big.LineNumber)
					AND n4.LineNumber - COALESCE(n3.LineNumber, n2.LineNumber, n1.LineNumber, cur.LineNumber, big.LineNumber) BETWEEN 1 AND 2)
		LEFT JOIN [importEDI_ITD] itd
			ON itd.EDIFileId = big.EDIFileId
				AND itd.ControlNumberGroup = big.ControlNumberGroup
				AND itd.ControlNumberTransaction = big.ControlNumberTransaction
				AND (itd.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND itd.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND itd.LineNumber > COALESCE(n4.LineNumber, n3.LineNumber, n2.LineNumber, n1.LineNumber, cur.LineNumber)
					AND itd.LineNumber - COALESCE(n4.LineNumber, n3.LineNumber, n2.LineNumber, n1.LineNumber, cur.LineNumber) >=1)
		LEFT JOIN [importEDI_DTM] dtm
			ON itd.EDIFileId = big.EDIFileId
				AND dtm.ControlNumberGroup = big.ControlNumberGroup
				AND dtm.ControlNumberTransaction = big.ControlNumberTransaction
				AND (dtm.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND dtm.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND dtm.LineNumber > COALESCE(itd.LineNumber, n4.LineNumber, n3.LineNumber, n2.LineNumber, n1.LineNumber)
					AND dtm.LineNumber - COALESCE(itd.LineNumber, n4.LineNumber, n3.LineNumber, n2.LineNumber, n1.LineNumber) >=1)
		LEFT JOIN [importEDI_IT1] it1
			ON it1.EDIFileId = big.EDIFileId
				AND it1.ControlNumberGroup = big.ControlNumberGroup
				AND it1.ControlNumberTransaction = big.ControlNumberTransaction
				AND (it1.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND it1.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND it1.LineNumber > COALESCE(dtm.LineNumber, itd.LineNumber, n4.LineNumber, n3.LineNumber, n2.LineNumber)
					AND it1.LineNumber - COALESCE(dtm.LineNumber, itd.LineNumber, n4.LineNumber, n3.LineNumber, n2.LineNumber) >=1)
		LEFT JOIN [importEDI_CTP] ctp
			ON it1.EDIFileId = big.EDIFileId
				AND ctp.ControlNumberGroup = big.ControlNumberGroup
				AND ctp.ControlNumberTransaction = big.ControlNumberTransaction
				AND (ctp.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND ctp.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND ctp.LineNumber > COALESCE(it1.LineNumber, dtm.LineNumber, itd.LineNumber, n4.LineNumber, n3.LineNumber)
					AND ctp.LineNumber - COALESCE(it1.LineNumber, dtm.LineNumber, itd.LineNumber, n4.LineNumber, n3.LineNumber) >=1)
		LEFT JOIN [importEDI_PID] pid
			ON pid.EDIFileId = big.EDIFileId
				AND pid.ControlNumberGroup = big.ControlNumberGroup
				AND pid.ControlNumberTransaction = big.ControlNumberTransaction
				AND (pid.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND pid.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND pid.LineNumber > COALESCE(ctp.LineNumber, it1.LineNumber, dtm.LineNumber, itd.LineNumber, n4.LineNumber)
					AND pid.LineNumber - COALESCE(ctp.LineNumber, it1.LineNumber, dtm.LineNumber, itd.LineNumber, n4.LineNumber) BETWEEN 1 AND 25)
		LEFT JOIN [importEDI_SAC] sac
			ON sac.EDIFileId = big.EDIFileId
				AND sac.ControlNumberGroup = big.ControlNumberGroup
				AND sac.ControlNumberTransaction = big.ControlNumberTransaction
				AND (sac.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND sac.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND sac.LineNumber > COALESCE(pid.LineNumber, ctp.LineNumber, it1.LineNumber, dtm.LineNumber, itd.LineNumber)
					AND sac.LineNumber - COALESCE(pid.LineNumber, ctp.LineNumber, it1.LineNumber, dtm.LineNumber, itd.LineNumber) =1)
		LEFT JOIN [importEDI_TDS] tds
			ON tds.EDIFileId = big.EDIFileId
				AND tds.ControlNumberGroup = big.ControlNumberGroup
				AND tds.ControlNumberTransaction = big.ControlNumberTransaction
				AND (tds.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND tds.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND tds.LineNumber > COALESCE(sac.LineNumber, pid.LineNumber, ctp.LineNumber, it1.LineNumber, dtm.LineNumber)
					AND tds.LineNumber - COALESCE(sac.LineNumber, pid.LineNumber, ctp.LineNumber, it1.LineNumber, dtm.LineNumber) =1)
		LEFT JOIN [importEDI_TXI] txi
			ON txi.EDIFileId = big.EDIFileId
				AND txi.ControlNumberGroup = big.ControlNumberGroup
				AND txi.ControlNumberTransaction = big.ControlNumberTransaction
				AND (txi.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND txi.LineNumber BETWEEN segs.RangeStart+1 AND segs.RangeEnd-1
					AND txi.LineNumber > COALESCE(tds.LineNumber, sac.LineNumber, pid.LineNumber, ctp.LineNumber, it1.LineNumber)
					AND txi.LineNumber - COALESCE(tds.LineNumber, sac.LineNumber, pid.LineNumber, ctp.LineNumber, it1.LineNumber) =1)
WHERE segs.EDIType = '810'
END