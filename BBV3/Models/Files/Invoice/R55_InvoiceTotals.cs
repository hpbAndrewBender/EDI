using FileHelpers;

namespace FormatBBV3.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	02 		Numeric 	Invoice Total 								"55"
		02	003-007 	05 		Numeric 	Record Sequence number
		03	008-015 	08 		Numeric 	Invoice Number  							Assigned by Ingram.
		04	016-020 	05 		AlphaNum 	Reserved 									Reserved – left justified, space filled.
		05	021-025 	05 		Numeric 	Invoice Record Count  						Number of lines in the invoice.
		06	026-030 	05 		Numeric 	Number of Items  							Number of items on order.
		07	031-036 	06 		Numeric 	Total Number of Units  						Number of units invoiced.
		08	037-080 	44 		AlphaNum 	Reserved 									Reserved – left justified, space filled.
 */

	[FixedLengthRecord]
	public class R55_InvoiceTotals
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string InvoiceTotal { get; set; }

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
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved016_020 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short InvoiceRecordCount { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short NumberofItems { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalNumberofUnits { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(44),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved057_080 { get; set; }
	}
}