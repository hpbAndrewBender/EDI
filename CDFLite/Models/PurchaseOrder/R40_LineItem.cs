namespace CDFLite.Models.PurchaseOrder
{
	internal class R40_LineItem
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string LineItemPONumber { get; set; }

		public string ItemNumber { get; set; }

		public char LineLevelBackorderCode { get; set; }

		public string SpecialActionCode { get; set; }

		public string ItemNumberType { get; set; }
	}
}