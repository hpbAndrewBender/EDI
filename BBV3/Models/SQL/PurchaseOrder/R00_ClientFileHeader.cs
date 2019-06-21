using System;

namespace FormatBBV3.Models.SQL.PurchaseOrder
{
	public class R00_ClientFileHeader
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string FileSourceSAN { get; set; }

		public string FileSourceName { get; set; }

		public DateTime CreationDate { get; set; }

		public string Filename { get; set; }

		public string FormatVersion { get; set; }

		public string IngramSAN { get; set; }

		public char VendorNameFlag { get; set; }

		public string ProductDescription { get; set; }
	}
}