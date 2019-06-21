namespace FormatBBV3.Models.SQL.PurchaseOrder
{
	public class R50_PurchaseOrderTrailer
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public short TotalPurchaseOrderRecords { get; set; }

		public short TotalLineItemsinfile { get; set; }

		public short TotalUnitsOrdered { get; set; }
	}
}