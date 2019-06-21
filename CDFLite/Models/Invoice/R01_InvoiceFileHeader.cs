using System;
using System.Collections.Generic;
using System.Text;

namespace CDFLite.Models.Invoice
{
	class R01_InvoiceFileHeader
	{
		public int Id { get; set; }

		public string FileHeader { get; set; }

		public short RecordSequence { get; set; }

		public string IngramSAN { get; set; }

		public string FileSource { get; set; }

		public DateTime CreationDate { get; set; }

		public string FileName { get; set; }
	}
}
