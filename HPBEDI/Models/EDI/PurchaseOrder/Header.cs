using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataHPBEDI.Models.EDI.PurchaseOrder
{
	public class Header
	{
		/*
			SET IDENTITY_INSERT EDI.PurchaseOrderHeader ON
				INSERT INTO EDI.PurchaseOrderHeader ([OrderId], [PONumber], [IssueDate], [VendorID], [ShipToLoc], [ShipToSAN], [BillToLoc], [BillToSAN], [ShipFromLoc], [ShipFromSAN], [TotalLines], [TotalQuantity], [InsertDateTime], [Processed], [ProcessedDateTime])
					SELECT 	 [OrdID]	AS	[OrderId]	
							,CAST([PONumber] AS	VARCHAR(10)) AS [PONumber]	
							,[IssueDate]	
							,CAST([VendorID] AS VARCHAR(20)) AS [VendorID]	
							,CAST([ShipToLoc] AS VARCHAR(05)) AS [ShipToLoc]	
							,CAST([ShipToSAN] AS VARCHAR(12)) AS [ShipToSAN]	
							,CAST([BillToLoc] AS VARCHAR(05)) AS [BillToLoc]	
							,CAST([BillToSAN] AS VARCHAR(12)) AS [BillToSAN]	
							,CAST([ShipFromLoc] AS VARCHAR(05)) AS [ShipFromLoc]	
							,CAST([ShipFromSAN] AS VARCHAR(12)) AS [ShipFromSAN]	
							,[TotalLines]	
							,[TotalQty] AS [TotalQuantity]	
							,[InsertDateTime]	
							,[Processed]	
							,[ProcessedDateTime]	
					FROM [850_PO_Hdr]
			SET IDENTITY_INSERT EDI.PurchaseOrderHeader OFF
			GO

			ALTER SCHEMA archiv	TRANSFER dbo.[850_PO_HDR]
			GO

			CREATE VIEW dbo.[850_PO_HDR]
			AS
				SELECT	 [OrderId] AS ORDID
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
				FROM EDI.PurchaseOrderHeader
			GO
		*/
		public int OrderId { get; set; }
		public string PONumber { get; set; }
		public DateTime IssueDate { get; set; }
		public string VendorID { get; set; }
		public string ShipToLoc { get; set; }
		public string ShipToSAN { get; set; }
		public string BillToLoc { get; set; }
		public string BillToSAN { get; set; }
		public string ShipFromLoc { get; set; }
		public string ShipFromSAN { get; set; }
		public int TotalLines { get; set; }
		public int TotalQuantity { get; set; }
		public DateTime InsertDateTime { get; set; }
		public bool Processed { get; set; }
		public DateTime ProcessedDateTime { get; set; }

		public static implicit operator Header(EnumerableRowCollection<Header> v)
		{
			throw new NotImplementedException();
		}
	}
}
