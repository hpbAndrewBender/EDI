CREATE VIEW [dbo].[vuImportEDI_Unprocessed_TransactionRanges]
AS
	SELECT t.EDIType, st.EDIFileId, st.TransactionSetControlNumber, st.LineNumber AS RangeStart, se.LineNumber AS RangeEnd, se.NumberOfIncludedSegments
	FROM importX12.EDIFiles f
		INNER JOIN importX12.EDITypes t
			ON f.EDITypeId = t.EDITypeId
		INNER JOIN importX12.TagST st
			ON f.EDIFileId = st.EDIFileId
		INNER JOIN importX12.TagSE se
			ON se.EDIFileId = st.EDIFileId
				AND st.TransactionSetControlNumber = se.TransactionSetControlNumber
	WHERE f.Processed = 0