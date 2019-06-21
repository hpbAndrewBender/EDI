using DataHPBEDI.Models.MetaData.X12_3060;
using System.Collections.Generic;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class PID
	{
		public PID()
		{
			Meta_ItemDescriptionTypes=new List<MetaCodes>
			{
				new MetaCodes("F","Free-form"),
				new MetaCodes("S","Structured(From Industry Code List)"),
			};
			Meta_ProductProcessCharacteristics=new List<MetaCodes>
			{
				new MetaCodes("08","Product"),
			};
			Meta_AgencyQualifiers=new List<MetaCodes>
			{
				new MetaCodes("BI","Book Industry Systems Advisory Committee"),
			};
			Meta_ProductDescriptions=new List<MetaCodes>
			{
				new MetaCodes("A1","Author(1st 80 characters)"),
				new MetaCodes("A2","Author(81-160 characters)"),
				new MetaCodes("B1","Volume Set"),
				new MetaCodes("B3","Edition Set"),
				new MetaCodes("B4","Binding code(physical features)"),
				new MetaCodes("B5","Title code"),
				new MetaCodes("B6","Author code"),
				new MetaCodes("B7","Publisher code"),
				new MetaCodes("P1","Publisher(1st 80 characters)"),
				new MetaCodes("P2","Publisher(81-160 characters)"),
				new MetaCodes("T1","Title(1st 80 characters)"),
				new MetaCodes("T2","Title(81-160 characters)"),
				new MetaCodes("T3","Title(161-240 characters)"),
			};
			Meta_Data=new List<MetaData>
			{
				new MetaData("PID01",   "349",  "M",    "ID",   1, 1,   MetaData.UsageName.Required,    string.Empty,   "Item Description Type",                "ItemDescriptionType",              Meta_ItemDescriptionTypes),
				new MetaData("PID02",   "750",  "O",    "ID",   2, 3,   MetaData.UsageName.Used,        string.Empty,   "Product/Process Characteristic Code",  "ProductProcessCharacteristicCode", Meta_ProductProcessCharacteristics),
				new MetaData("PID03",   "559",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Agency Qualifier Code",                "AgencyQualifierCode",              Meta_AgencyQualifiers),
				new MetaData("PID04",   "751",  "C",    "AN",   1,12,   MetaData.UsageName.Used,        string.Empty,   "Product Description Code",             "ProductDescriptionCode",           Meta_ProductDescriptions),
				new MetaData("PID05",   "352",  "C",    "AN",   1,80,   MetaData.UsageName.Used,        string.Empty,   "Description",                          "Description",                      null),
			};
		}

		public virtual List<MetaCodes> Meta_ItemDescriptionTypes { get; internal set; }

		public virtual List<MetaCodes> Meta_ProductProcessCharacteristics { get; internal set; }

		public virtual List<MetaCodes> Meta_AgencyQualifiers { get; internal set; }

		public virtual List<MetaCodes> Meta_ProductDescriptions { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code indicating the format of a description
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PID01	349	M	ID	001	001	Required		Item Description Type
		///
		///															Code	Name
		///															----	---------------
		///															F		Free-form
		///															S		Structured (From Industry Code List)
		/// </summary>
		virtual public object ItemDescriptionType { get; set; }

		/// <summary>
		/// Code identifying the general class of a product or process characteristic
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PID02	750		O	ID		002	003	Used		Product/Process Characteristic Code
		///
		///															Code	Name
		///															----	---------------
		///															08		Product
		/// </summary>
		virtual public object ProductProcessCharacteristicCode { get; set; }

		/// <summary>
		/// Code identifying the agency assigning the code values
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PID03	559		C	ID		002 002	Used			Agency Qualifier Code
		///
		///															Code	Name
		///															----	---------------
		///															BI		Book Industry Systems Advisory Committee
		/// </summary>
		virtual public object AgencyQualifierCode { get; set; }

		/// <summary>
		/// A code from an industry code list which provides specific data about a product characteristic (PROD - BISAC Publisher/Manufacturer Group product and services code list.)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PID04	751		C	AN		001	012	Used			Product Description Code
		///
		///															Code	Name  (In the library community the following code values values are used)
		///															----	---------------
		///															A1		Author (1st 80 characters)
		///															A2		Author (81-160 characters)
		///															B1		Volume Set
		///															B3		Edition Set
		///															B4		Binding code (physical features)
		///															B5		Title code
		///															B6		Author code
		///															B7		Publisher code
		///															P1		Publisher (1st 80 characters)
		///															P2		Publisher (81-160 characters)
		///															T1		Title (1st 80 characters)
		///															T2		Title (81-160 characters)
		///															T3		Title (161-240 characters)
		/// </summary>
		virtual public object ProductDescriptionCode { get; set; }

		/// <summary>
		/// A free-form description to clarify the related data elements and their content (Code and/or description as agreed upon by the Publisher/Manufacturer Group.)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PID05	352		C	AN		001	080	Used			Description
		/// </summary>
		virtual public object Description { get; set; }
	}
}