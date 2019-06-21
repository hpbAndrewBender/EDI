using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR10
	{
		public static Models.SQL.PurchaseOrder.R10_ClientHeader ToSQL(this Models.Files.PurchaseOrder.R10_ClientHeader current)
		{
			Models.SQL.PurchaseOrder.R10_ClientHeader to = new Models.SQL.PurchaseOrder.R10_ClientHeader()
			{

			};
			return to;
		}

		


		public static Models.Files.PurchaseOrder.R10_ClientHeader ToFiles(this Models.SQL.PurchaseOrder.R10_ClientHeader current)
		{
			Models.Files.PurchaseOrder.R10_ClientHeader to = new Models.Files.PurchaseOrder.R10_ClientHeader()
			{

			};
			return to;
		 }
	}
}
