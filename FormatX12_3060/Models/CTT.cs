using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class CTT : FormatX12_3060.Models.Abstracted.CTT
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long CTTId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			CTT01 = 1, NumberOfLineItems = CTT01,
			CTT02 = 2, HashTotal = CTT02,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "NumberOfLineItems", (int)Ordinal.NumberOfLineItems },
			{ "HashTotal", (int)Ordinal.HashTotal }
		};

		public int GetOrdinal(string name)
		{
			int ordinal = -1;
			if(Ordinals.ContainsKey(name))
			{
				ordinal = Ordinals[name];
			}
			return ordinal;			
		}
	}
}