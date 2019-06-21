using System;
using System.Collections.Generic;
using System.Text;

namespace IngramContent.Models.ShipNotice
{
	public class Order
	{
		public int Id { get; set; }

		public int CompanyID { get; set; }

		public short OrderStatusCode { get; set; }

		public decimal OrderSubtotal { get; set; }

		public decimal OrderDiscountAmount { get; set; }

		public decimal SalesTax { get; set; }

		public decimal ShippingHandling { get; set; }

		public decimal OrderTotal { get; set; }

		public decimal FreightCharge { get; set; }

		public short TotalItemDetailCount { get; set; }

		public DateTime ShipmentDate { get; set; }

		public string ConsumerPONumber { get; set; }
	}
}
