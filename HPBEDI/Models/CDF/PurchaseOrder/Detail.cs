namespace DataHPBEDI.Models.CDF.PurchaseOrder
{
	public class Detail
	{
		/*
			SET IDENTITY_INSERT edi.[PurchaseOrderDetail] ON
				INSERT INTO edi.[PurchaseOrderDetail] ([OrderItemId], [OrderId], [LineNo], [Quantity], [UnitOfMeasure], [UnitPrice], [PriceCode], [ItemIDCode], [ItemIdentifier], [ItemFillTerms], [XActionCode], [FillAmount])
					SELECT	 [ItemOrdID] AS [OrderItemId]				
							,d.[OrdID] AS [OrderId]						
							,CAST([LineNo] AS VARCHAR(10)) AS [LineNo]						
							,[Qty] AS [Quantity]						
							,CAST([UOM] AS CHAR(3)) AS [UnitOfMeasure]					
							,CAST([UnitPrice] AS MONEY) AS [UnitPrice]				
							,CAST([PriceCode] AS VARCHAR(10)) AS [PriceCode]				
							,CAST([ItemIDCode] AS VARCHAR(5)) AS [ItemIdCode]				
							,CAST([ItemIdentifier] AS VARCHAR(20)) AS [ItemIdentifier]		
							,CAST([ItemFillTerms] AS VARCHAR(30)) AS [ItemFillTerms]		
							,CAST([XActionCode] AS VARCHAR(10)) AS [XActionCode]			
							,CAST([FillAmount] AS VARCHAR(10)) AS [FillAmount]				
					FROM DBO.[850_PO_DTL] d
						INNER JOIN [850_PO_HDR] h
							ON d.OrdId = h.OrdID
			SET IDENTITY_INSERT edi.[PurchaseOrderDetail] OFF
			GO

			ALTER SCHEMA archiv TRANSFER DBO.[850_PO_DTL]	
			GO

			CREATE VIEW DBO.[850_PO_DTL]
			AS
				SELECT	 [OrderItemId] AS [ItemOrdID]
						,[OrderId] AS [OrdID]
						,[LineNo] AS NVARCHAR(10)) AS [LineNo]
						,[Quantity] AS [Qty]
						,CAST([UnitOfMeasure] AS NCHAR(3)) AS [UOM]
						,CAST([UnitPrice] AS NVARCHAR(10)) AS [UnitPrice]
						,CAST([PriceCode] AS NVARCHAR(10)) AS [PriceCode]
						,CAST([ItemIDCode] AS NVARCHAR(5)) AS [ItemIDCode]
						,CAST([ItemIdentifier] AS NVARCHAR(20)) AS [ItemIdentifier]
						,CAST([ItemFillTerms] AS NVARCHAR(30)) AS [ItemFillTerms]
						,CAST([XActionCode] AS NVARCHAR(10)) AS [XActionCode]
						,CAST([FillAmount] AS NVARCHAR(10)) AS [FillAmount]
				FROM edi.[PurchaseOrderDetail] 
			GO
		*/
		public long OrderItemId { get; set; }
		public int OrderId { get; set; }
		public string LineNo { get; set; }
		public short  Quantity { get; set; }
		public string UnitOfMeasure { get; set; }
		public decimal UnitPrice { get; set; }
		public string PriceCode { get; set; }
		public string ItemIDCode { get; set; }
		public string ItemIdentifier { get; set; }
		public string ItemFillTerms { get; set; }
		public string XActionCode { get; set; }
		public string FillAmount { get; set; }

		public string ponumber { get; set; }
	}
}
 