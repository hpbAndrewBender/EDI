using System;

namespace CDFLite.Models.PurchaseAcknowledgement
{
	internal class R41_AdditionalDetail
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public DateTime AvailabilityDate { get; set; }

		public string DCInventoryInformation { get; set; }
	}
}