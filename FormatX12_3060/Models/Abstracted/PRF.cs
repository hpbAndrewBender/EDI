using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class PRF
	{
		public PRF()
		{
			Meta_PurchaseOrderTypes = new List<MetaCodes>
			{
				new MetaCodes("SA","Stand-alone Order"),
			};
			Meta_Data = new List<MetaData>
			{
				new MetaData("PRF01",   "324",  "M",    "AN",   1,22,   MetaData.UsageName.Required,    string.Empty,   "Purchase Order Number",                "PurchaseOrderNumber",          null),
				new MetaData("PRF02",   "328",  "O",    "AN",   1,30,   MetaData.UsageName.Used,        string.Empty,   "Release Number",                       "ReleaseNumber",                null),
				new MetaData("PRF04",   "373",  "O",    "DT",   6, 6,   MetaData.UsageName.Used,        string.Empty,   "Date",                                 "Date",                         null),
				new MetaData("PRF05",   "350",  "O",    "AN",   1,20,   MetaData.UsageName.Used,        string.Empty,   "Assigned Identification",              "AssignedIdentification",       null),
				new MetaData("PRF06",   "367",  "O",    "AN",   1,30,   MetaData.UsageName.Used,        string.Empty,   "Contract Number",                      "ContractNumber",               null),
				new MetaData("PRF07",   "92",   "O",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Purchase Order Type Code",             "PurchaseOrderTypeCode",        Meta_PurchaseOrderTypes),
			};
		}

		public virtual List<MetaCodes> Meta_PurchaseOrderTypes { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Identifying number for Purchase Order assigned by the orderer/purchaser
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PRF01	324		M	AN		1	22	Requ'd			Purchase Order Number
		/// </summary>
		virtual public object PurchaseOrderNumber { get; set; }

		/// <summary>
		/// Number identifying a release against a Purchase Order previously placed by the parties involved in the transaction
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PRF02	328		O	AN		1	30	Used			Release Number
		/// </summary>
		virtual public object ReleaseNumber { get; set; }

		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		#PRF03
		/// </summary>
		virtual public object Reserved_ForFutureUse_01 { get; set; }

		/// <summary>
		/// Date (YYMMDD)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PRF04	373		O	DT		6	6	Used			Date
		/// </summary>
		virtual public object Date { get; set; }

		/// <summary>
		/// Alphanumeric characters assigned for differentiation within a transaction set
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PRF05	350		O	AN		1	20	Used			Assigned Identification
		/// </summary>
		virtual public object AssignedIdentification { get; set; }

		/// <summary>
		/// Contract number
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PRF06	367		O	AN		1	30	Used			Contract Number
		/// </summary>
		virtual public object ContractNumber { get; set; }

		/// <summary>
		/// Code specifying the type of Purchase Order
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PRF07	92		O	ID		2	2	Used			Purchase Order Type Code
		///		
		///															Code	Name
		///															----	---------------
		///															SA		Stand-alone Order
		/// </summary>
		virtual public object PurchaseOrderTypeCode { get; set; }
	}
}