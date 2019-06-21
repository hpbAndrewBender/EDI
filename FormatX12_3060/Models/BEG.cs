using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class BEG : FormatX12_3060.Models.Abstracted.BEG
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public long BEGId { get; set; }

		public enum Ordinal
		{
			BEG01 = 1, TransactionSetPurposeCode = BEG01,
			BEG02 = 2, PurchaseOrderTypeCode = BEG02,
			BEG03 = 3, PurchaseOrderNumber = BEG03,
			BEG04 = 4, Reserved_ForFutureUse_01 = BEG04,
			BEG05 = 5, Date = BEG05
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "TransactionSetPurposeCode", (int)Ordinal.TransactionSetPurposeCode },
			{ "PurchaseOrderTypeCode",(int)Ordinal.PurchaseOrderTypeCode },
			{ "PurchaseOrderNumber",(int)Ordinal.PurchaseOrderNumber },
			{ "Date",(int)Ordinal.Date },
		};
	}
}