namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R38_GiftMessage
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string GiftMessage { get; set; }
	}
}