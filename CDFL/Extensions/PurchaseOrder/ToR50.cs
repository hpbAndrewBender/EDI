using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR50
	{
		public static Models.SQL.PurchaseOrder.R50_PurchaseOrderControl ToSQL(this Models.Files.PurchaseOrder.R50_PurchaseOrderControl current)
		{
			Models.SQL.PurchaseOrder.R50_PurchaseOrderControl to = new Models.SQL.PurchaseOrder.R50_PurchaseOrderControl()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R50_PurchaseOrderControl ToFiles(this Models.SQL.PurchaseOrder.R50_PurchaseOrderControl current)
		{
			Models.Files.PurchaseOrder.R50_PurchaseOrderControl to = new Models.Files.PurchaseOrder.R50_PurchaseOrderControl()
			{

			};
			return to;
		}
	}
}
