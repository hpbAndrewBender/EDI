namespace CDFLite.Models.PurchaseAcknowledgement
{
	internal class R21_FreeFormVendor
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string VendorMessage { get; set; }
	}
}