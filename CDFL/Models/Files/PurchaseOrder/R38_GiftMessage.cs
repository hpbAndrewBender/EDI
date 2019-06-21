using CommonLib.Extensions;
using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"38" 
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field 	
		03	008-029 	022 	AlphaNum  	PO Number 												Y		Left justify, space fill 
		04	030-080 	051 	AlphaNum  	Gift Message 											Y		This field is available for the Bill-to (purchasing) consumer to specify a message to be printed on the recipient's packing slip (e.g., "Happy Birthday"). Message size is 255 characters - repeat record as necessary.  Left justify, space fill.  NOTE: Do NOT use carriage returns, line feeds, apostrophes, asterisks, quotation marks or other special characters in this message field 
	*/

	[FixedLengthRecord]
	public class R38_GiftMessage
	{
		public R38_GiftMessage()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.GiftMessageRecord;
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
			FieldFixedLength(51),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string GiftMessage { get; set; }
	}
}
 