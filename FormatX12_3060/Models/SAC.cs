using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class SAC : FormatX12_3060.Models.Abstracted.SAC
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public bool SummaryRecord { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long SACId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			SAC01 = 1, AllowanceOrChargeIndicator = SAC01,
			SAC02 = 2, ServicePromotionAllowanceOrChargeCode = SAC02,
			SAC03 = 3, Reserved_ForFutureUse_01 = SAC03,
			SAC04 = 4, Reserved_ForFutureUse_02 = SAC04,
			SAC05 = 5, Amount = SAC05,
			SAC06 = 6, Reserved_ForFutureUse_03 = SAC06,
			SAC07 = 7, Reserved_ForFutureUse_04 = SAC07,
			SAC08 = 8, Rate = SAC08,
			SAC09 = 9, UnitOrBasisForMeasurementCode = SAC09,
			SAC10 = 10, Quantity = SAC10
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "AllowanceOrChargeIndicator", (int)Ordinal.AllowanceOrChargeIndicator },
			{ "ServicePromotionAllowanceOrChargeCode", (int)Ordinal.ServicePromotionAllowanceOrChargeCode },
			{ "Amount", (int)Ordinal.Amount },
			{ "Rate", (int)Ordinal.Rate },
			{ "UnitOrBasisForMeasurementCode", (int)Ordinal.UnitOrBasisForMeasurementCode },
			{ "Quantity", (int)Ordinal.Quantity },
		};
	}
}