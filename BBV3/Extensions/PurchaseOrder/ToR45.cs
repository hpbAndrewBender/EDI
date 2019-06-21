using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseOrder
{
	public static class ToR45
	{
		public static Models.SQL.PurchaseOrder.R45_Imprint ToSQL(this Models.Files.PurchaseOrder.R45_Imprint current)
		{
			Models.SQL.PurchaseOrder.R45_Imprint to = new Models.SQL.PurchaseOrder.R45_Imprint()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R45_Imprint ToFiles(this Models.SQL.PurchaseOrder.R45_Imprint current)
		{
			Models.Files.PurchaseOrder.R45_Imprint to = new Models.Files.PurchaseOrder.R45_Imprint()
			{

			};
			return to;
		}
	}
}
