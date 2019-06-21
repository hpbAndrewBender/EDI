namespace DataMetaData.Models.X12_3060
{
	public class MetaCodes
	{
		public MetaCodes(string dataCode, string dataDescripton)
		{
			Code=dataCode;
			Description=dataDescripton;
		}

		public string Code { get; set; }
		public string Description { get; set; }
	}
}
