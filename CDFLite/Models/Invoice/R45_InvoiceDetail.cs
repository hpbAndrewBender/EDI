using System;

namespace CDFLite.Models.Invoice
{
	internal class R45_InvoiceDetail
	{
		public int Id { get; set; }

		public string DetailRecord { get; set; }

		public short RecordSequence { get; set; }

		public string InvoiceNumber { get; set; }

		public string ISBN10Shipped { get; set; }

		public short QuantityShipped { get; set; }

		public decimal IngramItemListPrice { get; set; }

		public decimal Discount { get; set; }

		public decimal NetPriceOrCost { get; set; }

		public DateTime MeteredDate { get; set; }
	}
}