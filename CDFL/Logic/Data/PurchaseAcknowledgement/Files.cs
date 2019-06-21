using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLib.Logic;
using CommonLib.Extensions;

namespace FormatCDFL.Logic.Data.PurchaseAcknowledgement
{
	public class Files : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		private T DefaultIfEmpty<T>(T obje)
		{
			if (obje == null)
			{
				return default(T);
			}
			else
			{
				return obje;
			}
		}

		public int CreateBatch(string filename, string vendor)
		{
			int batchnumber = 0;
			try
			{
				batchnumber = CommonLib.Logic.Globals.CreateBatch(filename, vendor, 4);
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return batchnumber;
		}


		public bool WriteFile(string filename, Models.Files.PurchaseAcknowledgement.DataSequence.V3 data)
		{
			List<object> writelist = new List<object>();
			bool success = false;

			try
			{
				//build list
				writelist.Add(data.FileHeaderRecord);
				if (Common.IsValid(data.PurchaseOrderHeaderRecord)) { writelist.Add(data.PurchaseOrderHeaderRecord); }
				if(data.FreeFormVendor != null && data.FreeFormVendor.Count > 0)
				{
					foreach (Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor item in data.FreeFormVendor)
					{
						if (Common.IsValid(item)) { writelist.Add(item); }
					}
				}
				if (Common.IsValid(data.RecipShipToNameAndAddressRecord)) { writelist.Add(data.RecipShipToNameAndAddressRecord); }
				if(data.RecipShipToAdditionalShippingInfo != null && data.RecipShipToAdditionalShippingInfo.Count > 0)
				{
					foreach(Models.Files.PurchaseAcknowledgement.R32_RecipientShipToAdditionalShippingInformation item in data.RecipShipToAdditionalShippingInfo)
					{
						if (Common.IsValid(item)) { writelist.Add(item); }
					}
				}
				if (Common.IsValid(data.RecipShipToCityStateAndZipRecord)) { writelist.Add(data.RecipShipToCityStateAndZipRecord); }
				if (data.LineItems != null && data.LineItems.Count > 0)
				{
					foreach (Models.Files.PurchaseAcknowledgement.DataSequence.LineItem item in data.LineItems)
					{
						if (Common.IsValid(item.LineItemRecord)) { writelist.Add(item.LineItemRecord); }
						if (Common.IsValid(item.AdditionalDetailRecord)) { writelist.Add(item.AdditionalDetailRecord); }
						if (Common.IsValid(item.AddtionalLineItemTitleRecord)) { writelist.Add(item.AddtionalLineItemTitleRecord); }
						if (Common.IsValid(item.AdditionalLineItemPublisherRecord)) { writelist.Add(item.AdditionalLineItemPublisherRecord); }
						if (Common.IsValid(item.ItemNumberOrPriceRecord)) { writelist.Add(item.ItemNumberOrPriceRecord); }
					}
				}
				if (Common.IsValid(data.PurchaseOrderControlTotalsRecord)) { writelist.Add(data.PurchaseOrderControlTotalsRecord); }
				if (Common.IsValid(data.FileTrailerRecord)) { writelist.Add(data.FileTrailerRecord); }
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.PurchaseAcknowledgement.R02_FileHeader),
					typeof(Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader),
					typeof(Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor),
					typeof(Models.Files.PurchaseAcknowledgement.R30_RecipientShipToNameAndAddress),
					typeof(Models.Files.PurchaseAcknowledgement.R32_RecipientShipToAdditionalShippingInformation),
					typeof(Models.Files.PurchaseAcknowledgement.R34_RecipientShipToCityStateAndZip),
					typeof(Models.Files.PurchaseAcknowledgement.R40_LineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail),
					typeof(Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R44_ItemNumberOrPrice),
					typeof(Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals),
					typeof(Models.Files.PurchaseAcknowledgement.R91_FileTrailer)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.Invoice.Selectors.V3.Custom)
				};
				engine.WriteFile(filename, writelist.ToArray());
				success = true;
			}
			catch (Exception ex)
			{
				log.Error(ex); 
				success = false;
			}
			return success;
		}

		public Models.Files.PurchaseAcknowledgement.DataSequence.V3 ReadFile(string filename, int batchnumber)
		{
			List<Models.Files.PurchaseAcknowledgement.R02_FileHeader> saveR02 = null;
			List<Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader> saveR11 = null;
			List<Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor> saveR21 = null;
			List<Models.Files.PurchaseAcknowledgement.R30_RecipientShipToNameAndAddress> saveR30 = null;
			List<Models.Files.PurchaseAcknowledgement.R32_RecipientShipToAdditionalShippingInformation> saveR32 = null;
			List<Models.Files.PurchaseAcknowledgement.R34_RecipientShipToCityStateAndZip> saveR34 = null;
			List<Models.Files.PurchaseAcknowledgement.R40_LineItem> saveR40 = null;
			List<Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail> saveR41 = null;
			List<Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem> saveR42 = null;
			List<Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem> saveR43 = null;
			List<Models.Files.PurchaseAcknowledgement.R44_ItemNumberOrPrice> saveR44 = null;
			List<Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals> saveR59 = null;
			List<Models.Files.PurchaseAcknowledgement.R91_FileTrailer> saveR91 = null;
			//
			Models.Files.PurchaseAcknowledgement.DataSequence.V3 file = null;
			Models.Files.PurchaseAcknowledgement.DataSequence.LineItem item = null;
			//
			string typename = string.Empty;
			int itemCount = 0;

			try
			{
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.PurchaseAcknowledgement.R02_FileHeader),
					typeof(Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader),
					typeof(Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor),
					typeof(Models.Files.PurchaseAcknowledgement.R30_RecipientShipToNameAndAddress),
					typeof(Models.Files.PurchaseAcknowledgement.R32_RecipientShipToAdditionalShippingInformation),
					typeof(Models.Files.PurchaseAcknowledgement.R34_RecipientShipToCityStateAndZip),
					typeof(Models.Files.PurchaseAcknowledgement.R40_LineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail),
					typeof(Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R44_ItemNumberOrPrice),
					typeof(Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals),
					typeof(Models.Files.PurchaseAcknowledgement.R91_FileTrailer)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.PurchaseAcknowledgement.Selectors.V3.Custom)
				};


				var res = engine.ReadFile(filename);
				if (res != null && res.Length > 0)
				{
					file = new Models.Files.PurchaseAcknowledgement.DataSequence.V3();

					foreach (var rec in res)
					{
						typename = rec.GetType().Name.ToUpper();
						switch (typename)
						{
							case "R02_FILEHEADER":
								Common.Initialize(ref saveR02);
								saveR02.Add((Models.Files.PurchaseAcknowledgement.R02_FileHeader)rec);
								file.FileHeaderRecord = saveR02.LastItem();
								break;

							case "R11_PURCHASEORDERHEADER":
								Common.Initialize(ref saveR11);
								saveR11.Add((Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader)rec);
								file.PurchaseOrderHeaderRecord = saveR11.LastItem();
								break;

							case "R21_FREEFORMVENDOR":
								Common.Initialize(ref saveR21);
								saveR21.Add((Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor)rec);
								if (file.FreeFormVendor == null) { file.FreeFormVendor = new List<Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor>(); }
								if (file.FreeFormVendor.Count < file.Maxes[typename])
								{
									file.FreeFormVendor.Add(saveR21.LastItem());
								}
								break;
								
							case "R30_RECIPIENTSHIPTONAMEANDADDRESS":
								Common.Initialize(ref saveR30);
								saveR30.Add((Models.Files.PurchaseAcknowledgement.R30_RecipientShipToNameAndAddress)rec);
								file.RecipShipToNameAndAddressRecord = saveR30.LastItem();
								break;

							case "R32_RECIPIENTSHIPTOADDITIONALSHIPPINGINFORMATION":
								Common.Initialize(ref saveR32);
								saveR32.Add((Models.Files.PurchaseAcknowledgement.R32_RecipientShipToAdditionalShippingInformation)rec);
								if(file.RecipShipToAdditionalShippingInfo == null) { file.RecipShipToAdditionalShippingInfo = new List<Models.Files.PurchaseAcknowledgement.R32_RecipientShipToAdditionalShippingInformation>(); }
								if(file.RecipShipToAdditionalShippingInfo.Count < file.Maxes[typename])
								{
									file.RecipShipToAdditionalShippingInfo.Add(saveR32.LastItem());
								}
								break;

							case "R34_RECIPIENTSHIPTOCITYSTATEANDZIP":
								Common.Initialize(ref saveR34);
								saveR34.Add((Models.Files.PurchaseAcknowledgement.R34_RecipientShipToCityStateAndZip)rec);
								file.RecipShipToCityStateAndZipRecord = saveR34.LastItem();
								break;

							case "R40_LINEITEM":
								Common.Initialize(ref saveR40);
								saveR40.Add((Models.Files.PurchaseAcknowledgement.R40_LineItem)rec);
								if(itemCount > 0)
								{
									if(item != null)
									{
										file.LineItems.Add(item);
										item = null;
									}
								}
								if( file.LineItems == null ) { file.LineItems = new List<Models.Files.PurchaseAcknowledgement.DataSequence.LineItem>(); }
								item = new Models.Files.PurchaseAcknowledgement.DataSequence.LineItem();
								itemCount++;
								item.LineItemRecord = saveR40.LastItem();
								break;

							case "R41_ADDITIONALDETAIL":
								Common.Initialize(ref saveR41);
								saveR41.Add((Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail)rec);
								item.AdditionalDetailRecord = saveR41.LastItem();
								break;

							case "R42_ADDITIONALLINEITEM":
								Common.Initialize(ref saveR42);
								saveR42.Add((Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem)rec);
								item.AddtionalLineItemTitleRecord = saveR42.LastItem();
								break;

							case "R43_ADDITIONALLINEITEM":
								Common.Initialize(ref saveR43);
								saveR43.Add((Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem)rec);
								item.AdditionalLineItemPublisherRecord = saveR43.LastItem();
								break;

							case "R44_ITEMNUMBERORPRICE":
								Common.Initialize(ref saveR44);
								saveR44.Add((Models.Files.PurchaseAcknowledgement.R44_ItemNumberOrPrice)rec);
								item.ItemNumberOrPriceRecord = saveR44.LastItem();
								break;						

							case "R59_PURCHASEORDERCONTROLTOTALS":
								Common.Initialize(ref saveR59);
								saveR59.Add((Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals)rec);
								file.PurchaseOrderControlTotalsRecord = saveR59.LastItem();
								break;

							case "R91_FILETRAILER":
								Common.Initialize(ref saveR91);
								saveR91.Add((Models.Files.PurchaseAcknowledgement.R91_FileTrailer)rec);
								file.FileTrailerRecord = saveR91.LastItem();
								break;
						}
					}
					if(item !=null)
					{
						file.LineItems.Add(item);
						item = null;
						itemCount = 0;
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return file;
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
		// ~Files() {
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