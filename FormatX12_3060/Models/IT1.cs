using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class IT1 : FormatX12_3060.Models.Abstracted.IT1
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long IT1Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			IT101 = 1, AssignedIdentification = IT101,
			IT102 = 2, QuantityInvoiced = IT102,
			IT103 = 3, UnitOrBasisForMeasurementCode = IT103,
			IT104 = 4, UnitPrice = IT104,
			IT105 = 5, BasisOfUnitPriceCode = IT105,
			IT106 = 6, ProductServiceIDQualifier_01 = IT106,
			IT107 = 7, ProductServiceID_01 = IT107,
			IT108 = 8, ProductServiceIDQualifier_02 = IT108,
			IT109 = 9, ProductServiceID_02 = IT109,
			IT110 = 10, ProductServiceIDQualifier_03 = IT110,
			IT111 = 11, ProductServiceID_03 = IT111,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "AssignedIdentification", (int)Ordinal.AssignedIdentification},
			{ "QuantityInvoiced" ,(int)Ordinal.QuantityInvoiced},
			{ "UnitOrBasisForMeasurementCode" ,(int)Ordinal.UnitOrBasisForMeasurementCode},
			{ "UnitPrice" ,(int)Ordinal.UnitPrice},
			{ "BasisOfUnitPriceCode" ,(int)Ordinal.BasisOfUnitPriceCode},
			{ "ProductServiceIDQualifier_01" ,(int)Ordinal.ProductServiceIDQualifier_01},
			{ "ProductServiceID_01",(int)Ordinal.ProductServiceID_01},
			{ "ProductServiceIDQualifier_02" ,(int)Ordinal.ProductServiceIDQualifier_02},
			{ "ProductServiceID_02",(int)Ordinal.ProductServiceID_02},
			{ "ProductServiceIDQualifier_03" ,(int)Ordinal.ProductServiceIDQualifier_03},
			{ "ProductServiceID_03",(int)Ordinal.ProductServiceID_03},
		};
	}
}