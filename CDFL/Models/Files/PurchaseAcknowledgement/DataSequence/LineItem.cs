using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement.DataSequence
{
	public class LineItem
	{
		public LineItem()
		{
			LineItemRecord = new R40_LineItem();
			AdditionalDetailRecord = new R41_AdditionalDetail();
			AddtionalLineItemTitleRecord = new R42_AdditionalLineItem();
			AdditionalLineItemPublisherRecord = new R43_AdditionalLineItem();
			ItemNumberOrPriceRecord = new R44_ItemNumberOrPrice();
		}

		public R40_LineItem LineItemRecord { get; set; }
		public R41_AdditionalDetail AdditionalDetailRecord { get; set; }
		public R42_AdditionalLineItem AddtionalLineItemTitleRecord { get; set; }
		public R43_AdditionalLineItem AdditionalLineItemPublisherRecord { get; set; }
		public R44_ItemNumberOrPrice ItemNumberOrPriceRecord { get; set; }

		public void Dispose()
		{
			LineItemRecord = null;
			AdditionalDetailRecord = null;
			AddtionalLineItemTitleRecord = null;
			AdditionalLineItemPublisherRecord = null;
			ItemNumberOrPriceRecord = null;
		}
	}
}
