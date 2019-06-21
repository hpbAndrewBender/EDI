using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseAcknowledgement
{
	public static class ToR21
	{
		public static Models.SQL.PurchaseAcknowledgement.R21_FreeFormVendor ToSQL(this Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor current)
		{
			Models.SQL.PurchaseAcknowledgement.R21_FreeFormVendor to = new Models.SQL.PurchaseAcknowledgement.R21_FreeFormVendor()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor ToFiles(this Models.SQL.PurchaseAcknowledgement.R21_FreeFormVendor current)
		{
			Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor to = new Models.Files.PurchaseAcknowledgement.R21_FreeFormVendor()
			{

			};
			return to;
		}

	}
}
