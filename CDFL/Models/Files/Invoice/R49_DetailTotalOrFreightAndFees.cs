using FileHelpers;

namespace FormatCDFL.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Detail Total Record  									Y		Must contain "49"
		02	003-007 	005 	Numeric 	Record Sequence 	  									Y		
		03	008-015 	008 	Numeric 	Invoice Number   										Y		Assigned by Ingram 	
		04	016-040 	025 	Numeric 	Tracking Number   										Y		"N.A" is sent if one is not assigned
		05	041-048 	008 	Numeric 	Net Price												Y		Product cost.  Contains an implied decimal point with 2 positions to the right of the decimal point. 	 Example: $15.75 – "00001575".	Y 
		06	049-054 	006 	AlphaNum 	Shipping   												Y		Freight charge. Contains an implied decimal point with 2 positions to the right of the decimal point. 	 Example: $2.75 – "000275".	Y 
		07	055-061 	007 	Numeric 	Handling   												Y		Fulfillment fee.  Contains an implied decimal point with 2 positions to the right of the decimal point. 	 Example: $1.50 – "0000150".	Y 
		08	062-067 	006 	Numeric 	Gift-Wrap  												Y		Gift wrap fee. Contains an implied decimal point with 2 positions to the right of the decimal point. 	 Example: $2.00 – "000200".	Y 
		09	068-073 	006 	AlphaNum 	Reserved 												Y		Blank 	Y 
		10	074-080 	007 	Numeric 	Amount Due 												Y		Contains an implied decimal point with 2 positions to the right of the decimal point.  Example: $35.00 – "0003500".	Y 
	*/

	[FixedLengthRecord]
	public class R49_DetailTotalOrFreightAndFees
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string DetailTotalRecord { get; set; }

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
		]
		public string InvoiceNumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(25),
		]
		public string TrackingNumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal NetPrice { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal Shipping { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal Handling { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal GiftWrap { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved068_073 { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal AmountDue { get; set; }
	}
}
 