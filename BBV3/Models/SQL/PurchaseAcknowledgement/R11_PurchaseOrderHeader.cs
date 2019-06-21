using System;

namespace FormatBBV3.Models.SQL.PurchaseAcknowledgement
{
	public class R11_PurchaseOrderHeader
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string TerminalOrderControlNumber { get; set; }

		public string PONumber { get; set; }

		public string IngramShipToAccountNumber { get; set; }

		public string IngramSAN { get; set; }

		public char POStatus { get; set; }

		public DateTime AcknowledgmentDate { get; set; }

		public DateTime PODate { get; set; }

		public DateTime POCancellationDate { get; set; }
	}
}