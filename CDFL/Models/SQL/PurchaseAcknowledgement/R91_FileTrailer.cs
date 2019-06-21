namespace FormatCDFL.Models.SQL.PurchaseAcknowledgement
{
	public class R91_FileTrailer
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public short TotalLineItemsinFile { get; set; }

		public short TotalPOsAcknowledged { get; set; }

		public short TotalUnitsAcknowledged { get; set; }

		public short RecordCount01To09 { get; set; }

		public short RecordCount10To19 { get; set; }

		public short RecordCount20To29 { get; set; }

		public short RecordCount30To39 { get; set; }

		public short RecordCount40To49 { get; set; }

		public short RecordCount50To59 { get; set; }

		public short RecordCount60To99 { get; set; }
	}
}