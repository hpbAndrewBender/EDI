﻿namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R29_CustomerBillToCityStateZip
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string PurchaserCity { get; set; }

		public string PurchaserStateOrProvince { get; set; }

		public string PurchaserPostalCode { get; set; }

		public string PurchaserCountry { get; set; }
	}
}