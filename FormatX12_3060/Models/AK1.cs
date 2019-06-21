using System;
using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class AK1 : FormatX12_3060.Models.Abstracted.AK1
	{
		public string Command { get; set; }
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public List<int> RequiredFields { get => throw new NotImplementedException(); internal set => throw new NotImplementedException(); }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long AK1Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			AK101 = 1, FunctionalIdentifierCode = AK101,
			AK102 = 2, GroupControlNumber = AK102,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "FunctionalIdentifierCode", (int)Ordinal.FunctionalIdentifierCode},
			{ "GroupControlNumber", (int)Ordinal.GroupControlNumber},
		};
	}
}
