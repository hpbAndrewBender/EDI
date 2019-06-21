using DataHPBEDI.Models.MetaData.X12_3060;
using System.Collections.Generic;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class ST
	{
		public ST()
		{
			Meta_TransactionSetIdentifiers=new List<MetaCodes>
			{
				new MetaCodes("810",""),
				new MetaCodes("850","X12.1 Purchase Order"),
				new MetaCodes("855","X12.1 Purchase Order Acknowledgment"),
				new MetaCodes("856",""),
				new MetaCodes("997",""),
			};
			Meta_Data=new List<MetaData>
			{
				new MetaData("ST01",    "143",  "M",    "ID",   3, 3,   MetaData.UsageName.Required,    string.Empty,   "Transaction Set Identifier Code",      "TransactionSetIdentifierCode", Meta_TransactionSetIdentifiers),
				new MetaData("ST02",    "329",  "M",    "AN",   4, 9,   MetaData.UsageName.Required,    string.Empty,   "Transaction Set Control Number",       "TransactionSetControlNumber",  null),
			};
		}

		public virtual List<MetaCodes> Meta_TransactionSetIdentifiers { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code uniquely identifying a Transaction Set
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ST01	143		M	ID		003	003	Requ'd			Transaction Set Identifier Code
		///
		///															Code	Name
		///															----	---------------
		///															850		X12.1 Purchase Order
		///															855		X12.1 Purchase Order Acknowledgment
		/// </summary>
		virtual public object TransactionSetIdentifierCode { get; set; }

		/// <summary>
		/// Identifying control number that must be unique within the transaction set functional group assigned by the originator for a transaction set
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ST02	329		M	AN		004	009	Requ'd			Transaction Set Control Number
		/// </summary>
		virtual public object TransactionSetControlNumber { get; set; }
	}
}