using System;

namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R10_ClientHeader
	{
		public int Id { get; set; }

		public short RecordCode { get; set; }
		
		public int SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string IngramBillToAccountNumber { get; set; }

		public string VendorSAN { get; set; }

		public DateTime OrderDate { get; set; }

		public DateTime BackorderCancelDate { get; set; }

		public char BackorderCode { get; set; }

		public char DDCFulfillmentOrSplitLineOrdering { get; set; }

		public bool ShipToIndicator { get; set; }

		public bool BillToIndicator { get; set; }
	}
}