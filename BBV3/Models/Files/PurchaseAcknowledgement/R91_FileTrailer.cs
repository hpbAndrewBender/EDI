using FileHelpers;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 								"91" 
		02	003-007 	005 	Numeric 	Sequence Number									 
		03	008-080 	010 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
	*/

	[FixedLengthRecord]
	public class R91_FileTrailer
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
			FieldFixedLength(73), // spec says 10
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved008_080 { get; set; }
	}
}