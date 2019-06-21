
CREATE view [dbo].[vuFileSummary]
as
	select f.EDIFileId, f.FullFileName, tc.EDITransactionCode, s.LineCount, tc.EDITransactionCodeDescription, tc.EDIPosition, tc.EDIMax, tc.EDILocation, tc.EDIMandatory, tc.EDILooping, tc.EDIElements
	from importEDIFiles f
		inner join importEDISummary s
			on f.EDIFileId = s.EDIFileId
		inner join importEDITransactionCodes tc
			on s.EDITransactionCodeId=tc.EDITransactionCodeId
			
