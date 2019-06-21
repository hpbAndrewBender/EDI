namespace FormatBBV3.Models.SQL.ShipNotice
{
	public class OD_ASNShipmentDetail
	{
		public int Id { get; set; }

		public string DetailRecordIdentifier { get; set; }

		public string LineItemIDNumber { get; set; }

		public string ISBN13OrEAN { get; set; }

		public short QuantityPredictedtoShip { get; set; }

		public short QuantityShipped { get; set; }

		public decimal IngramItemListPrice { get; set; }

		public decimal NetOrDiscountedPrice { get; set; }
	}
}