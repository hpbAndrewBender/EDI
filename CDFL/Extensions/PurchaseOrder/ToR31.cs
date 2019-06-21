using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR31
	{
		public static Models.SQL.PurchaseOrder.R31_RecipientShipToPhone ToSQL(this Models.Files.PurchaseOrder.R31_RecipientShipToPhone current)
		{
			Models.SQL.PurchaseOrder.R31_RecipientShipToPhone to = new Models.SQL.PurchaseOrder.R31_RecipientShipToPhone()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R31_RecipientShipToPhone ToFiles(this Models.SQL.PurchaseOrder.R31_RecipientShipToPhone current)
		{
			Models.Files.PurchaseOrder.R31_RecipientShipToPhone to = new Models.Files.PurchaseOrder.R31_RecipientShipToPhone()
			{

			};
			return to;
		}
	}
}
