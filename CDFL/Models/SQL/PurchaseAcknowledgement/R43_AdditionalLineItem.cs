using System;

namespace FormatCDFL.Models.SQL.PurchaseAcknowledgement
{
	public class R43_AdditionalLineItem
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string PublisherName { get; set; }

		public DateTime PublicationOrReleaseDate { get; set; }

		public string OriginalSeqNumber { get; set; }

		public string TotalQtyPredictedtoShipPrimary { get; set; }
	}
}