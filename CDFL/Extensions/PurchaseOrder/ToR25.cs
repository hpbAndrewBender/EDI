using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR25
	{
		public static Models.SQL.PurchaseOrder.R25_CustomerBillToName ToSQL(this Models.Files.PurchaseOrder.R25_CustomerBillToName current)
		{
			Models.SQL.PurchaseOrder.R25_CustomerBillToName to = new Models.SQL.PurchaseOrder.R25_CustomerBillToName()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R25_CustomerBillToName ToFiles(this Models.SQL.PurchaseOrder.R25_CustomerBillToName current)
		{
			Models.Files.PurchaseOrder.R25_CustomerBillToName to = new Models.Files.PurchaseOrder.R25_CustomerBillToName()
			{

			};
			return to;
		}
	}
}
