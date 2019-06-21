﻿namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R34_RecipientShippingRecordCityStateZip
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string RecipientCity { get; set; }

		public string RecipientStateOrProvince { get; set; }

		public string RecipientPostalCode { get; set; }

		public string Country { get; set; }
	}
}