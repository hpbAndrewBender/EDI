namespace FormatCDFL.Models.SQL.PurchaseAcknowledgement
{
	public class R59_PurchaseOrderControlTotals
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public short RecordCount { get; set; }

		public short TotalLineItemsinFile { get; set; }

		public short TotalUnitsAcknowledged { get; set; }
	}
}