using FileHelpers;
namespace FormatCDFL.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"34" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 02, this field 
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Order level PO number 
		04	030-054 	025 	AlphaNum 	Recipient City 	 										Y 
		05	055-057 	003 	AlphaNum 	Recipient State/Province 	 							Y 
		06	058-068 	011 	AlphaNum 	Zip/Postal Code 	 									Y 
		07	069-071 	003 	AlphaNum 	Country 														See Appendix D for country codes 	 
		08	072-080 	009 	AlphaNum 	Reserved 												Y		Blank 	

	*/
	[FixedLengthRecord]
	public class R34_RecipientShipToCityStateAndZip
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
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(25),
		]
		public string RecipientCity { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(3),
		]
		public string RecipientStateOrProvince { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(11),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string ZipOrPostalCode { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Country { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(9),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Resrved072_080 { get; set; }
	}
}