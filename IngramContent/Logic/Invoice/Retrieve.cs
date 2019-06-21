using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataHPBEDI.Models;

namespace VendorIngramContent.Logic.Invoice
{
	public class Retrieve : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public List<(DataHPBEDI.Models.EDI.Invoice.Header header, List<DataHPBEDI.Models.EDI.Invoice.Detail> details)> BBV3(string fullpathandname, string vendor)
		{
			DataHPBEDI.Models.EDI.Invoice.Header header = null;
			List<DataHPBEDI.Models.EDI.Invoice.Detail> details = new List<DataHPBEDI.Models.EDI.Invoice.Detail>();
			DataHPBEDI.Models.EDI.Invoice.Detail detail = null;
			FormatBBV3.Models.Files.Invoice.DataSequence.V3 invBBV3 = new FormatBBV3.Models.Files.Invoice.DataSequence.V3();
			List<(DataHPBEDI.Models.EDI.Invoice.Header header, List<DataHPBEDI.Models.EDI.Invoice.Detail> details)> invoices = new List<(DataHPBEDI.Models.EDI.Invoice.Header header, List<DataHPBEDI.Models.EDI.Invoice.Detail> details)>();
			List<string> storelist = new List<string>();
			List<DataHPBEDI.Models.MetaData.VendorStoreData> VendorStore = null;

			try
			{
				using (FormatBBV3.Logic.Data.Invoice.Files bbvINV = new FormatBBV3.Logic.Data.Invoice.Files())
				{
					invBBV3 = bbvINV.ReadFile(fullpathandname, bbvINV.CreateBatch(fullpathandname, vendor));
				}
				var invs = (from inv in invBBV3.Invoices
						 select inv.InvoiceDetails).ToArray();
				var invPOs = (from invpos in invs.First()
						  group invpos by invpos.InvoiceDetailRecord.PONumber into g
						  select new
						  {
							  PONumber = g.Key,
							  Items = g.ToList(),
							  g.First().InvoiceDetailRecord.RecordSequenceNumber,
						  }).ToList();
				storelist = (from list in invBBV3.Invoices select list.InvoiceHeaderRecord.StoreNumber).Distinct().ToList();
				using (DataHPBEDI.Logic.MetaData.Retreive metadata = new DataHPBEDI.Logic.MetaData.Retreive())
				{
					VendorStore = metadata.VendorStoreData(vendor, storelist);
				}


				for (int invoicecount = 0; invoicecount < invBBV3.Invoices.Count; invoicecount++)
				{
					for (int pocount = 0; pocount < invPOs.Count(); pocount++)
					{
						(string storenumber, string storesan) = (from vs in VendorStore
																 where vs.VendorShipTo == invBBV3.Invoices[invoicecount].InvoiceHeaderRecord.IngramShipToAccountNumber
																 select (vs.LocationNumber, vs.SanAccount)).First();
						details = new List<DataHPBEDI.Models.EDI.Invoice.Detail>();
						header = new DataHPBEDI.Models.EDI.Invoice.Header
						{
							BillToLoc = "",
							BillToSAN = "",
							CurrencyCode = "",
							GSNo = "",
							InsertDateTime = DateTime.UtcNow,
							InvoiceAckNo = "",
							InvoiceACKSent = false,
							InvoiceNo = invBBV3.Invoices[invoicecount].InvoiceHeaderRecord.InvoiceNumber.ToString(),
							IssueDate = invBBV3.Invoices[invoicecount].InvoiceHeaderRecord.InvoiceDate,
							PONumber = invPOs[pocount].PONumber,
							Processed = false,
							// ProcessedDateTime 
							ReferenceNo = invBBV3.Invoices[invoicecount].InvoiceVendorDetailRecord.IngramOrderEntryNumber,
							ShipFromLoc = invBBV3.Invoices[invoicecount].InvoiceVendorDetailRecord.DCCode.ToString(),
							ShipFromSAN = invBBV3.InvoiceFileHeaderRecord.IngramSAN,
							ShipToLoc = storenumber,
							ShipToSAN = storesan,
							TotalLines = (short)invPOs[pocount].Items.Count,
							TotalPayable = (from counts in invPOs[pocount].Items
											select counts.InvoiceDetailRecord.NetPriceOrCost).Sum(),
							//.invBBV3.Invoices[invoicecount].InvoiceTrailerRecord.TotalInvoiceAmount,
							TotalQuantity =(from counts in invPOs[pocount].Items
											select (int)counts.InvoiceDetailRecord.QuantityShipped).Sum(),
							//invBBV3.InvoiceFileTrailer.TotalItems,
							VendorId = vendor
						};

						for (int detailcount = 0; detailcount < invPOs[pocount].Items.Count; detailcount++)
						{
							detail = new DataHPBEDI.Models.EDI.Invoice.Detail
							{
								// InvoiceId = "",
								// InvoiceItemId = "",
								// DiscountCode = "",
								DiscountPct = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.DiscountPercent / 100m,
								DiscountPrice = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.NetPriceOrCost,
								InvoiceQty = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.QuantityShipped,
								ItemDesc = invPOs[pocount].Items[detailcount].DetailTotalRecord.Title,
								ItemIdCode = "EN",
								ItemIdentifier = invPOs[pocount].Items[detailcount].DetailISBN13OrEANRecord.ISBN13OrEANShipped,
								LineNo = invPOs[pocount].Items[detailcount].DetailISBN13OrEANRecord.RecordSequenceNumber.ToString().Trim().PadLeft(10, '0'),
								RetailPrice = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.IngramItemListPrice,
								UnitPrice = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.NetPriceOrCost,
								ReferenceNumber = invPOs[pocount].Items[detailcount].DetailISBN13OrEANRecord.LineItemIDNumber,
								ponumber = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.PONumber,
							};
							if (detail != null)
							{
								details.Add(detail);
							}
						}
						invoices.Add((header, details));
					}
				}			
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return invoices;
		}

		public List<(DataHPBEDI.Models.EDI.Invoice.Header header, List<DataHPBEDI.Models.EDI.Invoice.Detail> details)> CDFL(string fullpathandname, string vendor)
		{
			DataHPBEDI.Models.EDI.Invoice.Header header = null;
			List<DataHPBEDI.Models.EDI.Invoice.Detail> details = new List<DataHPBEDI.Models.EDI.Invoice.Detail>();
			DataHPBEDI.Models.EDI.Invoice.Detail detail = null;
			FormatCDFL.Models.Files.Invoice.DataSequence.V3 invCDFL = new FormatCDFL.Models.Files.Invoice.DataSequence.V3();
			List<(DataHPBEDI.Models.EDI.Invoice.Header header, List<DataHPBEDI.Models.EDI.Invoice.Detail> details)> invoices = new List<(DataHPBEDI.Models.EDI.Invoice.Header header, List<DataHPBEDI.Models.EDI.Invoice.Detail> details)>();
			List<string> storelist = new List<string>();
			List<DataHPBEDI.Models.MetaData.VendorStoreData> VendorStore = null;

			try
			{
				using (FormatCDFL.Logic.Data.Invoice.Files cdflINV = new FormatCDFL.Logic.Data.Invoice.Files())
				{
					invCDFL = cdflINV.ReadFile(fullpathandname, cdflINV.CreateBatch(fullpathandname, vendor));
				}
				var invs = (from inv in invCDFL.Invoices
							select inv.InvoiceDetails).ToArray();
				//?? var invPOs = (from invpos in invs.First()
				//?? 			  group invpos by invpos.InvoiceDetailRecord.PONumber into g
				//?? 			  select new
				//?? 			  {
				//?? 				  PONumber = g.Key,
				//?? 				  Items = g.ToList(),
				//?? 				  g.First().InvoiceDetailRecord.RecordSequenceNumber,
				//?? 			  }).ToList();
				//?? storelist = (from list in invCDFL.Invoices select list.InvoiceHeaderRecord.StoreNumber).Distinct().ToList();
				using (DataHPBEDI.Logic.MetaData.Retreive metadata = new DataHPBEDI.Logic.MetaData.Retreive())
				{
					VendorStore = metadata.VendorStoreData(vendor, storelist);
				}


				for (int invoicecount = 0; invoicecount < invCDFL.Invoices.Count; invoicecount++)
				{
					//?? for (int pocount = 0; pocount < invPOs.Count(); pocount++)
					//?? {
					//?? 	//?? (string storenumber, string storesan) = (from vs in VendorStore
					//?? 	//?? 										 where vs.VendorShipTo == invCDFL.Invoices[invoicecount].InvoiceHeaderRecord.IngramShipToAccountNumber
					//?? 	//?? 										 select (vs.LocationNumber, vs.SanAccount)).First();
					//?? 	details = new List<DataHPBEDI.Models.EDI.Invoice.Detail>();
					//?? 	header = new DataHPBEDI.Models.EDI.Invoice.Header
					//?? 	{
					//?? 		//?? BillToLoc = "",
					//?? 		//?? BillToSAN = "",
					//?? 		//?? CurrencyCode = "",
					//?? 		//?? GSNo = "",
					//?? 		//?? InsertDateTime = DateTime.UtcNow,
					//?? 		//?? InvoiceAckNo = "",
					//?? 		//?? InvoiceACKSent = false,
					//?? 		//?? InvoiceNo = invCDFL.Invoices[invoicecount].InvoiceHeaderRecord.InvoiceNumber.ToString(),
					//?? 		//?? IssueDate = invCDFL.Invoices[invoicecount].InvoiceHeaderRecord.InvoiceDate,
					//?? 		//?? PONumber = invPOs[pocount].PONumber,
					//?? 		//?? Processed = false,
					//?? 		//?? // ProcessedDateTime 
					//?? 		//?? ReferenceNo = invCDFL.Invoices[invoicecount].InvoiceVendorDetailRecord.IngramOrderEntryNumber,
					//?? 		//?? ShipFromLoc = invCDFL.Invoices[invoicecount].InvoiceVendorDetailRecord.DCCode.ToString(),
					//?? 		//?? ShipFromSAN = invCDFL.InvoiceFileHeaderRecord.IngramSAN,
					//?? 		//?? ShipToLoc = storenumber,
					//?? 		//?? ShipToSAN = storesan,
					//?? 		//?? TotalLines = (short)invPOs[pocount].Items.Count,
					//?? 		//?? TotalPayable = (from counts in invPOs[pocount].Items
					//?? 		//?? 				select counts.InvoiceDetailRecord.NetPriceOrCost).Sum(),
					//?? 		//?? //.invCDFL.Invoices[invoicecount].InvoiceTrailerRecord.TotalInvoiceAmount,
					//?? 		//?? TotalQuantity = (from counts in invPOs[pocount].Items
					//?? 		//?? 				 select (int)counts.InvoiceDetailRecord.QuantityShipped).Sum(),
					//?? 		//?? //invCDFL.InvoiceFileTrailer.TotalItems,
					//?? 		//?? VendorId = vendor
					//?? 	};
					//?? 
					//?? 	for (int detailcount = 0; detailcount < invPOs[pocount].Items.Count; detailcount++)
					//?? 	{
					//?? 		detail = new DataHPBEDI.Models.EDI.Invoice.Detail
					//?? 		{
					//?? 			//?? // InvoiceId = "",
					//?? 			//?? // InvoiceItemId = "",
					//?? 			//?? // DiscountCode = "",
					//?? 			//?? DiscountPct = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.DiscountPercent / 100m,
					//?? 			//?? DiscountPrice = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.NetPriceOrCost,
					//?? 			//?? InvoiceQty = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.QuantityShipped,
					//?? 			//?? ItemDesc = invPOs[pocount].Items[detailcount].DetailTotalRecord.Title,
					//?? 			//?? ItemIdCode = "EN",
					//?? 			//?? ItemIdentifier = invPOs[pocount].Items[detailcount].DetailISBN13OrEANRecord.ISBN13OrEANShipped,
					//?? 			//?? LineNo = invPOs[pocount].Items[detailcount].DetailISBN13OrEANRecord.RecordSequenceNumber.ToString().Trim().PadLeft(10, '0'),
					//?? 			//?? RetailPrice = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.IngramItemListPrice,
					//?? 			//?? UnitPrice = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.NetPriceOrCost,
					//?? 			//?? ReferenceNumber = invPOs[pocount].Items[detailcount].DetailISBN13OrEANRecord.LineItemIDNumber,
					//?? 			//?? ponumber = invPOs[pocount].Items[detailcount].InvoiceDetailRecord.PONumber,
					//?? 		};
					//?? 		if (detail != null)
					//?? 		{
					//?? 			details.Add(detail);
					//?? 		}
					//?? 	}
					//?? 	invoices.Add((header, details));
					//?? }
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return invoices;
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
