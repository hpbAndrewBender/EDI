using FileHelpers;

namespace FormatCDFL.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Invoice File Trailer  									Y		Must contain "95"	
		02	003-007 	005 	Numeric 	Record Sequence 	 									Y 
		03	008-020 	013 	Numeric 	Total Titles 	 										Y 
		04	021-025 	005 	Numeric 	Total Invoices 	 										Y 
		05	026-035 	010 	Numeric 	Total Units 	 										Y 
		06	036-080 	045 	AlphaNum 	Reserved 												Y		Blank 	
	*/

	[FixedLengthRecord]
	public class R95_InvoiceFileTrailer
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string InvoiceFileTrailer { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short SequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(13),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalTitles { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalInvoices { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalUnits { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(45),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved036_080 { get; set; }

	}
}
 