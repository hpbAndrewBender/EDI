namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R45_Imprint
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public char ImprintOrIndexCode { get; set; }

		public string ImprintTextandSymbols { get; set; }

		public char ImprintFontCode { get; set; }

		public char ImprintColorCode { get; set; }

		public char ImprintPositionCode { get; set; }

		public char ImprintAppendCode { get; set; }
	}
}