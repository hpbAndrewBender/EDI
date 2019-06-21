namespace FormatBBV3.Models.SQL.Invoice
{
	public class R16_InvoiceVendorDetail
	{
		public int Id { get; set; }

		public string RecordType { get; set; }

		public short SequenceNumber { get; set; }

		public short InvoiceNumber { get; set; }

		public char DCCode { get; set; }

		public string IngramOrderEntryNumber { get; set; }
	}
}