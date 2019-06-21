using System;
using System.Collections.Generic;
using System.Text;

namespace DataHPBEDI.Models.EDI.Invoice
{
	public class Header
	{
		/*
			SET IDENTITY_INSERT edi.InvoiceHeader ON
				INSERT INTO edi.InvoiceHeader ([InvoiceId], [PONumber], [InvoiceNo], [IssueDate], [VendorId], [ReferenceNo], [ShipToLoc], [ShipToSAN], [BillToLoc], [BillToSAN], [ShipFromLoc], [ShipFromSAN], [TotalLines], [TotalQuantity], [TotalPayable], [CurrencyCode], [InsertDateTime], [Processed], [ProcessedDateTime], [InvoiceACKSent], [InvoiceAckNo], [GSNo])
					SELECT	 CAST(InvoiceID AS INT) AS InvoiceID
							,CAST(PONumber AS VARCHAR(10)) AS PONumber
							,CAST(InvoiceNo AS VARCHAR(20)) AS InvoiceNo
							,CAST(IssueDate AS DATETIME) AS IssueDate
							,CAST(VendorID AS VARCHAR(20)) AS VendorID
							,CAST(ReferenceNo AS VARCHAR(20)) AS ReferenceNo
							,CAST(ShipToLoc AS VARCHAR(5)) AS ShipToLoc
							,CAST(ShipToSAN AS VARCHAR(12)) AS ShipToSAN
							,CAST(BillToLoc AS VARCHAR(5)) AS BillToLoc
							,CAST(BillToSAN AS VARCHAR(12)) AS BillToSAN
							,CAST(ShipFromLoc AS VARCHAR(5)) AS ShipFromLoc
							,CAST(ShipFromSAN AS VARCHAR(12)) AS ShipFromSAN
							,CAST(TotalLines AS SMALLINT) AS TotalLines
							,CAST(TotalQty AS INT) AS TotalQuantity
							,CAST(TotalPayable AS MONEY) AS TotalPayable
							,CAST(CurrencyCode AS VARCHAR(5)) AS CurrencyCode
							,CAST(InsertDateTime AS DATETIME) AS InsertDateTime
							,CAST(Processed AS BIT) AS Processed
							,CAST(ProcessedDateTime AS DATETIME) AS ProcessedDateTime
							,CAST(InvoiceACKSent AS VARCHAR(10)) as InvoiceAckSent
							,CAST(InvoiceAckNo AS VARCHAR(10)) AS InvoiceAckNo
 							,CAST(GSNo AS VARCHAR(10))
					FROM [810_Inv_Hdr]
			SET IDENTITY_INSERT edi.InvoiceHeader OFF
			GO

			ALTER SCHEMA archiv TRANSFER dbo.[810_INV_HDR]
			GO

			CREATE VIEW [810_INV_HDR]
			AS
			SELECT	 [InvoiceId] 
					,CAST([InvoiceNo] AS NVARCHAR(20)) AS [InvoiceNo]
					,CAST([IssueDate] AS DATETIME) AS [IssueDate]
					,CAST([VendorId] AS NVARCHAR(20)) [VendorID]
					,CAST([PONumber] AS NCHAR(6)) [PONumber]
					,CAST([ReferenceNo] AS NVARCHAR(20)) AS [ReferenceNo]
					,CAST([ShipToLoc] AS NVARCHAR(5)) AS [ShipToLoc]
					,CAST([ShipToSAN] AS NVARCHAR(12)) AS [ShipToSAN]
					,CAST([BillToLoc] AS NVARCHAR(5)) AS [BillToLoc]
					,CAST([BillToSAN] AS NVARCHAR(12)) AS [BillToSAN]
					,CAST([ShipFromLoc] AS NVARCHAR(5)) AS [ShipFromLoc]
					,CAST([ShipFromSAN] AS NVARCHAR(12)) AS [ShipFromSAN]
					,CAST([TotalLines] AS INT) AS [TotalLines]
					,[TotalQuantity] AS [TotalQty]
					,[TotalPayable] 
					,CAST([CurrencyCode] AS NVARCHAR(5)) AS [CurrencyCode]
					,[InsertDateTime]
					,[Processed]
					,[ProcessedDateTime]
					,[InvoiceACKSent]
					,CAST([InvoiceAckNo] AS NVARCHAR(10)) AS [InvoiceAckNo]
					,CAST([GSNo] AS NVARCHAR(10)) AS [GSNo]
			FROM edi.InvoiceHeader
			GO
		*/

		public string PONumber {get; set;}
		//-- public int InvoiceId {get; set;}
		public string InvoiceNo {get; set;}
		public DateTime IssueDate {get; set;}
		public string VendorId {get; set;}
		public string ReferenceNo {get; set;}
		public string ShipToLoc {get; set;}
		public string ShipToSAN {get; set;}
		public string BillToLoc {get; set;}
		public string BillToSAN {get; set;}
		public string ShipFromLoc {get; set;}
		public string ShipFromSAN {get; set;}
		public short TotalLines {get; set;}
		public int TotalQuantity {get; set;}
		public decimal TotalPayable {get; set;}
		public string CurrencyCode {get; set;}
		public DateTime InsertDateTime {get; set;}
		public bool  Processed {get; set;}
		public DateTime ProcessedDateTime {get; set;}
		public bool InvoiceACKSent {get; set;}
		public string InvoiceAckNo {get; set;}
		public string GSNo {get; set;}
	}
}
