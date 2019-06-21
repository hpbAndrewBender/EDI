using System;

namespace FormatBBV3.Models.Files.Invoice.DataSequence
{
	public class InvoiceDetail : IDisposable
	{
		public InvoiceDetail()
		{
			InvoiceDetailRecord = new R45_InvoiceDetail();
			DetailISBN13OrEANRecord = new R46_DetailISBN13OrEAN();
			DetailTotalRecord = new R48_DetailTotal();
			Initialized = true;
		}

		public bool Initialized { get; private set; }
		//
		public R46_DetailISBN13OrEAN DetailISBN13OrEANRecord { get; set; }
		public R48_DetailTotal DetailTotalRecord { get; set; }
		public R45_InvoiceDetail InvoiceDetailRecord { get; set; }

		public void Dispose()
		{
			InvoiceDetailRecord = null;
			DetailISBN13OrEANRecord = null;
			DetailTotalRecord = null;
			Initialized = false;
		}
	}
}