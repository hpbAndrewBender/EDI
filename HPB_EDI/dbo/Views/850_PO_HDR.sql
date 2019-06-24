
CREATE VIEW [dbo].[850_PO_HDR]
		AS
			SELECT	 [OrderId] AS [OrdID]
					,CAST([PONumber] AS CHAR(6)) AS [PONumber]
					,[IssueDate]
					,CAST([VendorID] AS NVARCHAR(20)) AS [VendorID]
					,CAST([ShipToLoc] AS NCHAR(5)) AS [ShipToLoc]
					,CAST([ShipToSAN] AS NVARCHAR(12)) AS [ShipToSAN]
					,CAST([BillToLoc] AS NCHAR(5)) AS [BillToLoc]
					,CAST([BillToSAN] AS NVARCHAR(12)) AS [BillToSAN]
					,CAST([ShipFromLoc] AS NCHAR(5)) AS [ShipFromLoc]
					,CAST([ShipFromSAN] AS NVARCHAR(12)) AS [ShipFromSAN]
					,[TotalLines]
					,[TotalQuantity] AS [TotalQty]
					,[InsertDateTime]
					,[Processed]
					,[ProcessedDateTime]
			FROM BLK.PurchaseOrderHeader
