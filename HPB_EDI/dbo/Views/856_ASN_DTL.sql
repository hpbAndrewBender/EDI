
	CREATE VIEW [dbo].[856_ASN_DTL]
			AS
				SELECT	 [ShipmentItemID] AS [ItemShipID]
						,[ShipmentID] AS [ShipID]
						,CAST([LineNo] AS NVARCHAR(10)) AS [LineNo]
						,CAST([ItemIdCode] AS NVARCHAR(50)) AS [ItemIDCode]
						,CAST([ItemIdentifier] AS NVARCHAR(20)) AS [ItemIdentifier]
						,CAST([ItemDesc] AS NVARCHAR(250)) AS [ItemDesc]
						,[QuantityShipped] AS [ShipQty]
						,CAST([PackageNo] AS NVARCHAR(30)) AS [PackageNo]
						,CAST([TrackingNo] AS NVARCHAR(30)) AS [TrackingNo]
				FROM BLK.ShipmentDetail