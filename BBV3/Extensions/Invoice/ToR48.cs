using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.Invoice
{
	public static class ToR48
	{
		public static Models.SQL.Invoice.R48_DetailTotal ToSQL(this Models.Files.Invoice.R48_DetailTotal current)
		{
			Models.SQL.Invoice.R48_DetailTotal to = new Models.SQL.Invoice.R48_DetailTotal()
			{

			};
			return to;
		}

		public static Models.Files.Invoice.R48_DetailTotal ToFiles(this Models.SQL.Invoice.R48_DetailTotal current)
		{
			Models.Files.Invoice.R48_DetailTotal to = new Models.Files.Invoice.R48_DetailTotal()
			{

			};
			return to;
		}

	}
}
