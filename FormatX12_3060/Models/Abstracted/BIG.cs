using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class BIG
	{
		public BIG()
		{
			Meta_TransactionTypes=new List<MetaCodes>
			{
				new MetaCodes("CI", "Consolidated Invoice")
			};
			Meta_TransactionSetPurposes=new List<MetaCodes>
			{
				new MetaCodes("00","Original")
			};
			Meta_Data=new List<MetaData>
			{
				new MetaData("BIG01",   "373",  "M",    "DT",   6,06,   MetaData.UsageName.Required, string.Empty,   "Date",                                 "Date_01",                      null),
				new MetaData("BIG02",   "76",   "M",    "AN",   1,22,   MetaData.UsageName.Required, string.Empty,   "Invoice Number",                       "InvoiceNumber",                null),
				new MetaData("BIG03",   "373",  "O",    "DT",   6,06,   MetaData.UsageName.Used,     string.Empty,   "Date",                                 "Date_02",                     null),
				new MetaData("BIG04",   "324",  "O",    "AN",   1,22,   MetaData.UsageName.Used,     string.Empty,   "Purchase Order Number",                "PurchaseOrderNumber",         null),
				new MetaData("BIG05",   "328",  "O",    "AN",   1,30,   MetaData.UsageName.Used,     string.Empty,   "Release Number",                       "ReleaseNumber",               null),
				new MetaData("BIG06",   "327",  "O",    "AN",   1,08,   MetaData.UsageName.Used,     string.Empty,   "Change Order Sequence Number",         "ChangeOrderSequenceNumber",   null),
				new MetaData("BIG07",   "640",  "O",    "ID",   2,02,   MetaData.UsageName.Used,     string.Empty,   "Transaction Type Code",                "TransactionTypeCode",         Meta_TransactionTypes),
				new MetaData("BIG08",   "353",  "O",    "ID",   2,02,   MetaData.UsageName.Used,     string.Empty,   "Transaction Set Purpose Code",         "TransactionSetPurposeCode",    Meta_TransactionSetPurposes),
			};
		}

		public virtual List<MetaCodes> Meta_TransactionTypes { get; internal set; }

		public virtual List<MetaCodes> Meta_TransactionSetPurposes { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Date(YYMMDD) 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BIG01	373	M DT  006 006	Required				Date
		/// </summary>
		virtual public object Date_01 { get; set; }

		/// <summary>
		/// Identifying number assigned by issuer 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BIG02   76		M	AN		001 022	Requ'd			Invoice Number
		/// </summary>
		virtual public object InvoiceNumber { get; set; }

		/// <summary>
		/// Date(YYMMDD) 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BIG03   373		O	DT		006 006	Used			Date
		/// </summary>
		virtual public object Date_02 { get; set; }

		/// <summary>
		/// Identifying number for Purchase Order assigned by the orderer/purchaser 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BIG04   324		O	AN		001	022	Used			Purchase Order Number
		/// </summary>
		virtual public object PurchaseOrderNumber { get; set; }


		/// <summary>
		/// Number identifying a release against a Purchase Order previously placed by the parties involved in the transaction 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BIG05   328		O	AN		001	030	Used			Release Number
		/// </summary>
		virtual public object ReleaseNumber { get; set; }

		/// <summary>
		/// Number assigned by the orderer identifying a specific change or revision to a previously transmitted transaction set
		///		User:   This element is used by the publisher/manufacturer group.
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BIG06   327		O	AN		001	008	Used			Change Order Sequence Number
		/// </summary>
		virtual public object ChangeOrderSequenceNumber { get; set; }

		/// <summary>
		/// Code specifying the type of transaction 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BIG07	640		O	ID		002 002	Used			Transaction Type Code
		///		
		///															Code	Name
		///															----	---------------
		///															CI		Consolidated Invoice
		/// </summary>
		virtual public object TransactionTypeCode { get; set; }

		/// <summary>
		/// Code identifying purpose of transaction set 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BIG08	353		O	ID		002	002	Used			Transaction Set Purpose Code
		///		
		///															Code	Name
		///															----	---------------
		///															00		Original
		///															
		/// </summary>
		virtual public object TransactionSetPurposeCode { get; set; }
	}
}