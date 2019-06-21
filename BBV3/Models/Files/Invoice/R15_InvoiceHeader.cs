using FileHelpers;
using System;

namespace FormatBBV3.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	2 		Numeric 	Invoice Header  							"15" 
		02	003-007 	5 		Numeric 	Record Sequence number 						 
		03	008-015 	8 		Numeric 	Invoice Number   							Assigned by Ingram 
		04	016-021 	6 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
		05	022-043 	22 		AlphaNum 	Purchase Order Number 	 
		06	044-050 	7 		AlphaNum 	Ingram Ship To Account Number 				Your Ingram ship to account number 
		07	051-055 	5 		AlphaNum 	Store Number 								If no store number, this field will be zero filled. 
		08	056-062 	7 		AlphaNum 	DC SAN 										Ingram assigned DC SAN, use to identify which DC the order shipped from. See DC codes for list of valid codes. 
		09	063-065 	3 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
		10	066-073 	8 		Date 		Invoice Date  								YYYYMMDD 
		11	074-080 	7 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
 	 	 	 	 


	*/

	[FixedLengthRecord]
	public class R15_InvoiceHeader
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string InvoiceHeader { get; set; }

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
			FieldFixedLength(6),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved016_021 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both),
		]
		public string PurchaseOrderNumber { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(7),
		]
		public string IngramShipToAccountNumber { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string StoreNumber { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(7),
		]
		public string DCSAN { get; set; }


		[
			FieldOrder(9),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved063_065 { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYYYMMDD)),
		]
		public DateTime InvoiceDate { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved074_080 { get; set; }
	}
}
 