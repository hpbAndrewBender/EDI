namespace FormatBBV3.Models.SQL.PurchaseOrder
{
	public class R45_Imprint
	{
		// (up to 4 occurrences)

		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public char ImprintCode { get; set; }

		public string ImprintTextandSymbols { get; set; }

		public char ImprintFontCode { get; set; }

		public char ImprintColorCode { get; set; }

		public char ImprintPositionCode { get; set; }

		public char ImprintAppendCode { get; set; }
	}
}