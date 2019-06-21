using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class GS
	{
		public GS()
		{
			Meta_FunctionalIdentifiers=new List<MetaCodes>
			{
				new MetaCodes("PO","Purchase Order"),
				new MetaCodes("SH","Ship Notice"),
				new MetaCodes("IN","Invoice"),
				new MetaCodes("FA","Functional Acknowledgment"),
				new MetaCodes("PC","Purchase Order Change"),
				new MetaCodes("RA","Remit Advice Status"),
				new MetaCodes("RS","Order Status"),
			};

			Meta_Data=new List<MetaData>
			{
				new MetaData("GS01",    "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Functional Identifier Code",           "FunctionalIdentifierCode",     Meta_FunctionalIdentifiers),
				new MetaData("GS02",    "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Application Sender's Code",            "ApplicationSendersCode",       null),
				new MetaData("GS03",    "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Application Receiver's Code",          "ApplicationReceiversCode",     null),
				new MetaData("GS04",    "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Date",                                 "Date",                         null),
				new MetaData("GS05",    "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Time",                                 "Time",                         null),
				new MetaData("GS06",    "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Group Control Number",                 "GroupControlNumber",           null),
				new MetaData("GS07",    "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Responsible Agency Code",              "ResponsibleAgencyCode",        null),
				new MetaData("GS08",    "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown,  string.Empty,   "Version/Rel. Ind. ID Code",            "VersionRelIndIDCode",          null),
			};
		}

		public virtual List<MetaCodes> Meta_FunctionalIdentifiers { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Two letter abbreviation for the type of transaction being sent
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		GS01												Functional Identifier Code
		///		
		///															Code	Name
		///															----	---------------
		///															PO		Purchase Order
		///															SH		Ship Notice
		///															IN		Invoice
		///															FA		Functional Acknowledgment
		///															PC		Purchase Order Change
		///															RA		Remit Advice Status
		///															RS		Order Status
		/// </summary>
		virtual public object FunctionalIdentifierCode { get; set; }


		/// <summary>
		/// The identification number from the sender
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		GS02												Application Sender's Code
		/// </summary>
		virtual public object ApplicationSenderCode { get; set; }

		/// <summary>

		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		GS03												Application Receiver's Code
		/// </summary>
		virtual public object ApplicationReceiverCode { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		------	-------	---	-------	---	---	-----	-------	-------------
		///		GS04												Date
		/// </summary>
		virtual public object Date { get; set; }

		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		GS05												Time
		/// </summary>
		virtual public object Time { get; set; }


		/// <summary>
		/// Sequentially assigned by sender for each functional group
		/// (Will match the control number in the AK1 segment of the 997 for a summary level 997)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		GS06												Group Control Number
		/// </summary>
		virtual public object GroupControlNumber { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		GS07												Responsible Agency Code
		/// </summary>
		virtual public object ResponsibleAgencyCode { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		GS08										Version/Rel. Ind. ID Code
		/// </summary>
		virtual public object VersionRelIndIDCode { get; set; }
	}
}