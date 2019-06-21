using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseOrder
{
	public static class ToR46_Barcode
	{
		public static Models.SQL.PurchaseOrder.R46_StickerBarcodeData ToSQL(this Models.Files.PurchaseOrder.R46_StickerBarcodeData current)
		{
			Models.SQL.PurchaseOrder.R46_StickerBarcodeData to = new Models.SQL.PurchaseOrder.R46_StickerBarcodeData()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R46_StickerBarcodeData ToFiles(this Models.SQL.PurchaseOrder.R46_StickerBarcodeData current)
		{
			Models.Files.PurchaseOrder.R46_StickerBarcodeData to = new Models.Files.PurchaseOrder.R46_StickerBarcodeData()
			{

			};
			return to;
		}
	}
}
