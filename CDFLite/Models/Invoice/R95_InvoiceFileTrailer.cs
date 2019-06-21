namespace CDFLite.Models.Invoice
{
	internal class R95_InvoiceFileTrailer
	{
		public int Id { get; set; }

		public string InvoiceFileTrailer { get; set; }

		public short RecordSequence { get; set; }

		public short TotalTitles { get; set; }

		public short TotalInvoices { get; set; }

		public short TotalUnits { get; set; }
	}
}