namespace FormatBBV3.Models.SQL.PurchaseOrder
{
	public class R40_LineItemDetail
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string LineItemPONumber { get; set; }

		public string ItemNumber { get; set; }

		public char BackorderCode_Linelevel { get; set; }

		public string SpecialActionCode { get; set; }

		public char DDCFulfillmentorSplitLineOrdering_Linelevel { get; set; }

		public string ItemNumberType { get; set; }
	}
}