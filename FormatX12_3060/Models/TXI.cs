using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class TXI : Abstracted.TXI
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long TXIId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			TXI01 = 1, TaxTypeCode = TXI01,
			TXI02 = 2, MonetaryAmount = TXI02,
			TXI03 = 3, Percent = TXI03
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "TaxTypeCode", (int)Ordinal.TaxTypeCode },
			{ "MonetaryAmount", (int)Ordinal.MonetaryAmount },
			{ "Percent", (int)Ordinal.Percent },
		};
	}
}