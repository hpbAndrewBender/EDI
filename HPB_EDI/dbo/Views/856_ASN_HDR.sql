﻿
	CREATE VIEW [dbo].[856_ASN_HDR]
			AS
				SELECT	 [ShipmentID] AS [ShipID]
						,CAST([PONumber] AS CHAR(6)) AS [PONumber]
						,CAST([ASNNo] AS NVARCHAR(20)) AS [ASNNo]
						,[IssueDate]
						,CAST([VendorID] AS NVARCHAR(20)) AS [VendorID]
						,CAST([ReferenceNo] AS NVARCHAR(20)) AS [ReferenceNo]
						,CAST([ShipToLoc] AS NCHAR(5)) AS [ShipToLoc]
						,CAST([ShipToSAN] AS NVARCHAR(12)) AS [ShipToSAN]
						,CAST([BillToLoc] AS NCHAR(5)) AS [BillToLoc]
						,CAST([BillToSAN] AS NVARCHAR(12)) AS [BillToSAN]
						,CAST([ShipFromLoc] AS NCHAR(5)) AS [ShipFromLoc]
						,CAST([ShipFromSAN] AS NVARCHAR(12)) AS [ShipFromSAN]
						,CAST([Carrier] AS NVARCHAR(20)) AS [Carrier]
						,[TotalLines]
						,[TotalQuantity] AS [TotalQty]
						,CAST([CurrencyCode] AS NVARCHAR(5)) AS [CurrencyCode]
						,[InsertDateTime]
						,[Processed]
						,[ProcessedDateTime]
						,[ASNACKSent]
						,CAST([ASNAckNo] AS NVARCHAR(10)) AS [ASNAckNo]
						,CAST([GSNo] AS NVARCHAR(10)) AS [GSNo]
				FROM [BLK].[ShipmentHeader] 
