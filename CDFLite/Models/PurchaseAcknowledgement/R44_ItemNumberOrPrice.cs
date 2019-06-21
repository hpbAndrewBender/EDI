using System;
using System.Collections.Generic;
using System.Text;

namespace CDFLite.Models.PurchaseAcknowledgement
{
	class R44_ItemNumberOrPrice
	{
		public int Id { get; set; }
		
		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public decimal NetPrice { get; set; }

		public byte ItemNumberType { get; set; }

		public decimal DiscountedListPrice { get; set; }

		public short TotalLineOrderQty { get; set; }
	}
}
