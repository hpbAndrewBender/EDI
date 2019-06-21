using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR24
	{
		public static Models.SQL.PurchaseOrder.R24_CustomerCost ToSQL(this Models.Files.PurchaseOrder.R24_CustomerCost current)
		{
			Models.SQL.PurchaseOrder.R24_CustomerCost to = new Models.SQL.PurchaseOrder.R24_CustomerCost()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R24_CustomerCost ToFiles(this Models.SQL.PurchaseOrder.R24_CustomerCost current)
		{
			Models.Files.PurchaseOrder.R24_CustomerCost to = new Models.Files.PurchaseOrder.R24_CustomerCost()
			{

			};
			return to;
		}
	}
}
