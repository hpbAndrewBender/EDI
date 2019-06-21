using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR21
	{
		public static Models.SQL.PurchaseOrder.R21_PurchaseOrderOptions ToSQL(this Models.Files.PurchaseOrder.R21_PurchaseOrderOptions current)
		{
			Models.SQL.PurchaseOrder.R21_PurchaseOrderOptions to = new Models.SQL.PurchaseOrder.R21_PurchaseOrderOptions()
			{


			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R21_PurchaseOrderOptions ToFiles(this Models.SQL.PurchaseOrder.R21_PurchaseOrderOptions current)
		{
			Models.Files.PurchaseOrder.R21_PurchaseOrderOptions to = new Models.Files.PurchaseOrder.R21_PurchaseOrderOptions()
			{

			};
			return to;
		}
	}
}
