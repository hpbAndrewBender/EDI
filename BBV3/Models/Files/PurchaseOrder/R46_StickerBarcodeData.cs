using FileHelpers;
using CommonLib.Extensions;

namespace FormatBBV3.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"46" 	
		02	003-007 	005 	Numeric 	Sequence Number 	 									Y	 
		03	008-029 	022 	AlphaNum  	PO Number 												Y		Left justify, space fill. 	
		04	030-031 	002 	AlphaNum	Barcode Type Code 										Y		Code = Barcode Format  "UP" = UPC  "EN" = EAN  "ZZ" = EAN with price add-on  "SK" = Code 128 	
		05	032-049 	018 	AlphaNum 	String for Barcode 										Y		This is a numeric item identifier, e.g., 9780385503952, to create the barcode, which will always print on sticker line 2 and is limited to 18 characters.   	
		06	050-080 	031 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill. 	
	*/
	[FixedLengthRecord(FixedMode.AllowMoreChars)]
	public class R46_StickerBarcodeData
	{
		public R46_StickerBarcodeData()
		{
			RecordCode = Enumerations.PurchaseOrders.Records.StickerTextLinesRecord.ToStringValue();
			Reserved050_080 = string.Empty;
		}

		[
			FieldOrder(1),
			FieldFixedLength(2)
		]
		public string RecordCode { get; set; }

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
			FieldTrim(TrimMode.Both)
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(2),
			FieldNullValue(typeof(char), " ")
		]
		public char BarcodeTypeCode { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(18)
		]
		public string StringforBarcode { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(31),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved050_080 { get; set; }
	}
}