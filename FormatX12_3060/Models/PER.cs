using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class PER : FormatX12_3060.Models.Abstracted.PER
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long PERId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			PER01 = 1, ContactFunctionCode = PER01,
			PER02 = 2, Name = PER02,
			PER03 = 3, CommunicationNumberQualifier_01 = PER03,
			PER04 = 4, CommunicationNumber_01 = PER04,
			PER05 = 5, CommunicationNumberQualifier_02 = PER05,
			PER06 = 6, CommunicationNumber_02 = PER06,
			PER07 = 7, CommunicationNumberQualifier_03 = PER07,
			PER08 = 8, CommunicationNumber_03 = PER08,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "ContactFunctionCode", (int)Ordinal.ContactFunctionCode },
			{ "Name", (int)Ordinal.Name },
			{ "CommunicationNumberQualifier_01", (int)Ordinal.CommunicationNumberQualifier_01 },
			{ "CommunicationNumber_01", (int)Ordinal.CommunicationNumber_01 },
			{ "CommunicationNumberQualifier_02", (int)Ordinal.CommunicationNumberQualifier_02 },
			{ "CommunicationNumber_02", (int)Ordinal.CommunicationNumber_02 },
			{ "CommunicationNumberQualifier_03", (int)Ordinal.CommunicationNumberQualifier_03 },
			{ "CommunicationNumber_03", (int)Ordinal.CommunicationNumber_03 },
		};
	}
}