using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class HL : FormatX12_3060.Models.Abstracted.HL
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long HLId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			HL01 = 1, HierarchicalIDNumber = HL01,
			HL02 = 2, HierarchicalParentIDNumber = HL02,
			HL03 = 3, HierarchicalLevelCode = HL03,
			HL04 = 4, HierarchicalChildCode = HL04
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "HierarchicalIDNumber", (int)Ordinal.HierarchicalIDNumber },
			{ "HierarchicalParentIDNumber", (int)Ordinal.HierarchicalParentIDNumber },
			{ "HierarchicalLevelCode", (int)Ordinal.HierarchicalLevelCode },
			{ "HierarchicalChildCode", (int)Ordinal.HierarchicalChildCode },
		};
	}
}