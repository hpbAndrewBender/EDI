namespace FormatCDFL.Models.SQL.Invoice
{
	public class R46_InvoiceDetail
	{
		public int Id { get; set; }

		public string TitleRecord { get; set; }

		public byte SequenceNumber { get; set; }

		public string InvoiceNumber { get; set; }

		public string ISBN13OrEANShipped { get; set; }
	}
}