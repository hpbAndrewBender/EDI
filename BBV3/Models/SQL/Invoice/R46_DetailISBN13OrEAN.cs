namespace FormatBBV3.Models.SQL.Invoice
{
	public class R46_DetailISBN13OrEAN
	{
		public int Id { get; set; }

		public string DetailISBN13OrEANRecord { get; set; }

		public short SequenceNumber { get; set; }

		public short InvoiceNumber { get; set; }

		public string LineItemIDNumber { get; set; }

		public string ISBN13OrEANShipped { get; set; }
	}
}