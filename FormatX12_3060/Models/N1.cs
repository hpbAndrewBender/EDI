using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class N1 : FormatX12_3060.Models.Abstracted.N1
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long N1Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			N101 = 1, EntityIdentifierCode = N101,
			N102 = 2, Name = N102,
			N103 = 3, IdentificationCodeQualifier = N103,
			N104 = 4, IdentificationCode = N104,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "EntityIdentifierCode", (int)Ordinal.EntityIdentifierCode},
			{ "Name" , (int)Ordinal.Name},
			{ "IdentificationCodeQualifier" , (int)Ordinal.IdentificationCodeQualifier},
			{ "IdentificationCode" , (int)Ordinal.IdentificationCode},
		};
	}
}