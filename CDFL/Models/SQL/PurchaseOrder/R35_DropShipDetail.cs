namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R35_DropShipDetail
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public decimal GiftWrapFeeAmount { get; set; }

		public bool SendConsumerEmail { get; set; }

		public bool OrderLevelGiftIndicator { get; set; }

		public bool SuppressPriceIndicator { get; set; }

		public string OrderLevelGiftWrapCode { get; set; }
	}
}