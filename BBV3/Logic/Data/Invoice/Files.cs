using FileHelpers;
using CommonLib.Logic;
using CommonLib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FormatBBV3.Logic.Data.Invoice
{
	public class Files : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		public int CreateBatch(string filename,string vendor)
		{
			int batchnumber = 0;
			try
			{
				batchnumber = CommonLib.Logic.Globals.CreateBatch("BBV3", filename, vendor, 4);
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return batchnumber;
		}

		public bool WriteFile(string filename, Models.Files.Invoice.DataSequence.V3 data)
		{
			List<object> writelist = new List<object>();
			List<(string code, Type type)> used = new List<(string code, Type type)>();
			bool success = false;
			try
			{
				//build list
				writelist.Add(data.InvoiceFileHeaderRecord);
				//++if((from u in used where u.code == data.InvoiceFileHeaderRecord.InvoiceFileHeader select u.code).Count() == 0) { used.Add((data.InvoiceFileHeaderRecord.InvoiceFileHeader,typeof(Models.Files.Invoice.R01_InvoiceFileHeader)); }
				if (data.Invoices != null && data.Invoices.Count > 0)
				{
					foreach (Models.Files.Invoice.DataSequence.InvoiceItem item in data.Invoices)
					{
						if (Common.IsValid(item.InvoiceHeaderRecord)) { writelist.Add(item.InvoiceHeaderRecord); }
						if (Common.IsValid(item.InvoiceVendorDetailRecord)) { writelist.Add(item.InvoiceVendorDetailRecord); }
						foreach (Models.Files.Invoice.DataSequence.InvoiceDetail detail in item.InvoiceDetails)
						{
							if (Common.IsValid(detail.InvoiceDetailRecord)) { writelist.Add(detail.InvoiceDetailRecord); }
							if (Common.IsValid(detail.DetailISBN13OrEANRecord)) { writelist.Add(detail.DetailISBN13OrEANRecord); }
							if (Common.IsValid(detail.DetailTotalRecord)) { writelist.Add(detail.DetailTotalRecord); }
						}
						if (Common.IsValid(item.InvoiceTotalRecord)) { writelist.Add(item.InvoiceTotalRecord); }
						if (Common.IsValid(item.InvoiceTrailerRecord)) { writelist.Add(item.InvoiceTrailerRecord); }
					}
				}
				if (Common.IsValid(data.InvoiceFileTrailer,false)) { writelist.Add(data.InvoiceFileTrailer); }
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.Invoice.R01_InvoiceFileHeader),
					typeof(Models.Files.Invoice.R15_InvoiceHeader),
					typeof(Models.Files.Invoice.R16_InvoiceVendorDetail),
					typeof(Models.Files.Invoice.R45_InvoiceDetail),
					typeof(Models.Files.Invoice.R46_DetailISBN13OrEAN),
					typeof(Models.Files.Invoice.R48_DetailTotal),
					typeof(Models.Files.Invoice.R55_InvoiceTotals),
					typeof(Models.Files.Invoice.R57_InvoiceTrailer),
					typeof(Models.Files.Invoice.R95_InvoiceFileTrailer)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.Invoice.Selectors.V3.Custom)
				};
				engine.WriteFile(filename, writelist.ToArray());
				success = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				success = false;
			}
			return success;
		}

		public Models.Files.Invoice.DataSequence.V3 ReadFile(string filename ,int batchnumber)
		{
			List<Models.Files.Invoice.R01_InvoiceFileHeader> r01 = null;
			List<Models.Files.Invoice.R15_InvoiceHeader> r15 = null;
			List<Models.Files.Invoice.R16_InvoiceVendorDetail> r16 = null;
			List<Models.Files.Invoice.R45_InvoiceDetail> r45 = null;
			List<Models.Files.Invoice.R46_DetailISBN13OrEAN> r46 = null;
			List<Models.Files.Invoice.R48_DetailTotal> r48 = null;
			List<Models.Files.Invoice.R55_InvoiceTotals> r55 = null;
			List<Models.Files.Invoice.R57_InvoiceTrailer> r57 = null;
			List<Models.Files.Invoice.R95_InvoiceFileTrailer> r95 = null;
			//
			Models.Files.Invoice.DataSequence.V3 file = null;
			Models.Files.Invoice.DataSequence.InvoiceItem invoice = null;
			Models.Files.Invoice.DataSequence.InvoiceDetail detail = null;
			//
			string typename = string.Empty;
			int invoiceCount = 0;
			int detailCount = 0;
			bool savedok = false;

			try
			{
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.Invoice.R01_InvoiceFileHeader),
					typeof(Models.Files.Invoice.R15_InvoiceHeader),
					typeof(Models.Files.Invoice.R16_InvoiceVendorDetail),
					typeof(Models.Files.Invoice.R45_InvoiceDetail),
					typeof(Models.Files.Invoice.R46_DetailISBN13OrEAN),
					typeof(Models.Files.Invoice.R48_DetailTotal),
					typeof(Models.Files.Invoice.R55_InvoiceTotals),
					typeof(Models.Files.Invoice.R57_InvoiceTrailer),
					typeof(Models.Files.Invoice.R95_InvoiceFileTrailer)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.Invoice.Selectors.V3.Custom)
				};

				var res = engine.ReadFile(filename);

				if (res != null && res.Length > 0)
				{
					file = new Models.Files.Invoice.DataSequence.V3();
					foreach (var rec in res)
					{
						typename = rec.GetType().Name.ToUpper();
						switch (typename)
						{
							case "R01_INVOICEFILEHEADER":
								Common.Initialize(ref r01);
								r01.Add((Models.Files.Invoice.R01_InvoiceFileHeader)rec);
								file.InvoiceFileHeaderRecord = r01.LastItem();
								break;

							case "R15_INVOICEHEADER":
								Common.Initialize(ref r15);
								r15.Add((Models.Files.Invoice.R15_InvoiceHeader)rec);
								if (invoiceCount > 0)
								{
									if (invoice != null)
									{
										file.Invoices.Add(invoice);
										invoice = null;
									}
								}
								invoiceCount++;
								if (invoice == null) { invoice = new Models.Files.Invoice.DataSequence.InvoiceItem(); }
								invoice.InvoiceHeaderRecord = r15.LastItem();
								break;

							case "R16_INVOICEVENDORDETAIL":
								Common.Initialize(ref r16);
								r16.Add((Models.Files.Invoice.R16_InvoiceVendorDetail)rec);
								invoice.InvoiceVendorDetailRecord = r16.LastItem();
								break;

							case "R45_INVOICEDETAIL":
								Common.Initialize(ref r45);
								r45.Add((Models.Files.Invoice.R45_InvoiceDetail)rec);
								if (detailCount > 0)
								{
									if (detail != null)
									{
										invoice.InvoiceDetails.Add(detail);
										detail= null;
									}
								}
								detailCount++;
								if (detail == null) { detail = new Models.Files.Invoice.DataSequence.InvoiceDetail(); }
								detail.InvoiceDetailRecord = r45.LastItem();
								break;

							case "R46_DETAILISBN13OREAN":
								Common.Initialize(ref r46);
								r46.Add((Models.Files.Invoice.R46_DetailISBN13OrEAN)rec);
								detail.DetailISBN13OrEANRecord = r46.LastItem();
								break;

							case "R48_DETAILTOTAL":
								Common.Initialize(ref r48);
								r48.Add((Models.Files.Invoice.R48_DetailTotal)rec);
								detail.DetailTotalRecord = r48.LastItem();
								break;

							case "R55_INVOICETOTALS":
								Common.Initialize(ref r55);
								r55.Add((Models.Files.Invoice.R55_InvoiceTotals)rec);
								invoice.InvoiceTotalRecord = r55.LastItem();
								if (detail != null)
								{
									invoice.InvoiceDetails.Add(detail);
									detail = null;
								}
								break;

							case "R57_INVOICETRAILER":
								Common.Initialize(ref r57);
								r57.Add((Models.Files.Invoice.R57_InvoiceTrailer)rec);
								invoice.InvoiceTrailerRecord = r57.LastItem();
								if (detail != null)
								{
									invoice.InvoiceDetails.Add(detail);
									detail = null;
								}
								break;

							case "R95_INVOICEFILETRAILER":
								Common.Initialize(ref r95);
								r95.Add((Models.Files.Invoice.R95_InvoiceFileTrailer)rec);
								file.InvoiceFileTrailer = r95.LastItem();
								break;
						}
					}
					if (invoice != null)
					{
						file.Invoices.Add(invoice);						
						invoice = null;
					}
					using (SQL sql = new SQL(batchnumber, r01, r15, r16, r45, r46, r48, r55, r57, r95)) { savedok = sql.Successful; }
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