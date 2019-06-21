using FileHelpers;

namespace FormatBBV3.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	02 		Numeric 	Invoice Detail 								"45" 
		02	003-007 	05 		Numeric 	Record Sequence number 	 
		03	008-015 	08 		Numeric 	Invoice Number  							Assigned by Ingram 
		04	016-021 	06 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
		05	022-043 	22 		AlphaNum 	PO Number 	 
		06	044-048 	05 		Numeric 	Quantity Shipped 	 
		07	049-055 	07 		Numeric 	Ingram Item									List Price 	Contains an implied decimal point with 2 positions to the right of the decimal point, e.g., $5.80 = "0000580". 
		08	056 		01 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
		09	057-060 	04 		Numeric 	Discount Percent 							Contains an implied decimal point with 2 positions to the right of the decimal point, e.g., 35% = "3500". 
		10	061 		01 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 
		11	062-069 	08 		Numeric 	Net Price / Cost 							Contains an implied decimal point with 2 positions to the right of the decimal point, e.g., $5.80 = "00000580". 
		12	070-080 	11 		AlphaNum 	Reserved 									Reserved – left justified, space filled. 

	 */
	[FixedLengthRecord]
	public class R45_InvoiceDetail
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string InvoiceDetail { get; set; }

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
		public string PONumber { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short QuantityShipped { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal IngramItemListPrice { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved056 { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(4),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal DiscountPercent { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved061 { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal NetPriceOrCost { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(11),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved070_080 { get; set; }
	}
}