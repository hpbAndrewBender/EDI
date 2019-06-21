using FileHelpers;
using System;

namespace FormatCDFL.Models.Files.ShipNotice
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Alpha	 	Order Record Identifier  								Y		Must contain "OR" 
		02	003-024 	022 	AlphaNum 	Client Order ID  										Y		Unique ID number (e.g. PO Number)
		03	025-032 	008 	AlphaNum 	Reserved 												Y		Blank 	
		04	033-034 	002 	AlphaNum 	Order Status Code  										Y		Please see ASN Order and Item Status Codes in Appendix D. 	
		05	035-042 	008 	Numeric 	Order Subtotal  										Y		This is the subtotal of items in an order. Client List Price multiplied by Qty Shipped.  Contains an implied decimal point with 2 positions to the right of  the decimal point.  Example: $11.50 – "00001150". 	
		06	043-050 	008 	Numeric 	Reserved 												Y		Zeroes 	
		07	051-058 	008 	AlphaNum 	Reserved 												Y		Blank  	
		08	059-066 	008 	Numeric 	Reserved  												Y		Zeroes	
		09	067-074 	008 	Numeric 	Order Discount Amount									Y		Discount Amount from PO data. Contains an implied decimal point with 2 positions to the right of  the decimal point – Example: $2.00 – "00000200".	Y 
		10	075-082 	008 	Numeric 	Sales Tax  												Y		Tax from PO data. Contains an implied decimal point with 2 positions to the right of the decimal  point – Example: $2.00 – "00000200".	Y 
		11	083-090 	008 	Numeric 	Shipping and Handling  									Y		Calculated S & H charges from PO data. Contains an implied decimal point with 2 positions to the right of the decimal point  	– Example: $2.00 – "00000200".	Y 
		12	091-098 	008 	Numeric 	Order Total  											Y		Includes Subtotal, Misc. Charges, Tax, Shipping & Handling & any Discount amount from the PO. Contains an implied decimal point with 2 positions to the right of the de 	cimal point – Example: $2.00 – "00000200".	Y 
		13	099-106 	008 	Numeric 	Freight Charge  										Y		Actual freight charge. Contains an implied decimal point with 4 positions to the right of the decimal  point – Example: $5.80 – "00058000". 	Y 
		14	107-109 	003 	AlphaNum 	Reserved 												Y		Blank  	
		15	110-113 	004 	Numeric 	Total Item Detail Count  								Y		Total number of detail items for this order.	
		16	114-121 	008 	Date	 	Shipment Date  											Y		Shipment date of the order.  Format is  YYYYMMDD.	
		17	122-143 	022 	AlphaNum 	Consumer PO Number  									Y		Secondary Purchase order number.  Example 	- Consumer Corporate PO number
		18	144-200 	057 	AlphaNum 	Reserved 												Y		Blank 	
	*/

	[FixedLengthRecord]
	public class OR_OrderRecord
	{

		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string OrderRecordIdentifier { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string ClientOrderID { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved025_032 { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(2),
		]
		public string OrderStatusCode { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal OrderSubtotal { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved043_050 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved051_058 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved059_066 { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal OrderDiscountAmount { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal SalesTax { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal ShippingandHandling { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal OrderTotal { get; set; }

		[
			FieldOrder(13),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal FreightCharge { get; set; }

		[
			FieldOrder(14),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved107_109 { get; set; }

		[
			FieldOrder(15),
			FieldFixedLength(4),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalItemDetailCount { get; set; }

		[
			FieldOrder(16),
			FieldFixedLength(8),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYYYMMDD)),
		]
		public DateTime ShipmentDate { get; set; }

		[
			FieldOrder(17),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string ConsumerPONumber { get; set; }

		[
			FieldOrder(18),
			FieldFixedLength(57),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved144_200 { get; set; }
	}
}
 