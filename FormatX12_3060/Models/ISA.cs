using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class ISA : FormatX12_3060.Models.Abstracted.ISA
	{
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long ISAId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			ISA01 = 1, AuthorizationInformationQualifier = ISA01,
			ISA02 = 2, AuthorizationInformation = ISA02,
			ISA03 = 3, SecurityInformationQualifier = ISA03,
			ISA04 = 4, SecurityInformation = ISA04,
			ISA05 = 5, SenderQualifierID = ISA05,
			ISA06 = 6, InterchangeSenderID = ISA06,
			ISA07 = 7, ReceiverQualifierID = ISA07,
			ISA08 = 8, InterchangeReceiverID = ISA08,
			ISA09 = 9, InterchangeDate = ISA09,
			ISA10 = 10, InterchangeTime = ISA10,
			ISA11 = 11, InterchangeControlStandardsID = ISA11,
			ISA12 = 12, InterchangeControlVersionNumber = ISA12,
			ISA13 = 13, InterchangeControlNumber = ISA13,
			ISA14 = 14, AcknowledgementRequested = ISA14,
			ISA15 = 15, UsageIndicator = ISA15,
			ISA16 = 16, SubelementSeparator = ISA16,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "AuthorizationInformationQualifier", (int)Ordinal.AuthorizationInformationQualifier },
			{ "AuthorizationInformation", (int)Ordinal.AuthorizationInformation },
			{ "SecurityInformationQualifier", (int)Ordinal.SecurityInformationQualifier },
			{ "SecurityInformation", (int)Ordinal.SecurityInformation },
			{ "SenderQualifierID", (int) Ordinal.SenderQualifierID },
			{ "InterchangeSenderID", (int)Ordinal.InterchangeSenderID },
			{ "ReceiverQualifierID", (int)Ordinal.ReceiverQualifierID },
			{ "InterchangeReceiverID",(int)Ordinal.InterchangeReceiverID },
			{ "InterchangeDate", (int)Ordinal.InterchangeDate},
			{ "InterchangeTime", (int)Ordinal.InterchangeTime},
			{ "InterchangeControlStandardsID", (int)Ordinal.InterchangeControlStandardsID},
			{ "InterchangeControlVersionNumber", (int)Ordinal.InterchangeControlVersionNumber},
			{ "InterchangeControlNumber",(int)Ordinal.InterchangeControlNumber },
			{ "AcknowledgementRequested", (int)Ordinal.AcknowledgementRequested },
			{ "UsageIndicator",(int)Ordinal.UsageIndicator },
			{ "SubelementSeparator", (int)Ordinal.SubelementSeparator },
		};
	}
}