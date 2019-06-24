CREATE PROCEDURE [dbo].[uspImportEDI_997_HeaderDetail]
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
				WHERE EDIType = '997') segs
			INNER JOIN [importX12].[TagISA] isa
				ON isa.EDIFileId = segs.EDIFileId
			INNER JOIN [importX12].[TagGS] gs
				ON gs.EDIFileId = segs.EDIFileId

	SELECT * FROM @AppCodes

	SELECT	 ak1.*
			,ak2.*
			,ak3.*
			,ak4.*
			,ak5.*
			,ak9.*
	FROM [importX12].[TagAK1] ak1
		INNER JOIN vuImportEDI_Unprocessed_TransactionRanges segs
			ON ak1.EDIFileID = segs.EDIFileId
		LEFT JOIN [importX12].[TagAK2] ak2
			ON ak2.EDIFileID = ak1.EDIFileID
				AND ak2.ControlNumberGroup = ak1.ControlNumberGroup
				AND ak2.ControlNumberTransaction = ak2.ControlNumberTransaction
				AND (ak2.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND ak2.LineNumber between segs.RangeStart+1 AND segs.RangeEnd-1
					AND ak2.LineNumber > ak1.LineNumber
					AND ak2.LineNumber - ak1.LineNumber >= 1)
		LEFT JOIN [importX12].[TagAK3] ak3
			ON ak3.EDIFileID = ak1.EDIFileID
				AND ak3.ControlNumberGroup = ak1.ControlNumberGroup
				AND ak3.ControlNumberTransaction = ak2.ControlNumberTransaction
				AND (ak3.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND ak3.LineNumber between segs.RangeStart+1 AND segs.RangeEnd-1
					AND ak3.LineNumber > COALESCE(ak2.LineNumber, ak1.LineNumber)
					AND ak3.LineNumber - COALESCE(ak2.LineNumber, ak1.LineNumber) >= 1)
		LEFT JOIN [importX12].[TagAK4] ak4
			ON ak4.EDIFileID = ak1.EDIFileID
				AND ak4.ControlNumberGroup = ak1.ControlNumberGroup
				AND ak4.ControlNumberTransaction = ak2.ControlNumberTransaction
				AND (ak4.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND ak4.LineNumber between segs.RangeStart+1 AND segs.RangeEnd-1
					AND ak4.LineNumber > COALESCE(ak3.LineNumber, ak2.LineNumber, ak1.LineNumber)
					AND ak4.LineNumber - COALESCE(ak3.LineNumber, ak2.LineNumber, ak1.LineNumber) >= 1)
		LEFT JOIN [importX12].[TagAK5] ak5
			ON ak5.EDIFileID = ak1.EDIFileID
				AND ak5.ControlNumberGroup = ak1.ControlNumberGroup
				AND ak5.ControlNumberTransaction = ak2.ControlNumberTransaction
				AND (ak5.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND ak5.LineNumber between segs.RangeStart+1 AND segs.RangeEnd-1
					AND ak5.LineNumber > COALESCE(ak4.LineNumber, ak3.LineNumber, ak2.LineNumber, ak1.LineNumber)
					AND ak5.LineNumber - COALESCE(ak4.LineNumber, ak3.LineNumber, ak2.LineNumber, ak1.LineNumber) >= 1)
		LEFT JOIN [importX12].[TagAK9] ak9
			ON ak9.EDIFileID = ak1.EDIFileID
				AND ak9.ControlNumberGroup = ak1.ControlNumberGroup
				AND ak9.ControlNumberTransaction = ak2.ControlNumberTransaction
				AND (ak9.ControlNumberTransaction = segs.TransactionSetControlNumber
					AND ak9.LineNumber between segs.RangeStart+1 AND segs.RangeEnd-1
					AND ak9.LineNumber > COALESCE(ak5.LineNumber, ak4.LineNumber, ak3.LineNumber, ak2.LineNumber, ak1.LineNumber)
					AND ak9.LineNumber - COALESCE(ak5.LineNumber, ak4.LineNumber, ak3.LineNumber, ak2.LineNumber, ak1.LineNumber) >= 1)
	WHERE segs.EDIType = '997'
END

