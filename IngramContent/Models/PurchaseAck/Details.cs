using System;

namespace IngramContent.Models.PurchaseAck
{
	public class Details
	{
		public int Id { get; set; }
		public int PurchaseId  {get;set;}

		public string LineItem_LineItemPONumber { get; set; }

		public string LineItem_ItemNumber { get; set; }

		public short LineItem_POAStatusCode { get; set; }
		
		public short LineItem_DCCode { get; set; }

		public DateTime AddDetail_AvailabilityDate { get; set; }

		public string AddDetail_DCInventory { get; set; }

		public string AddLineItem_Title { get; set; }

		public string AddLineItem_Author { get; set; }

		public short AddLineItem_BindingCode { get; set; }
		
		public string AddLineItem_Publisher { get; set; }

		public DateTime AddLineItem_ReleaseDate { get; set; }

		public short AddLineItem_OriginalSequenceNumber { get; set; }

		public short TotalQtyPredictedToShip { get; set; }

		public decimal PriceRecord_NetPrice { get; set; }

		public decimal PriceRecord_DiscountedList { get; set; }

		public short PriceRecord_TotalLineOrderQty { get; set; }
}
}