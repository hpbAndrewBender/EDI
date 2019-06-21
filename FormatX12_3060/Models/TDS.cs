using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class TDS : FormatX12_3060.Models.Abstracted.TDS
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long TDSId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			TDS01 = 1, Amount_01 = TDS01,
			TDS02 = 2, Amount_02 = TDS02,
			TDS03 = 3, Amount_03 = TDS03,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "Amount_01", (int)Ordinal.Amount_01 },
			{ "Amount_02", (int)Ordinal.Amount_02 },
			{ "Amount_03", (int)Ordinal.Amount_03 }
		};
	}
}