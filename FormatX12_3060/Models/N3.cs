using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class N3 : FormatX12_3060.Models.Abstracted.N3
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long N3Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			N301 = 1, AddressInformation_01 = N301,
			N302 = 2, AddressInformation_02 = N302
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "AddressInformation_01" , (int)Ordinal.AddressInformation_01 },
			{ "AddressInformation_02" , (int)Ordinal.AddressInformation_02 }
		};
	}
}