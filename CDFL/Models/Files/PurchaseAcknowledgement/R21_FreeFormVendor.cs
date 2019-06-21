using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"21" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 02, this field 	
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Order level PO number 
		04	030-079 	050 	AlphaNum 	Vendor Message 											Y		Message from ICG to client – may contain error messages if there is a problem with the PO sent.
		05	080 		001 	AlphaNum 	Reserved 												Y		Blank
	*/

	[FixedLengthRecord]
	public class R21_FreeFormVendor
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
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both, " ")

		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(50),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string VendorMessage { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved080 { get; set; }
	}
}