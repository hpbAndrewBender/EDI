namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R36_SpecialDeliveryInstructions
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string SpecialDeliveryInstructions { get; set; }
	}
}