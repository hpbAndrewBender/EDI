using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Models.Files.Invoice.DataSequence
{
	public class InvoiceItem : IDisposable
	{
		public InvoiceItem()
		{
			InvoiceHeaderRecord = new R15_InvoiceHeader();
			InvoiceDetails = new List<InvoiceDetail>();
			InvoiceTotalRecord = new R55_InvoiceTotals();
			InvoiceTrailerRecord = new R57_InvoiceTrailer();
			Initialized = true;
		}


		public bool Initialized { get; private set; }
		//
		public R15_InvoiceHeader InvoiceHeaderRecord { get; set; }
		public List<InvoiceDetail> InvoiceDetails { get; set; }
		public R55_InvoiceTotals InvoiceTotalRecord { get; set; }
		public R57_InvoiceTrailer InvoiceTrailerRecord { get; set; }

		public void Dispose()
		{
			InvoiceHeaderRecord = null;
			InvoiceDetails = null;
			InvoiceTotalRecord = null;
			InvoiceTrailerRecord = null;
			Initialized = false;
		}
	}
}