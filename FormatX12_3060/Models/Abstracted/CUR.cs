using DataHPBEDI.Models.MetaData.X12_3060;
using System.Collections.Generic;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class CUR
	{
		public CUR()
		{
			Meta_EntityIdentifiers=new List<MetaCodes>
			{
				new MetaCodes("SE","Selling Party")
			};

			Meta_Currencies=new List<MetaCodes>
			{
				new MetaCodes("USD", "U.S. Dollar"),
				new MetaCodes("CAD", "Canadian Dollar")
			};

			Meta_Data=new List<MetaData>
			{
				new MetaData("CUR01",   "98",   "M",    "ID",   2, 2,   MetaData.UsageName.Required, string.Empty,   "Entity Identifier Code",               "EntityIdentifierCode",         Meta_EntityIdentifiers),
				new MetaData("CUR02",   "100",  "M",    "ID",   3, 3,   MetaData.UsageName.Required, string.Empty,   "Currency Code",                        "CurrencyCode",                 Meta_Currencies),
			};
		}

		public virtual List<MetaCodes> Meta_EntityIdentifiers { get; internal set; }

		public virtual List<MetaCodes> Meta_Currencies { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code identifying an organizational entity, a physical location, or an individual
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CUR01	98		M   ID		020	002	Requ'd			Entity Identifier Code
		///
		///															Code	Name
		///															----	---------------
		///															SE		Selling Party
		/// </summary>
		virtual public object EntityIdentifierCode { get; set; }

		/// <summary>
		/// Code(Standard ISO) for country in whose currency the charges are specified
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CUR02   100		M	ID		003	003	Requ'd			Currency Code
		///
		///															Code	Name
		///															----	---------------
		///															USD		U.S. Dollar
		///															CAD		Canadian Dollar
		/// </summary>
		virtual public object CurrencyCode { get; set; }
	}
}