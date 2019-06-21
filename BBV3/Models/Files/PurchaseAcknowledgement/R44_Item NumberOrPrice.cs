using FileHelpers;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 								"44" 
		02	003-007 	005 	Numeric 	Sequence Number 	 
		03	008-029 	022 	AlphaNum 	PO Number 	 
		04	030-049 	020 	AlphaNum 	Forwarded Item Number 						May be different from the item number in the PO file – if the item has been replaced with or superseded by an alternate edition by the manufacturer and the title forward feature is turned on at the account level. 
		05	050-057 	008 	Numeric 	Net / Discount Price 						This field contains the NET cost of goods. Explicit decimal, two positions to the right of the decimal, e.g., 00000.00. 
		06	058-059 	002 	AlphaNum 	Item Number Type 							This is the same value provided in the item number type field in the PO file, record type 40, if applicable. 
		07	060-067 	008 	Numeric 	Reserved 									Reserved – right justified, zero filled. 
		08	068-074 	007 	Numeric 	Total Line Order Quantity 					Right justified, zero filled. 
		09	075-080 	006 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
	*/

	[FixedLengthRecord]
	public class R44_Item_NumberOrPrice
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
			FieldTrim(TrimMode.Both, " "),
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
			FieldFixedLength(20)
		]
		public string ForwardedItemNumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
		]
		public decimal NetOrDiscountPrice { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(2),
			FieldTrim(TrimMode.Both, " "),
		]
		public string ItemNumberType { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved060_067 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
		]
		public short TotalLineOrderQuantity { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved075_080 { get; set; }
	}
}