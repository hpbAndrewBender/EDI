using System;
using System.Collections.Generic;
using System.Text;

namespace CDFLite.Models.ShipNotice
{
	class OR_OrderRecord
	{
		public int Id { get; set; }

		public string OrderRecordIdentifier { get; set; }

		public string ClientOrderID { get; set; }

		public string OrderStatusCode { get; set; }

		public decimal OrderSubtotal { get; set; }

		public decimal OrderDiscountAmount { get; set; }

		public decimal SalesTax { get; set; }

		public decimal ShippingandHandling { get; set; }

		public decimal OrderTotal { get; set; }

		public decimal FreightCharge { get; set; }

		public short TotalItemDetailCount { get; set; }

		public DateTime ShipmentDate { get; set; }

		public string ConsumerPONumber { get; set; }
	}
}
