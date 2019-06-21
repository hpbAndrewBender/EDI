using FileHelpers;
using System;

namespace FormatBBV3.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	2 		Numeric 	Invoice File Header 						"01" 
		02	003-007 	5 		Numeric 	Record Sequence number 						"00001" 
		03	008-019 	12 		Numeric 	Ingram SAN   								"169797800000" 
		04	020-032 	13 		AlpahNum 	File Source 								"INGRAM BK CO" 
		05	033-038 	6 		Date 		Creation Date  								YYMMDD 
		06	039-060 	22 		AlphaNum 	File Name  									"INVOICE COMMUNICATIONS" 
		07	061-080 	20 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
	*/


	[FixedLengthRecord]
	public class R01_InvoiceFileHeader
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string InvoiceFileHeader { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short RecordSequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(12),
		]
		public string IngramSAN { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(13),
			FieldAlign(AlignMode.Left, ' '),
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
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved061_080 { get; set; }
	}
}
 