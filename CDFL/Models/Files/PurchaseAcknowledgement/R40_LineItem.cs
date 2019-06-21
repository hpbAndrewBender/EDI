using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"40"
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 02, this field 
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Order level PO number 	
		04	030-039 	010 	AlphaNum 	Line Item PO Number 									O		This will be the same as the Line Item PO number from PO file, Record 40 
		05	040-051 	012 	AlphaNum 	Reserved 												O		Blank
		06	052-071 	020 	AlphaNum 	Item Number 											Y		EAN (ISBN-13), ISBN-10, or UPC for the shipping item 	
		07	072-074 	003 	AlphaNum 	Reserved  												Y		Blank 	
		08	075-077 	003 	AlphaNum 	Reserved 												Y		Blank 	
		09	078-079 	002 	AlphaNum 	POA Status Code 										Y		See Appendix D for translation codes 	
		10	080 		001 	AlphaNum 	DC Code 												Y		See Appendix D for DC codes 	
	*/

	[FixedLengthRecord]
	public class R40_LineItem
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
			FieldFixedLength(10),
		]
		public string LineItemPONumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(12),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved040_051 { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string ItemNumber { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved072_074 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved075_077 { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(2),
		]
		public string POAStatusCode { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char DCCode { get; set; }
	}
}
 