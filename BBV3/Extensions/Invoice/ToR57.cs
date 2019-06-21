using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.Invoice
{
	public static class ToR57
	{
		public static Models.SQL.Invoice.R57_InvoiceTrailer ToSQL(this Models.Files.Invoice.R57_InvoiceTrailer current)
		{
			Models.SQL.Invoice.R57_InvoiceTrailer to = new Models.SQL.Invoice.R57_InvoiceTrailer()
			{

			};
			return to;
		}

		public static Models.Files.Invoice.R57_InvoiceTrailer ToFiles(this Models.SQL.Invoice.R57_InvoiceTrailer current)
		{
			Models.Files.Invoice.R57_InvoiceTrailer to = new Models.Files.Invoice.R57_InvoiceTrailer()
			{

			};
			return to;
		}

	}
}
