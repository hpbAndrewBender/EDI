using System;

namespace FormatBBV3.Models.SQL.PurchaseOrder
{
	public class R41_AdditionalLineItemDetail
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public DateTime BackorderCancellationDate_LineLevel { get; set; }

		public short OrderQuantity { get; set; }

		public string ClientItemNumber { get; set; }
	}
}