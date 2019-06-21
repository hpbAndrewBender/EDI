using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.Invoice
{
	public static class ToR15
	{
		public static Models.SQL.Invoice.R15_InvoiceHeader ToSQL(this Models.Files.Invoice.R15_InvoiceHeader current)
		{
			Models.SQL.Invoice.R15_InvoiceHeader to = new Models.SQL.Invoice.R15_InvoiceHeader()
			{

			};
			return to;
		}

		public static Models.Files.Invoice.R15_InvoiceHeader ToFiles(this Models.SQL.Invoice.R15_InvoiceHeader current)
		{
			Models.Files.Invoice.R15_InvoiceHeader to = new Models.Files.Invoice.R15_InvoiceHeader()
			{

			};
			return to;
		}

	}
}
