using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"44" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 02, this field 	
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Order level PO number 
		04	030-049 	020 	AlphaNum 	Reserved 												Y		Blank 
		05	050-057 	008 	Numeric 	Net Price  												Y		Eight position field with explicit decimal point and 2 positions to the right of the decimal. Example: 00000.00 
		06	058-059 	002 	AlphaNum 	Item Number Type 										Y		This is the same value provided in the Item Number Type field in the PO file, Record 40 	
		07	060-067 	008 	Numeric 	Discounted List Price 									Y		This is the list price after the Discount Percent in Record 43 has been applied. Eight position field with explicit decimal point and 2 positions to the right of the decimal. Example: 00000.00
		08	068-074 	007 	Numeric 	Total Line Order Qty 									Y		Right justified, zero filled
		09	075-080 	006 	AlphaNum 	Reserved 												Y		Blank
	*/

	[FixedLengthRecord]
	public class R44_ItemNumberOrPrice
	{
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
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string Reserved030_049 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.ExplicitDec2)),
		]
		public decimal NetPrice { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(2),
			FieldAlign(AlignMode.Right,' ')
			//FieldConverter(ConverterKind.Byte),
			//FieldNullValue(typeof(byte), "0")
		]
		public string ItemNumberType { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.ExplicitDec2)),
		]
		public decimal DiscountedListPrice { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalLineOrderQty { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved075_080 { get; set; }
	}
}