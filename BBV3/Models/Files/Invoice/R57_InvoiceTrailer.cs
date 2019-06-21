using FileHelpers;

namespace FormatBBV3.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	02 		Numeric 	Invoice Trailer  							"57" 
		02	003-007 	05 		Numeric 	Record Sequence number 	 
		03	008-015 	08 		Numeric 	Invoice Number  							Assigned by Ingram 
		04	016-024 	09 		Numeric 	Total Net Price  							Total item cost. Contains an implied decimal point with 2 positions to the right of the decimal point, e.g., $153.00 – "000015300". 
		05	025-031 	07 		Numeric 	Total Taxes 	 
		06	032-037 	06 		Numeric 	Total Shipping  	 
		07	038-055 	18 		Numeric 	Reserved 									Reserved – right justified, zero filled 
		08	056-062 	07 		Numeric 	Total VAT 									This field contains an implied decimal point with 2 positions to the right of the decimal point, e.g., $47.50 = "000004750". 
		09	063-069 	07 		Numeric 	Total Duty 									This field contains an implied decimal point with 2 positions to the right of the decimal point, e.g., $47.50 = "000004750". 
		10	070-078 	09 		Numeric 	Total Invoice Amount 						This field contains an implied decimal point with 2 positions to the right of the decimal point, e.g., $47.50 = "000004750". 
		11	079-080 	02 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
	 */
	[FixedLengthRecord]
	public class R57_InvoiceTrailer
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string InvoiceTrailer { get; set; }

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
			FieldFixedLength(9),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal TotalNetPrice { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal TotalTaxes { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal TotalShipping { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(18),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved038_055 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal TotalVAT { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal TotalDuty { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(9),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal TotalInvoiceAmount { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(2),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved079_080 { get; set; }
	}
}