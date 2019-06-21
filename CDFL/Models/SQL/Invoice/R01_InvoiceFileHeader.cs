using System;

namespace FormatCDFL.Models.SQL.Invoice
{
	public class R01_InvoiceFileHeader
	{
		public int Id { get; set; }

		public string FileHeader { get; set; }

		public short SequenceNumber { get; set; }

		public string IngramSAN { get; set; }

		public string FileSource { get; set; }

		public DateTime CreationDate { get; set; }

		public string FileName { get; set; }
	}
}