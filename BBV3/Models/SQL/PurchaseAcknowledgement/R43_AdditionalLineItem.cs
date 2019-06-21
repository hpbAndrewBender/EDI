using System;

namespace FormatBBV3.Models.SQL.PurchaseAcknowledgement
{
	public class R43_AdditionalLineItem
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string PublisherAlphaCode { get; set; }

		public DateTime PublicationOrReleaseDate { get; set; }

		public short OriginalSequenceNumber { get; set; }

		public string TotalQuantityPredictedtoShipPrimary { get; set; }

		public string TotalQuantityPredictedtoShipSecondary { get; set; }
	}
}