using System;

namespace FormatBBV3.Models.SQL.Invoice
{
	public class R15_InvoiceHeader
	{
		public int Id { get; set; }

		public string InvoiceHeader { get; set; }

		public short SequenceNumber { get; set; }

		public short InvoiceNumber { get; set; }

		public string PurchaseOrderNumber { get; set; }

		public string IngramShipToAccountNumber { get; set; }

		public string StoreNumber { get; set; }

		public string DCSAN { get; set; }

		public DateTime InvoiceDate { get; set; }
	}
}