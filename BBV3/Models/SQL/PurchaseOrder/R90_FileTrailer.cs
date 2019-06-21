namespace FormatBBV3.Models.SQL.PurchaseOrder
{
	public class R90_FileTrailer
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public short TotalLineItemsinfile { get; set; }

		public short TotalPurchaseOrderRecords { get; set; }

		public short TotalUnitsOrdered { get; set; }

		public short RecordCount00_09 { get; set; }

		public short RecordCount10_19 { get; set; }

		public short RecordCount20_29 { get; set; }

		public short RecordCount30_39 { get; set; }

		public short RecordCount40_49 { get; set; }

		public short RecordCount50_59 { get; set; }

		public short RecordCount60_69 { get; set; }

		public short RecordCount70_79 { get; set; }

		public short RecordCount80_99 { get; set; }
	}
}