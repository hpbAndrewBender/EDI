namespace FormatCDFL.Models.SQL.PurchaseOrder
{
	public class R27_CustomerBillToAddressLine
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string PurchaserAddressLine { get; set; }
	}
}