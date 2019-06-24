namespace DataHPBEDI.Models.BLK.Invoice
{
	/*
		SET IDENTITY_INSERT edi.InvoiceDetail ON
			INSERT INTO edi.[InvoiceDetail]  (InvoiceItemId , [InvoiceId], [LineNo], [ItemIdCode], [ItemIdentifier], [ItemDesc], [InvoiceQty], [UnitPrice], [DiscountPrice], [DiscountCode], [DiscountPct], [RetailPrice])
				SELECT	 [ItemInvoiceID]
						,[InvoiceID]
						,CAST([LineNo] AS VARCHAR(10)) AS [LineNo]
						,CAST([ItemIDCode] AS VARCHAR(5)) AS [ItemIdCode]
						,CAST([ItemIdentifier] AS VARCHAR(20)) AS [ItemIdentifier]
						,CAST([ItemDesc] AS VARCHAR(250)) AS [ItemDesc]
						,CAST([InvoiceQty] AS INT) AS [InvoiceQty]
						,CAST([UnitPrice] AS MONEY) AS [UnitPrice]
						,CAST([DiscountPrice] AS MONEY) AS  [DiscountPrice]
						,CAST([DiscountCode] AS VARCHAR(10)) AS [DiscountCode]
						,CAST([DiscountPct] AS DECIMAL(4,2)) AS [DiscountPct] 
						,CAST([RetailPrice] AS MONEY) AS [RetailPrice]
				FROM dbo.[810_Inv_Dtl]
					inner join dbo.[810_Inv_Hdr] h 
						on d.InvoiceID = h.InvoiceID
		SET IDENTITY_INSERT edi.InvoiceDetail OFF
		GO

		ALTER SCHEMA archiv TRANSFER dbo.[810_Inv_Dtl]
		GO

		CREATE VIEW dbo.[810_INV_DTL]
		AS
			SELECT	 [AckId]
					,CAST([PONumber] AS CHAR(6)) AS [PONumber]
					,[IssueDate]
					,CAST([VendorId] AS NVARCHAR(20)) AS [VendorID]
					,CAST([ReferenceNo] AS NVARCHAR(20)) AS [ReferenceNo] 
					,CAST([ShipToLoc] AS NVARCHAR(5)) AS [ShipToLoc]
					,CAST([ShipToSAN] AS NVARCHAR(12))  AS [ShipToSAN]
					,CAST([BillToLoc] AS NVARCHAR(5))  AS [BillToLoc]
					,CAST([BillToSAN] AS NVARCHAR(12)) AS [BillToSAN]
					,CAST([ShipFromLoc] AS NVARCHAR(5))  AS [ShipFromLoc]
					,CAST([ShipFromSAN] AS NVARCHAR(12))  AS [ShipFromSAN]
					,CAST([TotalLines] AS INT) AS [TotalLines]
					,CAST([TotalQuantity] AS INT) AS [TotalQty]
					,CAST([CurrencyCode] AS NVARCHAR(5)) AS [CurrencyCode]
					,[InsertDateTime]
					,[Processed]			
					,[ProcessedDateTime]
					,[ResponseACKSent]
					,CAST([ResponseAckNo] AS NVARCHAR(10)) AS [ResponseAckNo]
					,CAST([GSNo] AS NVARCHAR(10)) AS [GSNo]
			FROM EDI.AcknowledgeHeader
		GO
	*/
	public class Detail
	{	
		public string LineNo { get; set; }
		public string ItemIdCode { get; set; }
		public string ItemIdentifier { get; set; }
		public string ItemDesc { get; set; }
		public int InvoiceQty { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal DiscountPrice { get; set; }
		public string DiscountCode { get; set; }
		public decimal DiscountPct { get; set; }
		public decimal RetailPrice { get; set; }
		public string ReferenceNumber { get; set; }

		public string ponumber { get; set; }
	}
}