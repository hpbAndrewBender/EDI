using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Models.Files.Invoice.DataSequence
{
	public class InvoiceDetail : IDisposable
	{
		public InvoiceDetail()
		{
			InvoiceDetailRecord = new R45_InvoiceDetail();
			InvoiceDetail2Record = new R46_InvoiceDetail();
			DetailTotalRecord = new R48_DetailTotal();
			DetailTotalOrFreightAndFeesRecord = new R49_DetailTotalOrFreightAndFees();
			InvoiceTotalRecord = new R55_InvoiceTotals();
			InvoiceTrailerRecord = new R57_InvoiceTrailer();
			Initialized = true;
		}

		public bool Initialized { get; private set; }
		//
		public R45_InvoiceDetail InvoiceDetailRecord { get; set; }
		public R46_InvoiceDetail InvoiceDetail2Record { get; set; }
		public R48_DetailTotal DetailTotalRecord { get; set; }
		public R49_DetailTotalOrFreightAndFees DetailTotalOrFreightAndFeesRecord { get; set; }
		public R55_InvoiceTotals InvoiceTotalRecord { get; set; }
		public R57_InvoiceTrailer InvoiceTrailerRecord { get; set; }

		public void Dispose()
		{
			InvoiceDetailRecord = null;
			InvoiceDetail2Record = null;
			DetailTotalRecord = null;
			DetailTotalOrFreightAndFeesRecord = null;
			InvoiceTotalRecord = null;
			InvoiceTrailerRecord = null;
			Initialized = false;
		}
	}
}
