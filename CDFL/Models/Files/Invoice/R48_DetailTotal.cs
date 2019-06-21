using FileHelpers;

namespace FormatCDFL.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Detail Total Record #1  								Y		Must contain "48"	
		02	003-007 	005 	Numeric 	Record Sequence 	  									Y 
		03	008-015 	008 	Numeric 	Invoice Number   										Y		Assigned by Ingram	
		04	016-023 	008 	AlphaNum 	Reserved 												Y		Blank  	
		05	024-039 	016 	AlphaNum 	Title 													Y		Ingram's title description	
		06	040-044 	005 	AlphaNum 	Reserved 												Y		Blank  	
		07	045-066 	022 	Numeric 	Client Order ID  										Y		PO Number	
		08	067-076 	010 	AlphaNum 	Line Item ID Number  	 								Y		
		09	077-080 	004 	AlphaNum 	Reserved 												Y		Blank 	
	*/

	[FixedLengthRecord]
	public class R48_DetailTotal
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string DetailTotalRecord_1 { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short SequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(8),
		]
		public string InvoiceNumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved016_023 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(16),
		]
		public string Title { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved040_044 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(22),
		]
		public string ClientOrderID { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(10),
		]
		public string LineItemIDNumber { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(4),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved077_080 { get; set; }
	}
}
 