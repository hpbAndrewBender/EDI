namespace FormatBBV3.Models.SQL.Invoice
{
	public class R45_InvoiceDetail
	{
		public int Id { get; set; }

		public string InvoiceDetail { get; set; }

		public short SequenceNumber { get; set; }

		public short InvoiceNumber { get; set; }

		public string PONumber { get; set; }

		public short QuantityShipped { get; set; }

		public short IngramItemListPrice { get; set; }

		public decimal DiscountPercent { get; set; }

		public decimal NetPriceOrCost { get; set; }
	}
}