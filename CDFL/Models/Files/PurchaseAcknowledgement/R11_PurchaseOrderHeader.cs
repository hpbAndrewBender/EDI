using FileHelpers;
using System;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"11" 
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 02, this field 
		03	008-020 	013 	AlphaNum 	TOC 													Y		Terminal Order Control is a value assigned byIngram.  Will begin with a "C" for CDF-Lite orders 
		04	021-042 	022 	AlphaNum 	PO Number 	 											Y 
		05	043-049 	007 	AlphaNum 	ICG  Ship To Account Number 							Y		Your Ingram ship to account number 
		06	050-056 	007 	AlphaNum 	ICG SAN 												Y		"1697978" 	
		07	057 		001 	AlphaNum 	PO Status 												Y		See Appendix D for valid translation codes 	
		08	058-063 	006 	Date 		Acknowledgment Date 									Y		Format YYMMDD
		09	064-069 	006 	AlphaNum 	PO Date 												Y		Format YYMMDD
		10	070-075 	006 	Date 		PO Cancellation Date 									Y		Format YYMMDD
		11	076-080 	005 	AlphaNum 	Reserved 												Y		Blank 
	*/

	[FixedLengthRecord]
	public class R11_PurchaseOrderHeader
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
			FieldConverter(ConverterKind.Byte),
		]
		public byte RecordCode { get; set; }

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
		]
		public string TOC { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both, " ")

		]
		public string PONumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(7),
		]
		public string ICGShipToAccountNumber { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(7),
		]
		public string ICGSAN { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char POStatus { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
		]
		public DateTime AcknowledgmentDate { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
		]
		public DateTime PODate { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
		]
		public DateTime POCancellationDate { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved076_080 { get; set; }
	}
}