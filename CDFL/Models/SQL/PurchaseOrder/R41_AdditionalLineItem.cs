using System;

namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R41_AdditionalLineItem
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public decimal ClientItemListPrice { get; set; }

		public DateTime LineLevelBackorderCancelDate { get; set; }

		public string LineLevelGiftWrapCode { get; set; }

		public short OrderQuantity { get; set; }
	}
}