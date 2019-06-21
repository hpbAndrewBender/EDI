using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class IT8 : FormatX12_3060.Models.Abstracted.IT8
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileId { get; set; }
		public long IT8Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			IT801 = 1, SalesRequirementCode = IT801,
			IT802 = 2, Do_Not_ExceedActionCode = IT802,
			IT803 = 3, Amount = IT803
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "SalesRequirementCode", (int)Ordinal.SalesRequirementCode },
			{ "Do_Not_ExceedActionCode", (int)Ordinal.Do_Not_ExceedActionCode },
			{ "Amount", (int)Ordinal.Amount }
		};
	}
}