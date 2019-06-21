using System;
using System.Collections.Generic;

namespace FormatBBV3.Logic.Data.Invoice
{
	public class SQL : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private string ActionType { get; set; } = "Invoice";
		private string FileFormat { get; set; } = "BBV3";

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
						new List<(int order, string ColumnSource, string ColumnDesc)>
						{
							(1, "BatchId", "BatchId"),
							(2, "InvoiceFileHeader","InvoiceFileHeader"),
							(3, "RecordSequenceNumber","RecordSequenceNumber"),
							(4, "IngramSAN","IngramSAN"),
							(5, "FileSource","FileSource"),
							(6, "CreationDate", "CreationDate"),
							(7, "FileName", "FileName"),
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
							(3, "RecordSequenceNumber","RecordSequenceNumber"),
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

		public bool SaveR16_InvoiceVendorDetail(List<Models.Files.Invoice.R16_InvoiceVendorDetail> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.Invoice.R16_InvoiceVendorDetail>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordType","RecordType"),
							(3, "RecordSequencenumber","RecordSequencenumber"),
							(4, "InvoiceNumber","InvoiceNumber"),
							(5, "DCCode","DCCode"),
							(6, "IngramOrderEntryNumber","IngramOrderEntryNumber"),
						},
						new List<string> { "reserved028_080" }
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
							(1, "BatchId","BatchId"),
							(2, "InvoiceDetail","InvoiceDetail"),
							(3, "RecordSequenceNumber","RecordSequenceNumber"),
							(4, "InvoiceNumber","InvoiceNumber"),
							(5, "PONumber","PONumber"),
							(6, "QuantityShipped","QuantityShipped"),
							(7, "IngramItemListPrice","IngramItemListPrice"),
							(8, "DiscountPercent","DiscountPercent"),
							(9, "NetPriceOrCost","NetPriceOrCost"),
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

		public bool SaveR46_DetailISBN13EAN(List<Models.Files.Invoice.R46_DetailISBN13OrEAN> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.Invoice.R46_DetailISBN13OrEAN>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "DetailISBN13OrEANRecord","DetailISBN13OrEANRecord"),
							(3, "RecordSequenceNumber","RecordSequenceNumber"),
							(4, "InvoiceNumber","InvoiceNumber"),
							(5, "LineItemIDNumber","LineItemIDNumber"),
							(6, "ISBN13OrEANShipped","ISBN13OrEANShipped"),
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
							(1, "BatchId","BatchId"),
							(2, "DetailTotal","DetailTotal"),
							(3, "RecordSequenceNumber","RecordSequenceNumber"),
							(4, "InvoiceNumber","InvoiceNumber"),
							(5, "Title","Title"),
							(6, "CustomerPONumber","CustomerPONumber"),
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
							(1, "BatchId","BatchId"),
							(2, "InvoiceTotal","InvoiceTotal"),
							(3, "RecordSequenceNumber","RecordSequenceNumber"),
							(4, "InvoiceNumber","InvoiceNumber"),
							(5, "InvoiceRecordCount","InvoiceRecordCount"),
							(6, "NumberofItems","NumberofItems"),
							(7, "TotalNumberofUnits","TotalNumberofUnits"),},
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
							(1, "BatchId","BatchId"),
							(1, "InvoiceTrailer","InvoiceTrailer"),
							(1, "RecordSequenceNumber","RecordSequenceNumber"),
							(1, "InvoiceNumber", "InvoiceNumber"),
							(1, "TotalNetPrice", "TotalNetPrice"),
							(1, "TotalTaxes","TotalTaxes"),
							(1, "TotalShipping","TotalShipping"),
							(1, "TotalVAT","TotalVAT"),
							(1, "TotalDuty","TotalDuty"),
							(1, "TotalInvoiceAmount","TotalInvoiceAmount")
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
							(1, "BatchId","BatchId"),
							(2, "InvoiceFileTrailer","InvoiceFileTrailer"),
							(3, "RecordSequenceNumber","RecordSequenceNumber"),
							(4, "TotalItems","TotalItems"),
							(5, "TotalInvoices","TotalInvoices"),
							(6, "TotalUnits","TotalUnits"),
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