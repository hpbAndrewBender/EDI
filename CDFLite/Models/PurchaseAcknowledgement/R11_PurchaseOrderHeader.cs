using System;

namespace CDFLite.Models.PurchaseAcknowledgement
{
	internal class R11_PurchaseOrderHeader
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string TOC { get; set; }

		public string PONumber { get; set; }

		public string ICGShipToAccountNumber { get; set; }

		public string ICGSAN { get; set; }

		public char POStatus { get; set; }

		public DateTime AcknowledgmentDate { get; set; }

		public DateTime PODate { get; set; }

		public DateTime POCancellationDate { get; set; }
	}
}