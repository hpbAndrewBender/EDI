﻿namespace FormatCDFL.Models.SQL.PurchaseAcknowledgement
{
	public class R40_LineItem
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string LineItemPONumber { get; set; }

		public string ItemNumber { get; set; }

		public string POAStatusCode { get; set; }

		public char DCCode { get; set; }
	}
}