using FileHelpers;

namespace FormatCDFL.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Invoice Control Shipping Record  						Y		Must contain "55"
		02	003-007 	005 	Numeric 	Record Sequence 	 									Y		 
		03	008-015 	008 	Numeric 	Invoice Number  										Y		Assigned by Ingram 	
		04	016-020 	005 	AlphaNum 	Reserved 												Y		Blank  	 
		05	021-025 	005 	Numeric 	Invoice Record Count  									Y		Number of lines in the invoice 	
		06	026-030 	005 	Numeric 	Number of Titles  										Y		Number of titles on order 	 
		07	031-036 	006 	Numeric 	Total Number of Units  									Y		Number of units invoiced	
		08	037-046 	010 	AlphaNum 	Bill of Lading Number 	 								Y		 
		09	047-053 	007 	AlphaNum 	Reserved 												Y		Blank 
		10	054-060 	007 	Numeric 	Total Invoice Weight  									Y		Total Product weight.  Non-decimal number 	
		11	061-080 	020 	AlphaNum 	Reserved 												Y		Blank 
	*/

	[FixedLengthRecord]
	public class R55_InvoiceTotals
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string InvoiceControlShippingRecord { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Byte),
		]
		public byte SequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string InvoiceNumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left,' ')
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
		public short NumberofTitles { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalNumberofUnits { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(10),
		]
		public string BillofLadingNumber { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved047_053 { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalInvoiceWeight { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved061_080 { get; set; }
	}
}
 