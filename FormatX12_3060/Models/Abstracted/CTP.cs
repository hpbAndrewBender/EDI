using DataHPBEDI.Models.MetaData.X12_3060;
using System.Collections.Generic;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class CTP
	{
		public CTP()
		{
			Meta_PriceIdentifiers=new List<MetaCodes>
			{
				new MetaCodes("NET","Net Item Price"),
				new MetaCodes("SLP","Retail/List/Suggested Selling Price")
			};

			Meta_Units=new List<MetaCodes>
			{
				new MetaCodes("UN","Unit"),
			};

			Meta_PriceMultiplierQualifers=new List<MetaCodes>
			{
				new MetaCodes("DIS","Discount Multiplier")
			};

			Meta_Data=new List<MetaData>
			{
				new MetaData("CTP02",   "236",  "C",    "ID",   3,03,   MetaData.UsageName.Used,     string.Empty,   "Price Identifier Code",                "PriceIdentifierCode",          Meta_PriceIdentifiers),
				new MetaData("CTP03",   "212",  "O",    "R ",   1,17,   MetaData.UsageName.Used,     string.Empty,   "Unit Price",                           "UnitPrice",                    null),
				new MetaData("CTP04",   "380",  "C",    "R ",   1,15,   MetaData.UsageName.Used,     string.Empty,   "Quantity",                             "Quantity",                     null),
				new MetaData("CTP05",   "C001", "C",    "CMP",  0, 0,   MetaData.UsageName.Used,     string.Empty,   "Composite Unit of Measure",            "CompositeUnitOfMeasure",       Meta_Units),
				new MetaData("CTP06",   "648",  "C",    "R",    1,10,   MetaData.UsageName.Used,     string.Empty,   "Price Multiplier Qualifier",           "PriceMultiplierQualifier",     Meta_PriceMultiplierQualifers),
				new MetaData("CTP07",   "649",  "C",    "R",    1,10,   MetaData.UsageName.Used,     string.Empty,   "Multiplier",                           "Multiplier",                   null),
			};
		}

		public virtual List<MetaCodes> Meta_PriceIdentifiers { get; internal set; }

		public virtual List<MetaCodes> Meta_Units { get; internal set; }

		public virtual List<MetaCodes> Meta_PriceMultiplierQualifers { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		///	Code identifying pricing specification
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CTP02	236		C	ID		003	003	Used			Price Identifier Code
		///
		///															Code	Name
		///															----	--------------------------------------
		///															NET		Net Item Price
		///															SLP		Retail/List/Suggested Selling Price
		/// </summary>
		virtual public object PriceIdentifierCode { get; set; }

		/// <summary>
		///	Price per unit of product, service, commodity, etc.
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CTP03	212		O	R		001	017	Used			Unit Price
		/// </summary>
		virtual public object UnitPrice { get; set; }

		/// <summary>
		///	Numeric value of quantity
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CTP04	380		C	R		001 015 Used			Quantity
		/// </summary>
		virtual public object Quantity { get; set; }

		/// <summary>
		/// To identify a composite unit of measure(See Figures Appendix for examples of use)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CTP05	C001	C	Comp	       	Used			Composite Unit of Measure
		///				355		M	ID		002	002	Req'd			Unit or Basis for Measurement Code
		///
		///															Code	Name
		///															----	---------------
		///															UN		Unit
		/// </summary>
		virtual public object CompositeUnitOfMeasure { get; set; }

		/// <summary>
		/// Code indicating the type of price multiplier
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CTP06	648		C	R		001	010	Used			Price Multiplier Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															DIS		Discount Multiplier
		/// </summary>
		virtual public object PriceMultiplierQualifier { get; set; }

		/// <summary>
		/// Value to be used as a multiplier to obtain a new value
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CTP07	649		C	R		001	010	Used			Multiplier
		/// </summary>
		virtual public object Multiplier { get; set; }
	}
}