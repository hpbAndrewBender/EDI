CREATE PROCEDURE edi.[uspPurchaseOrder_Retrieve] 
(
	@ponumber VARCHAR(10)
)
AS
BEGIN
	SELECT	 [OrderId]
			,[PONumber]
			,[IssueDate]
			,[VendorID]
			,[ShipToLoc]
			,[ShipToSAN]
			,[BillToLoc]
			,[BillToSAN]
			,[ShipFromLoc]
			,[ShipFromSAN]
			,[TotalLines]
			,[TotalQuantity]
			,[InsertDateTime]
			,[Processed]
			,[ProcessedDateTime]
	FROM edi.PurchaseOrderHeader
	WHERE PONumber = @ponumber


	SELECT	 d.[OrderItemId]
			,d.[OrderId]
			,d.[LineNo]
			,d.[Quantity]
			,d.[UnitOfMeasure]
			,d.[UnitPrice]
			,d.[PriceCode]
			,d.[ItemIdCode]
			,d.[ItemIdentifier]
			,d.[ItemFillTerms]
			,d.[XActionCode]
			,d.[FillAmount]
	FROM edi.PurchaseOrderDetail d
		INNER JOIN edi.PurchaseOrderHeader h
			ON d.OrderId = h.OrderId
	WHERE h.PONumber = @ponumber
END