using DataHPBEDI.Models.MetaData.X12_3060;
using System.Collections.Generic;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class SLN
	{
		internal SLN()
		{
			Meta_Relationships=new List<MetaCodes>
			{
				new MetaCodes("O","Information Only (Charges which relate to but may not be included in or added to the unit price of the SLN (i.e. compute WATS calculation based upon usage amounts))"),
			};
			Meta_Measures=new List<MetaCodes>
			{
				 new MetaCodes("EA", "Each"),
			};
			Meta_UnitOfPrices=new List<MetaCodes>
			{
				new MetaCodes("CP","Current Price (Subject To Change)"),
			};
			Meta_Descriptions=new List<MetaCodes>
			{
				new MetaCodes("MG","Manufacturer's Part Number"),
				new MetaCodes("MN","3 digit manufacturer part code"),
				new MetaCodes("SN","Serial Number"),
				new MetaCodes("BP","Buyer's Part Number"),
				new MetaCodes("TZ","Hardware Product Description"),
				new MetaCodes("C6","Asset Type (Hardware)"),
				new MetaCodes("Z3","Hardware Invoice Date"),
				new MetaCodes("Z4","Hardware Invoice Number"),
				new MetaCodes("JN","Hardware Sales Order Number"),
			};
			Meta_Data=new List<MetaData>
			{
				new MetaData("SLN01",   "350",  "M",    "AN",   1,20,   MetaData.UsageName.Must,        string.Empty,   "Assigned Identification",              "AssignedIdentification",       null),
				new MetaData("SLN03",   "662",  "M",    "ID",   1, 1,   MetaData.UsageName.Must,        string.Empty,   "Relationship Code",                    "RelationshipCode_01",          Meta_Relationships),
				new MetaData("SLN04",   "380",  "X",    "R",    1,15,   MetaData.UsageName.Used,        string.Empty,   "Quantity",                             "Quantity",                     null),
				new MetaData("SLN05",   "Comp", "",     "",     0, 0,   MetaData.UsageName.Used,        string.Empty,   "Composite Unit of Measure",            "CompositeUnitOfMeasure",       Meta_Measures),
				new MetaData("SLN06",   "639",  "O",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Unit Price",                           "UnitPrice",                    null),
				new MetaData("SLN08",   "662",  "O",    "ID",   1, 1,   MetaData.UsageName.Used,        string.Empty,   "Relationship Code",                    "RelationshipCode_02",          Meta_Relationships),
				new MetaData("SLN09",   "235",  "X",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_01", Meta_Descriptions),
				new MetaData("SLN10",   "234",  "X",    "AN",   1,48,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID",                   "ProductServiceID_01",          null),
				new MetaData("SLN11",   "235",  "X",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_02", Meta_Descriptions),
				new MetaData("SLN12",   "234",  "X",    "AN",   1,48,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID",                   "ProductServiceID_02",          null),
				new MetaData("SLN13",   "235",  "X",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_03", Meta_Descriptions),
				new MetaData("SLN14",   "234",  "X",    "AN",   1,48,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID",                   "ProductServiceID_03",          null),
				new MetaData("SLN15",   "235",  "X",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQu4lifier_04", Meta_Descriptions),
				new MetaData("SLN16",   "234",  "X",    "AN",   1,48,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID",                   "ProductServiceID_04",          null),
				new MetaData("SLN17",   "235",  "X",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_05", Meta_Descriptions),
				new MetaData("SLN18",   "234",  "X",    "AN",   1,48,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID",                   "ProductServiceID_05",          null),
				new MetaData("SLN19",   "235",  "X",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_06", Meta_Descriptions),
				new MetaData("SLN20",   "234",  "X",    "AN",   1,48,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID",                   "ProductServiceID_06",          null),
				new MetaData("SLN21",   "235",  "X",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_07", Meta_Descriptions),
				new MetaData("SLN22",   "234",  "X",    "AN",   1,48,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID",                   "ProductServiceID_07",          null),
				new MetaData("SLN23",   "235",  "X",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_08", Meta_Descriptions),
				new MetaData("SLN24",   "234",  "X",    "AN",   1,48,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID",                   "ProductServiceID_08",          null),
				new MetaData("SLN25",   "235",  "X",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_09", Meta_Descriptions),
				new MetaData("SLN26",   "234",  "X",    "AN",   1,48,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID ",                  "ProductServiceID_09",          null),
			};
		}

		public virtual List<MetaCodes> Meta_Relationships { get; internal set; }

		public virtual List<MetaCodes> Meta_Measures { get; internal set; }

		public virtual List<MetaCodes> Meta_UnitOfPrices { get; internal set; }

		public virtual List<MetaCodes> Meta_Descriptions { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Alphanumeric characters assigned for differentiation within a transaction set
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN01	350		M	AN		001	020 Must			Assigned Identification
		/// </summary>
		virtual public object AssignedIdentification { get; set; }

		/// <summary>
		/// Code indicating the relationship between entities
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN03	662		M	ID		001	001	Must			Relationship Code
		///
		///															Code	Name
		///															----	---------------
		///															O		Information Only (Charges which relate to but may not be included in or added to the unit price
		///																	of the SLN (i.e. compute WATS calculation based upon usage amounts)
		/// </summary>
		virtual public object RelationshipCode_01 { get; set; }

		/// <summary>
		/// Numeric value of quantity
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN04	380		X	R		001	015	Used			Quantity
		/// </summary>
		virtual public object Quantity { get; set; }

		/// <summary>
		/// To identify a composite unit of measure(See Figures Appendix for examples of use)
		/// Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN05  C001/355 X	Comp			Used			Composite Unit of Measure
		///
		///															Code	Name
		///															----	---------------
		///															EA		Each
		/// </summary>
		virtual public object CompositeUnitOfMeasure { get; set; }

		/// <summary>
		/// Price per unit of product, service, commodity, etc.
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN06	639		O	ID		002	002	Used			Unit Price
		/// </summary>
		virtual public object UnitPrice { get; set; }

		/// <summary>
		/// Code identifying the type of unit price for an item
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN07	639		O	ID		002	002 Used			Basis of Unit Price Code
		///
		///															Code	Name
		///															----	---------------
		///															CP		Current Price (Subject To Change)
		/// </summary>
		virtual public object BasisOfUnitPriceCode { get; set; }

		/// <summary>
		/// Code indicating the relationship between entities
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN08	662		O	ID		001	001 Used			Relationship Code
		///
		///															Code	Name
		///															----	---------------
		///															O		Information Only
		///																	(Charges which relate to but may not be included in or added to the unit price of the SLN. (i.e., compute WATS calculation based upon usage amounts)
		/// </summary>
		virtual public object RelationshipCode_02 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID(234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN09	235		X	ID		002	002 Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															MG		Manufacturer's Part Number
		/// </summary>
		virtual public object ProductServiceIDQualifier_01 { get; set; }

		/// <summary>
		///  Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN10	234		X	AN		001	048 Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_01 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID(234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN11	235		X	ID		002	002 Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															MN		3 digit manufacturer part code
		/// </summary>
		virtual public object ProductServiceIDQualifier_02 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN12	234		X	AN		001	048 Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_02 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID(234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN13	235		X	ID		002	002 Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															SN		Serial Number
		/// </summary>
		virtual public object ProductServiceIDQualifier_03 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN14	234		X	AN		001	048 Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_03 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID(234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN15	235		X	ID		002	002 Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															BP		Buyer's Part Number
		/// </summary>
		virtual public object ProductServiceIDQualifier_04 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN16	234		X	AN		001	048 Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_04 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID(234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN17	235		X	ID		002	002 Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															TZ		Hardware Product Description
		/// </summary>
		virtual public object ProductServiceIDQualifier_05 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN18	234		X	AN		001	048 Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_05 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID(234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN19	235		X	ID		002	002 Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															C6		Asset Type (Hardware)
		/// </summary>
		virtual public object ProductServiceIDQualifier_06 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN20	234		X	AN		001	048 Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_06 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID(234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN21	235		X	ID		002	002 Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															Z3		Hardware Invoice Date
		/// </summary>
		virtual public object ProductServiceIDQualifier_07 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN22	234		X	AN		001	048 Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_07 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID(234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN23	235		X	ID		002	002 Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															Z4		Hardware Invoice Number
		/// </summary>
		virtual public object ProductServiceIDQualifier_08 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN24	234		X	AN		001	048 Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_08 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID(234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN25	235		X	ID		002	002 Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															JN		Hardware Sales Order Number
		/// </summary>
		virtual public object ProductServiceIDQualifier_09 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SLN26	234		X	AN		001	048 Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_09 { get; set; }
	}

	/*
	SLN01 public object AssignedIdentification
	SLN03 public object RelationshipCode_01
	SLN04 public object Quantity
	SLN05 public object CompositeUnitOfMeasure
	SLN06 public object UnitPrice
	SLN07 public object BasisOfUnitPriceCode
	SLN08 public object RelationshipCode_02
	SLN09 public object ProductServiceIDQualifier_01
	SLN10 public object ProductServiceID_01
	SLN11 public object ProductServiceIDQualifier_02
	SLN12 public object ProductServiceID_02
	SLN13 public object ProductServiceIDQualifier_03
	SLN14 public object ProductServiceID_03
	SLN15 public object ProductServiceIDQualifier_04
	SLN16 public object ProductServiceID_04
	SLN17 public object ProductServiceIDQualifier_05
	SLN18 public object ProductServiceID_05
	SLN19 public object ProductServiceIDQualifier_06
	SLN20 public object ProductServiceID_06
	SLN21 public object ProductServiceIDQualifier_07
	SLN22 public object ProductServiceID_07
	SLN23 public object ProductServiceIDQualifier_08
	SLN24 public object ProductServiceID_08
	SLN25 public object ProductServiceIDQualifier_09
	SLN26 public object ProductServiceID_09
~~~~
SLN01 350 Assigned Identification M AN 1/20 Must use
Description: Alphanumeric characters assigned for differentiation within a transaction set
SLN03 662 Relationship Code M ID 1/1 Must use
Description: Code indicating the relationship between entities
Code Name
O Information Only
Description: Charges which relate to but may not be included in or added to the
unit price of the SLN. (i.e., compute WATS calculation based upon usage amounts)
SLN04 380 Quantity X R 1/15 Used
Description: Numeric value of quantity
SLN05 C001 Composite Unit of Measure X Comp Used
Description: To identify a composite unit of measure(See Figures Appendix for examples
of use)
SLN05-01 355 Unit or Basis for Measurement Code M ID 2/2 Must use
Description: Code specifying the units in which a value is being expressed, or manner in
which a measurement has been taken
Code Name
EA Each
SLN06 212 Unit Price X R 1/17 Used
Description: Price per unit of product, service, commodity, etc.
SLN07 639 Basis of Unit Price Code O ID 2/2 Used
Description: Code identifying the type of unit price for an item
Code Name
CP Current Price (Subject to Change)
SLN08 662 Relationship Code O ID 1/1 Used
Description: Code indicating the relationship between entities
Code Name
O Information Only
Description: Charges which relate to but may not be included in or added to the
unit price of the SLN. (i.e., compute WATS calculation based upon usage amounts)
SLN09 235 Product/Service ID Qualifier X ID 2/2 Used
CDW Purchase Order - 850
Ref Id Element Name Req Type Min/Max Usage
X12V4010 19 CDW_850_O
Description: Code identifying the type/source of the descriptive number used in
Product/Service ID (234)
Code Name
MG Manufacturer's Part Number
SLN10 234 Product/Service ID X AN 1/48 Used
Description: Identifying number for a product or service
SLN11 235 Product/Service ID Qualifier X ID 2/2 Used
Description: Code identifying the type/source of the descriptive number used in
Product/Service ID (234)
Code Name
MN CDW's 3 digit manufacturer part code
SLN12 234 Product/Service ID X AN 1/48 Used
Description: Identifying number for a product or service
SLN13 235 Product/Service ID Qualifier X ID 2/2 Used
Description: Code identifying the type/source of the descriptive number used in
Product/Service ID (234)
Code Name
SN Serial Number
SLN14 234 Product/Service ID X AN 1/48 Used
Description: Identifying number for a product or service
SLN15 235 Product/Service ID Qualifier X ID 2/2 Used
Description: Code identifying the type/source of the descriptive number used in
Product/Service ID (234)
Code Name
BP Buyer's Part Number
SLN16 234 Product/Service ID X AN 1/48 Used
Description: Identifying number for a product or service
SLN17 235 Product/Service ID Qualifier X ID 2/2 Used
Description: Code identifying the type/source of the descriptive number used in
Product/Service ID (234)
Code Name
TZ Hardware Product Description
SLN18 234 Product/Service ID X AN 1/48 Used
Description: Identifying number for a product or service
SLN19 235 Product/Service ID Qualifier X ID 2/2 Used
Description: Code identifying the type/source of the descriptive number used in
Product/Service ID (234)
CDW Purchase Order - 850
Ref Id Element Name Req Type Min/Max Usage
X12V4010 20 CDW_850_O
Code Name
C6 Asset Type (Hardware)
SLN20 234 Product/Service ID X AN 1/48 Used
Description: Identifying number for a product or service
SLN21 235 Product/Service ID Qualifier X ID 2/2 Used
Description: Code identifying the type/source of the descriptive number used in
Product/Service ID (234)
Code Name
Z3 Hardware Invoice Date
SLN22 234 Product/Service ID X AN 1/48 Used
Description: Identifying number for a product or service
SLN23 235 Product/Service ID Qualifier X ID 2/2 Used
Description: Code identifying the type/source of the descriptive number used in
Product/Service ID (234)
Code Name
Z4 Hardware Invoice Number
SLN24 234 Product/Service ID X AN 1/48 Used
Description: Identifying number for a product or service
SLN25 235 Product/Service ID Qualifier X ID 2/2 Used
Description: Code identifying the type/source of the descriptive number used in
Product/Service ID (234)
Code Name
JN Hardware Sales Order Number
SLN26 234 Product/Service ID X AN 1/48 Used
Description: Identifying number for a product or service
	 */
}