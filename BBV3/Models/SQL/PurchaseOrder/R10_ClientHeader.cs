using System;

namespace FormatBBV3.Models.SQL.PurchaseOrder
{
	public class R10_ClientHeader
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string IngramBillToAccountNumber { get; set; }

		public string VendorSAN { get; set; }

		public DateTime OrderDate { get; set; }

		public DateTime BackorderCancellationDate { get; set; }

		public string BackorderCode { get; set; }

		public char DDCFulfillmentorSplitLineOrdering_Orderlevel { get; set; }

		public char RecipientOrShiptoAddressIndicator { get; set; }

		public char PurchasingConsumerOrOrderedByAddressIndicator { get; set; }

		public DateTime DoNotShipbeforedate { get; set; }
	}
}