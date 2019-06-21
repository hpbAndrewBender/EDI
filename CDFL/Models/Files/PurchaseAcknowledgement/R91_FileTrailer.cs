using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"91" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 02, this field 	
		03	008-020 	013 	Numeric 	Total Line Items in File 								Y		Count of 40 records in entire file
		04	021-025 	005 	Numeric 	Total PO's Acknowledged 								Y		Count of 11 records in entire file
		05	026-035 	010 	Numeric 	Total Units Acknowledged 								Y		Total of shippable quantities in 40, 41 and 43 records 
		06	036-040 	005 	Numeric 	Record Count 01-09 										Y		Count of 01-09 Records 
		07	041-045 	005 	Numeric 	Record Count 10-19 										Y		Count of 10-19 Records
		08	046-050 	005 	Numeric 	Record Count 20-29 										Y		Count of 20-29 Records
		09	051-055 	005 	Numeric 	Record Count 30-39 										Y		Count of 30-39 Records
		10	056-060 	005 	Numeric 	Record Count 40-49 										Y		Count of 40-49 Records
		11	061-065 	005 	Numeric 	Record Count 50-59 										Y		Count of 50-59 Records
		12	066-070 	005 	Numeric 	Record Count 60-99 										Y		Count of 60-99 Records
		13	071-080 	010 	AlphaNum 	Reserved 												Y		Blank 	
	*/

	[FixedLengthRecord]
	public class R91_FileTrailer
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
			FieldAlign(AlignMode.Right, '0'),
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
			FieldFixedLength(13),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalLineItemsinFile { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalPOsAcknowledged { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalUnitsAcknowledged { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short RecordCount01To09 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short RecordCount10To19 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short RecordCount20To29 { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short RecordCount30To39 { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short RecordCount40To49 { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short RecordCount50To59 { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short RecordCount60To99 { get; set; }

		[
			FieldOrder(13),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved071_080 { get; set; }
	}
}