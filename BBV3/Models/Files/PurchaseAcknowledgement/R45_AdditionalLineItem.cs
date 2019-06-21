using FileHelpers;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Numeric		Record Code 								"45" 
		02	003-007 	005 	Numeric		Sequence Number 	 
		03	008-029 	022 	AlphaNum 	PO Number 	 
		04	030-049 	020 	AlphaNum 	Client's Proprietary Item Number 			This is the same value provided in the item number type field in the PO file, record type 41, position 54 – 73. 
		05	050-080 	031 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 

	*/

	[FixedLengthRecord]
	public class R45_AdditionalLineItem
	{
		[
			FieldOrder(1),
			FieldFixedLength(2)
		]
		public string RecordCode { get; set; }

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
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(20),
			FieldTrim(TrimMode.Both, " "),
		]
		public string ClientsProprietaryItemNumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(31),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved050_080 { get; set; }
	}
}