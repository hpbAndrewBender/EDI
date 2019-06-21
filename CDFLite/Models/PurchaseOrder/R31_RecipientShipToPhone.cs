﻿namespace CDFLite.Models.PurchaseOrder
{
	internal class R31_RecipientShipToPhone
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string RecipientPhone { get; set; }
	}
}