using FileHelpers;

namespace FormatBBV3.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	02 		Numeric 	Detail ISBN-13 / EAN Record 				"46" 
		02	003-007 	05 		Numeric 	Record Sequence number 	 
		03	008-015 	08 		Numeric 	Invoice Number  							Assigned by Ingram 
		04	016-021 	06 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
		05	022-043 	22 		AlphaNum 	Line Item ID Number 	 
		06	044-056 	13 		AlphaNum 	ISBN-13/EAN Shipped 	 
		07	057-080 	24 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
	 */
	[FixedLengthRecord]
	public class R46_DetailISBN13OrEAN
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string DetailISBN13OrEANRecord { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short RecordSequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int32),
		]
		public int InvoiceNumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved016_021 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both),
		]
		public string LineItemIDNumber { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(13),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string ISBN13OrEANShipped { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(24),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved057_080 { get; set; }
	}
}