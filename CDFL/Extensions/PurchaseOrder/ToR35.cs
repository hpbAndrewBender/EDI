using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR35
	{
		public static Models.SQL.PurchaseOrder.R35_DropShipDetail ToSQL(this Models.Files.PurchaseOrder.R35_DropShipDetail current)
		{
			Models.SQL.PurchaseOrder.R35_DropShipDetail to = new Models.SQL.PurchaseOrder.R35_DropShipDetail()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R35_DropShipDetail ToFiles(this Models.SQL.PurchaseOrder.R35_DropShipDetail current)
		{
			Models.Files.PurchaseOrder.R35_DropShipDetail to = new Models.Files.PurchaseOrder.R35_DropShipDetail()
			{

			};
			return to;
		}
	}
}
