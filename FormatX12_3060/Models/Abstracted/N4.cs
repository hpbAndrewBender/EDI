using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class N4
	{
		public N4()
		{
			Meta_Data = new List<MetaData>
			{
				new MetaData("N401",    "19",   "O",    "AN",   2,30,   MetaData.UsageName.Used,        string.Empty,   "City Name",                            "CityName",                     null),
				new MetaData("N402",    "156",  "O",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "State or Province Code",               "StateOrProvinceCode",          null),
				new MetaData("N403",    "116",  "O",    "ID",   3,15,   MetaData.UsageName.Used,        string.Empty,   "Postal Code",                          "PostalCode",                   null),
				new MetaData("N404",    "26",   "O",    "ID",   2, 3,   MetaData.UsageName.Used,        string.Empty,   "Country Code",                         "CountryCode",                  null),
			};
		}

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Free-form text for city name
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N401	19		O	AN		002	030	Used			City Name 
		/// </summary>
		virtual public object CityName { get; set; }

		/// <summary>
		/// Code(Standard State/Province) as defined by appropriate government agency
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N402    156		O   ID		002	002	Used			State or Province Code
		/// </summary>
		virtual public object StateOrProvinceCode { get; set; }

		/// <summary>
		/// Code defining international postal zone code excluding punctuation and blanks(zip code for United States)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N403    116		O	ID		003	015	Used			Postal Code
		/// </summary>
		virtual public object PostalCode { get; set; }

		/// <summary>
		/// Code identifying the country
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N404    26		O	ID		002	003	Used			Country Code
		/// </summary>
		virtual public object CountryCode { get; set; }
	}
}