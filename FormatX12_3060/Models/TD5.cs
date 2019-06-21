using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class TD5 : FormatX12_3060.Models.Abstracted.TD5
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long TD5Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			TD501 = 1, RoutingSequenceCode = TD501,
			TD502 = 2, IdentificationCodeQualifier = TD502,
			TD503 = 3, IdentificationCode = TD503,
			TD504 = 4, Reserved_ForFutureUse_01 = TD504,
			TD505 = 5, Routing = TD505,
			TD506 = 6, Reserved_ForFutureUse_02 = TD506,
			TD507 = 7, Reserved_ForFutureUse_03 = TD507,
			TD508 = 8, Reserved_ForFutureUse_04 = TD508,
			TD509 = 9, Reserved_ForFutureUse_05 = TD509,
			TD510 = 10, Reserved_ForFutureUse_06 = TD510,
			TD511 = 11, Reserved_ForFutureUse_07 = TD511,
			TD512 = 12, ServiceLevelCode = TD512
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "RoutingSequenceCode", (int)Ordinal.RoutingSequenceCode },
			{ "IdentificationCodeQualifier", (int)Ordinal.IdentificationCodeQualifier },
			{ "IdentificationCode", (int)Ordinal.IdentificationCode },
			{ "Routing", (int)Ordinal.Routing },
			{ "ServiceLevelCode", (int)Ordinal.ServiceLevelCode },
		};
	}
}