namespace FormatBBV3.Models.SQL.PurchaseOrder
{
	public class R20_FixedSpecialHandlingInstructions
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public char SpecialHandlingPrefix { get; set; }

		public string SpecialHandlingCodes { get; set; }
	}
}