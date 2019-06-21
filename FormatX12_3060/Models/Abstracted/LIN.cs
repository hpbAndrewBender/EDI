using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class LIN
	{
		public LIN()
		{
			Meta_ProductServiceIDQualifiers=new List<MetaCodes>
			{
				new MetaCodes("AI","Alternate ISBN"),
				new MetaCodes("IB","International Standard Book Number (ISBN)"),
				new MetaCodes("EN","(ISBN-13) – Effectively doubles the number of ISBNs available."),
				new MetaCodes("UK","UCC/EAN-14:  Used when a leading digit is added to the ISBN-13 that specifies the packaging  level (such as a carton). When the packaging level is greater than a unit (such as a carton),  a new check digit must be calculated."),
			};
			Meta_Data=new List<MetaData>
			{
				new MetaData("LIN01",   "350",  "O",    "AN",   1,20,   MetaData.UsageName.Used,        string.Empty,   "Assigned Identification",              "AssignedIdentification",       null),
				new MetaData("LIN02",   "235",  "M",    "ID",   2, 2,   MetaData.UsageName.Required,    string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_01", Meta_ProductServiceIDQualifiers),
				new MetaData("LIN03",   "234",  "M",    "AN",   1,40,   MetaData.UsageName.Required,    string.Empty,   "Product/Service ID",                   "ProductServiceID_01",          null),
				new MetaData("LIN04",   "235",  "M",    "ID",   2, 2,   MetaData.UsageName.Required,    string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_02", Meta_ProductServiceIDQualifiers),
				new MetaData("LIN05",   "234",  "M",    "AN",   1,40,   MetaData.UsageName.Required,    string.Empty,   "Product/Service ID",                   "ProductServiceID_02",          null),
				new MetaData("LIN06",   "235",  "M",    "ID",   2, 2,   MetaData.UsageName.Required,    string.Empty,   "Product/Service ID Qualifier",         "ProductServiceIDQualifier_03", Meta_ProductServiceIDQualifiers),
				new MetaData("LIN07",   "234",  "M",    "AN",   1,40,   MetaData.UsageName.Required,    string.Empty,   "Product/Service ID",                   "ProductServiceID_03",          null),
			};
		}

		public virtual List<MetaCodes> Meta_ProductServiceIDQualifiers { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Alphanumeric characters assigned for differentiation within a transaction set 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		LIN01	350		O	AN		001	020	Used			Assigned Identification
		/// </summary>
		virtual public object AssignedIdentification { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID (234) 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		LIN02	235		M	ID		002	002	Requ'd			Product/Service ID Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															AI		Alternate ISBN
		///															IB		International Standard Book Number(ISBN)
		///															EN		(ISBN-13) – Effectively doubles the number of ISBNs available.
		///															UK		UCC/EAN-14:  Used when a leading digit is added to the ISBN-13 that specifies the 
		///																	packaging level(such as a carton). When the packaging level is greater than a unit
		///																	(such as a carton), a new check digit must be calculated.
		/// </summary>
		public object ProductServiceIDQualifier_01 { get; set; }

		/// <summary>
		/// Identifying number for a product or service 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		LIN03	234		M	AN		001	040	Requ'd			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_01 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		LIN04	235		M	ID		002	002	Requ'd			Product/Service ID Qualifier
		///															Code	Name
		///															----	---------------
		///															AI		Alternate ISBN
		///															IB		International Standard Book Number(ISBN)
		///															EN		(ISBN-13) – Effectively doubles the number of ISBNs available.
		///															UK		UCC/EAN-14:  Used when a leading digit is added to the ISBN-13 that specifies the 
		///																	packaging level(such as a carton). When the packaging level is greater than a unit
		///																	(such as a carton), a new check digit must be calculated.
		/// </summary>
		virtual public object ProductServiceIDQualifier_02 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		LIN05	234		M	AN		001	040	Requ'd			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_02 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		LIN06	235		M	ID		002	002	Requ'd			Product/Service ID Qualifier
		///															Code	Name
		///															----	---------------
		///															AI		Alternate ISBN
		///															IB		International Standard Book Number(ISBN)
		///															EN		(ISBN-13) – Effectively doubles the number of ISBNs available.
		///															UK		UCC/EAN-14:  Used when a leading digit is added to the ISBN-13 that specifies the 
		///																	packaging level(such as a carton). When the packaging level is greater than a unit
		///																	(such as a carton), a new check digit must be calculated.
		/// </summary>
		virtual public object ProductServiceIDQualifier_03 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		LIN07	234		M	AN		001	040	Requ'd			Product/Service ID
		/// </summary>
		virtual public object ProductServiceID_03 { get; set; }
	}
}
