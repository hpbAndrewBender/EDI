using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class BSN
	{
		public BSN()
		{
			Meta_TransactionSetPurposes = new List<MetaCodes>
			{
				new MetaCodes("00","Original")
			};

			Meta_HierarchicalStructures = new List<MetaCodes>
			{
				new MetaCodes("0001","Shipment, Order, Packaging, Item")
			};

			Meta_Data = new List<MetaData>
			{
				new MetaData("BSN01",	"353",	"M",	"ID",	2, 2,	MetaData.UsageName.Required,	string.Empty,	"Transaction Set Purpose Code",         "TransactionSetPurposeCode",    Meta_TransactionSetPurposes),
				new MetaData("BSN02",	"396",	"M",	"AN",	2,30,	MetaData.UsageName.Required,	string.Empty,	"Shipment Identification",              "ShipmentIdentification",		null),
				new MetaData("BSN03",	"373",	"M",	"DT",	6, 6,	MetaData.UsageName.Required,	string.Empty,	"Date",									"Date",							null),
				new MetaData("BSN04",	"337",	"M",	"TM",	4, 8,	MetaData.UsageName.Required,	string.Empty,	"Time",									"Time",							null),
				new MetaData("BSN05",	"1005",	"O",	"ID",	4, 4,	MetaData.UsageName.Used,		string.Empty,	"Hierarchical Structure Code",          "HierarchicalStructureCode",    Meta_HierarchicalStructures),
			};
		}

		public virtual List<MetaCodes> Meta_TransactionSetPurposes { get; internal set; }

		public virtual List<MetaCodes> Meta_HierarchicalStructures { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code identifying purpose of transaction set 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BSN01	353		M	ID		002	002	Requ'd			Transaction Set Purpose Code
		///		
		///															Code	Name
		///															----	---------------
		///															00		Original
		/// </summary>
		virtual public object TransactionSetPurposeCode { get; set; }

		/// <summary>
		/// A unique control number assigned by the original shipper to identify a specific shipment
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BSN02   396		M	AN		002	030	Requ'd			Shipment Identification					
		/// </summary>
		virtual public object ShipmentIdentification { get; set; }

		/// <summary>
		/// Date (YYMMDD) 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BSN03   373		M	DT		006	006	Requ'd			Date
		/// </summary>
		virtual public object Date { get; set; }

		/// <summary>
		/// Time expressed in 24-hour clock time as follows: HHMM, or HHMMSS, or HHMMSSD, or HHMMSSDD, where H = hours (00-23), M = minutes (00-59), S = integer seconds (00-59) and DD = decimal seconds; decimal seconds are expressed as follows: D = tenths (0-9) and DD = hundredths (00-99) 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BSN04   337		M	TM		004	008	Requ'd			Time
		/// </summary>
		virtual public object Time { get; set; }

		/// <summary>
		/// Code indicating the hierarchical application structure of a transaction set that utilizes the HL segment to define the structure of the transaction set 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		BSN05   1005	O	ID		004	004	Used			Hierarchical Structure Code
		///		
		///															Code	Name
		///															----	---------------
		///															0001	Shipment, Order, Packaging, Item
		/// </summary>
		virtual public object HierarchicalStructureCode { get; set; }
	}
}