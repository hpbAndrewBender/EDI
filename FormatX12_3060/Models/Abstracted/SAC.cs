using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class SAC
	{
		public SAC()
		{
			Meta_AllowanceOrChangeIndicators = new List<MetaCodes>
			{
				new MetaCodes("A","Allowance"),
				new MetaCodes("C","Charge"),
				new MetaCodes("P","Promotion"),

			};
			Meta_ServicePromotionAllowanceCharges = new List<MetaCodes>
			{
				new MetaCodes("A990","Cataloging Services"),
				new MetaCodes("B210","Co-op Credit"),
				new MetaCodes("D200","Freight Charges to Destination"),
				new MetaCodes("D220","Freight Passthrough"),
				new MetaCodes("E170","Labeling"),
			};
			Meta_Units = new List<MetaCodes>
			{
				new MetaCodes("UN","Units"),
			};
			Meta_Data = new List<MetaData>
			{
				new MetaData("SAC01",   "248",  "M",    "ID",   1, 1,   MetaData.UsageName.Required,    string.Empty,   "Allowance or Charge Indicator",                "	AllowanceOrChargeIndicator",               Meta_AllowanceOrChangeIndicators),
				new MetaData("SAC02",   "1300", "C",    "ID",   4, 4,   MetaData.UsageName.Used,        string.Empty,   "Service, Promotion, Allowance, or Charge Code","	ServicePromotionAllowanceOrChargeCode",    Meta_ServicePromotionAllowanceCharges),
				new MetaData("SAC05",   "610",  "O",    "N2",   1,15,   MetaData.UsageName.Used,        string.Empty,   "Amount",                                       "	Amount",                                    null),
				new MetaData("SAC08",   "118",  "O",    "R",    1, 9,   MetaData.UsageName.Used,        string.Empty,   "Rate",                                         "	Rate",                                      null),
				new MetaData("SAC09",   "355",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Unit or Basis for Measurement Code",           "	UnitOrBasisForMeasurementCode",            Meta_Units),
				new MetaData("SAC10",   "380",  "C",    "R",    1,15,   MetaData.UsageName.Used,        string.Empty,   "Quantity",                                     "	Quantity",                                  null),
			};
		}

		public virtual List<MetaCodes> Meta_AllowanceOrChangeIndicators { get; internal set; }

		public virtual List<MetaCodes> Meta_ServicePromotionAllowanceCharges { get; internal set; }

		public virtual List<MetaCodes> Meta_Units { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code which indicates an allowance or charge for the service specified
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SAC01	248		M	ID		001	001	Requ'd			Allowance or Charge Indicator
		///		
		///															Code	Name
		///															----	---------------
		///															A		Allowance
		///															C		Charge
		///															P		Promotion
		/// </summary>
		virtual public object AllowanceOrChargeIndicator { get; set; }

		/// <summary>
		/// Code identifying the service, promotion, allowance, or charge
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SAC02	1300	C	ID		004	004	Used			Service, Promotion, Allowance, or Charge Code
		///
		///															Code	Name
		///															----	---------------
		///															A990    Cataloging Services
		///															B210	Co-op Credit
		///															D200	Freight Charges to Destination
		///															D220    Freight Passthrough
		///															E170	Labeling
		/// </summary>
		virtual public object ServicePromotionAllowanceOrChargeCode { get; set; }

		/// <summary>
		/// Monetary amount
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SAC05	610		O	N2		001	015	Used			Amount
		/// </summary>
		virtual public object Amount { get; set; }

		/// <summary>
		/// Rate expressed in the standard monetary denomination for the currency specified
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SAC08	118		O	R		001	009	Used			Rate
		/// </summary>
		virtual public object Rate { get; set; }

		/// <summary>
		/// Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SAC09	355		C	ID		020	002	Used			Unit or Basis for Measurement Code
		///		
		///															Code	Name
		///															----	---------------
		///															UN		Unit
		/// </summary>
		virtual public object UnitOrBasisForMeasurementCode { get; set; }

		/// <summary>
		/// Numeric value of quantity
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SAC10	380		C	R		001	015	Used			Quantity
		/// </summary>
		virtual public object Quantity { get; set; }
	}
}