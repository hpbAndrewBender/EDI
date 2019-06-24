using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib.Extensions;
using FormatBBV3.Enumerations;
using Bulk = DataHPBEDI.Models.BLK;
using Direct = DataHPBEDI.Models.CDF;

namespace VendorIngramContent.Logic.PurchaseAcknowledgement
{
	public class Retrieve : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public List<(Bulk.Acknowledge.Header header, List<Bulk.Acknowledge.Detail> details)> BBV3(string fullpathandname, string vendor)
		{
			Bulk.Acknowledge.Header header = null;
			Bulk.Acknowledge.Detail detail = null;
			List<Bulk.Acknowledge.Detail> details = new List<Bulk.Acknowledge.Detail>();
			FormatBBV3.Models.Files.PurchaseAcknowledgement.DataSequence.V3 ackBBV3 = new FormatBBV3.Models.Files.PurchaseAcknowledgement.DataSequence.V3();
			List<(Bulk.Acknowledge.Header header, List<Bulk.Acknowledge.Detail>)> acks = new List<(Bulk.Acknowledge.Header header, List<Bulk.Acknowledge.Detail>)>();
			StringBuilder multimessage = new StringBuilder();
			List<(string PONumber, string Message)> VendorMessages = new List<(string PONumber, string Message)>();
			//++ List<string> storelist = new List<string>();
			//++ List<DataHPBEDI.Models.MetaData.VendorStoreData> VendorStore = null;

			try
			{
				using (FormatBBV3.Logic.Data.PurchaseAcknowledgement.Files bbvACK = new FormatBBV3.Logic.Data.PurchaseAcknowledgement.Files())
				{
					ackBBV3 = bbvACK.ReadFile(fullpathandname, bbvACK.CreateBatch(fullpathandname, vendor));
				}
				var items = (from item in ackBBV3.AcknowledgementItems select item).ToList();
				var orderPOs = (from order in items select order.LineItemRecord.PONumber).Distinct().ToList();				
				for (int ordercounter = 0; ordercounter < orderPOs.Count; ordercounter++)
				{					
					details = new List<Bulk.Acknowledge.Detail>();
					header = new Bulk.Acknowledge.Header
					{
						// AckId = 0,
						BillToLoc = "",
						BillToSAN = "",
						CurrencyCode = "USD",
						// EdiSourceTypeID
						GSNo = "",
						InsertDateTime = DateTime.UtcNow,
						IssueDate = ackBBV3.FileHeaderRecord.POACreationDate,
						PONumber = orderPOs[ordercounter],
						Processed = false,
						ProcessedDateTime = default(DateTime),
						ReferenceNo = orderPOs[ordercounter],
						ResponseAckNo = "",
						ResponseACKSent = false,
						ShipFromLoc = "",
						ShipFromSAN = "",
						ShipToLoc = "",
						ShipToSAN = "",
						TotalLines = (from f in items where f.ItemNumberOrPriceRecord.PONumber == orderPOs[ordercounter] select (int)f.ItemNumberOrPriceRecord.TotalLineOrderQuantity).Count(),
						TotalQuantity = (from f in items where f.ItemNumberOrPriceRecord.PONumber == orderPOs[ordercounter] select (int)f.ItemNumberOrPriceRecord.TotalLineOrderQuantity).Sum(),
						VendorID = vendor,
						VendorMessage = string.Join("", (from f in ackBBV3.FreeFormVendor where f.PONumber == orderPOs[ordercounter] select f.VendorMessage).ToArray()),
					};
					foreach (FormatBBV3.Models.Files.PurchaseAcknowledgement.DataSequence.AcknowledgementItem item in items)
					{
						if (item.LineItemRecord.PONumber == orderPOs[ordercounter])
						{
							detail = new Bulk.Acknowledge.Detail
							{
								// AckId = ,
								// AckItemId = ,
								// CurrencyCode = "",
								// EDIFileID = ,
								// EDILineNumber = ,
								ItemDesc = $"{item.AddtionalLineItemTitle.Author} / {item.AddtionalLineItemTitle.Title}",
								ItemIdCode = "EN",
								ItemIdentifier = item.LineItemRecord.ItemNumber,
								ItemStatusCode = item.LineItemRecord.POAStatusCode,
								LineNo = "", // .Trim().PadLeft(10,'0')
								LineStatusCode = "",
								PriceCode = "",
								QuantityBackordered = 0,
								QuantityCancelled = 0,
								QuantityOrdered = (int)item.ItemNumberOrPriceRecord.TotalLineOrderQuantity,
								QuantityShipped = int.Parse(item.AdditionalLineItemPublisher.TotalQuantityPredictedtoShipPrimary),
								UnitOfMeasure = "",
								UnitPrice = item.ItemNumberOrPriceRecord.NetOrDiscountPrice,
								ReferenceNumber = item.AdditionalLineItemClient.ClientsProprietaryItemNumber,
								VendorStatus = FormatBBV3.Enumerations.Acknowledgement.ValueToString(item.LineItemRecord.POAStatusCode).ToStringValue(),
								ponumber = item.ItemNumberOrPriceRecord.PONumber,
							};
							details.Add(detail);
						}
					}
					if (header != null && (details != null && details.Count > 0))
					{
						acks.Add((header, details));
					}
				}

				//--multimessage = new StringBuilder();
				//--if (ackBBV3.FreeFormVendor != null && ackBBV3.FreeFormVendor.Count > 0)
				//--{
				//--	foreach (FormatBBV3.Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor item in ackBBV3.FreeFormVendor)
				//--	{
				//--		multimessage.Append(item.VendorMessage);
				//--	}
				//--	VendorMessages.Add((ackBBV3.FreeFormVendor[0].PONumber, multimessage.ToString()));
				//--}
				//--
				//--//for (int headercounter = 0; headercounter < ackBBV3.AcknowledgementItems.Count; headercounter++)
				//--//{
				//--	details = new List<DataHPBEDI.Models.Acknowledge.Detail>();
				//--
				//--	header = new DataHPBEDI.Models.Acknowledge.Header
				//--	{
				//--		// AckId = ,
				//--		BillToLoc = "",
				//--		BillToSAN = ackBBV3.FileHeaderRecord.DestinationSAN,
				//--		CurrencyCode = "",
				//--		GSNo = "",
				//--		InsertDateTime = DateTime.UtcNow,
				//--		IssueDate = ackBBV3.FileHeaderRecord.POACreationDate,
				//--		PONumber =  pos[0],
				//--		Processed = false ,
				//--		// OPT: ProcessedDateTime = ,
				//--		ReferenceNo = "",
				//--		// OPT: ResponseAckNo = ,
				//--		// OPT: ResponseACKSent = ,
				//--		ShipFromLoc = "" ,
				//--		ShipFromSAN = "" ,
				//--		ShipToLoc =""  ,
				//--		ShipToSAN =""  ,
				//--		TotalLines =  0,
				//--		TotalQuantity = 0 ,
				//--		VendorID = vendor,
				//--	};
				//--
				//--	for(int detailcounter = 0; detailcounter < ackBBV3.AcknowledgementItems.Count; detailcounter++ )
				//--	{
				//--		header.PONumber = ackBBV3.FreeFormVendor[detailcounter].PONumber;
				//--		header.ReferenceNo = ackBBV3.AcknowledgementItems[detailcounter].LineItemRecord.LineItemPONumber;
				//--
				//--		detail = new DataHPBEDI.Models.Acknowledge.Detail
				//--		{
				//--			// AckId = ,
				//--			// AckItemId = ,
				//--			// CurrencyCode = "",
				//--			// EDIFileID = ,
				//--			// EDILineNumber = ,
				//--			ItemDesc =  $"{ackBBV3.AcknowledgementItems[detailcounter].AddtionalLineItemTitle.Author} / {ackBBV3.AcknowledgementItems[detailcounter].AddtionalLineItemTitle.Title}",
				//--			ItemIdCode = "EN",
				//--			ItemIdentifier = ackBBV3.AcknowledgementItems[detailcounter].LineItemRecord.ItemNumber,
				//--			ItemStatusCode = ackBBV3.AcknowledgementItems[detailcounter].LineItemRecord.POAStatusCode,
				//--			LineNo = "", // .Trim().PadLeft(10,'0')
				//--			LineStatusCode = "",
				//--			PriceCode = "",
				//--			QuantityBackordered = 0,
				//--			QuantityCancelled = 0,
				//--			QuantityOrdered = (int)ackBBV3.AcknowledgementItems[detailcounter].ItemNumberOrPriceRecord.TotalLineOrderQuantity,
				//--			QuantityShipped = int.Parse(ackBBV3.AcknowledgementItems[detailcounter].AdditionalLineItemPublisher.TotalQuantityPredictedtoShipPrimary),
				//--			UnitOfMeasure = "",
				//--			UnitPrice = ackBBV3.AcknowledgementItems[detailcounter].ItemNumberOrPriceRecord.NetOrDiscountPrice,
				//--			ReferenceNumber = ackBBV3.AcknowledgementItems[detailcounter].ItemNumberOrPriceRecord.PONumber,
				//--			ponumber = ackBBV3.AcknowledgementItems[detailcounter].ItemNumberOrPriceRecord.PONumber,
				//--
				//--		};
				//--		details.Add(detail);
				//--	}
				//--	acks.Add((header, details));
				//--// }
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return acks;
		}

		public List<(Direct.Acknowledge.Header header, List<Direct.Acknowledge.Detail> details)> CDFL(string fullpathandname, string vendor)
		{
			Direct.Acknowledge.Header header = null;
			Direct.Acknowledge.Detail detail = null;
			List<Direct.Acknowledge.Detail> details = new List<Direct.Acknowledge.Detail>();
			FormatCDFL.Models.Files.PurchaseAcknowledgement.DataSequence.V3 ackCDFL = new FormatCDFL.Models.Files.PurchaseAcknowledgement.DataSequence.V3();
			List<(Direct.Acknowledge.Header header, List<Direct.Acknowledge.Detail>)> acks = new List<(Direct.Acknowledge.Header header, List<Direct.Acknowledge.Detail>)>();
			StringBuilder multimessage = new StringBuilder();
			List<(string PONumber, string Message)> VendorMessages = new List<(string PONumber, string Message)>();
			//++ List<string> storelist = new List<string>();
			//++ List<DataHPBEDI.Models.MetaData.VendorStoreData> VendorStore = null;

			try
			{
				using (FormatCDFL.Logic.Data.PurchaseAcknowledgement.Files cdflACKN = new FormatCDFL.Logic.Data.PurchaseAcknowledgement.Files())
				{
					ackCDFL = cdflACKN.ReadFile(fullpathandname, cdflACKN.CreateBatch(fullpathandname, vendor));
				}
				//?? var items = (from item in ackCDFL.AcknowledgementItems select item).ToList();
				//?var orderPOs = (from order in items select order.LineItemRecord.PONumber).Distinct().ToList();
				//?? for (int ordercounter = 0; ordercounter < orderPOs.Count(); ordercounter++)
				//?? {
				//?? 	details = new List<DataHPBEDI.Models.EDI.Acknowledge.Detail>();
				//?? 	header = new DataHPBEDI.Models.EDI.Acknowledge.Header
				//?? 	{
				//?? 		// AckId = 0,
				//?? 		BillToLoc = "",
				//?? 		BillToSAN = "",
				//?? 		CurrencyCode = "USD",
				//?? 		// EdiSourceTypeID
				//?? 		GSNo = "",
				//?? 		InsertDateTime = DateTime.UtcNow,
				//?? 		IssueDate = ackCDFL.FileHeaderRecord.POACreationDate,
				//?? 		PONumber = orderPOs[ordercounter],
				//?? 		Processed = false,
				//?? 		ProcessedDateTime = default(DateTime),
				//?? 		ReferenceNo = orderPOs[ordercounter],
				//?? 		ResponseAckNo = "",
				//?? 		ResponseACKSent = false,
				//?? 		ShipFromLoc = "",
				//?? 		ShipFromSAN = "",
				//?? 		ShipToLoc = "",
				//?? 		ShipToSAN = "",
				//?? 		TotalLines = (from f in items where f.ItemNumberOrPriceRecord.PONumber == orderPOs[ordercounter] select (int)f.ItemNumberOrPriceRecord.TotalLineOrderQuantity).Count(),
				//?? 		TotalQuantity = (from f in items where f.ItemNumberOrPriceRecord.PONumber == orderPOs[ordercounter] select (int)f.ItemNumberOrPriceRecord.TotalLineOrderQuantity).Sum(),
				//?? 		VendorID = vendor,
				//?? 		VendorMessage = string.Join("", (from f in ackCDFL.FreeFormVendor where f.PONumber == orderPOs[ordercounter] select f.VendorMessage).ToArray()),
				//?? 	};
				//?? 	foreach (FormatCDFL.Models.Files.PurchaseAcknowledgement.DataSequence.AcknowledgementItem item in items)
				//?? 	{
				//?? 		if (item.LineItemRecord.PONumber == orderPOs[ordercounter])
				//?? 		{
				//?? 			detail = new DataHPBEDI.Models.EDI.Acknowledge.Detail
				//?? 			{
				//?? 				// AckId = ,
				//?? 				// AckItemId = ,
				//?? 				// CurrencyCode = "",
				//?? 				// EDIFileID = ,
				//?? 				// EDILineNumber = ,
				//?? 				ItemDesc = $"{item.AddtionalLineItemTitle.Author} / {item.AddtionalLineItemTitle.Title}",
				//?? 				ItemIdCode = "EN",
				//?? 				ItemIdentifier = item.LineItemRecord.ItemNumber,
				//?? 				ItemStatusCode = item.LineItemRecord.POAStatusCode,
				//?? 				LineNo = "", // .Trim().PadLeft(10,'0')
				//?? 				LineStatusCode = "",
				//?? 				PriceCode = "",
				//?? 				QuantityBackordered = 0,
				//?? 				QuantityCancelled = 0,
				//?? 				QuantityOrdered = (int)item.ItemNumberOrPriceRecord.TotalLineOrderQuantity,
				//?? 				QuantityShipped = int.Parse(item.AdditionalLineItemPublisher.TotalQuantityPredictedtoShipPrimary),
				//?? 				UnitOfMeasure = "",
				//?? 				UnitPrice = item.ItemNumberOrPriceRecord.NetOrDiscountPrice,
				//?? 				ReferenceNumber = item.AdditionalLineItemClient.ClientsProprietaryItemNumber,
				//?? 				VendorStatus = FormatCDFL.Enumerations.Acknowledgement.ValueToString(item.LineItemRecord.POAStatusCode).ToStringValue(),
				//?? 				ponumber = item.ItemNumberOrPriceRecord.PONumber,
				//?? 			};
				//?? 			details.Add(detail);
				//?? 		}
				//?? 	}
				//?? 	if (header != null && (details != null && details.Count > 0))
				//?? 	{
				//?? 		acks.Add((header, details));
				//?? 	}
				//?? }
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return acks;
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

		#endregion IDisposable Support
	}
}