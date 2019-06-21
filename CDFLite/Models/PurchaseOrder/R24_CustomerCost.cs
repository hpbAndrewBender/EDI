using System;
using System.Collections.Generic;
using System.Text;

namespace CDFLite.Models.PurchaseOrder
{
	class R24_CustomerCost
	{
		public int Id {get; set;}

		public byte RecordCode {get; set;}

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public decimal SalesTaxPercent { get; set; }

		public decimal FreightTaxPercent { get; set; }

		public decimal FreightAmount { get; set; }
	}
}
