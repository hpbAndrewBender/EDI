using System;
using System.Collections.Generic;
using System.Text;

namespace DataHPBEDI.Models.EDI.Acknowledge
{
	/* sql changes:
	 
		SET IDENTITY_INSERT [EDI].[AcknowledgeHeader] ON
			INSERT INTO [EDI].[AcknowledgeHeader] ([AckId], [PONumber], [IssueDate], [VendorID], [ReferenceNo], [ShipToLoc], [ShipToSAN], [BillToLoc], [BillToSAN], [ShipFromLoc], [ShipFromSAN], [TotalLines], [TotalQuantity], [CurrencyCode], [InsertDateTime], [Processed], [ProcessedDateTime], [ResponseACKSent], [ResponseAckNo], [GSNo])
				SELECT	 [AckID]
						,CAST([PONumber] AS VARCHAR(10)) AS [PONumber]
						,CAST([IssueDate] AS DATETIME) AS [IssueDate]
						,CAST([VendorID] AS VARCHAR(20)) AS [VendorID]
						,CAST([ReferenceNo] AS VARCHAR(20))  AS [ReferenceNo]
						,CAST([ShipToLoc] AS VARCHAR(5)) AS [ShipToLoc]
						,CAST([ShipToSAN] AS VARCHAR(12)) AS [ShipToSAN]
						,CAST([BillToLoc] AS VARCHAR(5)) AS [BillToLoc]
						,CAST([BillToSAN] AS VARCHAR(12)) AS [BillToSAN]
						,CAST([ShipFromLoc] AS VARCHAR(5)) AS [ShipFromLoc]
						,CAST([ShipFromSAN] AS VARCHAR(12)) AS [ShipFromSAN]
						,CAST([TotalLines] AS  INT) AS [TotalLines]
						,CAST([TotalQty] AS INT) AS [TotalQuantity]
						,CAST([CurrencyCode]  AS VARCHAR(5)) AS [CurrencyCode]
						,CAST([InsertDateTime] AS DATETIME) AS [InsertDateTime]
						,CAST([Processed] AS BIT) AS [Processed]
						,CAST([ProcessedDateTime] AS DATETIME) AS [ProcessedDateTime]
						,CAST([ResponseACKSent] AS BIT) AS [ResponseACKSent]
						,CAST([ResponseAckNo] AS VARCHAR(10)) AS [ResponseAckNo]
						,CAST([GSNo] AS VARCHAR(10)) AS [GSNo]
				FROM [855_Ack_Hdr]
		SET IDENTITY_INSERT [EDI].[AcknowledgeHeader] OFF
		GO

		ALTER SCHEMA archiv TRANSFER dbo.[855_Ack_Hdr]
		GO

		CREATE VIEW dbo.[855_ACK_HDR]
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
	public class Header
	{
		 	public int AckId {get; set;}
			public string PONumber {get; set;}
			public DateTime IssueDate {get; set;}
			public string VendorID {get; set;}
			public string ReferenceNo {get; set;}
			public string ShipToLoc {get; set;}
			public string ShipToSAN {get; set;}
			public string BillToLoc {get; set;}
			public string BillToSAN {get; set;}
			public string ShipFromLoc {get; set;}
			public string ShipFromSAN {get; set;}
			public int TotalLines {get; set;}
			public int TotalQuantity {get; set;}
			public string CurrencyCode {get; set;}
			public DateTime InsertDateTime {get; set;}
			public bool  Processed {get; set;}
			public DateTime ProcessedDateTime {get; set;}
			public bool  ResponseACKSent {get; set;}
			public string ResponseAckNo {get; set;}
			public string GSNo {get; set;}
			public byte EdiSourceTypeID { get; set; }
			public string VendorMessage { get; set; }
	}
}
