﻿
				CREATE VIEW [dbo].[850_PO_DTL]
			AS
				SELECT	 [OrderItemId] AS [ItemOrdID]
						,[OrderId] AS [OrdID]
						,CAST([LineNo] AS NVARCHAR(10)) AS [LineNo]
						,[Quantity] AS [Qty]
						,CAST([UnitOfMeasure] AS NCHAR(3)) AS [UOM]
						,CAST([UnitPrice] AS NVARCHAR(10)) AS [UnitPrice]
						,CAST([PriceCode] AS NVARCHAR(10)) AS [PriceCode]
						,CAST([ItemIDCode] AS NVARCHAR(5)) AS [ItemIDCode]
						,CAST([ItemIdentifier] AS NVARCHAR(20)) AS [ItemIdentifier]
						,CAST([ItemFillTerms] AS NVARCHAR(30)) AS [ItemFillTerms]
						,CAST([XActionCode] AS NVARCHAR(10)) AS [XActionCode]
						,CAST([FillAmount] AS NVARCHAR(10)) AS [FillAmount]
				FROM BLK.PurchaseOrderDetail
