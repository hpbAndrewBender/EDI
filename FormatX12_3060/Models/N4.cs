using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class N4 : FormatX12_3060.Models.Abstracted.N4
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long N4Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			N401 = 1, CityName = N401,
			N402 = 2, StateOrProvinceCode = N402,
			N403 = 3, PostalCode = N403,
			N404 = 4, CountryCode = N404,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "CityName", (int)Ordinal.CityName },
			{ "StateOrProvinceCode", (int)Ordinal.StateOrProvinceCode },
			{ "PostalCode", (int)Ordinal.PostalCode },
			{ "CountryCode", (int)Ordinal.CountryCode },
		};
	}
}