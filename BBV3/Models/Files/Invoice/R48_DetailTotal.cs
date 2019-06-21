using FileHelpers;

namespace FormatBBV3.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	02 		Numeric 	Detail Total 								"48" 
		02	003-007 	05 		Numeric 	Record Sequence number 	 
		03	008-015 	08 		Numeric 	Invoice Number   							Assigned by Ingram 
		04	016-020 	05 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
		05	021-045 	25 		AlphaNum 	Title 										Ingram's title description 
		06	046-067 	22 		AlphaNum 	Customer PO Number 							 
		07	068-080 	13 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
*/
	[FixedLengthRecord]
	public class R48_DetailTotal
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string DetailTotal { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string RecordSequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int32),
		]
		public int InvoiceNumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved016_020 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(25),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both),
		]
		public string Title { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(22),
			FieldTrim(TrimMode.Both),
		]
		public string CustomerPONumber { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(13),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved068_080 { get; set; }
	}
}