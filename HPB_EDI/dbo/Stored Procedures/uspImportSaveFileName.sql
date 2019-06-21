CREATE PROCEDURE [dbo].[uspImportSaveFileName]
(
	@EdiType SMALLINT,
	@FileName VARCHAR(1024),
	@UTCDateTime DATETIME
)
AS
BEGIN
	DECLARE @Inserted TABLE (FileID SMALLINT)
	DECLARE @FileID INT = -1

	BEGIN TRANSACTION

	BEGIN TRY
		INSERT INTO dbo.importEDIFiles(EDITypeId,FullFileName, ImportDate)
			OUTPUT inserted.EDIFileId into @Inserted (FileID)
		VALUES (@EdiType, @FileName, @UTCDateTime)		
		COMMIT TRANSACTION
	END TRY

	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH

	IF((SELECT COUNT(1) FROM @Inserted) = 1)
		BEGIN
			SELECT FileID 
			FROM @Inserted
		END
	ELSE
		SELECT -2
END