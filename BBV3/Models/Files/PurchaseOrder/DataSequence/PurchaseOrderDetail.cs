using System;
using System.Collections.Generic;

namespace FormatBBV3.Models.Files.PurchaseOrder.DataSequence
{
	public class PurchaseOrderDetail : IDisposable
	{
		public PurchaseOrderDetail()
		{
			AdditionalLineItemDetail = new R41_AdditionalLineItemDetail();
			Imprint = new List<R45_Imprint>();
			LineItemDetail = new R40_LineItemDetail();
			StickerBarcodeDataRecord = new R46_StickerBarcodeData();
			StickerTextLines = new List<R46_StickerTextLines>();
			Initialized = true;
		}

		public bool Initialized { get; private set; }
		//
		public R40_LineItemDetail LineItemDetail { get; set; }
		public R41_AdditionalLineItemDetail AdditionalLineItemDetail { get; set; }
		public List<R45_Imprint> Imprint { get; set; }
		public R46_StickerBarcodeData StickerBarcodeDataRecord { get; set; }
		public List<R46_StickerTextLines> StickerTextLines { get; set; }

		public void Dispose()
		{
			AdditionalLineItemDetail = null;
			Imprint = null;
			LineItemDetail = null;
			StickerBarcodeDataRecord = null;
			StickerTextLines = null;
			Initialized = false;
		}
	}
}