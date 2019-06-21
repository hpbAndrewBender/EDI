using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR27
	{
		public static Models.SQL.PurchaseOrder.R27_CustomerBillToAddressLine ToSQL(this Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine current)
		{
			Models.SQL.PurchaseOrder.R27_CustomerBillToAddressLine to = new Models.SQL.PurchaseOrder.R27_CustomerBillToAddressLine()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine ToFiles(this Models.SQL.PurchaseOrder.R27_CustomerBillToAddressLine current)
		{
			Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine to = new Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine()
			{

			};
			return to;
		}
	}
}
