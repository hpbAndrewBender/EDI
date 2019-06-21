using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"59" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 02, this field 
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Order level PO number 	
		04	030-034 	005 	Numeric 	Record Count 											Y		Count of 11 through 50 records 	
		05	035-044 	010 	Numeric 	Total Line Items in File 								Y		Count of 40 records 	
		06	045-054 	010 	Numeric 	Total Units Acknowledged 								Y		Total of Quantity Predicted to Ship in records 40, 41, and 43  	
		07	055-064 	010 	Numeric 	Reserved 												Y		Filled with zeroes.
		08	065-072 	008 	Numeric 	Reserved 												Y		Filled with zeroes.
		09	073-080 	008 	Numeric 	Reserved 												Y		Filled with zeroes.
	*/

	[FixedLengthRecord]
	public class R59_PurchaseOrderControlTotals
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
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short RecordCount { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalLineItemsinFile { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalUnitsAcknowledged { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved055_064 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved065_072 { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved073_080 { get; set; }
	}
}