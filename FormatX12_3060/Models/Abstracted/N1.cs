using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class N1
	{

		public static readonly List<MetaCodes> Meta_EntityIdentifiers = new List<MetaCodes>
		{
			new MetaCodes("BT","Bill to Party"),
			new MetaCodes("ST","Ship To"),
		};

		public static readonly List<MetaCodes> Meta_Identifications = new List<MetaCodes>
		{
			new MetaCodes("15","Standard Address Number, SAN, recommended by the book industry"),
		};

		public static readonly List<MetaData> Meta_Data = new List<MetaData>
		{
			new MetaData("N101",	"98",	"M",	"ID",	2, 2,	MetaData.UsageName.Required,	string.Empty,	"Entity Identifier Code",				"EntityIdentifierCode",			Meta_EntityIdentifiers),
			new MetaData("N102",	"93",	"C",	"AN",	1,35,	MetaData.UsageName.NotRequired,	string.Empty,	"Name",									"Name",							null),
			new MetaData("N103",	"66",	"C",	"ID",	1, 2,	MetaData.UsageName.Required,	string.Empty,	"Identification Code Qualifier",		"IdentificationCodeQualifier",	Meta_Identifications),
			new MetaData("N104",	"67",	"C",	"AN",	2,20,	MetaData.UsageName.Required,	string.Empty,	"Identification Code",					"IdentificationCode",			null),
		};

		/// <summary>
		/// Code identifying an organizational entity, a physical location, or an individual
		/// 		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N101	98		M	ID		002	002	Req'rd			Entity Identifier Code
		///		
		///															Code	Name
		///															----	---------------
		///															BT		Bill to Party
		///															ST		Ship To
		/// </summary>
		virtual public object EntityIdentifierCode { get; set; }

		/// <summary>
		///	Free-form name
		///	
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N102	93		C	AN		001	035	NotRecd			Name									
		/// </summary>
		virtual public object Name { get; set; }

		/// <summary>
		///	Code designating the system/method of code structure used for Identification Code (67)
		///	
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N103	66		C	ID		001	002	Rec'd			Identification Code Qualifier								
		///		
		///															Code	Name
		///															----	---------------
		///															15		Standard Address Number, SAN, recommended by the book industry
		/// </summary>
		virtual public object IdentificationCodeQualifier { get; set; }

		/// <summary>
		///	Code identifying a part or other code
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N104	67		C	AN		002	020	Rec'd			Identification Code						
		/// </summary>
		virtual public object IdentificationCode { get; set; }
	}
}