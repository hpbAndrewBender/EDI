using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.Invoice
{
	public static class ToR16
	{
		public static Models.SQL.Invoice.R16_InvoiceVendorDetail ToSQL(this Models.Files.Invoice.R16_InvoiceVendorDetail current)
		{
			Models.SQL.Invoice.R16_InvoiceVendorDetail to = new Models.SQL.Invoice.R16_InvoiceVendorDetail()
			{

			};
			return to;
		}

		public static Models.Files.Invoice.R16_InvoiceVendorDetail ToFiles(this Models.SQL.Invoice.R16_InvoiceVendorDetail current)
		{
			Models.Files.Invoice.R16_InvoiceVendorDetail to = new Models.Files.Invoice.R16_InvoiceVendorDetail()
			{

			};
			return to;
		}

	}
}
