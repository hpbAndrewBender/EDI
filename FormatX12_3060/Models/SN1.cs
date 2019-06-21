using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class SN1 : FormatX12_3060.Models.Abstracted.SN1
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long SN1Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			SN101 = 1, AssignedIdentification = SN101,
			SN102 = 2, NumberOfUnitsShipped = SN102,
			SN103 = 3, UnitOrBasisForMeasurementCode_01 = SN103,
			SN104 = 4, QuantityShippedToDate = SN104,
			SN105 = 5, QuantityOrdered = SN105,
			SN106 = 6, UnitOrBasisForMeasurementCode_02 = SN106,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "AssignedIdentification", (int)Ordinal.AssignedIdentification },
			{ "NumberOfUnitsShipped", (int)Ordinal.NumberOfUnitsShipped },
			{ "UnitOrBasisForMeasurementCode_01", (int)Ordinal.UnitOrBasisForMeasurementCode_01 },
			{ "QuantityShippedToDate", (int)Ordinal.QuantityShippedToDate },
			{ "QuantityOrdered", (int)Ordinal.QuantityOrdered },
			{ "UnitOrBasisForMeasurementCode_02", (int)Ordinal.UnitOrBasisForMeasurementCode_02 }
		};
	}
}