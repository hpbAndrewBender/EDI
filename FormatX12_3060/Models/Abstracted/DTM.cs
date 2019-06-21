using DataHPBEDI.Models.MetaData.X12_3060;
using System.Collections.Generic;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class DTM
	{
		public DTM()
		{
			Meta_DateTimeQualifiers=new List<MetaCodes>
			{
				new MetaCodes("011","Date/Time Shipment Leaves the Supplier"),
				new MetaCodes("014","Deferred Payment"),
				new MetaCodes("017","Date/Time Shipment estimated arrival"),
				new MetaCodes("037","Ship Not Before"),
				new MetaCodes("175","Cancel if not shipped by")
			};

			Meta_Data=new List<MetaData>
			{
				new MetaData("DTM01",   "374",  "M",    "ID",   3, 3,   MetaData.UsageName.Required, string.Empty,   "Date/Time Qualifier",                  "DateTimeQualifier",            Meta_DateTimeQualifiers),
				new MetaData("DTM02",   "373",  "C",    "DT",   6, 6,   MetaData.UsageName.Required, string.Empty,   "Date",                                 "Date",                         null),
				new MetaData("DTM05",   "624",  "O",    "N0",   2, 2,   MetaData.UsageName.Required, string.Empty,   "Century",                              "Century",                      null),
			};
		}

		public virtual List<MetaCodes> Meta_DateTimeQualifiers { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code specifying type of date or time, or both date and time
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		DTM01	374		M	ID		003	003	Reqrd			Date/Time Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															014		Deferred Payment
		///															037		Ship Not Before
		///															175		Cancel if not shipped by
		/// </summary>
		virtual public object DateTimeQualifier { get; set; }

		/// <summary>
		/// Date(YYMMDD)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		DTM02	373		C	DT		006	006	Reqrd			Date
		/// </summary>
		virtual public object Date { get; set; }

		/// <summary>
		/// The first two characters in the designation of the year(CCYY)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		DTM03
		virtual public object Reserved_ForFutureUse_01 { get; set; }

		/// <summary>
		/// The first two characters in the designation of the year(CCYY)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		DTM04
		virtual public object Reserved_ForFutureUse_02 { get; set; }

		/// <summary>
		/// The first two characters in the designation of the year(CCYY)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		DTM05	624		O	N0		002	002	Reqrd			Century
		/// </summary>
		virtual public object Century { get; set; }
	}
}