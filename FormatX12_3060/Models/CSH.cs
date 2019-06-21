using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class CSH : FormatX12_3060.Models.Abstracted.CSH
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long CSHId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			CSH01 = 1, SalesRequirementCode = CSH01,
			CSH02 = 2, Reserved_ForFutureUse_01 = CSH02,
			CSH03 = 3, Reserved_ForFutureUse_02 = CSH03,
			CSH04 = 4, Reserved_ForFutureUse_03 = CSH04,
			CSH05 = 5, Reserved_ForFutureUse_04 = CSH05,
			CSH06 = 6, AgencyQualifierCode = CSH06,
			CSH07 = 7, SpecialServicesCode = CSH07,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "SalesRequirementCode", (int)Ordinal.SalesRequirementCode },
			{ "AgencyQualifierCode", (int)Ordinal.AgencyQualifierCode},
			{ "SpecialServicesCode", (int)Ordinal.SpecialServicesCode},
		};
	}
}