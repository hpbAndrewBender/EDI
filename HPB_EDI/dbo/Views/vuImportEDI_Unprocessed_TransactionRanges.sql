CREATE VIEW [vuImportEDI_Unprocessed_TransactionRanges]
AS
	SELECT t.EDIType, st.EDIFileId, st.TransactionSetControlNumber, st.LineNumber AS RangeStart, se.LineNumber AS RangeEnd, se.NumberOfIncludedSegments
	FROM importEDIFiles f
		INNER JOIN importEDITypes t
			ON f.EDITypeId = t.EDITypeId
		INNER JOIN importedi_st st
			ON f.EDIFileId = st.EDIFileId
		INNER JOIN importedi_se se
			ON se.EDIFileId = st.EDIFileId
				AND st.TransactionSetControlNumber = se.TransactionSetControlNumber
	WHERE f.Processed = 0