using System;
using System.Collections.Generic;

namespace FormatX12_3060.Models

{
	public class AK2 : FormatX12_3060.Models.Abstracted.AK2
	{
		public string Command { get; set; }
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public List<int> RequiredFields { get => throw new NotImplementedException(); internal set => throw new NotImplementedException(); }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long AK2Id { get; set; }

		public enum Ordinal
		{
			Command = 0,
			AK201 = 1, TransactionSetIdentifierCode = AK201,
			AK202 = 2, TransactionSetControlNumber = AK202
		};

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "TransactionSetIdentifierCode", (int)Ordinal.TransactionSetIdentifierCode },
			{ "TransactionSetControlNumber", (int)Ordinal.TransactionSetControlNumber },
		};
	}
}