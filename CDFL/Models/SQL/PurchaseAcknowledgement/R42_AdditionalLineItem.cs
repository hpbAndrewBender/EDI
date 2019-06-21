namespace FormatCDFL.Models.SQL.PurchaseAcknowledgement
{
	public class R42_AdditionalLineItem
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string Title { get; set; }

		public string Author { get; set; }

		public char BindingCode { get; set; }
	}
}