using System;
using System.Collections.Generic;
using System.Text;

namespace CDFLite.Models.Invoice
{
	class R49_DetailTotalOrFreightAndFees
	{
		public int Id { get; set; }

		public string DetailTotalRecord { get; set; }

		public short RecordSequence { get; set; }

		public string InvoiceNumber { get; set; }

		public string TrackingNumber { get; set; }

		public decimal NetPrice { get; set; }

		public decimal Shipping { get; set; }

		public decimal Handling { get; set; }

		public decimal GiftWrap { get; set; }

		public decimal AmountDue { get; set; }
}
}
