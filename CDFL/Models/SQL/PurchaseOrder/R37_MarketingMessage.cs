namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R37_MarketingMessage
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string MarketingMessage { get; set; }
	}
}