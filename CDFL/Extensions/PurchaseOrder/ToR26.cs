using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR26
	{
		public static Models.SQL.PurchaseOrder.R26_CustomerBillToPhoneNumber ToSQL(this Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber current)
		{
			Models.SQL.PurchaseOrder.R26_CustomerBillToPhoneNumber to = new Models.SQL.PurchaseOrder.R26_CustomerBillToPhoneNumber()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber ToFiles(this Models.SQL.PurchaseOrder.R26_CustomerBillToPhoneNumber current)
		{
			Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber to = new Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber()
			{

			};
			return to;
		}
	}
}
