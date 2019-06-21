CREATE PROCEDURE [EDI].[uspAcknowledge_Insert]
(
	 @header AS EDI.TypeAcknowledgeHeader READONLY
	,@detail AS EDI.TypeAcknowledgeDetail READONLY
	,@ediver AS TINYINT
)
AS
BEGIN
	DECLARE	 @success BIT = 0
			,@message VARCHAR(2500)
	CREATE TABLE #inserted ( id INT,po VARCHAR(22))

	BEGIN TRANSACTION acknowledge_insert
	BEGIN TRY
		INSERT INTO edi.AcknowledgeHeader ([PONumber], [IssueDate], [VendorId], [ReferenceNo], [ShipToLoc], [ShipToSAN], [BillToLoc], [BillToSAN], [ShipFromLoc], [ShipFromSAN], [TotalLines], [TotalQuantity], [CurrencyCode], [InsertDateTime], [Processed], [ProcessedDateTime], [ResponseACKSent], [ResponseAckNo], [GSNo], [EDISourceTypeId] )
			OUTPUT inserted.AckId, inserted.ponumber INTO #inserted(id, po)
			SELECT [PONumber], [IssueDate], [VendorId], [ReferenceNo], [ShipToLoc], [ShipToSAN], [BillToLoc], [BillToSAN], [ShipFromLoc], [ShipFromSAN], [TotalLines], [TotalQuantity], [CurrencyCode], [InsertDateTime], [Processed], [ProcessedDateTime], [ResponseACKSent], [ResponseAckNo], [GSNo], @ediver
			FROM @header

		IF EXISTS(SELECT 1 FROM @detail d INNER JOIN #inserted i on d.[ponumber] = i.po)
			BEGIN
				-- must have both header and detail data to be a valid record
				INSERT INTO edi.AcknowledgeDetail ([AckId], [LineNo], [LineStatusCode], [ItemStatusCode], [UnitOfMeasure], [QuantityOrdered], [QuantityShipped], [QuantityCancelled], [QuantityBackordered], [UnitPrice], [PriceCode], [CurrencyCode], [ItemIdCode], [ItemIdentifier], [ItemDesc], [EDIFileID], [EDILineNumber])
					SELECT i.id, [LineNo], [LineStatusCode], [ItemStatusCode], [UnitOfMeasure], [QuantityOrdered], [QuantityShipped], [QuantityCancelled], [QuantityBackordered], [UnitPrice], [PriceCode], [CurrencyCode], [ItemIdCode], [ItemIdentifier], [ItemDesc], [EDIFileID], [EDILineNumber]
					FROM @detail d
						INNER JOIN #inserted i		
							 ON LTRIM(RTRIM(d.[PoNumber])) =  LTRIM(RTRIM(i.po))
					SET @success = 1
			END
		ELSE	
			BEGIN
				SELECT	 @success = 0
						,@message = 'Could not get detail data'		
			END
	END TRY
	BEGIN CATCH
		SELECT	 @success = 0
				,@message = CAST(ERROR_NUMBER() AS VARCHAR(10)) + ' ' + CAST(ERROR_LINE() AS VARCHAR(10)) + ' ' +  ERROR_MESSAGE()
	END CATCH

	IF @success = 1
		COMMIT TRANSACTION acknowledge_insert
	ELSE
		BEGIN
			ROLLBACK TRANSACTION acknowledge_insert
			INSERT INTO Logging.SQLMessages(ProcedureName, ErrorMessage) VALUES ('uspAcknowledge_Insert', @message)
		END
	SELECT @success AS [Successful]
END