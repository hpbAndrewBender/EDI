using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model = DataHPBEDI.Models.BLK;
using Direct = DataHPBEDI.Models.CDF;

namespace VendorIngramContent.Logic.ShipNotice
{
	public class Retrieve : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public List<(Model.Shipment.Header header, List<Model.Shipment.Detail> details)> BBV3(string fullpathandname, string vendor)
		{
			Model.Shipment.Header header = null;
			List<Model.Shipment.Detail> details = new List<Model.Shipment.Detail>();
			Model.Shipment.Detail detail = null;
			FormatBBV3.Models.Files.ShipNotice.DataSequence.V3 shpBBV3 = new FormatBBV3.Models.Files.ShipNotice.DataSequence.V3();
			List<(Model.Shipment.Header header, List<Model.Shipment.Detail> details)> shipments = new List<(Model.Shipment.Header header, List<Model.Shipment.Detail> details)>();
			List<(string po , string reference, int quant)> quantity = new List<(string, string, int)>();

			try
			{
				using (FormatBBV3.Logic.Data.ShipNotice.Files bbvSHP = new FormatBBV3.Logic.Data.ShipNotice.Files())
				{
					shpBBV3 = bbvSHP.ReadFile(fullpathandname, bbvSHP.CreateBatch(fullpathandname, vendor));
				}
				var items = (from item in shpBBV3.Shipments
							 select item).ToList();
				var shipPOs = (from ship in items
							 select ship.ShipmentRecord.PONumber).Distinct().ToList();
				for (int shipcounter = 0; shipcounter < shipPOs.Count; shipcounter++)
				{
					details = new List<Model.Shipment.Detail>();
					header = new Model.Shipment.Header
					{
						// ShipmentID = ,
						ASNAckNo = string.Empty,
						ASNACKSent = false,
						ASNNo = string.Empty,
						BillToLoc = string.Empty,
						BillToSAN = string.Empty,
						Carrier = shpBBV3.PackRecord.SCAC,
						CurrencyCode = "USD",
						GSNo = string.Empty,
						InsertDateTime = DateTime.UtcNow,
						IssueDate = shpBBV3.PackRecord.ShipmentDate ,
						PONumber = shipPOs[shipcounter],
						Processed = false,
						ProcessedDateTime = default(DateTime),
						ReferenceNo = "",
						ShipFromLoc = shpBBV3.PackRecord.ShippingDCCode,
						ShipFromSAN = string.Empty,
						ShipToLoc = string.Empty,
						ShipToSAN = string.Empty,
						TotalLines = -1,
						TotalQuantity = -1,
						VendorID = vendor,
					};
					FormatBBV3.Models.Files.ShipNotice.OR_ASNShipment shipmentrecord = (from f in items where f.ShipmentRecord.PONumber == shipPOs[shipcounter] select f.ShipmentRecord).FirstOrDefault();
					foreach(FormatBBV3.Models.Files.ShipNotice.OD_ASNShipmentDetail singleitem in items[shipcounter].LineItemDetailRecords)
					{
						detail = new Model.Shipment.Detail
						{
							// ShipmentID = ,
							// ShipmentItemID = ,
							ItemDesc = "",
							// ItemIdCode = ,
							ItemIdentifier = singleitem.ISBN13OrEAN,
							//LineNo =  ++.PadLeft(10,'0')
							PackageNo = shipmentrecord.IngramOrderEntryNumber,
							QuantityShipped = singleitem.QuantityShipped,
							TrackingNo =  shipmentrecord.PONumber,
							ReferenceNumber = singleitem.LineItemIDNumber,
							ponumber = shipPOs[shipcounter],
						};
						quantity.Add((shipPOs[shipcounter], shipmentrecord.IngramOrderEntryNumber, singleitem.QuantityShipped));
						details.Add(detail);
					}
					var poquantity = (from f in quantity where f.po == shipPOs[shipcounter] select f.quant);
					header.TotalQuantity = poquantity.Sum();
					header.TotalLines = poquantity.Count();
					header.ReferenceNo = (from f in quantity where f.po == shipPOs[shipcounter] select f.reference).FirstOrDefault();
					shipments.Add((header, details));

				}




				//--for (int shipcount = 0; shipcount < shpBBV3.Shipments.Count; shipcount++)
				//--{
				//--	details = new List<DataHPBEDI.Models.Shipment.Detail>();
				//--
				//--	header = new DataHPBEDI.Models.Shipment.Header
				//--	{
				//--		// ShipmentID = ,
				//--		// ASNAckNo = ,
				//--		// ASNACKSent = ,
				//--		// ASNNo = ,
				//--		BillToLoc = "",
				//--		BillToSAN = "",
				//--		Carrier = shpBBV3.PackRecord.SCAC,
				//--		CurrencyCode = "",
				//--		// GSNo = ,
				//--		InsertDateTime = DateTime.UtcNow,
				//--		IssueDate = shpBBV3.PackRecord.ShipmentDate,
				//--		PONumber = shpBBV3.Shipments[shipcount].ShipmentRecord.PONumber ,
				//--		Processed = false,
				//--		// ProcessedDateTime = 
				//--		ReferenceNo = shpBBV3.Shipments[shipcount].ShipmentRecord.IngramOrderEntryNumber,
				//--		ShipFromLoc = shpBBV3.PackRecord.ShippingDCCode,
				//--		ShipFromSAN = shpBBV3.FileHeaderRecord.IngramShipToAccountNumber,
				//--		ShipToLoc = "",
				//--		ShipToSAN = "",
				//--		TotalLines = 0 ,
				//--		TotalQuantity = 0,
				//--		VendorID = vendor
				//--	};
				//--	
				//--	for (int detailcount = 0; detailcount < shpBBV3.Shipments[shipcount].LineItemDetailRecords.Count; detailcount++)
				//--	{
				//--		detail = new DataHPBEDI.Models.Shipment.Detail
				//--		{
				//--			ItemDesc = "",
				//--			// ItemIdCode = ,
				//--			ItemIdentifier = shpBBV3.Shipments[shipcount].LineItemDetailRecords[detailcount].ISBN13OrEAN,
				//--			// LineNo =  , // .Trim().PadLeft(10,'0')
				//--			PackageNo = "",
				//--			QuantityShipped = shpBBV3.Shipments[shipcount].LineItemDetailRecords[detailcount].QuantityShipped ,
				//--			// ShipmentID = ,
				//--			// ShipmentItemID = ,
				//--			TrackingNo = shpBBV3.Shipments[shipcount].ShipmentRecord.ShipmentRecordIdentifier,		
				//--			ReferenceNumber = shpBBV3.Shipments[shipcount].LineItemDetailRecords[detailcount].LineItemIDNumber,
				//--			ponumber = shpBBV3.Shipments[shipcount].ShipmentRecord.PONumber,
				//--		};
				//--
				//--		if (detail != null)
				//--		{
				//--			details.Add(detail);
				//--		}
				//--	}
				//--	shipments.Add((header, details));
				//--}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return shipments;
		}

		public List<(Direct.Shipment.Header header, List<Direct.Shipment.Detail> details)> CDFL(string fullpathandname, string vendor)
		{
			Direct.Shipment.Header header = null;
			List<Direct.Shipment.Detail> details = new List<Direct.Shipment.Detail>();
			Direct.Shipment.Detail detail = null;
			FormatCDFL.Models.Files.ShipNotice.DataSequence.V3 shpCDFL = new FormatCDFL.Models.Files.ShipNotice.DataSequence.V3();
			List<(Direct.Shipment.Header header, List<Direct.Shipment.Detail> details)> shipments = new List<(Direct.Shipment.Header header, List<Direct.Shipment.Detail> details)>();
			List<(string po, string reference, int quant)> quantity = new List<(string, string, int)>();

			try
			{
				using (FormatCDFL.Logic.Data.ShipNotice.Files cdflSHP = new FormatCDFL.Logic.Data.ShipNotice.Files())
				{
					//??shpCDFL = cdflSHP.ReadFile(fullpathandname, cdflSHP.CreateBatch(fullpathandname, vendor));
				}
				var items = (from item in shpCDFL.Shipments
							 select item).ToList();
				//?? var shipPOs = (from ship in items
				//?? 			   select ship.ShipmentRecord.PONumber).Distinct().ToList();
				//??for (int shipcounter = 0; shipcounter < shipPOs.Count(); shipcounter++)
				//??{
				//??	details = new List<Model.Shipment.Detail>();
				//??	header = new Model.Shipment.Header
				//??	{
				//??		// ShipmentID = ,
				//??		ASNAckNo = string.Empty,
				//??		ASNACKSent = false,
				//??		ASNNo = string.Empty,
				//??		BillToLoc = string.Empty,
				//??		BillToSAN = string.Empty,
				//??		//??Carrier = shpCDFL.PackRecord.SCAC,
				//??		CurrencyCode = "USD",
				//??		GSNo = string.Empty,
				//??		InsertDateTime = DateTime.UtcNow,
				//??		//??IssueDate = shpCDFL.PackRecord.ShipmentDate,
				//??		PONumber = shipPOs[shipcounter],
				//??		Processed = false,
				//??		ProcessedDateTime = default(DateTime),
				//??		ReferenceNo = "",
				//??		//??ShipFromLoc = shpCDFL.PackRecord.ShippingDCCode,
				//??		ShipFromSAN = string.Empty,
				//??		ShipToLoc = string.Empty,
				//??		ShipToSAN = string.Empty,
				//??		TotalLines = -1,
				//??		TotalQuantity = -1,
				//??		VendorID = vendor,
				//??	};
				//??	//?? FormatCDFL.Models.Files.ShipNotice.OR_ASNShipment shipmentrecord = (from f in items where f.ShipmentRecord.PONumber == shipPOs[shipcounter] select f.ShipmentRecord).FirstOrDefault();
				//??	//?? foreach (FormatCDFL.Models.Files.ShipNotice.OD_ASNShipmentDetail singleitem in items[shipcounter].LineItemDetailRecords)
				//??	//?? {
				//??	//?? 	detail = new Model.Shipment.Detail
				//??	//?? 	{
				//??	//?? 		// ShipmentID = ,
				//??	//?? 		// ShipmentItemID = ,
				//??	//?? 		ItemDesc = "",
				//??	//?? 		// ItemIdCode = ,
				//??	//?? 		ItemIdentifier = singleitem.ISBN13OrEAN,
				//??	//?? 		//LineNo =  ++.PadLeft(10,'0')
				//??	//?? 		PackageNo = shipmentrecord.IngramOrderEntryNumber,
				//??	//?? 		QuantityShipped = singleitem.QuantityShipped,
				//??	//?? 		TrackingNo = shipmentrecord.PONumber,
				//??	//?? 		ReferenceNumber = singleitem.LineItemIDNumber,
				//??	//?? 		ponumber = shipPOs[shipcounter],
				//??	//?? 	};
				//??	//?? 	quantity.Add((shipPOs[shipcounter], shipmentrecord.IngramOrderEntryNumber, singleitem.QuantityShipped));
				//??	//?? 	details.Add(detail);
				//??	//?? }
				//??	var poquantity = (from f in quantity where f.po == shipPOs[shipcounter] select f.quant);
				//??	header.TotalQuantity = poquantity.Sum();
				//??	header.TotalLines = poquantity.Count();
				//??	header.ReferenceNo = (from f in quantity where f.po == shipPOs[shipcounter] select f.reference).FirstOrDefault();
				//??	shipments.Add((header, details));
				//??
				//??}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return shipments;
		}


		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~Retrieve() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion

	}
}