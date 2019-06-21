using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.Invoice
{
	public static class ToR46
	{
		public static Models.SQL.Invoice.R46_InvoiceDetail ToSQL(this Models.Files.Invoice.R46_InvoiceDetail current)
		{
			Models.SQL.Invoice.R46_InvoiceDetail to = new Models.SQL.Invoice.R46_InvoiceDetail()
			{

			};
			return to;
		}

		public static Models.Files.Invoice.R46_InvoiceDetail ToFiles(this Models.SQL.Invoice.R46_InvoiceDetail current)
		{
			Models.Files.Invoice.R46_InvoiceDetail to = new Models.Files.Invoice.R46_InvoiceDetail()
			{

			};
			return to;
		}

	}
}
