using System;

namespace IngramContent.Models.Invoice
{
	public class Detail
	{
		public int Id { get; set; }
		public int HeaderID { get; set; }
		public string Detail_ISBN10Shipped { get; set; }
		public short Detail_QuantityShipped { get; set; }
		public decimal Detail_IngramItemListPrice { get; set; }
		public decimal Detail_Discount { get; set; }
		public decimal Detail_NetPriceOrCost { get; set; }
		public DateTime Detail_MeteredDate { get; set; }
		public string EAN_ISBN13EANShipped { get; set; }
		public string Total_Title { get; set; }
		public string Total_ClientOrderID { get; set; }
		public string Total_LineItemID { get; set; }
		public string Fees_TrackingNumber { get; set; }
		public decimal Fees_NetPrice { get; set; }
		public decimal Fees_Shipping { get; set; }
		public decimal Fees_Handling { get; set; }
		public decimal Fees_GiftWrap { get; set; }
		public decimal Fees_AmountDue { get; set; }
	}
}