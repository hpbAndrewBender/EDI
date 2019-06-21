using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseAcknowledgement
{
	public static class ToR11
	{
		public static Models.SQL.PurchaseAcknowledgement.R11_PurchaseOrderHeader ToSQL(this Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader current)
		{
			Models.SQL.PurchaseAcknowledgement.R11_PurchaseOrderHeader to = new Models.SQL.PurchaseAcknowledgement.R11_PurchaseOrderHeader()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader ToFiles(this Models.SQL.PurchaseAcknowledgement.R11_PurchaseOrderHeader current)
		{
			Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader to = new Models.Files.PurchaseAcknowledgement.R11_PurchaseOrderHeader()
			{

			};
			return to;
		}

	}
}
