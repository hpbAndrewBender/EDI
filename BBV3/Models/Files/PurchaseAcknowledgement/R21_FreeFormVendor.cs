using FileHelpers;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement
{
	/*
		Position 	Length 	Format 		Field Name 									Description 
		----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		001-002 	002 	Numeric		Record Code 								"21" 
		003-007 	005 	Numeric		Sequence Number 	 
		008-029 	022 	AlphaNum 	PO Number 	 
		030-079 	050 	AlphaNum 	Vendor Message 								Message from Ingram to client – will contain error messages if there is a problem with the PO sent. Please see the PO and POA status codes for details. 
		080 		001 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
	*/
	[FixedLengthRecord]
	public class R21_FreeFormVendor //  (up to 3 occurrences)
	{
		[
			FieldFixedLength(2),
			FieldTrim(TrimMode.Both, " "),
		]
		public string RecordCode { get; set; }

		[
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short SequenceNumber { get; set; }

		[
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldFixedLength(50),
			FieldTrim(TrimMode.Both, " "),
		]
		public string VendorMessage { get; set; }

		[
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved080 { get; set; }
	}
}