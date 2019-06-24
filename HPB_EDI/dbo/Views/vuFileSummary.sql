CREATE view [dbo].[vuFileSummary]
AS
	SELECT f.EDIFileId, f.FullFileName, tc.EDITransactionCode, s.LineCount, tc.EDITransactionCodeDescription, tc.EDIPosition, tc.EDIMax, tc.EDILocation, tc.EDIMandatory, tc.EDILooping, tc.EDIElements
	FROM importX12.EDIFiles f
		INNER JOIN importX12.EDISummary s
			ON f.EDIFileId = s.EDIFileId
		INNER JOIN importX12.EDITransactionCodes tc
			ON s.EDITransactionCodeId=tc.EDITransactionCodeId
			
