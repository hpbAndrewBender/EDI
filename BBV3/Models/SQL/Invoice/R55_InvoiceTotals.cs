namespace FormatBBV3.Models.SQL.Invoice
{
	public class R55_InvoiceTotals
	{
		public int Id { get; set; }

		public string InvoiceTotal { get; set; }

		public short SequenceNumber { get; set; }

		public short InvoiceNumber { get; set; }

		public short InvoiceRecordCount { get; set; }

		public short NumberofItems { get; set; }

		public short TotalNumberofUnits { get; set; }
	}
}