using System;
using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class AK5 : FormatX12_3060.Models.Abstracted.AK5
	{
		public string Command { get; set; }
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public List<int> RequiredFields { get => throw new NotImplementedException(); internal set => throw new NotImplementedException(); }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long AK5Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			AK501 = 1, TransactionSetAcknowledgmentCode = AK501,
			AK502 = 2, TransactionSetSyntaxErrorCode_01 = AK502,
			AK503 = 3, TransactionSetSyntaxErrorCode_02 = AK503,
			AK504 = 4, TransactionSetSyntaxErrorCode_03 = AK504,
			AK505 = 5, TransactionSetSyntaxErrorCode_04 = AK505,
			AK506 = 6, TransactionSetSyntaxErrorCode_05 = AK506,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{"TransactionSetAcknowledgmentCode", (int)Ordinal.TransactionSetAcknowledgmentCode },
			{"TransactionSetSyntaxErrorCode_01", (int)Ordinal.TransactionSetSyntaxErrorCode_01 },
			{"TransactionSetSyntaxErrorCode_02", (int)Ordinal.TransactionSetSyntaxErrorCode_02 },
			{"TransactionSetSyntaxErrorCode_03", (int)Ordinal.TransactionSetSyntaxErrorCode_03 },
			{"TransactionSetSyntaxErrorCode_04", (int)Ordinal.TransactionSetSyntaxErrorCode_04 },
			{"TransactionSetSyntaxErrorCode_05", (int)Ordinal.TransactionSetSyntaxErrorCode_05 },
		};
	}
}