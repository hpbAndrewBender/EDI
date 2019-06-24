using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib.Logic;
using CommonLib.Extensions;

namespace FormatBBV3.Logic.Data.PurchaseAcknowledgement
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
				batchnumber = CommonLib.Logic.Globals.CreateBatch("BBV3", filename, vendor, 1);
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
				if (data.FreeFormVendor != null && data.FreeFormVendor.Count > 0)
				{
					foreach (Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor item in data.FreeFormVendor)
					{
						if (Common.IsValid(item)) { writelist.Add(item); }
					}
				}
				if (data.AcknowledgementItems!= null && data.AcknowledgementItems.Count > 0)
				{
					foreach (Models.Files.PurchaseAcknowledgement.DataSequence.AcknowledgementItem item in data.AcknowledgementItems)
					{
						if (Common.IsValid(item.LineItemRecord)) { writelist.Add(item.LineItemRecord); }
						if (Common.IsValid(item.AdditionalDetailRecord)) { writelist.Add(item.AdditionalDetailRecord); }
						if (Common.IsValid(item.AddtionalLineItemTitle)) { writelist.Add(item.AddtionalLineItemTitle); }
						if (Common.IsValid(item.AdditionalLineItemPublisher)) { writelist.Add(item.AdditionalLineItemPublisher); }
						if (Common.IsValid(item.ItemNumberOrPriceRecord)) { writelist.Add(item.ItemNumberOrPriceRecord); }
						if (Common.IsValid(item.AdditionalLineItemClient)) { writelist.Add(item.AdditionalLineItemClient); }
					}
				}
				if (Common.IsValid(data.PurchaseOrderControlTotalsRecord)) { writelist.Add(data.PurchaseOrderControlTotalsRecord); }
				if (Common.IsValid(data.FileTrailerRecord)) { writelist.Add(data.FileTrailerRecord); }
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.PurchaseAcknowledgement.R02_FileHeader),
					typeof(Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader),
					typeof(Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor),
					typeof(Models.Files.PurchaseAcknowledgement.R40_LineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail),
					typeof(Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R44_Item_NumberOrPrice),
					typeof(Models.Files.PurchaseAcknowledgement.R45_AdditionalLineItem),
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
			List<Models.Files.PurchaseAcknowledgement.R02_FileHeader> r02 = null;
			List<Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader> r11 = null;
			List<Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor> r21 = null;
			List<Models.Files.PurchaseAcknowledgement.R40_LineItem> r40 = null;
			List<Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail> r41 = null;
			List<Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem> r42 = null;
			List<Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem> r43 = null;
			List<Models.Files.PurchaseAcknowledgement.R44_Item_NumberOrPrice> r44 = null;
			List<Models.Files.PurchaseAcknowledgement.R45_AdditionalLineItem> r45 = null;
			List<Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals> r59 = null;
			List<Models.Files.PurchaseAcknowledgement.R91_FileTrailer> r91 = null;
			//
			Models.Files.PurchaseAcknowledgement.DataSequence.V3 file = null;
			Models.Files.PurchaseAcknowledgement.DataSequence.AcknowledgementItem acknowledgement = null;
			//
			string typename = string.Empty;
			int acknowledgementCount = 0;
			bool savedokay = false;

			try
			{
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.PurchaseAcknowledgement.R02_FileHeader),
					typeof(Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader),
					typeof(Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor),
					typeof(Models.Files.PurchaseAcknowledgement.R40_LineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail),
					typeof(Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem),
					typeof(Models.Files.PurchaseAcknowledgement.R44_Item_NumberOrPrice),
					typeof(Models.Files.PurchaseAcknowledgement.R45_AdditionalLineItem),
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
								Common.Initialize(ref r02);
								r02.Add((Models.Files.PurchaseAcknowledgement.R02_FileHeader)rec);
								file.FileHeaderRecord = r02.LastItem();
								break;

							case "R11_PURCHASEORDERHEADER":
								Common.Initialize(ref r11);
								r11.Add((Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader)rec);
								file.PurchaseOrderHeaderRecord = r11.LastItem();
								break;

							case "R21_FREEFORMVENDOR":
								Common.Initialize(ref r21);
								r21.Add((Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor)rec);
								if (file.FreeFormVendor == null) { file.FreeFormVendor = new List<Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor>(); }
								if (file.FreeFormVendor.Count <= file.Maxes[typename])
								{
									file.FreeFormVendor.Add(r21.LastItem());
								}
								break;

							case "R40_LINEITEM":
								Common.Initialize(ref r40);
								r40.Add((Models.Files.PurchaseAcknowledgement.R40_LineItem)rec);
								if (acknowledgementCount == 0)
								{
									file.AcknowledgementItems = new List<Models.Files.PurchaseAcknowledgement.DataSequence.AcknowledgementItem>();
								}
								else
								{
									file.AcknowledgementItems.Add(acknowledgement);
									acknowledgement = new Models.Files.PurchaseAcknowledgement.DataSequence.AcknowledgementItem();
								}
								acknowledgementCount++;
								acknowledgement = new Models.Files.PurchaseAcknowledgement.DataSequence.AcknowledgementItem
								{
									LineItemRecord = r40.LastItem()
								};
								break;

							case "R41_ADDITIONALDETAIL":
								Common.Initialize(ref r41);
								r41.Add((Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail)rec);
								acknowledgement.AdditionalDetailRecord = r41.LastItem();
								break;

							case "R42_ADDITIONALLINEITEM":
								Common.Initialize(ref r42);
								r42.Add((Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem)rec);
								acknowledgement.AddtionalLineItemTitle = r42.LastItem();
								break;

							case "R43_ADDITIONALLINEITEM":
								Common.Initialize(ref r43);
								r43.Add((Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem)rec);
								acknowledgement.AdditionalLineItemPublisher = r43.LastItem();
								break;

							case "R44_ITEM_NUMBERORPRICE":
								Common.Initialize(ref r44);
								r44.Add((Models.Files.PurchaseAcknowledgement.R44_Item_NumberOrPrice)rec);
								acknowledgement.ItemNumberOrPriceRecord = r44.LastItem();
								break;

							case "R45_ADDITIONALLINEITEM":
								Common.Initialize(ref r45);
								r45.Add((Models.Files.PurchaseAcknowledgement.R45_AdditionalLineItem)rec);
								acknowledgement.AdditionalLineItemClient = r45.LastItem();
								break;

							case "R59_PURCHASEORDERCONTROLTOTALS":
								Common.Initialize(ref r59);
								r59.Add((Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals)rec);
								if (acknowledgement != null)
								{
									file.AcknowledgementItems.Add(acknowledgement);
									acknowledgement = null;
								}
								file.PurchaseOrderControlTotalsRecord = r59.LastItem();
								break;

							case "R91_FILETRAILER":
								Common.Initialize(ref r91);
								r91.Add((Models.Files.PurchaseAcknowledgement.R91_FileTrailer)rec);
								file.FileTrailerRecord = r91.LastItem();
								break;
						}
					}
					using (SQL sql = new SQL(batchnumber, r02, r11, r21, r40, r41, r42, r43, r44, r45, r59, r91)) { savedokay = sql.Successful; } 
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