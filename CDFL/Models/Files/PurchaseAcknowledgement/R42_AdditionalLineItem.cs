using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"42" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 02, this field 	
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Order level PO number 	
		04	030-059 	030 	AlphaNum 	Title 	 												Y 
		05	060-079 	020 	AlphaNum 	Author 	 												Y 
		06	080 		001 	AlphaNum 	Binding Code 											Y		Valid Codes: "M" - Mass Market "A" - Audio products  "T" - Trade Paper "H" - Hard Cover " " Blank - Other 	
	*/

	[FixedLengthRecord]
	public class R42_AdditionalLineItem
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
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(30),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Title { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Author { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char BindingCode { get; set; }
	}
}