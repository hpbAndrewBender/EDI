using System;

namespace FormatCDFL.Models.SQL.PurchaseAcknowledgement
{
	public class R02_FileHeader
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string FileSourceSAN { get; set; }

		public string FileSourceName { get; set; }

		public DateTime POACreationDate { get; set; }

		public string ElectronicControlUnit { get; set; }

		public string Filename { get; set; }

		public string FormatVersion { get; set; }

		public string DestinationSAN { get; set; }

		public char POAType { get; set; }
	}
}