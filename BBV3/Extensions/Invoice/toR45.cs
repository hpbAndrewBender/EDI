using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.Invoice
{
	public static class ToR45
	{
		public static Models.SQL.Invoice.R45_InvoiceDetail ToSQL(this Models.Files.Invoice.R45_InvoiceDetail current)
		{
			Models.SQL.Invoice.R45_InvoiceDetail to = new Models.SQL.Invoice.R45_InvoiceDetail()
			{

			};
			return to;
		}

		public static Models.Files.Invoice.R45_InvoiceDetail ToFiles(this Models.SQL.Invoice.R45_InvoiceDetail current)
		{
			Models.Files.Invoice.R45_InvoiceDetail to = new Models.Files.Invoice.R45_InvoiceDetail()
			{

			};
			return to;
		}

	}
}
