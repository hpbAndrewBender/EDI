namespace FormatBBV3.Models.SQL.PurchaseOrder
{
	public class R46_StickerBarcodeData
	{
		public int Id { get; set; }

		public string RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public char BarcodeTypeCode { get; set; }

		public string StringforBarcode { get; set; }
	}
}