using FileHelpers;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 								"59" 
		02	003-007 	005 	Numeric 	Sequence Number 	 
		03	008-029 	022 	AlphaNum 	PO Number 	 
		04	030-080 	071 	Numeric 	Reserved 	 
	*/

	[FixedLengthRecord]
	public class R59_PurchaseOrderControlTotals
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
			FieldFixedLength(51),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved030_080 { get; set; }
	}
}