using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR37
	{
		public static Models.SQL.PurchaseOrder.R37_MarketingMessage ToSQL(this Models.Files.PurchaseOrder.R37_MarketingMessage current)
		{
			Models.SQL.PurchaseOrder.R37_MarketingMessage to = new Models.SQL.PurchaseOrder.R37_MarketingMessage()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R37_MarketingMessage ToFiles(this Models.SQL.PurchaseOrder.R37_MarketingMessage current)
		{
			Models.Files.PurchaseOrder.R37_MarketingMessage to = new Models.Files.PurchaseOrder.R37_MarketingMessage()
			{

			};
			return to;
		}
	}
}
