using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class REF : FormatX12_3060.Models.Abstracted.REF
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long REFId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			REF01 = 1, ReferenceIdentificationQualifier = REF01,
			REF02 = 2, ReferenceIdentification = REF02,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "ReferenceIdentificationQualifier", (int)Ordinal.ReferenceIdentificationQualifier },
			{ "ReferenceIdentification", (int)Ordinal.ReferenceIdentification },
		};
	}
}