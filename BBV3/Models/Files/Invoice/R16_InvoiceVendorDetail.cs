using FileHelpers;

namespace FormatBBV3.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	2 		Numeric 	Record Type 								"16" 
		02	003-007 	5 		Numeric 	Record Sequence number 	 
		03	008-015 	8 		Numeric 	Invoice Number  							Assigned by Ingram 
		04	016-021 	6 		AlpphaNum 	Reserved 									Reserved – left justified, space filled. 
		05	022  		1 		AlpphaNum 	DC Code 									DC where the order has been shipped. See DC codes  for list of valid codes. 
		06	023-027 	5 		AlpphaNum 	Ingram Order Entry Number 					Order number assigned by Ingram as an internal tracking number.  
		07	028-080 	53 		AlpphaNum 	Reserved 									Reserved – left justified, space filled. 
	 */
	[FixedLengthRecord]
	public class R16_InvoiceVendorDetail
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string RecordType { get; set; }

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
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char DCCode { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string IngramOrderEntryNumber { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(53),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved028_080 { get; set; }
	}
}