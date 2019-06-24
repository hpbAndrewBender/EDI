CREATE PROCEDURE [dbo].[uspImportEDISummary]
(
	 @EDITypeId TINYINT
	,@EDIFileId INT
	,@TransCode VARCHAR(10)
	,@LineCount INT
)
AS
BEGIN
	DECLARE @TransCodeId INT

	SELECT @TransCodeId = EDITransactionCodeId
	FROM importx12.EDITransactionCodes tc
	WHERE tc.EDITransactionCode = @TransCode
		AND EDITypeId = @EDITypeId

	BEGIN TRANSACTION
	BEGIN TRY
		INSERT INTO importx12.EDISummary (EDIFileId, EDITransactionCodeId, LineCount)
			VALUES (@EDIFileId, @TransCodeId, @LineCount)
		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
END
