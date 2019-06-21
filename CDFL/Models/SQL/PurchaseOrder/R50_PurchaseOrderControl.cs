namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R50_PurchaseOrderControl
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public short TotalPurchaseOrderRecords { get; set; }

		public short TotalLineItemsinfile { get; set; }

		public short TotalUnitsOrdered { get; set; }
	}
}