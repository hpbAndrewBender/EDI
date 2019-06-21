using DataHPBEDI.Models.MetaData.X12_3060;
using System.Collections.Generic;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class BEG
	{
		public BEG()
		{
			Meta_TransactionSetPurposes=new List<MetaCodes>
			{
				new MetaCodes("00", "Original"),
			};
			Meta_PurchaseOrderTypes=new List<MetaCodes>
			{
				new MetaCodes("NE","New Order - Mos commonly used value in the book industry"),
			};
			Meta_Data=new List<MetaData>
			{
				new MetaData("BEG01",   "353",  "M",    "ID",   2, 2,   MetaData.UsageName.Required, string.Empty,   "Transaction Set Purpose Code",         "TransactionSetPurposeCode",    Meta_TransactionSetPurposes),
				new MetaData("BEG02",   "92",   "M",    "ID",   2, 2,   MetaData.UsageName.Required, string.Empty,   "Purchase Order Type Code",             "PurchaseOrderTypeCode",        Meta_PurchaseOrderTypes),
				new MetaData("BEG03",   "324",  "M",    "AN",   1,22,   MetaData.UsageName.Required, string.Empty,   "Purchase Order Number",                "PurchaseOrderNumber",          null),
				new MetaData("BEG05",   "373",  "M",    "DT",   6, 6,   MetaData.UsageName.Required, string.Empty,   "Date",                                 "Date",                         null),
			};
		}

		public virtual List<MetaCodes> Meta_TransactionSetPurposes { get; internal set; }

		public virtual List<MetaCodes> Meta_PurchaseOrderTypes { get; internal set; }
		public virtual List<MetaData> Meta_Data { get; internal set;}

		/// <summary>
		/// Code identifying purpose of transaction set
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BEG01	353		M	ID		002	002	Reqrd			Transaction Set Purpose Code
		///
		///															Code	Name
		///															----	---------------
		///															00		Original
		/// </summary>
		virtual public object TransactionSetPurposeCode { get; set; }

		/// <summary>
		/// Code specifying the type of Purchase Order
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BEG02	92		M	ID		002	002	Reqrd			Purchase Order Type Code
		///
		///															Code	Name
		///															----	---------------
		///															NE		New Order - Mos commonly used value in the book industry
		/// </summary>
		virtual public object PurchaseOrderTypeCode { get; set; }

		/// <summary>
		/// Identifying number for Purchase Order assigned by the orderer/purchaser
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BEG03	324		M	AN		001	022	Reqrd			Purchase Order Number
		/// </summary>
		virtual public object PurchaseOrderNumber { get; set; }

		/// <summary>
		/// Date(YYMMDD)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BEG04
		/// </summary>
		virtual public object Reserved_ForFutureUse_01 { get; set; }

		/// <summary>
		/// Date(YYMMDD)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BEG05	373		M	DT		006	006	Reqr'd			Date
		/// </summary>
		virtual public object Date { get; set; }
	}
}