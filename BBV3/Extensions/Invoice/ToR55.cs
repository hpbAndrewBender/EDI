using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.Invoice
{
	public static class ToR55
	{
		public static Models.SQL.Invoice.R55_InvoiceTotals ToSQL(this Models.Files.Invoice.R55_InvoiceTotals current)
		{
			Models.SQL.Invoice.R55_InvoiceTotals to = new Models.SQL.Invoice.R55_InvoiceTotals()
			{

			};
			return to;
		}

		public static Models.Files.Invoice.R55_InvoiceTotals ToFiles(this Models.SQL.Invoice.R55_InvoiceTotals current)
		{
			Models.Files.Invoice.R55_InvoiceTotals to = new Models.Files.Invoice.R55_InvoiceTotals()
			{

			};
			return to;
		}

	}
}
