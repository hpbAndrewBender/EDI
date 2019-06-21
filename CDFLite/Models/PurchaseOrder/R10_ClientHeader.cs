using System;

namespace CDFLite.Models.PurchaseOrder
{
	internal class R10_ClientHeader
	{
		private int Id { get; set; }

		private short RecordCode { get; set; }
		
		private int SequenceNumber {  get; set;  }
		private string PONumber { get; set; }

		private string IngramBillToAccountNumber { get; set; }

		private string VendorSAN { get; set; }

		private DateTime OrderDate { get; set; }

		private DateTime BackorderCancelDate { get; set; }

		private char BackorderCode { get; set; }

		private char DDCFulfillmentOrSplitLineOrdering { get; set; }

		private bool ShipToIndicator { get; set; }

		private bool BillToIndicator { get; set; }
	}
}