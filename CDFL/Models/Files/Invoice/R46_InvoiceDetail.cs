using FileHelpers;

namespace FormatCDFL.Models.Files.Invoice
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Title Record											Y		Must contain "46"	 
		02	003-007 	005 	Numeric 	Record Sequence 	  									Y 
		03	008-015 	008 	Numeric 	Invoice Number  										Y		Assigned by Ingram	
		04	016-021 	006 	AlphaNum 	Reserved 												Y		Blank 	 
		05	022-041 	020 	AlphaNum 	Reserved 												Y		Blank 	 
		06	042-061 	020 	AlphaNum 	Reserved 												Y		Blank 	 
		07	062-075 	014 	AlphaNum 	ISBN-13/EAN Shipped 									Y		
		08	076-080 	005 	AlphaNum 	Reserved 												Y		Blank 	
	*/

	[FixedLengthRecord]
	public class R46_InvoiceDetail
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string TitleRecord { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Byte),
		]
		public byte SequenceNumber { get; set; }

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
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved022_041 { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved042_061 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(14),
		]
		public string ISBN13OrEANShipped { get; set; }
		
		[
			FieldOrder(8),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved076_080 { get; set; }

	}
}
 