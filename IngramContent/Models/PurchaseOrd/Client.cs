using System;
using System.Collections.Generic;
using System.Text;

namespace IngramContent.Models.PurchaseOrd
{
	class Client
	{
		public int Idint { get; set; }

		public int FileId { get; set; }

		public short Head_SequenceNumber { get; set; }

		public string Head_PONumber { get; set; }

		public string Head_IngramBillToAccount { get; set; }

		public string Head_VendorSAN { get; set; }

		public DateTime Head_OrderDate { get; set; }

		public DateTime Head_BackorderCancelDate { get; set; }

		public char Head_BackOrderCode { get; set; }

		public bool Head_DCCFullfillment { get; set; }
		
		public bool Head_ShipToIndicator { get; set; }

		public short Foot_TotalPurchaseOrderRecords { get; set; }

		public short Foot_TotalUnitsOrdered { get; set; }
	}
}
