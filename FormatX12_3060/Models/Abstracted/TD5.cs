using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class TD5
	{
		public TD5()
		{
			Meta_RoutingSequences = new List<MetaCodes>
			{
				new MetaCodes("B","Origin/Delivery Carrier (Any Mode)"),
			};
			Meta_IdentificationCodeQualifiers = new List<MetaCodes>
			{
				new MetaCodes("2","Standard Carrier Alpha Code (SCAC)"),
			};
			Meta_ServiceLevels = new List<MetaCodes>
			{
				new MetaCodes("3D","Three Day Service"),
				new MetaCodes("G2","Standard Service"),
				new MetaCodes("ME","Metro Pickup"),
				new MetaCodes("ND","Next Day Air (Delivery during business day hours of next business day)"),
				new MetaCodes("NH","Next Day Hundred Weight"),
				new MetaCodes("ON","Overnight"),
				new MetaCodes("SE","Second Day"),
				new MetaCodes("SG","Standard Ground"),
				new MetaCodes("SH","Second Day Hundred Weight"),
				new MetaCodes("SI","Standard Ground Hundred Weight"),
			};
			Meta_Data = new List<MetaData>
			{
				new MetaData("TD501",   "133",  "O",    "ID",   1, 2,   MetaData.UsageName.Used,        string.Empty,   "Routing Sequence Code",                "RoutingSequenceCode",          Meta_RoutingSequences),
				new MetaData("TD502",   "66",   "C",    "ID",   1, 2,   MetaData.UsageName.Used,        string.Empty,   "Identification Code Qualifier",        "IdentificationCodeQualifier",  Meta_IdentificationCodeQualifiers),
				new MetaData("TD503",   "67",   "C",    "AN",   2,20,   MetaData.UsageName.Used,        string.Empty,   "Identification Code",                  "IdentificationCode",           null),
				new MetaData("TD505",   "387",  "C",    "AN",   1,35,   MetaData.UsageName.Used,        string.Empty,   "Routing",                              "Routing",                      null),
				new MetaData("TD512",   "284",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Service Level Code",                   "ServiceLevelCode",             Meta_ServiceLevels),
			};
		}

		public virtual List<MetaCodes> Meta_RoutingSequences { get; internal set; }

		public virtual List<MetaCodes> Meta_IdentificationCodeQualifiers { get; internal set; }

		public virtual List<MetaCodes> Meta_ServiceLevels { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code describing the relationship of a carrier to a specific shipment movement
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD501	133		O	ID		1	2	Used			Routing Sequence Code
		///		
		///															Code	Name
		///															----	---------------
		///															B		Origin/Delivery Carrier (Any Mode)
		/// </summary>
		virtual public object RoutingSequenceCode { get; set; }

		/// <summary>
		/// Code designating the system/method of code structure used for Identification Code (67)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD502	66		C	ID		1	2	Used			Identification Code Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															2		Standard Carrier Alpha Code (SCAC)
		/// </summary>
		virtual public object IdentificationCodeQualifier { get; set; }

		/// <summary>
		/// Code identifying a party or other code
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD503	67		C	AN		2	20	Used			Identification Code
		/// </summary>
		virtual public object IdentificationCode { get; set; }

		/// <summary>
		/// Purchaser Account number with Carrier if purchaser pays shipping 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD505	387		C	AN		1	35	Used			Routing
		/// </summary>
		virtual public object Routing { get; set; }

		/// <summary>
		/// Code indicating the level of transportation service or the billing service offered by the transportation carrier
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TD512	284		C	ID		2	2	Used			Service Level Code
		///		
		///															Code	Name
		///															----	---------------
		///															3D		Three Day Service
		///															G2		Standard Service
		///															ME		Metro Pickup
		///															ND		Next Day Air (Delivery during business day hours of next business day)
		///															NH		Next Day Hundred Weight
		///															ON		Overnight
		///															SE		Second Day
		///															SG		Standard Ground
		///															SH		Second Day Hundred Weight
		///															SI		Standard Ground Hundred Weight
		/// </summary>
		virtual public object ServiceLevelCode { get; set; }
	}
}