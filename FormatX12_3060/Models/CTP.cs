using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class CTP : FormatX12_3060.Models.Abstracted.CTP
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long CTPId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			CTP01 = 1, Reserved_ForFutureUse_01 = CTP01,
			CTP02 = 2, PriceIdentifierCode = CTP02,
			CTP03 = 3, UnitPrice = CTP03,
			CTP04 = 4, Quantity = CTP04,
			CTP05 = 5, CompositeUnitOfMeasure = CTP05,
			CTP06 = 6, PriceMultiplierQualifier = CTP06,
			CTP07 = 7, Multiplier = CTP07
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "PriceIdentifierCode",(int)Ordinal.PriceIdentifierCode },
			{ "UnitPrice",(int)Ordinal.UnitPrice },
			{ "Quantity",(int)Ordinal.Quantity },
			{ "CompositeUnitOfMeasure",(int)Ordinal.CompositeUnitOfMeasure },
			{ "PriceMultiplierQualifier",(int)Ordinal.PriceMultiplierQualifier },
			{ "Multiplier",(int)Ordinal.Multiplier }
		};
	}
}