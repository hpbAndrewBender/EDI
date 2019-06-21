using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.Invoice
{
	public static class ToR95
	{
		public static Models.SQL.Invoice.R95_InvoiceFileTrailer ToSQL(this Models.Files.Invoice.R95_InvoiceFileTrailer current)
		{
			Models.SQL.Invoice.R95_InvoiceFileTrailer to = new Models.SQL.Invoice.R95_InvoiceFileTrailer()
			{

			};
			return to;
		}

		public static Models.Files.Invoice.R95_InvoiceFileTrailer ToFiles(this Models.SQL.Invoice.R95_InvoiceFileTrailer current)
		{
			Models.Files.Invoice.R95_InvoiceFileTrailer to = new Models.Files.Invoice.R95_InvoiceFileTrailer()
			{

			};
			return to;
		}

	}
}
