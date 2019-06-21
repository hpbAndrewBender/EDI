using System;
using System.Collections.Generic;
using System.Text;

namespace IngramContent.Models.ShipNotice
{
	public class Detail
	{
		public int Id { get; set; }

		public int OrderID { get; set; }

		public string ClientOrderID { get; set; }

		public short ShippingWarehouse { get; set; }

		public string IngramOrderEntry { get; set; }

		public string ISBN10Ordered { get; set; }

		public string ISBN10Shipped { get; set; }

		public short QuantityPredicted { get; set; }

		public short QuantitySlashed { get; set; }

		public short QuantityShipped { get; set; }

		public short ItemDetailStatusCode { get; set; }

		public string TrackingNumber { get; set; }

		public string SCAC { get; set; }

		public decimal IngramItemListPrice { get; set; }

		public decimal NetDiscountedPrice { get; set; }

		public string LineItemIDNumber { get; set; }

		public string SSL { get; set; }

		public decimal Weight { get; set; }

		public string SMCorSCRC { get; set; }

		public string ISBN13OrEAN { get; set; }

	}
}
