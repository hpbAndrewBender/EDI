namespace FormatBBV3.Models.SQL.PurchaseOrder
{
	public class R21_PurchaseOrderOptions
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string IngramShipToAccountNumber { get; set; }

		public string POType { get; set; }

		public string OrderTypeCode { get; set; }

		public char DCCode { get; set; }

		public char BackorderHoldAndReleaseIndicator { get; set; }

		public char ExtendedPOAStatusCodes { get; set; }

		public char DCPairs { get; set; }

		public char POATypeCode { get; set; }

		public string IngramShipToAccountPassword { get; set; }

		public string CarrierOrShippingMethod { get; set; }

		public char SplitLineIndicator_OrderLevel { get; set; }
	}
}