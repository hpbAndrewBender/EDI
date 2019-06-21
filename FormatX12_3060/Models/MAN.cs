using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class MAN : FormatX12_3060.Models.Abstracted.MAN
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long MANId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			MAN01 = 1, MarksAndNumbersQualifier_01 = MAN01,
			MAN02 = 2, MarksAndNumbers_01 = MAN02,
			MAN03 = 3,
			MAN04 = 4, MarksAndNumbersQualifier_02 = MAN04,
			MAN05 = 5, MarksAndNumbers_02 = MAN05
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "MarksAndNumbersQualifier_01", (int)Ordinal.MarksAndNumbersQualifier_01 },
			{ "MarksAndNumbers_01", (int)Ordinal.MarksAndNumbers_01 },
			{ "MarksAndNumbersQualifier_02", (int)Ordinal.MarksAndNumbersQualifier_02 },
			{ "MarksAndNumbers_02", (int)Ordinal.MarksAndNumbers_02 }
		};
	}
}