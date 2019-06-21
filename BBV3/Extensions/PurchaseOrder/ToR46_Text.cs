using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseOrder
{
	public static class ToR46_Text
	{
		public static Models.SQL.PurchaseOrder.R46_StickerTextLines ToSQL(this Models.Files.PurchaseOrder.R46_StickerTextLines current)
		{
			Models.SQL.PurchaseOrder.R46_StickerTextLines to = new Models.SQL.PurchaseOrder.R46_StickerTextLines()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseOrder.R46_StickerTextLines ToFiles(this Models.SQL.PurchaseOrder.R46_StickerTextLines current)
		{
			Models.Files.PurchaseOrder.R46_StickerTextLines to = new Models.Files.PurchaseOrder.R46_StickerTextLines()
			{

			};
			return to;
		}
	}
}
