using System;
using System.Collections.Generic;

namespace FormatCDFL.Logic.Data.Invoice
{
	public class SQL : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private string ActionType { get; set; } = "Invoice";
		private string FileFormat { get; set; } = "CDFL";
		public bool Successful { private set; get; }

		public SQL
		(
			int batchnumber,
			List<Models.Files.Invoice.R01_InvoiceFileHeader> items01,
			List<Models.Files.Invoice.R15_InvoiceHeader> items15,
			List<Models.Files.Invoice.R45_InvoiceDetail> items45,
			List<Models.Files.Invoice.R46_InvoiceDetail> items46,
			List<Models.Files.Invoice.R48_DetailTotal> items48,
			List<Models.Files.Invoice.R49_DetailTotalOrFreightAndFees> items49,
			List<Models.Files.Invoice.R55_InvoiceTotals> items55,
			List<Models.Files.Invoice.R57_InvoiceTrailer> items57,
			List<Models.Files.Invoice.R95_InvoiceFileTrailer> items95
		)
		{
			bool result = false;
			try
			{
				if (items01 != null && items01.Count > 0) { SaveR01_InvoiceFileHeader(items01, batchnumber); }
				if (items15 != null && items01.Count > 0) { SaveR15_InvoiceHeader(items15, batchnumber); }
				if (items45 != null && items01.Count > 0) { SaveR45_InvoiceDetail(items45, batchnumber); }
				if (items46 != null && items01.Count > 0) { SaveR46_DetailISBN13EAN(items46, batchnumber); }
				if (items48 != null && items01.Count > 0) { SaveR48_DetailTotal(items48, batchnumber); }
				if (items49 != null && items01.Count > 0) { SaveR49_DetailTotalOrFreightAndFees(items49, batchnumber); }
				if (items55 != null && items01.Count > 0) { SaveR55_InvoiceTotals(items55, batchnumber); }
				if (items57 != null && items01.Count > 0) { SaveR57_InvoiceTrailer(items57, batchnumber); }
				if (items95 != null && items95.Count > 0) { SaveR95_InvoiceFileTrailer(items95, batchnumber); }
				result = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				result = false;
			}
			Successful= result;
		}

		public bool SaveR01_InvoiceFileHeader(List<Models.Files.Invoice.R01_InvoiceFileHeader> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.Invoice.R01_InvoiceFileHeader>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1,	"BatchId", "BatchId"),
							(2,	"FileHeader", "FileHeader"),
							(3, "SequenceNumber", "RecordSequence"),
							(4,	"IngramSAN", "IngramSAN"),
							(5,	"FileSource", "FileSource"),
							(6,	"CreationDate", "CreationDate"),
							(7,	"FileName", "FileName"),
						},
						new List<string> { "Reserved061_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR15_InvoiceHeader(List<Models.Files.Invoice.R15_InvoiceHeader> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.Invoice.R15_InvoiceHeader>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "InvoiceHeader","InvoiceHeader"),
							(3, "SequenceNumber","RecordSequence"),
							(4, "InvoiceNumber","InvoiceNumber"),
							(5, "PurchaseOrderNumber","PurchaseOrderNumber"),
							(6, "IngramShipToAccountNumber","IngramShipToAccountNumber"),
							(7, "StoreNumber","StoreNumber"),
							(8, "DCSAN","DCSAN"),
							(9, "InvoiceDate","InvoiceDate"),
						},
						new List<string> { "reserved016_021", "reserved063_065", "reserved074_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR45_InvoiceDetail(List<Models.Files.Invoice.R45_InvoiceDetail> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.Invoice.R45_InvoiceDetail>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "DetailRecord","DetailRecord"),
							( 3, "SequenceNumber","RecordSequence"),
							( 4, "InvoiceNumber","InvoiceNumber"),
							( 5, "ISBN10Shipped","ISBN10Shipped"),
							( 6, "QuantityShipped","QuantityShipped"),
							( 7, "IngramItemListPrice","IngramItemListPrice"),
							( 8, "Discount","Discount"),
							( 9, "NetPriceOrCost","NetPriceOrCost"),
							(10, "MeteredDate","MeteredDate")
						},
						new List<string> { "reserved016_021", "reserved056", "reserved061", "reserved070_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR46_DetailISBN13EAN(List<Models.Files.Invoice.R46_InvoiceDetail> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.Invoice.R46_InvoiceDetail>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1 ,"BatchId","BatchId"),
							( 2 ,"TitleRecord","TitleRecord"),
							( 3, "SequenceNumber","RecordSequence"),
							( 4 ,"InvoiceNumber","InvoiceNumber"),
							( 5 ,"ISBN13OrEANShipped","ISBN13OrEANShipped")
						},
						new List<string> { "reserved057_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR48_DetailTotal(List<Models.Files.Invoice.R48_DetailTotal> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.Invoice.R48_DetailTotal>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId", "BatchId"),
							(2, "DetailTotalRecord#1", "DetailTotalRecord#1"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "InvoiceNumber" , "InvoiceNumber"),
							(5, "Title", "Title"),
							(6, "ClientOrderID", "ClientOrderID"),
							(7, "LineItemIDNumber", "LineItemIDNumber"),
						},
						new List<string> { "reserved016_020", "reeserved06_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR49_DetailTotalOrFreightAndFees(List<Models.Files.Invoice.R49_DetailTotalOrFreightAndFees> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.Invoice.R49_DetailTotalOrFreightAndFees>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId", "BatchId"),
							( 2, "DetailTotalRecord", "DetailTotalRecord"),
							(3, "SequenceNumber", "RecordSequence"),
							( 4, "InvoiceNumber", "InvoiceNumber"),
							( 5, "TrackingNumber", "TrackingNumber"),
							( 6, "NetPrice", "NetPrice"),
							( 7, "Shipping", "Shipping"),
							( 8, "Handling", "Handling"),
							( 9, "GiftWrap", "GiftWrap"),
							(10, "AmountDue", "AmountDue"),
						},
						new List<string> { "reserved016_020", "reserved057_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR55_InvoiceTotals(List<Models.Files.Invoice.R55_InvoiceTotals> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.Invoice.R55_InvoiceTotals>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId", "BatchId"),
							(2, "InvoiceControlShippingRecord", "InvoiceControlShippingRecord"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "InvoiceNumber", "InvoiceNumber"),
							(5, "InvoiceRecordCount", "InvoiceRecordCount"),
							(6, "NumberofTitles", "NumberofTitles"),
							(7, "TotalNumberofUnits", "TotalNumberofUnits"),
							(8, "BillofLadingNumber", "BillofLadingNumber"),
							(9, "TotalInvoiceWeight", "TotalInvoiceWeight"),
						},
						new List<string> { "reserved016_020", "reserved057_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR57_InvoiceTrailer(List<Models.Files.Invoice.R57_InvoiceTrailer> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.Invoice.R57_InvoiceTrailer>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId", "BatchId"),
							(2, "InvoiceTrailer", "InvoiceTrailer"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "InvoiceNumber", "InvoiceNumber"),
							(5, "TotalNetPrice", "TotalNetPrice"),
							(6, "TotalShipping", "TotalShipping"),
							(7, "TotalHandling", "TotalHandling"),
							(8, "TotalGiftWrap", "TotalGiftWrap"),
							(9, "TotalInvoice", "TotalInvoice"),
						},
						new List<string> { "reserved038_055", "reserved079_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR95_InvoiceFileTrailer(List<Models.Files.Invoice.R95_InvoiceFileTrailer> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.Invoice.R95_InvoiceFileTrailer>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId", "BatchId"),
							(2, "InvoiceFileTrailer", "InvoiceFileTrailer"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "TotalTitles", "TotalTitles"),
							(5, "TotalInvoices", "TotalInvoices"),
							(6, "TotalUnits", "TotalUnits"),
						},
						new List<string> { "reserved036_080" }
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