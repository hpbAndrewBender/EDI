using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class SE : FormatX12_3060.Models.Abstracted.SE
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long SEId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			SE01 = 1, NumberOfIncludedSegments = SE01,
			SE02 = 2, TransactionSetControlNumber = SE02
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "NumberOfIncludedSegments" ,(int)Ordinal.NumberOfIncludedSegments },
			{ "TransactionSetControlNumber", (int)Ordinal.TransactionSetControlNumber }
		};
	}
}