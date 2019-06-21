using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR36
	{
		public static Models.SQL.PurchaseOrder.R36_SpecialDeliveryInstructions ToSQL(this Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions current)
		{
			Models.SQL.PurchaseOrder.R36_SpecialDeliveryInstructions to = new Models.SQL.PurchaseOrder.R36_SpecialDeliveryInstructions()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions ToFiles(this Models.SQL.PurchaseOrder.R36_SpecialDeliveryInstructions current)
		{
			Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions to = new Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions()
			{

			};
			return to;
		}
	}
}
