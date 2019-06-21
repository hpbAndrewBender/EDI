namespace FormatCDFL.Models.SQL.ShipNotice
{
	public class CR_CompanyRecord
	{
		public int Id { get; set; }

		public string CompanyRecordIdentifier { get; set; }

		public string CompanyAccountIDNumber { get; set; }

		public short TotalOrderCount { get; set; }

		public string FileVersionNumber { get; set; }
	}
}