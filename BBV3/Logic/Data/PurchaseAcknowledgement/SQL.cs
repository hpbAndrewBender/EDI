using System;
using System.Collections.Generic;

namespace FormatBBV3.Logic.Data.PurchaseAcknowledgement
{
	public class SQL : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private string ActionType { get; set; } = "PurchaseAcknowledgement";
		private string FileFormat { get; set; } = "BBV3";
		public bool Successful {private set; get;}

		public SQL
		(
			int batchnumber,
			List<Models.Files.PurchaseAcknowledgement.R02_FileHeader> items02,
			List<Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader> items11,
			List<Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor> items21,
			List<Models.Files.PurchaseAcknowledgement.R40_LineItem> items40,
			List<Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail> items41,
			List<Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem> items42,
			List<Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem> items43,
			List<Models.Files.PurchaseAcknowledgement.R44_Item_NumberOrPrice> items44,
			List<Models.Files.PurchaseAcknowledgement.R45_AdditionalLineItem> items45,
			List<Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals> items59,
			List<Models.Files.PurchaseAcknowledgement.R91_FileTrailer> items91
		)
		{
			bool result = false;
			try
			{
				if (items02 != null && items02.Count > 0) { SaveR02_FileHeader(items02, batchnumber); }
				if (items11 != null && items11.Count > 0) { SaveR11_PurchaseOrderHeader(items11, batchnumber); }
				if (items21 != null && items21.Count > 0) { SaveR21_FreeFormVendor(items21, batchnumber); }
				if (items40 != null && items40.Count > 0) { SaveR40_LineItem(items40, batchnumber); }
				if (items41 != null && items41.Count > 0) { SaveR41_AdditionalDetail(items41, batchnumber); }
				if (items42 != null && items42.Count > 0) { SaveR42_AdditionalLineItem(items42, batchnumber); }
				if (items43 != null && items43.Count > 0) { SaveR43_AdditionalLineItem(items43, batchnumber); }
				if (items44 != null && items44.Count > 0) { SaveR44_ItemNumberOrPrice(items44, batchnumber); }
				if (items45 != null && items45.Count > 0) { SaveR45_AdditionalLineItem(items45, batchnumber); }
				if (items59 != null && items59.Count > 0) { SaveR59_PurchaseOrderControlTotals(items59, batchnumber); }
				if (items91 != null && items91.Count > 0) { SaveR91_FileTrailer(items91, batchnumber); }
				result = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				result = false;
			}
			Successful= result;
		}

		public bool SaveR02_FileHeader(List<Models.Files.PurchaseAcknowledgement.R02_FileHeader> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseAcknowledgement.R02_FileHeader>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "RecordCode", "RecordCode"),
							( 3, "SequenceNumber","SequenceNumber"),
							( 4, "FileSourceSAN","FileSourceSAN"),
							( 5, "FileSourceName","FileSourceName"),
							( 6, "POACreationDate","POACreationDate"),
							( 7, "ElectronicControlUnit","ElectronicControlUnit"),
							( 8, "Filename","Filename"),
							( 9, "FormatVersion","FormatVersion"),
							(10, "DestinationSAN","DestinationSAN"),
							(11, "POATypeCode","POATypeCode"),
						},
						new List<string> { }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR11_PurchaseOrderHeader(List<Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "RecordCode","RecordCode"),
							( 3, "SequenceNumber","SequenceNumber"),
							( 4, "TerminalOrderControlNumber","TerminalOrderControlNumber"),
							( 5, "PONumber","PONumber"),
							( 6, "IngramShipToAccountNumber","IngramShipToAccountNumber"),
							( 7, "IngramSAN","IngramSAN"),
							( 8, "POStatus","POStatus"),
							( 9, "AcknowledgmentDate","AcknowledgmentDate"),
							(10, "PODate","PODate"),
							(11, "POCancellationDate","POCancellationDate"),
						},

						new List<string> { }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR21_FreeFormVendor(List<Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),
							(5, "VendorMessage","VendorMessage"),
						},
						new List<string> { }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR40_LineItem(List<Models.Files.PurchaseAcknowledgement.R40_LineItem> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseAcknowledgement.R40_LineItem>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),
							(5, "LineItemPONumber","LineItemPONumber"),
							(6, "ItemNumber","ItemNumber"),
							(7, "POAStatusCode","POAStatusCode"),
							(8, "DCCodeOrPrimaryDC","DCCodeOrPrimaryDC"),
						},
						new List<string> { "reserved072_076" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR41_AdditionalDetail(List<Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),
							(5, "DCCodeOrSecondaryDC","DCCodeOrSecondaryDC"),
							(6, "AvailabilityDate","AvailabilityDate"),
							(7, "DCInventoryInformation","DCInventoryInformation"),
						},
						new List<string> { "reserved030_032", "reserved040_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR42_AdditionalLineItem(List<Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),
							(5, "Title","Title"),
							(6, "Author","Author"),
							(7, "BindingCode","BindingCode"),
						},
						new List<string> { }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR43_AdditionalLineItem(List<Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),
							(5, "PublisherAlphaCode","PublisherAlphaCode"),
							(6, "PublicationOrReleaseDate","PublicationOrReleaseDate"),
							(7, "OriginalSequenceNumber","OriginalSequenceNumber"),
							(8, "TotalQuantityPredictedtoShipPrimary","TotalQuantityPredictedtoShipPrimary"),
							(9, "TotalQuantityPredictedtoShipSecondary","TotalQuantityPredictedtoShipSecondary"),},
						new List<string> { "reserved059_062", "reserved077_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR44_ItemNumberOrPrice(List<Models.Files.PurchaseAcknowledgement.R44_Item_NumberOrPrice> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseAcknowledgement.R44_Item_NumberOrPrice>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId", "BatchId"),
							(2, "RecordCode", "RecordCode"),
							(3, "SequenceNumber", "SequenceNumber"),
							(4, "PONumber", "PONumber"),
							(5, "ForwardedItemNumber", "ForwardedItemNumber"),
							(6, "NetOrDiscountPrice", "NetOrDiscountPrice"),
							(7, "ItemNumberType", "ItemNumberType"),
							(8, "TotalLineOrderQuantity", "TotalLineOrderQuantity"),
						},
						new List<string> { "reserved060_067", "reserved075_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}

			return result;
		}

		public bool SaveR45_AdditionalLineItem(List<Models.Files.PurchaseAcknowledgement.R45_AdditionalLineItem> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseAcknowledgement.R45_AdditionalLineItem>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),
							(5, "ClientPropiertaryItemNumber","ClientPropiertaryItemNumber")},
						new List<string> { "reserved050_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR59_PurchaseOrderControlTotals(List<Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),},
						new List<string> { "reserved030_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR91_FileTrailer(List<Models.Files.PurchaseAcknowledgement.R91_FileTrailer> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseAcknowledgement.R91_FileTrailer>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
						},
						new List<string> { "reserved030_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
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
		// ~SQL() {
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