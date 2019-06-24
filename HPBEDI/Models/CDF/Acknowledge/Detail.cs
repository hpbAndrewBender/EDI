using System;
using System.Collections.Generic;
using System.Text;

namespace DataHPBEDI.Models.CDF.Acknowledge
{
	/*
	 SET IDENTITY_INSERT [EDI].[AcknowledgeDetail] ON
		INSERT INTO [EDI].[AcknowledgeDetail] ([AckItemId], [AckId], [LineNo], [LineStatusCode], [ItemStatusCode], [UnitOfMeasure], [QuantityOrdered], [QuantityShipped], [QuantityCancelled], [QuantityBackordered], [UnitPrice], [PriceCode], [CurrencyCode], [ItemIdCode], [ItemIdentifier], [ItemDesc], [EDIFileID], [EDILineNumber])
			SELECT	 [ItemAckID] AS [AckItemId]
					,d.[AckID] AS [AckID]			
					,CAST([LineNo] AS VARCHAR(10)) AS [LineNo]			
					,CAST([LineStatusCode] AS VARCHAR(10)) AS [LineStatusCode]
					,CAST([ItemStatusCode] AS VARCHAR(10)) AS [ItemStatusCode]
					,CAST([UOM] AS CHAR(3)) AS [UnitOfMeasure]				
					,CAST([OrdQty] AS INT) AS [QuantityOrdered]			
					,CAST([ShipQty] AS INT) AS [QuantityShipped]
					,CAST([CanceledQty] AS INT) AS [QuantityCancelled]		
					,CAST([BackOrdQty] AS INT) AS [QuantityBackOrdered]
					,CAST([UnitPrice] AS MONEY) AS [UnitPrice]
					,CAST([PriceCode] AS VARCHAR(10)) AS [PriceCode]
					,CAST(d.[CurrencyCode] AS VARCHAR(5)) AS [CurrencyCode]		
					,CAST([ItemIDCode] AS VARCHAR(5)) AS [ItemIdCode]
					,CAST([ItemIdentifier] AS VARCHAR(20)) AS [ItemIdentifier]
					,CAST([ItemDesc] AS VARCHAR(250)) AS [ItemDesc]
					,CAST([EDIFileID] AS INT) AS [EDIFileID]
					,CAST([EDILineNumber] AS INT) AS [EDILineNumber]
			FROM [dbo].[855_Ack_Dtl] d
				inner join dbo.[855_Ack_Hdr] h 
					on d.AckID = h.AckID
	SET IDENTITY_INSERT [EDI].[AcknowledgeDetail] OFF
	GO

	ALTER SCHEMA archiv TRANSFER dbo.[855_Ack_Dtl]
	GO

	CREATE VIEW dbo.[855_ACK_DTL]
	AS 
		SELECT	 [AckItemId] AS [ItemAckID]
				,[AckId]
				,CAST([LineNo] AS NVARCHAR(10)) AS [LineNo]
				,CAST([LineStatusCode] AS NVARCHAR(10)) AS [LineStatusCode]
				,CAST([ItemStatusCode] AS NVARCHAR(10)) AS [ItemStatusCode]
				,CAST([UnitOfMeasure] AS NVARCHAR(3)) AS [UOM]
				,CAST([QuantityOrdered] AS INT) AS [OrdQty]
				,CAST([QuantityShipped] AS INT) AS [ShipQty]
				,CAST([QuantityCancelled] AS INT) AS [CanceledQty]	
				,CAST([QuantityBackordered] AS INT) AS [BackOrdQty]
				,CAST([UnitPrice] AS NVARCHAR(10)) AS [UnitPrice]
				,CAST([PriceCode] AS NVARCHAR(10)) AS [PriceCode]
				,CAST([CurrencyCode] AS NVARCHAR(5)) AS [CurrencyCode]
				,CAST([ItemIdCode] AS NVARCHAR(5)) AS [ItemIdCode]
				,CAST([ItemIdentifier] AS NVARCHAR(20)) AS [ItemIdentifier]
				,CAST([ItemDesc] AS NVARCHAR(250)) AS [ItemDesc]
				,CAST([EDIFileID] AS INT) AS [EDIFileID]
				,CAST([EDILineNumber] AS INT) AS [EDILineNumber]
		FROM [EDI].[AcknowledgeDetail] 
	GO
	*/
	public class Detail
	{
		public int AckItemId {get; set; }
		public int AckId {get; set; }
		public string LineNo { get; set; }
		public string LineStatusCode {get; set; }
		public string ItemStatusCode {get; set; }
		public string UnitOfMeasure {get; set; }
		public int QuantityOrdered {get; set; }
		public int QuantityShipped {get; set; }
		public int QuantityCancelled {get; set; }
		public int QuantityBackordered {get; set; }
		public decimal UnitPrice {get; set; }
		public string PriceCode {get; set; }
		public string CurrencyCode {get; set; }
		public string ItemIdCode {get; set; }
		public string ItemIdentifier {get; set; }
		public string ItemDesc {get; set; }
		public int EDIFileID {get; set; }
		public int EDILineNumber {get; set; }
		public string ReferenceNumber { get; set; }
		public string VendorStatus { get; set; }
		public string ponumber { get; set; }
	}
}
