using FileHelpers;

namespace FormatBBV3.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	02		Numeric 	Invoice File Trailer  						"95" 
		02	003-007 	05		Numeric 	Record Sequence number 	 
		03	008-020 	13		Numeric 	Total Items 								Number of items in file. 
		04	021-025 	05		Numeric 	Total Invoices 								Number of invoices in file. 
		05	026-035 	10		Numeric 	Total Units 								Number of units invoiced in file. 
		06	036-080 	45		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
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
		public short RecordSequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(13),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalItems { get; set; }

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
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved036_080 { get; set; }
	}
}