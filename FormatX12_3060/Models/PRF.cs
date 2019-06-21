using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class PRF : FormatX12_3060.Models.Abstracted.PRF
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long PRFId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			PRF01 = 1, PurchaseOrderNumber = PRF01,
			PRF02 = 2, ReleaseNumber = PRF02,
			PRF03 = 3, Reserved_ForFutureUse_01 = PRF03,
			PRF04 = 4, Date = PRF04,
			PRF05 = 5, AssignedIdentification = PRF05,
			PRF06 = 6, ContractNumber = PRF06,
			PRF07 = 7, PurchaseOrderTypeCode = PRF07
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "PurchaseOrderNumber", (int)Ordinal.PurchaseOrderNumber},
			{ "ReleaseNumber", (int)Ordinal.ReleaseNumber },
			{ "Date", (int)Ordinal.Date },
			{ "AssignedIdentification", (int)Ordinal.AssignedIdentification },
			{ "ContractNumber", (int)Ordinal.ContractNumber },
			{ "PurchaseOrderTypeCode", (int)Ordinal.PurchaseOrderTypeCode }
		};
	}
}