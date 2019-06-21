using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Models.Files.PurchaseOrder.DataSequence
{
	public class Item : IDisposable
	{
		public Item()
		{
			LineItemRecord = new R40_LineItem();
			AdditionalLineItemRecord = new R41_AdditionalLineItem();
			LineItemGiftMessage = new List<R42_LineItemGiftMessage>();
			Imprint = new List<R45_Imprint>();
			Initialized = true;
		}

		public bool Initialized { get; private set; }
		//
		public R40_LineItem LineItemRecord { get; set; }
		public R41_AdditionalLineItem AdditionalLineItemRecord { get; set; }
		public List<R42_LineItemGiftMessage> LineItemGiftMessage { get; set; }
		public List<R45_Imprint> Imprint { get; set; }
		public void Dispose()
		{
			LineItemRecord = null;
			AdditionalLineItemRecord = null;
			LineItemGiftMessage = null;
			Imprint = null;
			Initialized = false;
		}
	}
}
