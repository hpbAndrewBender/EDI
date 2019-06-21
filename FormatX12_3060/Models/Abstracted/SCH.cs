using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class SCH
	{
		public SCH()
		{
			Meta_Units = new List<MetaCodes>
			{
				new MetaCodes("UN","Units"),
			};

			Meta_EntityIdentifiers = new List<MetaCodes>
			{
				new MetaCodes("WH","Warehouse"),
			};

			Meta_DateTimeQualifiers = new List<MetaCodes>
			{
				new MetaCodes("068","Current Schedule Ship"),
			};

			Meta_Data = new List<MetaData>
			{
				new MetaData("SCH01",   "380",  "M",    "R",    1,15,   MetaData.UsageName.Required, string.Empty,  "Quantity",                             "Quantity",                         null),
				new MetaData("SCH02",   "355",  "M",    "ID",   2, 2,   MetaData.UsageName.Required, string.Empty,  "Unit or Basis for Measurement Code",   "UnitOrBasisForMeasurementCode",    Meta_Units),
				new MetaData("SCH03",   "98",   "O",    "ID",   2, 2,   MetaData.UsageName.Used    , string.Empty,  "Entity Identifier Code",               "EntityIdentifierCode",             Meta_EntityIdentifiers),
				new MetaData("SCH04",   "93",   "C",    "AN",   1,35,   MetaData.UsageName.Used    , string.Empty,  "Name",                                 "Name",                             null),
				new MetaData("SCH05",   "374",  "M",    "ID",   3, 3,   MetaData.UsageName.Required, string.Empty,  "Date/Time Qualifier",                  "DateTimeQualifier",                Meta_DateTimeQualifiers),
				new MetaData("SCH06",   "373",  "M",    "DT",   6, 6,   MetaData.UsageName.Required, string.Empty,  "Date",                                 "Date",                             null),
				new MetaData("SCH11",   "326",  "O",    "AN",   1,45,   MetaData.UsageName.Used    , string.Empty,  "Request Reference Number",             "RequestReferenceNumber",           null),
			};
		}

		public virtual List<MetaCodes> Meta_Units { get; internal set; }

		public virtual List<MetaCodes> Meta_EntityIdentifiers { get; internal set; }

		public virtual List<MetaCodes> Meta_DateTimeQualifiers { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Numeric value of quantity
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SCH01	380	M	R	1/15	Required	Quantity
		/// </summary>
		virtual public object Quantity { get; set; }

		/// <summary>
		/// Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SCH02	355	M	ID	2/2	Required	Unit or Basis for Measurement Code
		///		
		///															Code	Name
		///															----	---------------
		///															UN		Unit
		/// </summary>
		virtual public object UnitOrBasisForMeasurementCode { get; set; }

		/// <summary>
		/// Code identifying an organizational entity, a physical location, or an individual
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SCH03	98	O	ID	2/2	Used	Entity Identifier Code
		///		
		///															Code	Name
		///															----	---------------
		///															WH		Warehouse
		/// </summary>
		virtual public object EntityIdentifierCode { get; set; }

		/// <summary>
		/// Free-form name
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SCH04	93	C	AN	1/35	Used	Name
		/// </summary>
		virtual public object Name { get; set; }

		/// <summary>
		/// Code specifying type of date or time, or both date and time
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SCH05	374	M	ID	3/3	Required	Date/Time Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															068		Current Schedule Ship
		/// </summary>
		virtual public object DateTimeQualifier { get; set; }

		/// <summary>
		///  Date (YYMMDD)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SCH06	373	M	DT	6/6	Required	Date
		/// </summary>
		virtual public object Date { get; set; }

		/// <summary>
		/// Reference number or RFQ number to use to identify a particular transaction set and query (additional reference number or description which can be used with contract number)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SCH11	326	O	AN	1/45	Used	Request Reference Number
		/// </summary>
		virtual public object RequestReferenceNumber { get; set; }

	}
}