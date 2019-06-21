using FileHelpers;
using System;

namespace FormatCDFL.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Detail Record  											Y		Must contain "45"	
		02	003-007 	005 	Numeric 	Record Sequence 	  									Y 
		03	008-015 	008 	Numeric 	Invoice Number  										Y		Assigned by Ingram	 
		04	016-021 	006 	AlphaNum 	Reserved 												Y		Blank  
		05	022-034 	013 	AlphaNum 	Reserved 												Y		Blank  
		06	035-044 	010 	AlphaNum 	ISBN-10 Shipped 	 									Y 
		07	045			001 	AlphaNum 	Reserved 												Y		Blank  
		08	046-050 	005 	Numeric 	Quantity Shipped 	 									Y 
		09	051-057 	007 	Numeric 	Ingram Item List Price  								Y		Contains an implied decimal point with 2 positions to the right of the decimal point.  Example: $5.80 – "0000580". 	 
		10	058 		001 	AlphaNum 	Reserved 												Y		Blank 
		11	059-062 	004 	Numeric 	Discount  												Y		Contains an implied decimal point with 2 positions to the right of the decimal point. 	 Example:  .35 – "3500".	
		12	063			001 	AlphaNum 	Reserved 												Y		Blank 	
		13	064-071 	008 	Numeric 	Net Price / Cost  										Y		Contains an implied decimal point with 2 positions to the right of the decimal point . Example: $5.80 – "00000580". 	
		14	072-079 	008 	Date 		Metered Date  											Y		YYYYMMDD 	
		15	080			001 	AlphaNum 	Reserved 												Y		Blank 	
	*/

	[FixedLengthRecord]
	public class R45_InvoiceDetail
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string DetailRecord { get; set; }

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
			FieldFixedLength(6),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved016_021 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(13),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved022_034 { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(10),
		]
		public string ISBN10Shipped { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved045 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short QuantityShipped { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal IngramItemListPrice { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved058 { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(4),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal Discount { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved063 { get; set; }

		[
			FieldOrder(13),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal NetPriceOrCost { get; set; }

		[
			FieldOrder(14),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYYYMMDD)),
		]
		public DateTime MeteredDate { get; set; }

		[
			FieldOrder(15),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved080 { get; set; }
	}
}
 