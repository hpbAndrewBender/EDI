using CommonLib.Extensions;
using FileHelpers;
using System;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"41"
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field
		03	008-029 	022 	AlphaNum  	PO Number 												Y		Left justify, space fill
		04	030-037 	008 	Numeric 	Client Item List Price 									O		This is your list price or discounted price to the consumer and is used to recalculate product charges for each Order Record. It is printed on the Packing Slip and is required for International shipping. Right justify, zero fill.  Explicit (required) decimal, max 2 decimal places to the right of the decimal. Example:  "00012.75".
		05	038-043 	006 	Date 		Line Level Backorder Cancel Date 						O		Format is YYMMDD
		06	044-046 	003 	AlphaNum 	Line Level Gift Wrap Code 								P		"022".  This code is for a plain Blue gift wrap.  Currently, it is the only gift wrap offered.
		07	047-053 	007 	Numeric 	Order Quantity 											Y		Right justify, zero fill.
		08	054-073 	020 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill
		09	074-080 	007 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill
	*/

	[FixedLengthRecord]
	public class R41_AdditionalLineItem
	{
		public R41_AdditionalLineItem()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.AdditionalLineItemRecord;
			Reserved054_073 = string.Empty;
			Reserved074_080 = string.Empty;
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
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.ExplicitDec2)),
		]
		public decimal ClientItemListPrice { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
			FieldNullValue(typeof(DateTime), "01/01/0001"),
		]
		public DateTime LineLevelBackorderCancelDate { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string LineLevelGiftWrapCode { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short OrderQuantity { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved054_073 { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved074_080 { get; set; }
	}
}