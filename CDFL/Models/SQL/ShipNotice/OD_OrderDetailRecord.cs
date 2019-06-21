namespace FormatCDFL.Models.SQL.ShipNotice
{
	public class OD_OrderDetailRecord
	{
		public int Id { get; set; }

		public string OrderRecordIdentifier { get; set; }

		public string ClientOrderID { get; set; }

		public string ShippingWarehouseCode { get; set; }

		public string IngramOrderEntryNumber { get; set; }

		public short QuantityCancelled { get; set; }

		public string ISBN10Ordered { get; set; }

		public string ISBN10Shipped { get; set; }

		public short QuantityPredicted { get; set; }

		public short QuantitySlashed { get; set; }

		public short QuantityShipped { get; set; }

		public string ItemDetailStatusCode { get; set; }

		public string TrackingNumber { get; set; }

		public string SCAC { get; set; }

		public decimal IngramItemListPrice { get; set; }

		public decimal NetOrDiscountedPrice { get; set; }

		public string LineItemIDNumber { get; set; }

		public string SSL { get; set; }

		public decimal Weight { get; set; }

		public string ShippingMethodCodeorSlashOrCancelReasonCode { get; set; }

		public string ISBN13OrEANv { get; set; }
	}
}