using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseOrder
{
	public static class ToR41
	{
		public static Models.SQL.PurchaseOrder.R41_AdditionalLineItemDetail ToSQL(this Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail current)
		{
			Models.SQL.PurchaseOrder.R41_AdditionalLineItemDetail to = new Models.SQL.PurchaseOrder.R41_AdditionalLineItemDetail()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail ToFiles(this Models.SQL.PurchaseOrder.R41_AdditionalLineItemDetail current)
		{
			Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail to = new Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail()
			{

			};
			return to;
		}
	}
}
