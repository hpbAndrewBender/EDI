using FileHelpers;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Numeric		Record Code 								"40" 
		02	003-007 	005 	Numeric		Sequence Number 	 
		03	008-029 	022 	AlphaNum 	PO Number 	 
		04	030-051 	022 	AlphaNum 	Line Item PO Number 						This will be the same as the line item PO number from PO file, record type 40, position 30 – 51. 
		05	052-071 	020 	AlphaNum 	Item Number 								EAN (ISBN-13), ISBN-10, or UPC for the shipping item. 
		06	072-077 	006 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
		07	078-079 	002 	AlphaNum 	POA Status Code 							See POA status code translation file for a list of codes. 
		08	080 		001 	AlphaNum 	DC Code, Primary DC 						See DC codes for list of valid codes. 
	*/

	[FixedLengthRecord]
	public class R40_LineItem
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
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both, " "),
		]
		public string LineItemPONumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both, " "),
		]
		public string ItemNumber { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved072_076 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(2),
			FieldTrim(TrimMode.Both, " "),
		]
		public string POAStatusCode { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char DCCodeOrPrimaryDC { get; set; }
	}
}