using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class TD1 : FormatX12_3060.Models.Abstracted.TD1
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long TD1Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			TD101 = 1, PackagingCode = TD101,
			TD102 = 2, LadingQuantity = TD102,
			TD103 = 3, CommodityCodeQualifier = TD103,
			TD104 = 4, CommodityCode = TD104,
			TD105 = 5, LadingDescription = TD105,
			TD106 = 6, WeightQualifier = TD106,
			TD107 = 7, Weight = TD107,
			TD108 = 8, UnitOrBasisForMeasurementCode = TD108,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "PackagingCode", (int)Ordinal.PackagingCode },
			{ "LadingQuantity", (int)Ordinal.LadingQuantity },
			{ "CommodityCodeQualifier", (int)Ordinal.CommodityCodeQualifier },
			{ "CommodityCode", (int)Ordinal.CommodityCode },
			{ "LadingDescription", (int)Ordinal.LadingDescription },
			{ "WeightQualifier", (int)Ordinal.WeightQualifier },
			{ "Weight", (int)Ordinal.Weight },
			{ "UnitOrBasisForMeasurementCode", (int)Ordinal.UnitOrBasisForMeasurementCode }
		};
	}
}