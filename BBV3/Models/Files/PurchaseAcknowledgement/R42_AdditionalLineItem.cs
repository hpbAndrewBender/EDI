using FileHelpers;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 								"42" 
		02	003-007 	005 	Numeric 	Sequence Number 	 
		03	008-029 	022 	AlphaNum 	PO Number 	 
		04	030-059 	030 	AlphaNum 	Title 										short title description. 
		05	060-079 	020 	AlphaNum 	Author 										Last name, first name, middle initial. 
		06	080 		001 	AlphaNum 	Binding Code 								Valid Codes: "M" = Mass Market paperback,"A" = Audio,"T" = Trade Paper,"H" = Hardcover,"  " = Spaced (blank) - Other 
	*/

	[FixedLengthRecord]
	public class R42_AdditionalLineItem
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
			FieldTrim(TrimMode.Both, " "),
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
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(30),
			FieldTrim(TrimMode.Both, " "),
		]
		public string Title { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(20),
			FieldTrim(TrimMode.Both, " "),
		]
		public string Author { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char BindingCode { get; set; }
	}
}