using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class GS : FormatX12_3060.Models.Abstracted.GS
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long GSId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			GS01 = 1, FunctionalIdentifierCode = GS01,
			GS02 = 2, ApplicationSenderCode = GS02,
			GS03 = 3, ApplicationReceiverCode = GS03,
			GS04 = 4, IssueDate = GS04,
			GS05 = 5, IssueTime = GS05,
			GS06 = 6, GroupControlNumber = GS06,
			GS07 = 7, ResponsibleAgencyCode = GS07,
			GS08 = 8, EDIVersion = GS08
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "FunctionalIdentifierCode", (int)Ordinal.FunctionalIdentifierCode },
			{ "ApplicationSenderCode", (int)Ordinal.ApplicationSenderCode },
			{ "ApplicationReceiverCode", (int)Ordinal.ApplicationReceiverCode },
			{ "IssueDate", (int)Ordinal.IssueDate },
			{ "IssueTime", (int)Ordinal.IssueTime },
			{ "GroupControlNumber", (int)Ordinal.GroupControlNumber },
			{ "ResponsibleAgencyCode", (int)Ordinal.ResponsibleAgencyCode },
			{ "EDIVersion", (int)Ordinal.EDIVersion },
		};
	}
}
