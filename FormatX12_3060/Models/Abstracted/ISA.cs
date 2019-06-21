using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class ISA
	{
		public ISA()
		{
			Meta_QualifierCodes=new List<MetaCodes>
			{
				new MetaCodes("01","DUNS #"),
				new MetaCodes("08","UCC EDI #"),
				new MetaCodes("12","Phone #"),
				new MetaCodes("14","DUNS + Suffix #"),
				new MetaCodes("ZZ","Mutually Defined"),
			};

			Meta_UsageIndicatorCodes=new List<MetaCodes>
			{
				new MetaCodes("P","Production"),
				new MetaCodes("T","Test")
			};

			Meta_Data=new List<MetaData>
			{
				new MetaData("ISA01",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Authorization Information Qualifier",  "AuthorizationInformationQualifier",null),
				new MetaData("ISA02",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Authorization Information",            "AuthorizationInformation",         null),
				new MetaData("ISA03",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Security Information Qualifier",       "SecurityInformationQualifier",     null),
				new MetaData("ISA04",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Security Information",                 "SecurityInformation",              null),
				new MetaData("ISA05",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Sender Qualifier ID",                  "SenderQualifierID",                Meta_QualifierCodes),
				new MetaData("ISA06",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Interchange Sender ID",                "InterchangeSenderID",              null),
				new MetaData("ISA07",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Receiver Qualifier ID",                "ReceiverQualifierID",              Meta_QualifierCodes),
				new MetaData("ISA08",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Interchange Receiver ID",              "InterchangeReceiverID",            null),
				new MetaData("ISA09",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Interchange Date",                     "InterchangeDate",                  null),
				new MetaData("ISA10",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Interchange Time",                     "InterchangeTime",                  null),
				new MetaData("ISA11",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Interchange Control Standards ID",     "InterchangeControlStandardsID",    null),
				new MetaData("ISA12",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "InterchangeControlVersionNumber",      "InterchangeControlVersionNumber",  null),
				new MetaData("ISA13",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Interchange Control Number",           "InterchangeControlNumber",         null),
				new MetaData("ISA14",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Acknowledgment Requested",             "AcknowledgmentRequested",          null),
				new MetaData("ISA15",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Usage Indicator",                      "UsageIndicator",                   Meta_UsageIndicatorCodes),
				new MetaData("ISA16",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Subelement Separator",                 "SubelementSeparator",              null),
			};
		}
		public virtual List<MetaCodes> Meta_QualifierCodes { get; internal set; }

		public virtual List<MetaCodes> Meta_UsageIndicatorCodes { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA01										Authorization Information Qualifier
		/// </summary>
		virtual public object AuthorizationInformationQualifier { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA02										Authorization Information
		/// </summary>
		virtual public object AuthorizationInformation { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA03												Security Information Qualifier
		/// </summary>
		virtual public object SecurityInformationQualifier { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA04												Security Information
		/// </summary>
		virtual public object SecurityInformation { get; set; }

		/// <summary>
		/// Two digits that specify what kind of sender identification is used in segment ISA06
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA05												Sender Qualifier ID
		///		
		///															Code	Name
		///															----	---------------
		///															01		Duns #
		///															08		UCC EDI #
		///															12		phone #
		///															14		Duns + suffix #
		///															ZZ		mutually defined
		/// </summary>
		virtual public object SenderQualifierID { get; set; }


		/// <summary>
		/// 	A number that uniquely identifies the sender (The Duns #, UCC EID #, phone #, Duns + suffix #, or mutually defined #)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA06												Interchange Sender ID
		/// </summary>
		virtual public object InterchangeSenderID { get; set; }

		/// <summary>
		/// Two digits that specify what kind of receiver identification is used in segment ISA08
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA07												Receiver Qualifier ID
		///		
		///															Code	Name
		///															----	---------------
		///															01		Duns #
		///															08		UCC EDI #
		///															12		phone #
		///															14		Duns + suffix #
		///															ZZ		mutually defined
		/// </summary>
		virtual public object ReceiverQualifierID { get; set; }

		/// <summary>
		/// A number that uniquely identifies the receiver	(The Duns #, UCC EID #, phone #, Duns + suffix #, or mutually defined #)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA08												Interchange Receiver ID
		/// </summary>
		virtual public object InterchangeReceiverID { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA09												Interchange Date
		/// </summary>
		virtual public object InterchangeDate { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA10												Interchange Time
		/// </summary>
		virtual public object InterchangeTime { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA11												Interchange Control Standards ID
		/// </summary>
		virtual public object InterchangeControlStandardsID { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA12												InterchangeControlVersionNumber
		/// </summary>
		virtual public object InterchangeControlVersionNumber { get; set; }

		/// <summary>
		/// Sequential assigned number by the sender for this transmission (Will match the ISA15 number in the envelope report on EC Grid)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA13										Interchange Control Number
		/// </summary>
		virtual public object InterchangeControlNumber { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA14												Acknowledgment Requested
		/// </summary>
		virtual public object AcknowledgmentRequested { get; set; }

		/// <summary>
		/// Identifies this transmission's purpose for production or test
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA15												Usage Indicator
		///		
		///															Code	Name
		///															----	---------------
		///															P		Production
		///															T		Test
		/// </summary>
		virtual public object UsageIndicator { get; set; }

		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ISA16												Subelement Separator
		/// </summary>
		virtual public object SubelementSeparator { get; set; }
	}
}