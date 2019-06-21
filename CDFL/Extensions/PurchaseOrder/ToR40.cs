using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR40
	{
		public static Models.SQL.PurchaseOrder.R40_LineItem ToSQL(this Models.Files.PurchaseOrder.R40_LineItem current)
		{
			Models.SQL.PurchaseOrder.R40_LineItem to = new Models.SQL.PurchaseOrder.R40_LineItem()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R40_LineItem ToFiles(this Models.SQL.PurchaseOrder.R40_LineItem current)
		{
			Models.Files.PurchaseOrder.R40_LineItem to = new Models.Files.PurchaseOrder.R40_LineItem()
			{

			};
			return to;
		}
	}
}
