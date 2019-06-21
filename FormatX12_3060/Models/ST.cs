using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class ST : FormatX12_3060.Models.Abstracted.ST
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long STId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			ST01 = 1, TransactionSetIdentifierCode = ST01,
			ST02 = 2, TransactionSetControlNumber = ST02
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "TransactionSetIdentifierCode"  ,(int)Ordinal.TransactionSetIdentifierCode },
			{ "TransactionSetControlNumber"   ,(int)Ordinal.TransactionSetControlNumber },
		};
	}
}