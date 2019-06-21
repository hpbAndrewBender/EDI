using System;
using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class AK9 : FormatX12_3060.Models.Abstracted.AK9
	{
		public string Command { get; set; }
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public List<int> RequiredFields { get => throw new NotImplementedException(); internal set => throw new NotImplementedException(); }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long AK9Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			AK901 = 1, FunctionalGroupAcknowledgeCode = AK901,
			AK902 = 2, NumberOfTransactionSetsIncluded = AK902,
			AK903 = 3, NumberOfReceivedTransactionSets = AK903,
			AK904 = 4, NumberOfAcceptedTransactionSets = AK904,
			AK905 = 5, FunctionalGroupSyntaxErrorCode_01 = AK905,
			AK906 = 6, FunctionalGroupSyntaxErrorCode_02 = AK906,
			AK907 = 7, FunctionalGroupSyntaxErrorCode_03 = AK907,
			AK908 = 8, FunctionalGroupSyntaxErrorCode_04 = AK908,
			AK909 = 9, FunctionalGroupSyntaxErrorCode_05 = AK909,
		};

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "FunctionalGroupAcknowledgeCode",  (int)Ordinal.FunctionalGroupAcknowledgeCode },
			{ "NumberOfTransactionSetsIncluded", (int)Ordinal.NumberOfTransactionSetsIncluded },
			{ "NumberOfReceivedTransactionSets", (int)Ordinal.NumberOfReceivedTransactionSets },
			{ "NumberOfAcceptedTransactionSets", (int)Ordinal.NumberOfAcceptedTransactionSets },
			{ "FunctionalGroupSyntaxErrorCode_01", (int)Ordinal.FunctionalGroupSyntaxErrorCode_01 },
			{ "FunctionalGroupSyntaxErrorCode_02", (int)Ordinal.FunctionalGroupSyntaxErrorCode_02 },
			{ "FunctionalGroupSyntaxErrorCode_03", (int)Ordinal.FunctionalGroupSyntaxErrorCode_03 },
			{ "FunctionalGroupSyntaxErrorCode_04", (int)Ordinal.FunctionalGroupSyntaxErrorCode_04 },
			{ "FunctionalGroupSyntaxErrorCode_05", (int)Ordinal.FunctionalGroupSyntaxErrorCode_05 },
		};		
	}
}
 