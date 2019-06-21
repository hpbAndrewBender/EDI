using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class MEA : FormatX12_3060.Models.Abstracted.MEA
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long MEAId { get; set; }


		public enum Ordinal
		{
			Command = 0,
			MEA01 = 1, MeasurementReferenceIdCode = MEA01,
			MEA02 = 2, MeasurementQualifier = MEA02,
			MEA03 = 3, MeasurementValue = MEA03,
			MEA04 = 4, CompositeUnitOfMeasure = MEA04
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "MeasurementReferenceIdCode", (int)Ordinal.MeasurementReferenceIdCode },
			{ "MeasurementQualifier", (int)Ordinal.MeasurementQualifier },
			{ "MeasurementValue", (int)Ordinal.MeasurementValue },
			{ "CompositeUnitOfMeasure", (int)Ordinal.CompositeUnitOfMeasure }
		};
	}
}