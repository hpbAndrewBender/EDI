using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class SCH : FormatX12_3060.Models.Abstracted.SCH
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long SCHId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			SCH01 = 1, Quantity = SCH01,
			SCH02 = 2, UnitOrBasisForMeasurementCode = SCH02,
			SCH03 = 3, EntityIdentifierCode = SCH03,
			SCH04 = 4, Name = SCH04,
			SCH05 = 5, DateTimeQualifier = SCH05,
			SCH06 = 6, Date = SCH06,
			SCH07 = 7, Reserved_ForFutureUse_01 = SCH07,
			SCH08 = 8, Reserved_ForFutureUse_02 = SCH08,
			SCH09 = 9, Reserved_ForFutureUse_03 = SCH09,
			SCH10 = 10, Reserved_ForFutureUse_04 = SCH10,
			SCH11 = 11, RequestReferenceNumber = SCH11
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "Quantity", (int)Ordinal.Quantity },
			{ "UnitOrBasisForMeasurementCode", (int)Ordinal.UnitOrBasisForMeasurementCode },
			{ "EntityIdentifierCode", (int)Ordinal.EntityIdentifierCode },
			{ "Name", (int)Ordinal.Name },
			{ "DateTimeQualifier", (int)Ordinal.DateTimeQualifier },
			{ "Date", (int)Ordinal.Date },
			{ "RequestReferenceNumber", (int)Ordinal.RequestReferenceNumber },
		};
	}
}