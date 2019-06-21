using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class BAK
	{
		public BAK()
		{
			Meta_TransactionSetPurposes=new List<MetaCodes>
			{
				new MetaCodes("00", "Original")
			};
			Meta_AcknowledgmentTypes=new List<MetaCodes>
			{
				new MetaCodes("AC", "Acknowledge-with Detail an Change"),
				new MetaCodes("AD", "Acknowledge-with Detail, no change"),
				new MetaCodes("ZZ", "Mutually Defined")
			};
			Meta_Data=new List<MetaData>
			{
				new MetaData("BAK01",   "353",  "M",    "ID",   2, 2,   MetaData.UsageName.Required, string.Empty,   "Transaction Set Purpose Code", "TransactionSetPurposeCodes",   Meta_TransactionSetPurposes ),
				new MetaData("BAK02",   "587",  "M",    "ID",   2, 2,   MetaData.UsageName.Required, string.Empty,   "Acknowledgment Type",          "AcknowledgmentType",           Meta_AcknowledgmentTypes ),
				new MetaData("BAK03",   "324",  "M",    "AN",   1,22,   MetaData.UsageName.Required, string.Empty,   "Purchase Order Number",        "PurchaseOrderNumber",          null ),
				new MetaData("BAK04",   "373",  "M",    "DT",   6, 6,   MetaData.UsageName.Required, string.Empty,   "Date",                         "Date_01",                      null),
				new MetaData("BAK05",   "328",  "O",    "AN",   1,30,   MetaData.UsageName.Used,     "Blank",        "Release Number",               "ReleaseNumber",                null),
				new MetaData("BAK06",   "326",  "O",    "AN",   1,45,   MetaData.UsageName.Used,     "Blank",        "Request Reference Number",     "RequestedReferenceNumber",     null),
				new MetaData("BAK07",   "367",  "O",    "AN",   1,30,   MetaData.UsageName.Used,     "Blank",        "Contract number",              "ContractNumber",               null),
				new MetaData("BAK09",   "373",  "O",    "DT",   6, 6,   MetaData.UsageName.Required, string.Empty,   "Date",                         "Date_02",                      null)
			};
		}

		public virtual List<MetaCodes> Meta_TransactionSetPurposes { get; internal set; }

		public virtual List<MetaCodes> Meta_AcknowledgmentTypes { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code identifying purpose of transaction set 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BAK01	353		M	ID		002	002	Req'rd			Transaction Set Purpose Code
		///		
		///															Code	Name
		///															----	---------------
		///															00		Original
		/// </summary>
		virtual public string TransactionSetPurposeCode { get; set; }

		/// <summary>
		/// Code specifying the type of acknowledgment
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default Element Name
		///		-------	-------	---	-------	---	---	-----	------- -------------
		///		BAK02	587		M	ID		002	002	Req'rd	        Acknowledgment Type
		///															
		///															Code	Name
		///															----	---------------
		///															AD		Acknowledge -with detail, no change
		/// </summary>
		virtual public object AcknowledgmentType { get; set; }

		/// <summary>
		/// Identifying number for Purchase Order assigned by the orderer/purchaser 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BAK03	324		M	AN		001	022	Req'rd			Purchase Order Number
		/// </summary>
		virtual public object PurchaseOrderNumber { get; set; }

		/// <summary>
		/// DATE (YYMMDD)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BAK04	373		M	DT		006	006	Req'rd			Date										
		/// </summary>
		virtual public object Date_01 { get; set; }

		/// <summary>
		/// Number identifying a release against a Purchase Order previously placed by the parties involved in the transaction
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BAK05	328		O	AN		001	030	Used	Blank  	Release Number 								
		/// </summary>
		virtual public object ReleaseNumber { get; set; }

		/// <summary>
		/// Reference number or RFQ number to use to identify a particular transaction set and query (additional reference number or description which can be used with contract number) 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BAK06	326		O	AN		001	045	Used	Blank	Request Reference Number
		/// </summary>
		virtual public object RequestReferenceNumber { get; set; }

		/// <summary>
		/// Contract Number
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BAK07	367		O	AN		001	030	Used	Blank	Contract number
		/// </summary>
		virtual public object ContractNumber { get; set; }

		/// <summary>
		/// N/A
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BAK08	n/a		n/a	n/a		000	000	n/a		n/a		n/a								
		/// </summary>
		virtual public object Reserved_ForFutureUse_01 { get; set; }
		/// <summary>
		/// Date (YYMMDD)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BAK09	373		O	DT		006	006	Req'rd			Date							
		/// </summary>
		virtual public object Date_02 { get; set; }

	}
}