using System;

namespace FormatCDFL.Models.SQL.PurchaseAcknowledgement
{
	public class R41_AdditionalDetail
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string AvailabilityDate { get; set; }

		public string DCInventoryInformation { get; set; }
	}
}