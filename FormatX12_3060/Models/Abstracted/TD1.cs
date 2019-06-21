using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class TD1
	{
		internal TD1()
		{
			Meta_PackingCodes = new List<MetaCodes>
			{
				new MetaCodes("CTN25","Carton, corrugated or solid"),
				new MetaCodes("PLT94","Pallet, wood"),
				new MetaCodes("UNT76","Unit, paper"),
			};
			Meta_CommodifyQualiifers = new List<MetaCodes>
			{
				new MetaCodes("Z","Mutually defined. (The Book Industry uses this value for insurance commodity codes.)"),
			};
			Meta_WeightQualifiers = new List<MetaCodes>
			{
				new MetaCodes("G","Gross Weight"),
			};
			Meta_Weights = new List<MetaCodes>
			{
				new MetaCodes("LB","Pound"),
			};
			Meta_Data = new List<MetaData>
			{
  				new MetaData("TD101",   "103",  "O",    "AN",   3, 5,   MetaData.UsageName.Used,        string.Empty,   "Packaging Code",                       "PackagingCode",                Meta_PackingCodes),
				new MetaData("TD102",   "80",   "C",    "N0",   1, 7,   MetaData.UsageName.Used,        string.Empty,   "Lading Quantity",                      "LadingQuantity",               null),
				new MetaData("TD103",   "23",   "O",    "ID",   1, 1,   MetaData.UsageName.Used,        string.Empty,   "Commodity Code Qualifier",             "CommodityCodeQualifier",       Meta_CommodifyQualiifers),
				new MetaData("TD104",   "22",   "C",    "AN",   1,30,   MetaData.UsageName.Used,        string.Empty,   "Commodity Code",                       "CommodityCode",                null),
				new MetaData("TD105",   "79",   "O",    "AN",   1,50,   MetaData.UsageName.Used,        string.Empty,   "Lading Description",                   "LadingDescription",            null),
				new MetaData("TD106",   "187",  "O",    "ID",   1, 2,   MetaData.UsageName.Used,        string.Empty,   "Weight Qualifier",                     "WeightQualifier",              Meta_WeightQualifiers),
				new MetaData("TD107",   "81",   "C",    "R",    1,10,   MetaData.UsageName.Used,        string.Empty,   "Weight",                               "Weight",                       null),
				new MetaData("TD108",   "355",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Unit or Basis for Measurement Code",   "UnitOrBasisForMeasurementCode",Meta_Weights),
			};
		}

		public virtual List<MetaCodes> Meta_PackingCodes { get; internal set; }

		public virtual List<MetaCodes> Meta_CommodifyQualiifers { get; internal set; }

		public virtual List<MetaCodes> Meta_WeightQualifiers { get; internal set; }

		public virtual List<MetaCodes> Meta_Weights { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

	/// <summary>
	/// Code identifying the type of packaging; Part 1: Packaging Form, Part 2: Packaging Material
	///		
	///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
	///		-------	-------	---	-------	---	---	-----	-------	-------------
	///		TD101	103		O	AN		3	5	Used			Packaging Code
	///		
	///															Code	Name (The Book Industry uses the following code values)
	///															----	---------------
	///															CTN25	Carton, corrugated or solid
	///															PLT94	Pallet, wood
	///															UNT76	Unit, paper
	/// </summary>
	virtual public object PackagingCode { get; set; }

		/// <summary>
		/// Number of units (pieces) of the lading commodity
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD102	80		C	N0		1	7	Used			Lading Quantity
		/// </summary>
		virtual public object LadingQuantity { get; set; }

		/// <summary>
		/// Code identifying the commodity coding system used for Commodity Code
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD103	23		O	ID		1	1	Used			Commodity Code Qualifier
		///															Code	Name
		///															----	---------------
		///															Z		Mutually defined. (The Book Industry uses this value for insurance comodity codes.)
		/// </summary>
		virtual public object CommodityCodeQualifier { get; set; }

		/// <summary>
		/// Code describing a commodity or group of commodities
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD104	22		C	AN		1	30	Used			Commodity Code
		/// </summary>
		virtual public object CommodityCode { get; set; }

		/// <summary>
		/// Description of an item as required for rating and billing purposes
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD105	79		O	AN		1	50	Used			Lading Description
		/// </summary>
		virtual public object LadingDescription { get; set; }

		/// <summary>
		/// Code defining the type of weight
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD106	187		O	ID		1	2	Used			Weight Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															G		Gross Weight
		/// </summary>
		virtual public object WeightQualifier { get; set; }

		/// <summary>
		/// Numeric value of weight
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD107	81		C	R		1	10	Used			Weight
		/// </summary>
		virtual public object Weight { get; set; }

		/// <summary>
		/// Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD108	355		C	ID		2	2	Used			Unit or Basis for Measurement Code
		///		
		///															Code	Name
		///															----	---------------
		///															LB		Pound
		/// </summary>
		virtual public object UnitOrBasisForMeasurementCode { get; set; }
	}
}