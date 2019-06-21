using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class BSN : FormatX12_3060.Models.Abstracted.BSN
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long BSNId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			BSN01 = 1, TransactionSetPurposeCode = BSN01,
			BSN02 = 2, ShipmentIdentification = BSN02,
			BSN03 = 3, Date = BSN03,
			BSN04 = 4, Time = BSN04,
			BSN05 = 5, HierarchicalStructureCode = BSN05
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "TransactionSetPurposeCode", (int)Ordinal.TransactionSetPurposeCode },
			{ "ShipmentIdentification", (int)Ordinal.ShipmentIdentification },
			{ "Date", (int)Ordinal.Date },
			{ "Time", (int)Ordinal.Time },
			{ "HierarchicalStructureCode", (int)Ordinal.HierarchicalStructureCode },
		};
	}
}