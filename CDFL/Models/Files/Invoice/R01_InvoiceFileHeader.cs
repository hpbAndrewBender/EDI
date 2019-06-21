using FileHelpers;
using System;

namespace FormatCDFL.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	File Header   											Y		Must contain "01" 	
		02	003-007 	005 	Numeric 	Record Sequence  										Y		Must contain "00001" 	
		03	008-019 	012 	Numeric 	Ingram SAN   											Y		"169797800000" 	
		04	020-032 	013 	Alpha	 	File Source 											Y		"INGRAM BK CO" 	
		05	033-038 	006 	Date		Creation Date  											Y		YYMMDD 	
		06	039-060 	022 	Alpha	 	File Name  												Y		"INVOICE COMMUNICATIONS"	
		07	061-080 	020 	AlphaNum 	Reserved 												Y		Blank 	
	*/

	[FixedLengthRecord]
	public class R01_InvoiceFileHeader
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string FileHeader { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short SequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(12),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string IngramSAN { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(13),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string FileSource { get; set; }

		[	
			FieldOrder(5),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
		]
		public DateTime CreationDate { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string FileName { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved061_080 { get; set; }
	}
}
 