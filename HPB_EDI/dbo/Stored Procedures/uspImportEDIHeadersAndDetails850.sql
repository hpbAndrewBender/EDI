CREATE PROCEDURE [dbo].[uspImportEDIHeadersAndDetails850]
AS
BEGIN
	DECLARE @EDINumber VARCHAR(3) = '850'

	DECLARE @Inserted TABLE (
								 IID INT
								,PurchaseOrderNumber VARCHAR(15)
								,InvoiceNumber VARCHAR(15)
							)


	DECLARE @AppCodes TABLE (
								 EDIFileID INT
								,DTM VARCHAR(10)
								,SC VARCHAR(50)
								,RC VARCHAR(50)
								,ICN VARCHAR(50)
								,VER VARCHAR(25)
							)

	INSERT INTO @AppCodes(EDIFileID, DTM, SC, RC, ICN, VER)
		SELECT ranges.EDIFileId, gs.[Date], gs.ApplicationSenderCode, gs.ApplicationReceiverCode, isa.InterchangeControlNumber, gs.VersionRelIndIDCode
		from (	SELECT DISTINCT EDIFileId
				FROM  vuImportEDI_Unprocessed_TransactionRanges
				WHERE EDIType = @EDINumber) ranges
			INNER JOIN importx12.TagISA isa
				ON isa.EDIFileId = ranges.EDIFileId
			INNER JOIN importx12.TagGS gs
				ON gs.EDIFileId = ranges.EDIFileId


	INSERT INTO [temp_850_PO_Hdr] (PONumber,IssueDate,VendorID,ShipToLoc,ShipToSAN,BillToLoc,BillToSAN,ShipFromLoc,ShipFromSAN,TotalLines,TotalQty,InsertDateTime,Processed,ProcessedDateTime)
	OUTPUT INSERTED.OrdID, INSERTED.PONumber INTO @Inserted (IID, PurchaseOrderNumber) 
		SELECT	 NULL AS PONumber
				,NULL AS IssueDate
				,NULL AS VendorID
				,NULL AS ShipToLoc
				,NULL AS ShipToSAN
				,NULL AS BillToLoc
				,NULL AS BillToSAN
				,NULL AS ShipFromLoc
				,NULL AS ShipFromSAN
				,NULL AS TotalLines
				,NULL AS TotalQty
				,NULL AS InsertDateTime
				,NULL AS Processed
				,NULL AS ProcessedDateTime
		FROM vuImportEDI_Unprocessed_TransactionRanges ranges
			INNER JOIN @AppCodes ac
				ON ranges.EDIFileId = ac.EDIFileID
			INNER JOIN Vendor_SAN_Codes vsc
				ON ac.SC=vsc.SanCode				
		WHERE ranges.EDIType = @EDINumber

	INSERT INTO [temp_850_PO_Dtl] (ItemOrdID,OrdID,[LineNo],Qty,UOM,UnitPrice,PriceCode,ItemIDCode,ItemIdentifier,ItemFillTerms,XActionCode,FillAmount)
		SELECT   ii.IID AS ItemOrderID
				,NULL AS OrdID
				,NULL AS [LineNo]
				,NULL AS Qty
				,NULL AS UOM
				,NULL AS UnitPrice
				,NULL AS PriceCode
				,NULL AS ItemIDCode
				,NULL AS ItemIdentifier
				,NULL AS ItemFillTerms
				,NULL AS XActionCode
				,NULL AS FillAmount
			FROM vuImportEDI_Unprocessed_TransactionRanges ranges
				INNER JOIN @AppCodes ac
					ON ranges.EDIFileId = ac.EDIFileID
				INNER JOIN [importx12].[TagBIG] big
					ON ranges.EDIFileID = big.EDIFileId
						AND ranges.TransactionSetControlNumber = big.ControlNumberTransaction
				INNER JOIN @Inserted ii
					ON ii.PurchaseOrderNumber = big.PurchaseOrderNumber
						AND ii.[InvoiceNumber]=big.[InvoiceNumber]
				INNER JOIN Vendor_SAN_Codes vsc
					ON ac.SC=vsc.SanCode
				INNER JOIN [importx12].[TagBEG] beg
					ON beg.EDIfileID = ranges.EDIFileID
END