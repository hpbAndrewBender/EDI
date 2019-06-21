using DataHPBEDI.Models.MetaData.X12_3060;
using System.Collections.Generic;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class PO1
	{
		public PO1()
		{
			Meta_ProductServiceIDQualifiers=new List<MetaCodes>
			{
				new MetaCodes("AI","Alternate ISBN"),
				new MetaCodes("IB","International Standard Book Number (ISBN)"),
				new MetaCodes("EN","(ISBN-13) – Effectively doubles the number of ISBNs available."),
				new MetaCodes("UK","UCC/EAN-14:  Used when a leading digit is added to the ISBN-13 that specifies the packaging  level (such as a carton). When the packaging level is greater than a unit (such as a carton),  a new check digit must be calculated."),
			};
			Meta_Units=new List<MetaCodes>
			{
				new MetaCodes("UN","Unit"),
			};
			Meta_UnitPrices=new List<MetaCodes>
			{
				new MetaCodes("NT","Net(Net Unit Price)"),
				new MetaCodes("SR","Retail/List/Suggested Selling Price"),
			};
			Meta_Data=new List<MetaData>
			{
				new MetaData("PO101",   "350",  "O",    "AN",   1,20,   MetaData.UsageName.Received,    string.Empty,   "Assigned Identification",              "AssignedIdentification",       null),
				new MetaData("PO102",   "330",  "C",    "R",    1, 9,   MetaData.UsageName.Required,    string.Empty,   "Quantity Ordered",                     "QuantityOrdered",              null),
				new MetaData("PO103",   "355",  "O",    "ID",   2, 2,   MetaData.UsageName.Required,    string.Empty,   "Unit or Basis for Measurement Code",   "UnitOrBasisForMeasurementCode",Meta_Units),
				new MetaData("PO104",   "212",  "C",    "R",    1,17,   MetaData.UsageName.Used,        string.Empty,   "Unit Price",                           "UnitPrice",                    null),
				new MetaData("PO105",   "639",  "O",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Basis of Unit Price Code",             "BasisOfUnitPriceCode",         Meta_UnitPrices),
				new MetaData("PO106",   "235",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_01", Meta_ProductServiceIDQualifiers),
				new MetaData("PO107",   "234",  "C",    "AN",   1,40,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID",                   "ProductServiceID_01",          null),
				new MetaData("PO108",   "235",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_02", Meta_ProductServiceIDQualifiers),
				new MetaData("PO109",   "234",  "C",    "AN",   1,40,   MetaData.UsageName.Unknown, string.Empty,   "Product/Service ID",                   "ProductServiceID_02",          null),
				new MetaData("PO110",   "235",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_03", Meta_ProductServiceIDQualifiers),
				new MetaData("P0111",   "234",  "C",    "AN",   1,40,   MetaData.UsageName.Used,        string.Empty,   "Product/Service ID",                   "ProductServiceID_03",          null),
			};
		}

		public virtual List<MetaCodes> Meta_ProductServiceIDQualifiers { get; internal set; }

		public virtual List<MetaCodes> Meta_Units { get; internal set; }

		public virtual List<MetaCodes> Meta_UnitPrices { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Alphanumeric characters assigned for differentiation within a transaction set
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PO101	350		O	AN		001	020	Rec'd			Assigned Identification
		/// </summary>
		virtual public object AssignedIdentification { get; set; }

		/// <summary>
		/// Quantity ordered
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PO102	330		C	R		001	009	Reqr'd			Quantity Ordered
		/// </summary>
		virtual public object QuantityOrdered { get; set; }

		/// <summary>
		/// Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PO103	355		O	ID		002	002	Reqr'd			Unit or Basis for Measurement Code
		///
		///															Code	Name
		///															----	---------------
		///															UN		Unit
		/// </summary>
		virtual public object UnitOrBasisForMeasurementCode { get; set; }

		/// <summary>
		/// Price per unit of product, service, commodity, etc.
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PO104	212		C	R		001	017	Used			Unit Price
		/// </summary>
		virtual public object UnitPrice { get; set; }

		/// <summary>
		/// Code identifying the type of unit price for an item
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PO105	639		O	ID		002	002	Used			Basis of Unit Price Code
		///
		///															Code	Name
		///															----	---------------
		///															NT		Net (Net Unit Price)
		///															SR		Retail/List/Suggested Selling Price
		/// </summary>
		virtual public object BasisOfUnitPriceCode { get; set; }

		/// <summary>
		///	Code identifying the type/source of the descriptive number used in Product/Service ID (234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PO106	235		C	ID		002	002	Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															IB		ISBN: International Standard Book Number
		///															EN		ISBN-13: Effectively doubles the number of ISBNs available
		///															UK		UCC/EAN-14: Used when a leading digit is added to ISBN-13 that
		///																	specifies the packaging level (such as a carton).
		///																	When the packaging level is greater than a unit
		///																	(such as a carton), a new check digit must be calculated.
		/// </summary>
		virtual public object ProductServiceIDQualifier_01 { get; set; }

		/// <summary>
		///	Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PO107	234		C	AN		001	040	Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_01 { get; set; }

		/// <summary>
		///	Code identifying the type/source of the descriptive number used in Product/Service ID (234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PO108	235		C	ID		002	002	Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															IB		ISBN: International Standard Book Number
		///															EN		ISBN-13: Effectively doubles the number of ISBNs available
		///															UK		UCC/EAN-14: Used when a leading digit is added to ISBN-13 that
		///																	specifies the packaging level (such as a carton).
		///																	When the packaging level is greater than a unit
		///																	(such as a carton), a new check digit must be calculated.
		/// </summary>
		virtual public object ProductServiceIDQualifier_02 { get; set; }

		/// <summary>
		///	Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PO109	234		C	AN		001	040					Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_02 { get; set; }

		/// <summary>
		///	Code identifying the type/source of the descriptive number used in Product/Service ID (234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PO110	235		C	ID		002	002	Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															IB		ISBN: International Standard Book Number
		///															EN		ISBN-13: Effectively doubles the number of ISBNs available
		///															UK		UCC/EAN-14: Used when a leading digit is added to ISBN-13 that
		///																	specifies the packaging level (such as a carton).
		///																	When the packaging level is greater than a unit
		///																	(such as a carton), a new check digit must be calculated.
		/// </summary>
		virtual public object ProductServiceIDQualifier_03 { get; set; }

		/// <summary>
		///	Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		P0111	234		C	AN		001	040	Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_03 { get; set; }

		/// <summary>
		///	Code identifying the type/source of the descriptive number used in Product/Service ID (234)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PO112	235		C	ID		002	002	Used			Product/Service ID Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															IB		ISBN: International Standard Book Number
		///															EN		ISBN-13: Effectively doubles the number of ISBNs available
		///															UK		UCC/EAN-14: Used when a leading digit is added to ISBN-13 that
		///																	specifies the packaging level (such as a carton).
		///																	When the packaging level is greater than a unit
		///																	(such as a carton), a new check digit must be calculated.
		/// </summary>

		virtual public object ProductServiceIDQualifier_04 { get; set; }

		/// <summary>
		///	Identifying number for a product or service
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		P0113	234		C	AN		001	040	Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_04 { get; set; }
	}
}