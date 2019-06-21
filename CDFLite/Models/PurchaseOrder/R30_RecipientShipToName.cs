namespace CDFLite.Models.PurchaseOrder
{
	internal class R30_RecipientShipToName
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string RecipientConsumerName { get; set; }

		public char AddressValidation { get; set; }
	}
}