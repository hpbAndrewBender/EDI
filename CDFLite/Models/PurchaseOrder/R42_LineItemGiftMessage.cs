namespace CDFLite.Models.PurchaseOrder
{
	internal class R42_LineItemGiftMessage
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string LineLevelGiftMessage { get; set; }
	}
}