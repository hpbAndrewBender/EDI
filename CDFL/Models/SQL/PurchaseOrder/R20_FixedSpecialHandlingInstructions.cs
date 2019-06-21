namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R20_FixedSpecialHandlingInstructions
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public int SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string SpecialHandlingCodes { get; set; }
	}
}