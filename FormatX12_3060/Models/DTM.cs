using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class DTM : FormatX12_3060.Models.Abstracted.DTM
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long DTMId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			DTM01 = 1, DateTimeQualifier = DTM01,
			DTM02 = 2, Date = DTM02,
			DTM03 = 3, Reserved_ForFutureUse_01 = DTM03,
			DTM04 = 4, Reserved_ForFutureUse_02 = DTM04,
			DTM05 = 5, Century = DTM05
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "DateTimeQualifier", (int)Ordinal.DateTimeQualifier },
			{ "Date", (int)Ordinal.Date },
			{ "Century", (int)Ordinal.Century },
		};
	}
}