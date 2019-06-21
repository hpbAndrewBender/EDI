namespace FormatBBV3.Models.SQL.PurchaseAcknowledgement
{
	public class R44_Item_NumberOrPrice
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string ForwardedItemNumber { get; set; }

		public decimal NetOrDiscountPrice { get; set; }

		public string ItemNumberType { get; set; }

		public short TotalLineOrderQuantity { get; set; }
	}
}