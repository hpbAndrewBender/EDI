using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.Invoice
{
	public static class ToR01
	{
		public static Models.SQL.Invoice.R01_InvoiceFileHeader ToSQL(this Models.Files.Invoice.R01_InvoiceFileHeader current)
		{
			Models.SQL.Invoice.R01_InvoiceFileHeader to = new Models.SQL.Invoice.R01_InvoiceFileHeader()
			{

			};
			return to;
		}

		public static Models.Files.Invoice.R01_InvoiceFileHeader ToFiles(this Models.SQL.Invoice.R01_InvoiceFileHeader current)
		{
			Models.Files.Invoice.R01_InvoiceFileHeader to = new Models.Files.Invoice.R01_InvoiceFileHeader()
			{

			};
			return to;
		}
	}
}
