using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR29
	{
		public static Models.SQL.PurchaseOrder.R29_CustomerBillToCityStateZip ToSQL(this Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip current)
		{
			Models.SQL.PurchaseOrder.R29_CustomerBillToCityStateZip to = new Models.SQL.PurchaseOrder.R29_CustomerBillToCityStateZip()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip ToFiles(this Models.SQL.PurchaseOrder.R29_CustomerBillToCityStateZip current)
		{
			Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip to = new Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip()
			{

			};
			return to;
		}
	}
}
