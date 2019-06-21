namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R32_ShippingRecordRecipientAddressLine
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string RecipientAddressLine { get; set; }
	}
}