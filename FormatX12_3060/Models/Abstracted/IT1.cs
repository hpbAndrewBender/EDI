using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class IT1
	{
		public IT1()
		{
			Meta_ProductServiceIDQualifiers=new List<MetaCodes>
			{
				new MetaCodes("AI","Alternate ISBN"),
				new MetaCodes("IB","International Standard Book Number (ISBN)"),
				new MetaCodes("EN","(ISBN-13) – Effectively doubles the number of ISBNs available."),
				new MetaCodes("UK","UCC/EAN-14:  Used when a leading digit is added to the ISBN-13 that specifies the packaging  level (such as a carton). When the packaging level is greater than a unit (such as a carton),  a new check digit must be calculated."),
			};

			Meta_UnitPrices = new List<MetaCodes>
			{
				new MetaCodes("PE","Price per Each"),
			};

			Meta_Measurements = new List<MetaCodes>
			{
				new MetaCodes("UN","Unit"),
			};

			Meta_Data = new List<MetaData>
			{
				new MetaData("IT101",   "350",  "O",    "AN",   1,20,   MetaData.UsageName.Used,     string.Empty,   "Assigned Identification",              "AssignedIdentification",       null),
				new MetaData("IT102",   "358",  "C",    "R",    1,10,   MetaData.UsageName.Used,     string.Empty,   "Quantity Invoiced",                    "QuantityInvoiced",             null),
				new MetaData("IT103",   "355",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,     string.Empty,   "Unit or Basis for Measurement Code",   "UnitOrBasisForMeasurementCode",Meta_Measurements),
				new MetaData("IT104",   "212",  "C",    "R",    1,17,   MetaData.UsageName.Used,     string.Empty,   "Unit Price",                           "UnitPrice",                    null),
				new MetaData("IT105",   "639",  "O",    "ID",   2, 2,   MetaData.UsageName.Used,     string.Empty,   "Basis of Unit Price Code",             "BasisOfUnitPriceCode",         Meta_UnitPrices),
				new MetaData("IT106",   "235",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,     string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_01", Meta_ProductServiceIDQualifiers),
				new MetaData("IT107",   "234",  "C",    "AN",   1,40,   MetaData.UsageName.Used,     string.Empty,   "Product/Service ID",                   "ProductServiceID_01",          null),
				new MetaData("IT108",   "235",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,     string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_02", Meta_ProductServiceIDQualifiers),
				new MetaData("IT109",   "234",  "C",    "AN",   1,40,   MetaData.UsageName.Used,     string.Empty,   "Product/Service ID",                   "ProductServiceID_02",          null),
				new MetaData("IT110",   "235",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,     string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_03", Meta_ProductServiceIDQualifiers),
				new MetaData("IT111",   "234",  "C",    "AN",   1,40,   MetaData.UsageName.Used,     string.Empty,   "Product/Service ID",                   "ProductServiceID_03",          null),
			};
		}

		public virtual List<MetaCodes> Meta_ProductServiceIDQualifiers { get; internal set; }
		
		public virtual List<MetaCodes> Meta_UnitPrices { get; internal set; }

		public virtual List<MetaCodes> Meta_Measurements { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Alphanumeric characters assigned for differentiation within a transaction set
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT101	350		O	AN		001	020	Used			Assigned Identification 
		/// </summary>
		virtual public object AssignedIdentification { get; set; }

		/// <summary>
		/// Number of units invoiced (supplier units)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT102	358		C	R		001	010	Used			Quantity Invoiced
		/// </summary>
		virtual public object QuantityInvoiced { get; set; }

		/// <summary>
		/// Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT103	355		C	ID		002	002	Used			Unit or Basis for Measurement Code
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
		///		IT104	212		C	R		001	017	Used			Unit Price
		/// </summary>
		virtual public object UnitPrice { get; set; }

		/// <summary>
		/// Code identifying the type of unit price for an item (Standard Book Industry definitions should be applied to this element.)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT105	639		O	ID		002	002	Used			Basis of Unit Price Code 
		///		
		///															Code	Name
		///															----	---------------
		///															PE		Price per Each
		/// </summary>
		virtual public object BasisOfUnitPriceCode { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID (234) (When using both an RP and IB code value, the RP code value must be used first.)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT106	235	C	ID	2/2	Used	Product/Service ID Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															AI		Alternate ISBN
		///															IB		International Standard Book Number (ISBN)
		///															EN      (ISBN-13) – Effectively doubles the number of ISBNs available.
		///															UK		UCC/EAN-14:  Used when a leading digit is added to the ISBN-13 that specifies the packaging 
		///																	level (such as a carton). When the packaging level is greater than a unit (such as a carton), 
		///																	a new check digit must be calculated.
		/// </summary>
		virtual public object ProductServiceIDQualifier_01 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT107	234		C	AN		001	040	Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_01 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID (234) (When using both an RP and IB code value, the RP code value must be used first.)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT108	235		C	ID		002	002	Used			Product/Service ID Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															AI		Alternate ISBN
		///															IB		International Standard Book Number (ISBN)
		///															EN      (ISBN-13) – Effectively doubles the number of ISBNs available.
		///															UK		UCC/EAN-14:  Used when a leading digit is added to the ISBN-13 that specifies the packaging 
		///																	level (such as a carton). When the packaging level is greater than a unit (such as a carton), 
		///																	a new check digit must be calculated.
		/// </summary>
		virtual public object ProductServiceIDQualifier_02 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT109	234		C	AN		010	040	Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_02 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID (234) 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT110	235		C	ID		002	002	Used			Product/Service ID Qualifier
		/// 
		///															Code	Name
		///															----	---------------
		///															AI		Alternate ISBN
		///															IB		International Standard Book Number (ISBN)
		///															EN      (ISBN-13) – Effectively doubles the number of ISBNs available.
		///															UK		UCC/EAN-14:  Used when a leading digit is added to the ISBN-13 that specifies the packaging 
		///																	level (such as a carton). When the packaging level is greater than a unit (such as a carton), 
		///																	a new check digit must be calculated.
		/// </summary>
		virtual public object ProductServiceIDQualifier_03 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT111	234		C	AN		001	040	Used			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_03 { get; set; }
	}
}