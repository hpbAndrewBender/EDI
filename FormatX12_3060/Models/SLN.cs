using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class SLN : FormatX12_3060.Models.Abstracted.SLN
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long SLNId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			SLN01 = 1, AssignedIdentification = SLN01,
			SLN02 = 2, Reserved_ForFutureUse_01 = SLN02,
			SLN03 = 3, RelationshipCode_01 = SLN03,
			SLN04 = 4, Quantity = SLN04,
			SLN05 = 5, CompositeUnitOfMeasure = SLN05,
			SLN06 = 6, UnitPrice = SLN06,
			SLN07 = 7, BasisOfUnitPriceCode = SLN07,
			SLN08 = 8, RelationshipCode_02 = SLN08,
			SLN09 = 9, ProductServiceIDQualifier_01 = SLN09,
			SLN10 = 10, ProductServiceID_01 = SLN10,
			SLN11 = 11, ProductServiceIDQualifier_02 = SLN11,
			SLN12 = 12, ProductServiceID_02 = SLN12,
			SLN13 = 13, ProductServiceIDQualifier_03 = SLN13,
			SLN14 = 14, ProductServiceID_03 = SLN14,
			SLN15 = 15, ProductServiceIDQualifier_04 = SLN15,
			SLN16 = 16, ProductServiceID_04 = SLN16,
			SLN17 = 17, ProductServiceIDQualifier_05 = SLN17,
			SLN18 = 18, ProductServiceID_05 = SLN18,
			SLN19 = 19, ProductServiceIDQualifier_06 = SLN19,
			SLN20 = 20, ProductServiceID_06 = SLN20,
			SLN21 = 21, ProductServiceIDQualifier_07 = SLN21,
			SLN22 = 22, ProductServiceID_07 = SLN22,
			SLN23 = 23, ProductServiceIDQualifier_08 = SLN23,
			SLN24 = 24, ProductServiceID_08 = SLN24,
			SLN25 = 25, ProductServiceIDQualifier_09 = SLN25,
			SLN26 = 26, ProductServiceID_09 = SLN26,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "AssignedIdentification" , (int)Ordinal.AssignedIdentification },
			{ "RelationshipCode_01", (int) Ordinal.RelationshipCode_01 },
			{ "Quantity", (int)Ordinal.Quantity },
			{ "CompositeUnitOfMeasure", (int)Ordinal.CompositeUnitOfMeasure },
			{ "UnitPrice", (int)Ordinal.UnitPrice },
			{ "BasisOfUnitPriceCode", (int)Ordinal.BasisOfUnitPriceCode },
			{ "RelationshipCode_02", (int)Ordinal.RelationshipCode_02 },
			{ "ProductServiceIDQualifier_01", (int)Ordinal.ProductServiceIDQualifier_01 },
			{ "ProductServiceID_01", (int)Ordinal.ProductServiceID_01 },
			{ "ProductServiceIDQualifier_02", (int)Ordinal.ProductServiceIDQualifier_02 },
			{ "ProductServiceID_02", (int)Ordinal.ProductServiceID_02 },
			{ "ProductServiceIDQualifier_03", (int)Ordinal.ProductServiceIDQualifier_03 },
			{ "ProductServiceID_03", (int)Ordinal.ProductServiceID_03 },
			{ "ProductServiceIDQualifier_04", (int)Ordinal.ProductServiceIDQualifier_04 },
			{ "ProductServiceID_04", (int)Ordinal.ProductServiceID_04 },
			{ "ProductServiceIDQualifier_05", (int)Ordinal.ProductServiceIDQualifier_05 },
			{ "ProductServiceID_05", (int)Ordinal.ProductServiceID_05 },
			{ "ProductServiceIDQualifier_06", (int)Ordinal.ProductServiceIDQualifier_06 },
			{ "ProductServiceID_06", (int)Ordinal.ProductServiceID_06 },
			{ "ProductServiceIDQualifier_07", (int)Ordinal.ProductServiceIDQualifier_07 },
			{ "ProductServiceID_07", (int)Ordinal.ProductServiceID_07 },
			{ "ProductServiceIDQualifier_08", (int)Ordinal.ProductServiceIDQualifier_08 },
			{ "ProductServiceID_08", (int)Ordinal.ProductServiceID_08 },
			{ "ProductServiceIDQualifier_09", (int)Ordinal.ProductServiceIDQualifier_09 },
			{ "ProductServiceID_09", (int)Ordinal.ProductServiceID_09 },
		};
	}
}