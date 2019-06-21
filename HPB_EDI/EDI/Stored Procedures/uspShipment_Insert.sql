
CREATE PROCEDURE [EDI].[uspShipment_Insert]
(
	 @header AS EDI.TypeShipmentHeader READONLY
	,@detail AS EDI.TypeShipmentDetail READONLY
	,@ediver AS TINYINT
)
AS
BEGIN
	DECLARE  @success BIT = 0
			,@message  VARCHAR(2500)
	CREATE TABLE #inserted (id INT,po VARCHAR(22))

	BEGIN TRANSACTION shipment_insert
	BEGIN TRY
		INSERT INTO edi.ShipmentHeader ([PONumber], [ASNNo], [IssueDate], [VendorID], [ReferenceNo], [ShipToLoc], [ShipToSAN], [BillToLoc], [BillToSAN], [ShipFromLoc], [ShipFromSAN], [Carrier], [TotalLines], [TotalQuantity], [CurrencyCode], [InsertDateTime], [Processed], [ProcessedDateTime], [ASNACKSent], [ASNAckNo], [GSNo], [EDISourceTypeId])
			OUTPUT inserted.ShipmentID, inserted.ponumber into #inserted(id, po)
			SELECT [PONumber], [ASNNo], [IssueDate], [VendorID], [ReferenceNo], [ShipToLoc], [ShipToSAN], [BillToLoc], [BillToSAN], [ShipFromLoc], [ShipFromSAN], [Carrier], [TotalLines], [TotalQuantity], [CurrencyCode], [InsertDateTime], [Processed], [ProcessedDateTime], [ASNACKSent], [ASNAckNo], [GSNo], @ediver
			FROM @header

		IF EXISTS(SELECT 1 FROM @detail d INNER JOIN #inserted i ON d.[ponumber] = i.po)
			BEGIN
				-- must have both header and detail data to be a valid record
				INSERT INTO edi.ShipmentDetail ([ShipmentID], [LineNo], [ItemIdCode], [ItemIdentifier], [ItemDesc], [QuantityShipped], [PackageNo], [TrackingNo])
					SELECT i.id, [LineNo], [ItemIdCode], [ItemIdentifier], [ItemDesc], [QuantityShipped], [PackageNo], [TrackingNo]
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
		COMMIT TRANSACTION shipment_insert
	ELSE
		BEGIN
			ROLLBACK TRANSACTION invoice_insert
			INSERT INTO Logging.SQLMessages(ProcedureName, ErrorMessage ) VALUES ('uspShipment_Insert', @message)
		END

	SELECT @success AS [Successful]
END