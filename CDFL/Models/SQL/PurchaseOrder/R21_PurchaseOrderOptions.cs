namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R21_PurchaseOrderOptions
	{
		public int Id { get; set; }
		public byte RecordCode { get; set; }

		public int SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string IngramShipToAccountNumber { get; set; }

		public char POType { get; set; }

		public string OrderType { get; set; }

		public char DCCode { get; set; }

		public char Greenlight { get; set; }

		public char POAType { get; set; }

		public string ShipToPassword { get; set; }

		public string CarrierOrShippingMethod { get; set; }

		public bool SplitOrderAcrossDCsAllowed { get; set; }
	}
}