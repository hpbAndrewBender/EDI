using System;
using System.Collections.Generic;

namespace FormatBBV3.Models.Files.Invoice.DataSequence
{
	public class V3 : IDisposable
	{
		public V3()
		{
			InvoiceFileHeaderRecord = new R01_InvoiceFileHeader();
			Invoices = new List<InvoiceItem>();
			InvoiceFileTrailer = new R95_InvoiceFileTrailer();
			Initialized = true;
		}

		public bool Initialized { get; private set; }
		//
		public R01_InvoiceFileHeader InvoiceFileHeaderRecord { get; set; }
		public List<InvoiceItem> Invoices { get; set; }
		public R95_InvoiceFileTrailer InvoiceFileTrailer { get; set; }

		public void Dispose()
		{
			InvoiceFileHeaderRecord = null;
			Invoices = null;
			InvoiceFileTrailer = null;
			Initialized = false;
		}
	}
}