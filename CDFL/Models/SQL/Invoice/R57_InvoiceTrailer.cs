namespace FormatCDFL.Models.SQL.Invoice
{
	public class R57_InvoiceTrailer
	{
		public int Id { get; set; }

		public string InvoiceTrailer { get; set; }

		public short SequenceNumber { get; set; }

		public string InvoiceNumber { get; set; }

		public decimal TotalNetPrice { get; set; }

		public decimal TotalShipping { get; set; }

		public decimal TotalHandling { get; set; }

		public decimal TotalGiftWrap { get; set; }

		public decimal TotalInvoice { get; set; }
	}
}