using System;
using System.Collections.Generic;
using System.Text;

namespace DataHPBEDI.Models.EDI.Shipment
{
	public class Detail
	{
		/*
			BEGIN TRANSACTION
			SET IDENTITY_INSERT [EDI].[ShipmentDetail] ON
				INSERT INTO [EDI].[ShipmentDetail] ([ShipmentItemID], [ShipmentID], [LineNo], [ItemIdCode], [ItemIdentifier], [ItemDesc], [QuantityShipped], [PackageNo], [TrackingNo])
					SELECT	 [ItemShipID] AS [ShipmentItemID]
							,d.[ShipID] AS [ShipmentID]
							,CAST([LineNo] AS VARCHAR(10)) AS [LineNo]
							,CAST([ItemIDCode] AS VARCHAR(5)) AS [ItemIdCode]
							,CAST([ItemIdentifier] AS VARCHAR(20)) AS [ItemIdentifier]
							,CAST([ItemDesc] AS VARCHAR(250)) AS [ItemDesc]
							,[ShipQty] AS [QuantityShipped]
							,CAST([PackageNo] AS VARCHAR(30)) AS [PackageNo]
							,CAST([TrackingNo] AS VARCHAR(30))  AS [TrackingNo]
					FROM [dbo].[856_ASN_DTL] d
						INNER JOIN dbo.[856_ASN_Hdr] h
							ON d.ShipID = h.ShipID
			SET IDENTITY_INSERT [EDI].[ShipmentDetail] OFF
			-- COMMIT TRANSACTION

			GO
			
			ALTER SCHEMA archiv TRANSFER [dbo].[856_ASN_DTL]
			GO

			CREATE VIEW DBO.[856_ASN_DTL]
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
				FROM EDI.ShipmentDetail
			GO
		 */
		public long ShipmentItemID { get; set; }
		public int ShipmentID { get; set; }
		public string LineNo { get; set; }
		public string ItemIdCode { get; set; }
		public string ItemIdentifier { get; set; }
		public string ItemDesc { get; set; }
		public int QuantityShipped { get; set; }
		public string PackageNo { get; set; }
		public string TrackingNo { get; set; }
		public string ReferenceNumber { get; set; }

		public string ponumber { get; set; }
	}
}
