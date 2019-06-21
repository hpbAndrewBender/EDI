using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR41
	{
		public static Models.SQL.PurchaseOrder.R41_AdditionalLineItem ToSQL(this Models.Files.PurchaseOrder.R41_AdditionalLineItem current)
		{
			Models.SQL.PurchaseOrder.R41_AdditionalLineItem to = new Models.SQL.PurchaseOrder.R41_AdditionalLineItem()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R41_AdditionalLineItem ToFiles(this Models.SQL.PurchaseOrder.R41_AdditionalLineItem current)
		{
			Models.Files.PurchaseOrder.R41_AdditionalLineItem to = new Models.Files.PurchaseOrder.R41_AdditionalLineItem()
			{

			};
			return to;
		}
	}
}
