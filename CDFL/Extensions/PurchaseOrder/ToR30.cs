using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR30
	{
		public static Models.SQL.PurchaseOrder.R30_RecipientShipToName ToSQL(this Models.Files.PurchaseOrder.R30_RecipientShipToName current)
		{
			Models.SQL.PurchaseOrder.R30_RecipientShipToName to = new Models.SQL.PurchaseOrder.R30_RecipientShipToName()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R30_RecipientShipToName ToFiles(this Models.SQL.PurchaseOrder.R30_RecipientShipToName current)
		{
			Models.Files.PurchaseOrder.R30_RecipientShipToName to = new Models.Files.PurchaseOrder.R30_RecipientShipToName()
			{

			};
			return to;
		}
	}
}
