using CommonLib.Extensions;
using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"50" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field 	
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Left justify, space fill 	
		04	030-034 	005 	Numeric 	Total Purchase Order Records 							Y		Count of recorSMALds 10 through 50 in entire file. Right justify, zero fill 
		05	035-044 	010 	Numeric 	Total Line Items in file 								Y		Count of 40 records in entire file.  Right justify, zero fill 	
		06	045-054 	010 	Numeric 	Total Units Ordered 									Y		Total order quantities in records 40 and 41.   Right justify, zero fill 	
		07	055-080 	026 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill  	
 	*/

	[FixedLengthRecord(FixedMode.AllowMoreChars)]
	public class R50_PurchaseOrderControl
	{
		public R50_PurchaseOrderControl()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.PurchaseOrderControlTrailerRecord;
			Reserved055_080 = string.Empty;
		}

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
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalPurchaseOrderRecords { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalLineItemsInfile { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalUnitsOrdered { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(26),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved055_080 { get; set; }
	}
}
 