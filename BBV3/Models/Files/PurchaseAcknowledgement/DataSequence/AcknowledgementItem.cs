using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement.DataSequence
{
	public class AcknowledgementItem : IDisposable
	{
		public AcknowledgementItem()
		{
			LineItemRecord = new R40_LineItem();
			AdditionalDetailRecord = new R41_AdditionalDetail();
			AddtionalLineItemTitle = new R42_AdditionalLineItem();
			AdditionalLineItemPublisher = new R43_AdditionalLineItem();
			ItemNumberOrPriceRecord = new R44_Item_NumberOrPrice();
			AdditionalLineItemClient = new R45_AdditionalLineItem();
			Initialized = true;
		}

		public bool Initialized { get; private set; }
		//
		public R40_LineItem LineItemRecord { get; set; }
		public R41_AdditionalDetail AdditionalDetailRecord { get; set; }
		public R42_AdditionalLineItem AddtionalLineItemTitle { get; set; }
		public R43_AdditionalLineItem AdditionalLineItemPublisher { get; set; }
		public R44_Item_NumberOrPrice ItemNumberOrPriceRecord { get; set; }
		public R45_AdditionalLineItem AdditionalLineItemClient { get; set; }
		public void Dispose()
		{
			LineItemRecord = null;
			AdditionalDetailRecord = null;
			AddtionalLineItemTitle = null;
			AdditionalLineItemPublisher = null;
			ItemNumberOrPriceRecord = null;
			AdditionalLineItemClient = null;
			Initialized = false;
		}
	}
}
