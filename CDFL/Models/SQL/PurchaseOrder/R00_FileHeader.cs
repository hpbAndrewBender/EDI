using System;

namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R00_FileHeader
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public int SequenceNumber { get; set; }

		public string FileSourceSAN { get; set; }

		public string FileSourceName { get; set; }

		public DateTime CreationDate { get; set; }

		public string FIleName { get; set; }

		public string FormatVersion { get; set; }

		public string IngramSAN { get; set; }

		public char VendorNameFlag { get; set; }

		public string ProductDescription { get; set; }
	}
}