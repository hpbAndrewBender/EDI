using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class GE : FormatX12_3060.Models.Abstracted.GE
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long GEId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			GE01 = 1, NumberOfIncludedFunctionalGroups = GE01,
			GE02 = 2, GroupControlNumber = GE02,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "NumberOfIncludedFunctionalGroups", (int)Ordinal.NumberOfIncludedFunctionalGroups },
			{ "GroupControlNumber", (int)Ordinal.GroupControlNumber },
		};
	}
}