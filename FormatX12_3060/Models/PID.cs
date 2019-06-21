using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class PID : Abstracted.PID
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long PIDId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			PID01 = 1, ItemDescriptionType = PID01,
			PID02 = 2, ProductProcessCharacteristicCode = PID02,
			PID03 = 3, AgencyQualifierCode = PID03,
			PID04 = 4, ProductDescriptionCode = PID04,
			PID05 = 5, Description = PID05,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "ItemDescriptionType" , (int)Ordinal.ItemDescriptionType},
			{ "ProductProcessCharacteristicCode", (int)Ordinal.ProductProcessCharacteristicCode },
			{ "AgencyQualifierCode", (int)Ordinal.AgencyQualifierCode },
			{ "ProductDescriptionCode", (int)Ordinal.ProductDescriptionCode },
			{ "Description", (int)Ordinal.Description },
		};
	}
}