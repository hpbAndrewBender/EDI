using FileHelpers;
using System;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Numeric		Record Code									"11" 
		02	003-007 	005 	Numeric		Sequence Number
		03	008-020 	013 	AlphaNum 	Terminal Order Control Number 				TOC is a value assigned by Ingram for internal order tracking purposes. 
		04	021-042 	022 	AlphaNum 	PO Number 									Order level PO number 
		05	043-049 	007 	AlphaNum 	Ingram Ship To Account Number 				Ship to account number from your EO profile  
		06	050-056 	007 	AlphaNum 	Ingram SAN 									"1697978" – Ingram Book "6318630" – Ingram Publisher Services 
		07	057 		001 	AlphaNum 	PO Status 									See PO status code translation file for valid codes. Please also see the POA status for additional details. 
		08	058-063 	006 	Date 		Acknowledgment Date 						Format YYMMDD 
		09	064-069 	006 	AlphaNum 	PO Date 									Format YYMMDD 
		10	070-075 	006 	Date 		PO Cancellation Date 						Format YYMMDD 
		11	076-080 	005 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
	*/
	[FixedLengthRecord]
	public class R11_PurchaseOrderHeader
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
			FieldTrim(TrimMode.Both, " "),
		]
		public string RecordCode { get; set; }

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
			FieldTrim(TrimMode.Both, " "),
		]
		public string TerminalOrderControlNumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(7),
			FieldTrim(TrimMode.Both, " "),
		]
		public string IngramShipToAccountNumber { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(7),
			FieldTrim(TrimMode.Both, " "),
		]
		public string IngramSAN { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char POStatus { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD))
		]
		public DateTime AcknowledgmentDate { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD))
		]
		public DateTime PODate { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD))
		]
		public DateTime POCancellationDate { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved076_080 { get; set; }
	}
}