using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class LIN : FormatX12_3060.Models.Abstracted.LIN
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long LINId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			LIN01 = 1, AssignedIdentification = LIN01,
			LIN02 = 2, ProductServiceIDQualifier_01 = LIN02,
			LIN03 = 3, ProductServiceID_01 = LIN03,
			LIN04 = 4, ProductServiceIDQualifier_02 = LIN04,
			LIN05 = 5, ProductServiceID_02 = LIN05,
			LIN06 = 6, ProductServiceIDQualifier_03 = LIN06,
			LIN07 = 7, ProductServiceID_03 = LIN07
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command},
			{ "AssignedIdentification", (int)Ordinal.AssignedIdentification},
			{ "ProductServiceIDQualifier_01", (int)Ordinal.ProductServiceIDQualifier_01},
			{ "ProductServiceID_01", (int)Ordinal.ProductServiceID_01},
			{ "ProductServiceIDQualifier_02", (int)Ordinal.ProductServiceIDQualifier_02},
			{ "ProductServiceID_02", (int)Ordinal.ProductServiceID_02},
			{ "ProductServiceIDQualifier_03", (int)Ordinal.ProductServiceIDQualifier_03},
			{ "ProductServiceID_03", (int)Ordinal.ProductServiceID_03}
		};
	}
}