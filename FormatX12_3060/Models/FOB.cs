using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class FOB : FormatX12_3060.Models.Abstracted.FOB
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long FOBId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			FOB01 = 1, ShipmentMethodOfPayment = FOB01,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "ShipmentMethodOfPayment", (int)Ordinal.ShipmentMethodOfPayment },
		};
	}
}
