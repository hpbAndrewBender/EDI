namespace FormatCDFL.Models.SQL.Invoice
{
	public class R55_InvoiceTotals
	{
		public int Id { get; set; }

		public string InvoiceControlShippingRecord { get; set; }

		public byte SequenceNumber { get; set; }

		public string InvoiceNumber { get; set; }

		public short InvoiceRecordCount { get; set; }

		public short NumberofTitles { get; set; }

		public short TotalNumberofUnits { get; set; }

		public string BillofLadingNumber { get; set; }

		public short TotalInvoiceWeight { get; set; }
	}
}