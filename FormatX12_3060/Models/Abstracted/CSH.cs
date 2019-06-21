using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class CSH
	{
		public CSH()
		{
			Meta_SalesRequirements = new List<MetaCodes>
			{
				new MetaCodes("B","Back Order Only If New Item"),
				new MetaCodes("N","No Back Order"),
				new MetaCodes("O","Back Order if Items are out of stock or net yet published"),
				new MetaCodes("Y","Back ORder if out of stock")
			};

			Meta_AgencyQualifiers = new List<MetaCodes>
			{
				new MetaCodes("BI","Book Industry Systems Advisory Committee")
			};

			Meta_SpecialServices = new List<MetaCodes>
			{
				new MetaCodes("CA","Cataloging Services"),
				new MetaCodes("HC","Handling Service"),
				new MetaCodes("LA","Labeling")
			};

			Meta_Data = new List<MetaData>
			{
				new MetaData("CSH01",   "563",  "O",    "ID",   1, 2,   MetaData.UsageName.Used,     string.Empty,   "Sales Requirement Code",               "SalesRequirementCode",         Meta_SalesRequirements),
				new MetaData("CSH06",   "559",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,     string.Empty,   "Agency Qualifier Code",                "AgencyQualifierCode",          Meta_AgencyQualifiers),
				new MetaData("CSH07",   "560",  "C",    "ID",   2,10,   MetaData.UsageName.Used,     string.Empty,   "Special Services Code",                "SpecialServicesCode",          Meta_SpecialServices),
			};
		}

		public virtual List<MetaCodes> Meta_SalesRequirements { get; internal set; }

		public virtual List<MetaCodes> Meta_AgencyQualifiers { get; internal set; }

		public virtual List<MetaCodes> Meta_SpecialServices { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code to identify a specific requirement or agreement of sale
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CSH01	563		O	ID		001	002	Used			Sales Requirement Code
		///		
		///															Code	Name
		///															----	---------------
		///															B		Back Order Only If New Item
		///															N		No Back Order
		///															O		Back Order If Items Are Out of Stock or Not Yet Published
		///															Y		Back Order if Out of Stock
		/// </summary>
		virtual public object SalesRequirementCode { get; set; }

		/// <summary>
		/// Code identifying the agency assigning the code values
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CSH06	559		C	ID		002	002	Used			Agency Qualifier Code
		///		
		///															Code	Name
		///															----	---------------
		///															BI		Book Industry Systems Advisory Committee
		/// </summary>
		virtual public object AgencyQualifierCode { get; set; }

		/// <summary>
		/// Code identifying the special service
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CSH07	560		C	ID		002	010	Used			Special Services Code
		///		
		///															Code	Name
		///															----	---------------
		///															CA		Cataloging Services
		///															HC		Handling Service
		///															LA		Labeling
		/// </summary>
		virtual public object SpecialServicesCode { get; set; }
	}
}