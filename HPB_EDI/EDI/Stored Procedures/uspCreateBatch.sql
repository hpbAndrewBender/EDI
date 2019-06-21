CREATE PROCEDURE EDI.uspCreateBatch
(
	 @file VARCHAR(255)
	,@vend VARCHAR(20)
	,@type TINYINT
)
AS
BEGIN
	DECLARE  @Message VARCHAR(2500)	
			,@Success BIT = 0
	DECLARE @Inserted TABLE ( Id INT, BatchItemID TINYINT, VendorID VARCHAR(20))

	BEGIN TRANSACTION insert_batch
	BEGIN TRY
		INSERT INTO ImportBBV3.Batch(batchitemid, VendorID, [Filename])
			OUTPUT inserted.Id, inserted.BatchItemId, inserted.VendorID INTO @Inserted (id, BatchItemID, VendorID)
			VALUES (@type, @vend,@file)
			SET @Success = 1
	END TRY
	BEGIN CATCH
		SELECT	 @Success = 0
				,@Message = CAST(ERROR_NUMBER() AS VARCHAR(50))  + ' ' + CAST(ERROR_LINE() AS VARCHAR(50)) + ' ' + CAST(ERROR_MESSAGE() AS VARCHAR(2500))
	END CATCH

	IF @Success = 1
		BEGIN
			COMMIT TRANSACTION insert_batch

			SELECT id from @Inserted
		END
	ELSE
		BEGIN
			ROLLBACK TRANSACTION insert_batch
			INSERT INTO Logging.SQLMessages (ProcedureName, ErrorMessage)
				VALUES ('EDI.uspCreateBatch', @Message)
			SELECT -1 AS id
		END
END