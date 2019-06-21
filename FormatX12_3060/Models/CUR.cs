using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class CUR : FormatX12_3060.Models.Abstracted.CUR
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long CURId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			CUR01 = 1, EntityIdentifierCode = CUR01,
			CUR02 = 2, CurrencyCode = CUR02
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "EntityIdentifierCode", (int)Ordinal.EntityIdentifierCode },
			{ "CurrencyCode", (int)Ordinal.CurrencyCode }
		};
	}
}