using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR38
	{
		public static Models.SQL.PurchaseOrder.R38_GiftMessage ToSQL(this Models.Files.PurchaseOrder.R38_GiftMessage current)
		{
			Models.SQL.PurchaseOrder.R38_GiftMessage to = new Models.SQL.PurchaseOrder.R38_GiftMessage()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R38_GiftMessage ToFiles(this Models.SQL.PurchaseOrder.R38_GiftMessage current)
		{
			Models.Files.PurchaseOrder.R38_GiftMessage to = new Models.Files.PurchaseOrder.R38_GiftMessage()
			{

			};
			return to;
		}
	}
}
