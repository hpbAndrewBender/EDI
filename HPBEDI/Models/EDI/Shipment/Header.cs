using System;
using System.Collections.Generic;
using System.Text;

namespace DataHPBEDI.Models.EDI.Shipment
{
	public class Header
	{
		/*
			SET IDENTITY_INSERT [EDI].[ShipmentHeader] ON
				INSERT INTO [EDI].[ShipmentHeader] ([ShipmentID], [PONumber], [ASNNo], [IssueDate], [VendorID], [ReferenceNo], [ShipToLoc], [ShipToSAN], [BillToLoc], [BillToSAN], [ShipFromLoc], [ShipFromSAN], [Carrier], [TotalLines], [TotalQuantity], [CurrencyCode], [InsertDateTime], [Processed], [ProcessedDateTime], [ASNACKSent], [ASNAckNo], [GSNo])
					SELECT	 [ShipID] AS [ShipmentID]			
							,CAST([PONumber] AS VARCHAR(10)) AS [PONumber]			
							,CAST([ASNNo] AS VARCHAR(20)) AS [ASNNo]			
							,[IssueDate]
							,CAST([VendorID] AS VARCHAR(20)) AS [VendorID]			
							,CAST([ReferenceNo] AS VARCHAR(20)) AS [ReferenceNo]			
							,CAST([ShipToLoc] AS VARCHAR(5)) AS [ShipToLoc]			
							,CAST([ShipToSAN] AS VARCHAR(12)) AS [ShipToSAN]			
							,CAST([BillToLoc] AS VARCHAR(5)) AS [BillToLoc]			
							,CAST([BillToSAN] AS VARCHAR(12)) AS [BillToSAN]			
							,CAST([ShipFromLoc] AS VARCHAR(5)) AS [ShipFromLoc]			
							,CAST([ShipFromSAN] AS VARCHAR(12)) AS [ShipFromSAN]			
							,CAST([Carrier] AS VARCHAR(20)) AS [Carrier]			
							,[TotalLines] AS [TotalLines]			
							,[TotalQty] AS [TotalQuantity]			
							,CAST([CurrencyCode] AS CHAR(3)) AS [CurrencyCode]			
							,[InsertDateTime] 
							,[Processed] 
							,CAST([ProcessedDateTime] AS DATETIME) AS [ProcessedDateTime]			
							,[ASNACKSent]			
							,CAST([ASNAckNo] AS VARCHAR(10)) AS [ASNAckNo]			
							,CAST([GSNo] AS VARCHAR(10)) AS [GSNo]			
					FROM [dbo].[856_ASN_HDR]
			SET IDENTITY_INSERT [EDI].[ShipmentHeader] OFF
			GO

			ALTER SCHEMA archiv TRANSFER [dbo].[856_ASN_HDR]
			GO

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
				FROM [EDI].[ShipmentHeader] 
			GO
		 */
		public int ShipmentID { get; set; }
		public string PONumber { get; set; }
		public string ASNNo { get; set; }
		public DateTime IssueDate { get; set; }
		public string VendorID { get; set; }
		public string ReferenceNo { get; set; }
		public string ShipToLoc { get; set; }
		public string ShipToSAN { get; set; }
		public string BillToLoc { get; set; }
		public string BillToSAN { get; set; }
		public string ShipFromLoc { get; set; }
		public string ShipFromSAN { get; set; }
		public string Carrier { get; set; }
		public int TotalLines { get; set; }
		public int TotalQuantity { get; set; }
		public string CurrencyCode { get; set; }
		public DateTime InsertDateTime { get; set; }
		public bool Processed { get; set; }
		public DateTime ProcessedDateTime { get; set; }
		public bool ASNACKSent { get; set; }
		public string ASNAckNo { get; set; }
		public string GSNo { get; set; }
	}
}
