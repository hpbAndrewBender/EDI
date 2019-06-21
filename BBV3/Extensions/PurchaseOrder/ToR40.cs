using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseOrder
{
	public static class ToR40
	{
		public static Models.SQL.PurchaseOrder.R40_LineItemDetail ToSQL(this Models.Files.PurchaseOrder.R40_LineItemDetail current)
		{
			Models.SQL.PurchaseOrder.R40_LineItemDetail to = new Models.SQL.PurchaseOrder.R40_LineItemDetail()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R40_LineItemDetail ToFiles(this Models.SQL.PurchaseOrder.R40_LineItemDetail current)
		{
			Models.Files.PurchaseOrder.R40_LineItemDetail to = new Models.Files.PurchaseOrder.R40_LineItemDetail()
			{

			};
			return to;
		}
	}
}
