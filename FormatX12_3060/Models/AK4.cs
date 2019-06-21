using System;
using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class AK4 : FormatX12_3060.Models.Abstracted.AK4
	{
		public string Command { get; set; }
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public List<int> RequiredFields { get => throw new NotImplementedException(); internal set => throw new NotImplementedException(); }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long AK4Id { get; set; }

		public enum Ordinal
		{ Command = 0,
			AK401 = 1, PositionInSegment = AK401,
			AK402 = 2, DataElementReferenceNumber = AK402,
			AK403 = 3, DataElementSyntaxErrorCode = AK403,
			AK404 = 4, CopyOfBadDataElement = AK404
		};

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "PositionInSegment", (int)Ordinal.PositionInSegment },
			{ "DataElementReferenceNumber", (int)Ordinal.DataElementReferenceNumber },
			{ "DataElementSyntaxErrorCode", (int)Ordinal.DataElementSyntaxErrorCode },
			{ "CopyOfBadDataElement", (int)Ordinal.CopyOfBadDataElement },
		};
	}
}