using CommonLib.Extensions;
using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"35" 
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field 
		03	008-029 	022 	AlphaNum  	PO Number 												Y		Left justify, space fill 
		04	030-037 	008 	AlphaNum 	Reserved 												Y		Blank 
		05	038-044 	007 	Numeric  	Gift-Wrap Fee Amount 									O		Fee charged to the consumer for gift wrapping or other services. Right justify, zero fill.  Explicit (required) decimal, max 2 decimal places to the right of the decimal.  Example:  "0002.75".  
		06	045 		001 	AlphaNum  	Send Consumer Email 									Y		"N" 
		07	046 		001 	AlphaNum  	Order Level Gift Indicator 								Y		"Y" or "N" – This Indicator denotes if the Order is a gift. The title on the Packing Slip will be replaced with "A Gift For You" and all Pricing will be suppressed (unless required for shipment). If the order is to be gift wrapped, use in conjunction with the order level gift wrap code in this record, position 48-50  
		08	047 		001 	AlphaNum 	Suppress Price Indicator 								Y		"Y" or "N" 	
		09	048-050 	003 	Numeric 	Order Level Gift Wrap Code 								O		See Appendix C for valid codes 	
		10	051-080 	030 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill  	
	*/

	[FixedLengthRecord]
	public class R35_DropShipDetail
	{
		public R35_DropShipDetail()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.DropShipDetailRecord;
			Reserved030_037 = string.Empty;
			Reserved051_080 = string.Empty;
		}

		[
			FieldOrder(1),
			FieldFixedLength(2),
			FieldConverter(ConverterKind.Byte),
		]
		public byte RecordCode { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short SequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved030_037 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.ExplicitDec2)),
			FieldNullValue(typeof(decimal), "0.00")
		]
		public decimal GiftWrapFeeAmount { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(1),
			FieldConverter(typeof(CommonLib.Converters.Bools.YN)),
		]
		public bool SendConsumerEmail { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(1),
			FieldConverter(typeof(CommonLib.Converters.Bools.YN)),
		]
		public bool OrderLevelGiftIndicator { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(1),
			FieldConverter(typeof(CommonLib.Converters.Bools.YN)),
		]
		public bool SuppressPriceIndicator { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Right,'0')
		]
		public string OrderLevelGiftWrapCode { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(30),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved051_080 { get; set; }
	}
}
 