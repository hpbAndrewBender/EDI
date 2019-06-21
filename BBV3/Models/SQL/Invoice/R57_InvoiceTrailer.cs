namespace FormatBBV3.Models.SQL.Invoice
{
	public class R57_InvoiceTrailer
	{
		public int Id { get; set; }

		public string InvoiceTrailer { get; set; }

		public short SequenceNumber { get; set; }

		public short InvoiceNumber { get; set; }

		public decimal TotalNetPrice { get; set; }

		public decimal TotalTaxes { get; set; }

		public decimal TotalShipping { get; set; }

		public decimal TotalVAT { get; set; }

		public decimal TotalDuty { get; set; }

		public decimal TotalInvoiceAmount { get; set; }
	}
}