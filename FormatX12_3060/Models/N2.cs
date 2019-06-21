using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class N2 : FormatX12_3060.Models.Abstracted.N2
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long N2Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			N201 = 1, Name_01 = N201,
			N202 = 2, Name_02 = N202,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "Name_01", (int)Ordinal.Name_01 },
			{ "Name_02", (int)Ordinal.Name_02 }
		};
	}
}