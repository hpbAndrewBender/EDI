using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Models.Files.Invoice.DataSequence
{
	public class V3 : IDisposable
	{
		public V3()
		{
			InvoiceFileHeaderRecord = new R01_InvoiceFileHeader();
			Invoices = new List<InvoiceItem>();
			InvoiceFileTrailerRecord = new R95_InvoiceFileTrailer();
			Initialized = true;
		}

		public bool Initialized { get; private set; }
		//
		public R01_InvoiceFileHeader InvoiceFileHeaderRecord { get; set; }
		public List<InvoiceItem> Invoices { get; set; }
		public R95_InvoiceFileTrailer InvoiceFileTrailerRecord { get; set; }

		public void Dispose()
		{
			InvoiceFileTrailerRecord = null;
			Invoices = null;
			InvoiceFileTrailerRecord = null;
			Initialized = false;
		}
	}
}
