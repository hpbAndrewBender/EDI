using System;
using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class AK3 : FormatX12_3060.Models.Abstracted.AK3
	{
		public string Command { get; set; }
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public List<int> RequiredFields { get => throw new NotImplementedException(); internal set => throw new NotImplementedException(); }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long AK3Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			AK301 = 1, SegmentIDCode = AK301,
			AK302 = 2, SegmentPositionInTransactionSet = AK302,
			AK303 = 3, LoopIdentifierCode = AK303,
			AK304 = 4, SegmentSyntaxErrorCode = AK304,
		};

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "SegmentIDCode", (int)Ordinal.SegmentIDCode },
			{ "SegmentPositionInTransactionSet", (int)Ordinal.SegmentPositionInTransactionSet },
			{ "LoopIdentifierCode", (int)Ordinal.LoopIdentifierCode },
			{ "SegmentSyntaxErrorCode", (int)Ordinal.SegmentSyntaxErrorCode },
		};
	}
}