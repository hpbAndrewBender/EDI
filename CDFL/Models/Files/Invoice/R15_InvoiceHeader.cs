using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Models.Files.Invoice
{
	/*
		Alpha   = Alpha(Text) A-Z upper or lower case left justified, blank filled
		Numeric = Numeric 0-9 right justified, zero-filled
		AlphaNum= Alpha Numeric (TextS) left justified blank filled
		DT      = Date (8 Digit = YYYYMMDD, 6 Digit = YYMMDD, 4 Digit = YYMM)

		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Invoice Header  										Y		Must contain "15"	
		02	003-007 	005 	Numeric 	Record Sequence 										Y 
		03	008-015 	008 	Numeric 	Invoice Number   										Y		Assigned by Ingram	
		04	016-034 	019 	AlphaNum 	Reserved 												Y		Blank  	
		05	035-041 	007 	AlphaNum 	Company Account ID Number								Y		IFSI assigned Account Number
		06	042-046 	005 	AlphaNum 	Reserved 												Y		Blank 
		07	047-053 	007 	Numeric 	Warehouse SAN 	 										Y 
		08	054-056 	003 	AlphaNum 	Reserved 												Y		Blank  
		09	057-064 	008 	Date 		Invoice Date  											Y		YYYYMMDD	
		10	065-080 	016 	AlphaNum 	Reserved  												Y		Blank 	
	*/

	[FixedLengthRecord]
	public class R15_InvoiceHeader
	{

		[
			FieldOrder(1),
			FieldFixedLength(2),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short InvoiceHeader { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16)
		]
		public short SequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
		]
		public int InvoiceNumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(19),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved016_034 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string CompanyAccountIDNumber { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved042_046 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string WarehouseSAN { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved054_056 { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYYYMMDD))
		]
		public DateTime InvoiceDate { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(16),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved065_080 { get; set; }

	}
}