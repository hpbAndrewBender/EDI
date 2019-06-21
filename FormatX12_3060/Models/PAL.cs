using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class PAL : FormatX12_3060.Models.Abstracted.PAL
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long PALId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			PAL01 = 1, PalletTypeCode = PAL01,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "PalletTypeCode", (int)Ordinal.PalletTypeCode },
		};
	}
}