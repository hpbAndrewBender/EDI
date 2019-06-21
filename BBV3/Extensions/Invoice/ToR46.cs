using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.Invoice
{
	public static class ToR46
	{
		public static Models.SQL.Invoice.R46_DetailISBN13OrEAN ToSQL(this Models.Files.Invoice.R46_DetailISBN13OrEAN current)
		{
			Models.SQL.Invoice.R46_DetailISBN13OrEAN to = new Models.SQL.Invoice.R46_DetailISBN13OrEAN()
			{

			};
			return to;
		}

		public static Models.Files.Invoice.R46_DetailISBN13OrEAN ToFiles(this Models.SQL.Invoice.R46_DetailISBN13OrEAN current)
		{
			Models.Files.Invoice.R46_DetailISBN13OrEAN to = new Models.Files.Invoice.R46_DetailISBN13OrEAN()
			{

			};
			return to;
		}

	}
}
