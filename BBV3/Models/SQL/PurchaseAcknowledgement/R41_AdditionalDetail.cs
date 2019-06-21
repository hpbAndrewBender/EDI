using System;

namespace FormatBBV3.Models.SQL.PurchaseAcknowledgement
{
	public class R41_AdditionalDetail
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public char DCCodeSecondaryDC { get; set; }

		public string AvailabilityDate { get; set; }

		public string DCInventoryInformation { get; set; }
	}
}