using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class IEA : FormatX12_3060.Models.Abstracted.IEA
	{

		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long IEAId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			IEA01 = 1, NumberOfIncludedFunctionalGroups = IEA01,
			IEA02 = 2, InterchangeControlNumber = IEA02,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "NumberOfIncludedFunctionalGroups", (int)Ordinal.NumberOfIncludedFunctionalGroups },
			{ "InterchangeControlNumber" ,(int)Ordinal.InterchangeControlNumber },
		};
	}
}