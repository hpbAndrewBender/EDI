namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R90_FileTrailer
	{
		public int Id { get; set; }

		public short RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string TotalLineItemsinfile { get; set; }

		public short TotalPurchaseOrderRecords { get; set; }

		public short TotalUnitsOrdered { get; set; }

		public short RecordCount00To09 { get; set; }

		public short RecordCount10To19 { get; set; }

		public short RecordCount20To29 { get; set; }

		public short RecordCount30To39 { get; set; }

		public short RecordCount40To49 { get; set; }

		public short RecordCount50To59 { get; set; }

		public short RecordCount60To69 { get; set; }

		public short RecordCount70To79 { get; set; }

		public short RecordCount80To99 { get; set; }
	}
}