using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class ACK
	{
		public ACK()
		{
			Meta_TransactionSetPurposes=new List<MetaCodes>
			{
				new MetaCodes("IA", "Item Accepted"),
				new MetaCodes("IB", "Item Back-ordered"),
				new MetaCodes("IC", "Item Accepted- Changes Made"),
				new MetaCodes("ID", "Item Deleted"),
				new MetaCodes("IQ", "Item Accepted - Quantity Changed"),
				new MetaCodes("IR", "Item Rejected"),
			};
			Meta_ProductServiceIDQualifiers=new List<MetaCodes>
			{
				new MetaCodes("AI","Alternative ISBN"),
				new MetaCodes("EN","ISBN-13 - Effectively doubles the number of ISBNs available"),
				new MetaCodes("IB","ISBN - International Standard Book Number"),
				new MetaCodes("UK","UCC/EAN-14 - Used when a leading digit is added to the ISBN-13 code that specifies the packaging level, such as a cartain.  When the packaging level is greater than a unit, such as a cartion, a new check digit must be calculated")
			};
			Meta_IndustryCodes=new List<MetaCodes>
			{
				new MetaCodes("AC","Item accepted and shipped (Shipping)"),
				new MetaCodes("AN","Available:Shipping - new edition/ISBN(Shipping)"),
				new MetaCodes("AO","Available: Shipping From Other Location"),
				new MetaCodes("AR","Item Accepted: Released for shipment(Shipping)"),
				new MetaCodes("AS","Available: Shipping - same ISBN(Shipping)"),
				new MetaCodes("AV","Inventory available for order(Available)"),
				new MetaCodes("AX","Available : Shipping - free book(Shipping)"),
				new MetaCodes("BA","BackOrdered: Not yet available(Not Shipped)"),
				new MetaCodes("BB","BackOrdered: Reprint under consideration(Not Shipped)"),
				new MetaCodes("BC","BackOrdered: Current edition not available - to be replaced with...(Not Shipped)"),
				new MetaCodes("BD","BackOrdered: Delay in publication(Not Shipped)"),
				new MetaCodes("BH","BackOrdered: On hold(Not Shipped)"),
				new MetaCodes("BI","BackOrdered: To be reissued(Not Shipped)"),
				new MetaCodes("BK","BackOrdered: from previous order(Not Shipped)"),
				new MetaCodes("BN","BackOrdered: Inventory in progress; closed for stocktaking(Not Shipped)"),
				new MetaCodes("BO","BackOrdered: At customer's request (Not Shipped)"),
				new MetaCodes("BP","Item Accepted: partial shipment; balance back-ordered(Shipping)"),
				new MetaCodes("BR","BackOrdered: To be reprinted(Not Shipped)"),
				new MetaCodes("BW","BackOrdered: Waiting for catalog/processing(Not Shipped)"),
				new MetaCodes("BX","BackOrdered: Not yet published(Not Shipped)"),
				new MetaCodes("CA","Canceled: Not yet available(Not Shipped)"),
				new MetaCodes("CB","Canceled:  Not our publication(Not Shipped)"),
				new MetaCodes("CD","Canceled: Delay in publication(Not Shipped)"),
				new MetaCodes("CE","Canceled: Order partially filled and shipped; remainder of order canceled(Shipping)"),
				new MetaCodes("CF","Canceled: Current edition not available(Not Shipped)"),
				new MetaCodes("CG","Canceled: No geographic rights, e.g.Canadian(Not Shipped)"),
				new MetaCodes("CH","Canceled: Rights no longer ours(Not Shipped)"),
				new MetaCodes("CI","Canceled: To be reissued(Not Shipped)"),
				new MetaCodes("CJ","Canceled: Out of print in cloth; available in paper - reorder(Not Shipped)"),
				new MetaCodes("CL","Canceled: Out of print in paper; available in cloth - reorder(Not Shipped)"),
				new MetaCodes("CN","Canceled: Inventory in progress; closed for stocktaking(Not Shipped)"),
				new MetaCodes("CO","Canceled: Out of stock(Not Shipped)"),
				new MetaCodes("CQ","Canceled: Did not meet minimum order requirements; e.g., quantity or dollar value(Not Shipped)"),
				new MetaCodes("CR","Canceled: To be reprinted(Not Shipped)"),
				new MetaCodes("CT","Canceled: Publisher did not respond by your cancellation date(Not Shipped)"),
				new MetaCodes("CU","Canceled: Kits not available(Not Shipped)"),
				new MetaCodes("CV","Canceled: Complete set volume must be purchased(Not Shipped)"),
				new MetaCodes("CW","Canceled: Apply direct; not available through wholesale channels(Not Shipped)"),
				new MetaCodes("CX","Canceled: Never published(Not Shipped)"),
				new MetaCodes("CY","Canceled: Not available as a processed book(Not Shipped)"),
				new MetaCodes("DR","Item accepted: Date rescheduled(Shipping)"),
				new MetaCodes("DS","Out of Stock"),
				new MetaCodes("IA","Item Accepted(Shipping)"),
				new MetaCodes("IB","Item Back-ordered(Not Shipped"),
				new MetaCodes("ID","Item Deleted(Not Shipped)"),
				new MetaCodes("IE","Item accepted: Price pending(Shipping)"),
				new MetaCodes("IF","Item on hold: Incomplete description(Not Shipped)"),
				new MetaCodes("IG","Item Forwarded to Proper Source/Published"),
				new MetaCodes("IH","Item on hold(Not Shipped)"),
				new MetaCodes("IN","Item accepted: Forwarded to new supplier(Not Shipped)"),
				new MetaCodes("IP","Item accepted: Price changed(Shipping)"),
				new MetaCodes("IQ","Item accepted: Quantity changed(Shipping)"),
				new MetaCodes("IR","Item rejected(Not Shipped)"),
				new MetaCodes("IS","Item accepted: Substitution made(Shipping)"),
				new MetaCodes("IW","Item on hold: Waiver required(Not Shipped)"),
				new MetaCodes("KC","Canceled: REprint under consideration(Not Shipped)"),
				new MetaCodes("KK","Canceled: ISBN incorrect/unknown(Not Shipped)"),
				new MetaCodes("KM","Canceled: Market for this title is restricted(Not Shipped)"),
				new MetaCodes("KP","Canceled: Out of print(Not Shipped)"),
				new MetaCodes("KR","Canceled: Title Remaindered(Not Shipped)"),
				new MetaCodes("KS","Canceled: book sold by subscription only(Not Shipped)"),
				new MetaCodes("NF","Not yet published(Not Shipped)"),
				new MetaCodes("OP","Out of print(Not Shipped)"),
				new MetaCodes("OR","Temporarily out of stock(Not Shipped)"),
				new MetaCodes("PA","Partial shipment(Shipping)"),
				new MetaCodes("SC","Shipment complete(Shipping)"),
				new MetaCodes("SP","Item accepted: Schedule date pending(Shipping)"),
				new MetaCodes("SS","Split Shipment(Shipping)"),
			};
			Meta_Units=new List<MetaCodes>
			{
				new MetaCodes("UN","Unit")
			};
			Meta_DateTimeQualifiers=new List<MetaCodes>
			{
				new MetaCodes("080","Scheduled for Shipment (After and including)"),
				new MetaCodes("100","No Shipping Schedule Established as of (This is the default if no scheduled shipment information is known at the time of the ack)")
			};
			Meta_Data=new List<MetaData>
			{
				new MetaData("ACK01",   "688",  "M",    "ID",   2, 2,   MetaData.UsageName.Required, string.Empty,   "Transaction Set Purpose Code",         "LineItemStatusCode",           Meta_TransactionSetPurposes),
				new MetaData("ACK02",   "2380", "C",    "R",    1,15,   MetaData.UsageName.Used,     string.Empty,   "Quantity",                             "Quantity",                     null),
				new MetaData("ACK03",   "355",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,     "UN",           "Unit or Basis for Measurement Code",   "UnitOrBasisForMeasurementCode",Meta_Units),
				new MetaData("ACK04",   "374",  "O",    "ID",   3, 3,   MetaData.UsageName.Used,     "100",          "Date/Time Qualifier",                  "DateTimeQualifier",            Meta_DateTimeQualifiers),
				new MetaData("ACK05",   "374",  "O",    "ID",   6, 6,   MetaData.UsageName.Used,     "Blank",        "Date",                                 "Date",                         null),
				new MetaData("ACK07",   "235",  "C",    "R",    2, 2,   MetaData.UsageName.Used,     "Blank",        "Product/Service ID Qualifier",         "ProductServiceIDQualifier_01", Meta_ProductServiceIDQualifiers),
				new MetaData("ACK08",   "234",  "C",    "AN",   1,40,   MetaData.UsageName.Used,     string.Empty,   "Product/Service ID",                   "ProductServiceID_01",          null),
				new MetaData("ACK09",   "235",  "C",    "R",    2, 2,   MetaData.UsageName.Used,     "Blank",        "Product/Service ID Qualifier",         "ProductServiceIDQualifier_02", Meta_ProductServiceIDQualifiers),
				new MetaData("ACK10",   "234",  "C",    "AN",   1,40,   MetaData.UsageName.Used,     string.Empty,   "Product/Service ID",                   "ProductServiceID_02",          null),
				new MetaData("ACK11",   "235",  "C",    "R",    2, 2,   MetaData.UsageName.Used,     "Blank",        "Product/Service ID Qualifier",         "ProductServiceIDQualifier_03", Meta_ProductServiceIDQualifiers),
				new MetaData("ACK12",   "234",  "C",    "AN",   1,40,   MetaData.UsageName.Used,     string.Empty,   "Product/Service ID",                   "ProductServiceID_03",          null),
				new MetaData("ACK29",   "1271", "C",    "AN",   1,30,   MetaData.UsageName.Used,     string.Empty,   "IndustryCodes",                        "IndustryCodes",                Meta_IndustryCodes),
			};
		}

		virtual public List<MetaCodes> Meta_TransactionSetPurposes { get; internal set; }

		virtual public List<MetaCodes> Meta_ProductServiceIDQualifiers { get; internal set; }

		virtual public List<MetaCodes> Meta_IndustryCodes  { get; internal set;}

		virtual public List<MetaCodes> Meta_Units { get; internal set; }

		virtual public List<MetaCodes> Meta_DateTimeQualifiers { get; internal set; }

		virtual public List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code specifying the action taken by the seller on a line item requested by the buyer
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK01	668		M  	ID		002	002	Req'rd			Line Item Status Code 
		///		
		///															Code	Name
		///															----	---------------
		///															IA 		Item Accepted
		///															IQ 		Item Accepted - Quantity Changed
		///															IR		Item Rejected
		/// </summary>
		virtual public string LineItemStatusCode { get; set; }

		/// <summary>
		/// Numeric value of quantity
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK02	2380	C	R 		001	015	Used			Quantity
		/// </summary>
		virtual public decimal Quantity { get; set; }

		/// <summary>
		/// Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK03	355		c	ID		002	002	Used	UN		Unit or Basis for Measurement Code
		///		
		///															Code	Name
		///															----	---------------
		///															UN		Unit
		/// </summary>
		virtual public string UnitOrBasisForMeasurementCode { get; set; }


		/// <summary>
		/// Code specifying type of date or time, or both date and time
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK04	374		O	ID 		003	003	Used	100		Date/Time Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															080		Scheduled for Shipment (After and including)
		///															100		No Shipping Schedule Established as of 
		///																	(This is the default if no scheduled shipment information is known at the time of the ack)
		/// </summary>
		virtual public string DateTimeQualifier { get; set; }

		/// <summary>
		/// Date (YYMMDD)
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK05	374		O	ID		006	006	Used	Blank	Date
		/// </summary>
		virtual public string Date { get; set; }


		/// <summary>
		/// Description: 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK06								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_01 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID (234)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK07	235		C	R		002	002	Used	Blank	Product/Service ID Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															AI		Alternative ISBN
		///															EN		(ISBN-13) Effectively doubles the number of ISBNs available
		///															IB		(ISBN) International Standard Boo Number
		///															UK		(UCC/EAN-14) Used when a leading digit is added to the ISBN-13 that specifies the
		///																	packaging level (such as a carton). When the packaging level is greater than a 
		///																	unit (such as a carton), a new check digit must be calculated
		/// </summary>
		virtual public object ProductServiceIDQualifier_01 { get; set; }


		/// <summary>
		/// Identifying number for a product or service
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK08	234		C	AN		001	040	Used			Product/Service ID								
		/// </summary>
		virtual public string ProductServiceID_01 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID (234)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK09	235		C	R		002	002	Used	Blank	Product/Service ID Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															AI		Alternative ISBN
		///															EN		(ISBN-13) Effectively doubles the number of ISBNs available
		///															IB		(ISBN) International Standard Boo Number
		///															UK		(UCC/EAN-14) Used when a leading digit is added to the ISBN-13 that specifies the
		///																	packaging level (such as a carton). When the packaging level is greater than a 
		///																	unit (such as a carton), a new check digit must be calculated
		virtual public string ProductServiceIDQualifier_02 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK10	234		C	AN		001	040	Used			Product/Service ID								
		/// </summary>
		virtual public string ProductServiceID_02 { get; set; }

		/// <summary>
		/// Code identifying the type/source of the descriptive number used in Product/Service ID (234)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK11	235		C	R		002	002	Used	Blank	Product/Service ID Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															AI		Alternative ISBN
		///															EN		(ISBN-13) Effectively doubles the number of ISBNs available
		///															IB		(ISBN) International Standard Boo Number
		///															UK		(UCC/EAN-14) Used when a leading digit is added to the ISBN-13 that specifies the
		///																	packaging level (such as a carton). When the packaging level is greater than a 
		///																	unit (such as a carton), a new check digit must be calculated		
		virtual public string ProductServiceIDQualifier_03 { get; set; }

		/// <summary>
		/// Identifying number for a product or service
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK12	234		C	AN		001	040	Used			Product/Service ID								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public string ProductServiceID_03 { get; set; }

		/// <summary>
		/// Description: 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK13								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_02 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK14								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_03 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK15								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_04 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK16								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_05 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK17								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_06 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK18							
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_07 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK19							
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_08 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK20
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_09 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK21								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_10 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK22								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_11 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK23								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_12 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK24								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_13 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK25								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_14 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK26								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_15 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK27								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_16 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK28								
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object Reserved_ForFutureUse_17 { get; set; }

		/// <summary>
		/// $ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ACK29	1271	C	AN		001	030	Used										
		///															Code	Name
		///															----	---------------
		///															AC		Item accepted and shipped (Shipping)
		///															AN		Available:Shipping - new edition/ISBN(Shipping)
		/// 														AO		Available: Shipping From Other Location
		/// 														AR		Item Accepted: Released for shipment(Shipping)
		/// 														AS		Available: Shipping - same ISBN(Shipping)
		/// 														AV		Inventory available for order(Available)
		/// 														AX		Available : Shipping - free book(Shipping)
		/// 														BA		BackOrdered: Not yet available(Not Shipped)
		/// 														BB		BackOrdered: Reprint under consideration(Not Shipped)
		/// 														BC		BackOrdered: Current edition not available - to be replaced with...(Not Shipped)
		/// 														BD		BackOrdered: Delay in publication(Not Shipped)
		/// 														BH		BackOrdered: On hold(Not Shipped)
		/// 														BI		BackOrdered: To be reissued(Not Shipped)
		/// 														BK		BackOrdered: from previous order(Not Shipped)
		/// 														BN		BackOrdered: Inventory in progress; closed for stocktaking(Not Shipped)
		/// 														BO		BackOrdered: At customer's request (Not Shipped)
		/// 														BP		Item Accepted: partial shipment; balance back ordered(Shipping)
		/// 														BR		BackOrdered: To be reprinted(Not Shipped)
		/// 														BW		BackOrdered: Waiting for catalog/processing(Not Shipped)
		/// 														BX		BackOrdered: Not yet published(Not Shipped)
		/// 														CA		Canceled: Not yet available(Not Shipped)
		/// 														CB		Canceled:  Not our publication(Not Shipped)
		/// 														CD		Canceled: Delay in publication(Not Shipped)
		/// 														CE		Canceled: Order partially filled and shipped; remainder of order cancelled (Shipping)
		///															CF		Canceled: Current edition not available(Not Shipped)
		///															CG		Canceled: No geographic rights, e.g.Canadian(Not Shipped)
		///															CH		Canceled: Rights no longer ours(Not Shipped)
		///															CI		Canceled: To be reissued(Not Shipped)
		///															CJ		Canceled: Out of print in cloth; available in paper - reorder(Not Shipped)
		///															CL		Canceled: Out of print in paper; available in cloth - reorder(Not Shipped)
		///															CN		Canceled: Inventory in progress; closed for stocktaking(Not Shipped)
		///															CO		Canceled: Out of stock(Not Shipped)
		///															CQ		Canceled: Did not meet minimum order requirements; e.g., quantity or dollar value(Not Shipped)
		///															CR		Canceled: To be reprinted(Not Shipped)
		///															CT		Canceled: Publisher did not respond by your cancellation date(Not Shipped)
		///															CU		Canceled: Kits not available(Not Shipped)
		///															CV		Canceled: Complete set volume must be purchased(Not Shipped)
		///															CW		Canceled: Apply direct; not available through wholesale channels(Not Shipped)
		///															CX		Canceled: Never published(Not Shipped)
		///															CY		Canceled: Not available as a processed book(Not Shipped)
		///															DR		Item accepted: Date rescheduled(Shipping)
		///															DS		Out of Stock
		///															IA		Item Accepted(Shipping)
		///															IB		Item Back ordered(Not Shipped)
		///															ID		Item Deleted(Not Shipped)
		///															IE		Item accepted: Price pending(Shipping)
		///															IF		Item on hold: Incomplete description(Not Shipped)
		///															IG		Item Forwarded to Proper Source/Published
		///															IH		Item on hold(Not Shipped)
		///															IN		Item accepted: Forwarded to new supplier(Not Shipped)
		///															IP		Item accepted: Price changed(Shipping)
		///															IQ		Item accepted: Quantity changed(Shipping)
		///															IR		Item rejected(Not Shipped)
		///															IS		Item accepted: Substitution made(Shipping)
		///															IW		Item on hold: Waiver required(Not Shipped)
		///															KC		Canceled: REprint under consideration(Not Shipped)
		///															KK		Canceled: ISBN incorrect/unknown(Not Shipped)
		///															KM		Canceled: Market for this title is restricted(Not Shipped)
		///															KP		Canceled: Out of print(Not Shipped)
		///															KR		Canceled: Title Remaindered(Not Shipped)
		///															KS		Canceled: book sold by subscription only(Not Shipped)
		///															NF		Not yet published(Not Shipped)
		///															OP		Out of print(Not Shipped)
		///															OR		Temporarily out of stock(Not Shipped)
		///															PA		Partial shipment(Shipping)
		///															SC		Shipment complete(Shipping)
		///															SP		Item accepted: Schedule date pending(Shipping)
		/// 														SS		Split Shipment(Shipping)
		/// </summary>
		virtual public string IndustryCode { get; set; }
	}
}