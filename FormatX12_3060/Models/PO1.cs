using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class PO1 : FormatX12_3060.Models.Abstracted.PO1
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long PO1Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			PO101 = 1, AssignedIdentification = PO101,
			PO102 = 2, QuantityOrdered = PO102,
			PO103 = 3, UnitOrBasisForMeasurementCode = PO103,
			PO104 = 4, UnitPrice = PO104,
			PO105 = 5, BasisOfUnitPriceCode = PO105,
			PO106 = 6, ProductServiceIDQualifier_01 = PO106,
			PO107 = 7, ProductServiceID_01 = PO107,
			PO108 = 8, ProductServiceIDQualifier_02 = PO108,
			PO109 = 9, ProductServiceID_02 = PO109,
			PO110 = 10, ProductServiceIDQualifier_03 = PO110,
			PO111 = 11, ProductServiceID_03 = PO111,
			PO112 = 12, ProductServiceIDQualifier_04 = PO112,
			PO113 = 13, ProductServiceID_04 = PO113,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "AssignedIdentification", (int)Ordinal.AssignedIdentification },
			{ "QuantityOrdered", (int)Ordinal.QuantityOrdered },
			{ "UnitOrBasisForMeasurementCode", (int)Ordinal.UnitOrBasisForMeasurementCode },
			{ "UnitPrice", (int)Ordinal.UnitPrice },
			{ "BasisOfUnitPriceCode", (int)Ordinal.BasisOfUnitPriceCode },
			{ "ProductServiceIDQualifier_01", (int)Ordinal.ProductServiceIDQualifier_01 },
			{ "ProductServiceID_01", (int)Ordinal.ProductServiceID_01 },
			{ "ProductServiceIDQualifier_02", (int)Ordinal.ProductServiceIDQualifier_02 },
			{ "ProductServiceID_02", (int)Ordinal.ProductServiceID_02 },
			{ "ProductServiceIDQualifier_03", (int)Ordinal.ProductServiceIDQualifier_03 },
			{ "ProductServiceID_03", (int)Ordinal.ProductServiceID_03 },
			{ "ProductServiceIDQualifier_04", (int)Ordinal.ProductServiceIDQualifier_04 },
			{ "ProductServiceID_04", (int)Ordinal.ProductServiceID_04 },
		};
	}
}