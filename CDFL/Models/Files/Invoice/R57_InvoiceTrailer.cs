using FileHelpers;

namespace FormatCDFL.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Invoice Trailer  										Y		Must contain "57"	
		02	003-007 	005 	Numeric 	Record Sequence 	  									Y 
		03	008-015 	008 	Numeric 	Invoice Number  										Y		Assigned by Ingram	 
		04	016-020 	005 	AlphaNum 	Reserved 												Y		Blank 	
		05	021-029 	009 	Numeric 	Total Net Price  										Y		Total Product Cost.  Contains an implied decimal point with 2 positions to the right of the decimal  point.   Example: $153.00 – "000015300".	Y 
		06	030-035 	006 	AlphaNum 	Reserved 	Blank 										Y 
		07	036-042 	007 	AlphaNum 	Total Shipping  										Y		Total Freight.  If the field is an allowance, byte 36 will be a minus sign. Contains an implied decimal point with 2 positions to the right of the decimal  point.   Example: $12.00 – "0001200
		08	043-049 	007 	Numeric 	Total Handling  										Y		Total Handling fees. Contains an implied decimal point with 2 positions to the right of the decimal  point.    Example: $2.10 – "0000210".
		09	050-055 	006 	Numeric 	Total Gift-Wrap   										Y		Total Gift-Wrap fees.  Contains an implied decimal point with 2 positions to the right of the decimal  point.    Example: $2.00 – "000200".
		10	056-061 	006 	AlphaNum 	Reserved 												Y		Blank 
		11	062-071 	010 	AlphaNum 	Reserved 												Y		Blank 
		12	072-080 	009 	Numeric 	Total Invoice  											Y		Total Charges.  Contains an implied decimal point with 2 positions to the right of the decimal point. 	 Example: $47.50 – "000004750".
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
		public short SequenceNumber { get; set; }

		[
			FieldOrder(3),			
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string InvoiceNumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved016_020 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(9),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal TotalNetPrice { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved030_035 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal TotalShipping { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal TotalHandling { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal TotalGiftWrap { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved056_61 { get; set; }
		[
			FieldOrder(11),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved062_071 { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(9),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal TotalInvoice { get; set; }
	}
}
 