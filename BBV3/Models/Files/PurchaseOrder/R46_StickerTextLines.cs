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
		04	030-063 	033 	AlphaNum 	Sticker Text Line 										Y		Free form text field, which means that you control the line format, the line will print exactly how it appears in this field.  
		05	064-080 	021 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill.  
	*/

	[FixedLengthRecord(FixedMode.AllowMoreChars)]
	public class R46_StickerTextLines //(up to 3 occurrences)
	{
		public R46_StickerTextLines()
		{
			RecordCode = Enumerations.PurchaseOrders.Records.StickerTextLinesRecord.ToStringValue();
			Reserved064_080 = string.Empty;
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
			FieldFixedLength(33)
		]
		public string StickerTextLine { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(21),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved064_080 { get; set; }
	}
}