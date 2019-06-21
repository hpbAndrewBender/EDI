using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseOrder
{
	public static class ToR20
	{
		public static Models.SQL.PurchaseOrder.R20_FixedSpecialHandlingInstructions ToSQL(this Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions current)
		{
			Models.SQL.PurchaseOrder.R20_FixedSpecialHandlingInstructions to = new Models.SQL.PurchaseOrder.R20_FixedSpecialHandlingInstructions()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions ToFiles(this Models.SQL.PurchaseOrder.R20_FixedSpecialHandlingInstructions current)
		{
			Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions to = new Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions()
			{

			};
			return to;
		}
	}
}
