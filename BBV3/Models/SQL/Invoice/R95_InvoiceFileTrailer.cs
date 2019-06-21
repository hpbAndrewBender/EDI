namespace FormatBBV3.Models.SQL.Invoice
{
	public class R95_InvoiceFileTrailer
	{
		public int Id { get; set; }

		public string InvoiceFileTrailer { get; set; }

		public short SequenceNumber { get; set; }

		public short TotalItems { get; set; }

		public short TotalInvoices { get; set; }

		public short TotalUnits { get; set; }
	}
}