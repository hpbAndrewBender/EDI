using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Models.SQL.Invoice
{
	public class R15_InvoiceHeader
	{
		public int Id { get; set; }

		public short InvoiceHeader { get; set; }

		public short SequenceNumber { get; set; }

		public int InvoiceNumber { get; set; }

		public string CompanyAccountIDNumber { get; set; }

		public string WarehouseSAN { get; set; }

		public DateTime InvoiceDate { get; set; }
	}
}
