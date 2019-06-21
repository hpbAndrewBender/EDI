using CommonLib.Extensions;
using FileHelpers;

namespace FormatBBV3.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"90" 	
		02	003-007 	005 	Numeric 	Sequence Number 	 									Y 
		03	008-020 	013 	Numeric 	Total Line Items in file 								Y		Count of 40 records in entire file. Optional field if not using then Right justify, zero fill.. 	
		04	021-025 	005 	Numeric 	Total Purchase Order Records 							Y		Count of 10 records in entire file. Right justify, zero fill. 	Y 
		05	026-035 	010 	Numeric 	Total Units Ordered 									Y		Total order quantity in 40 and 41 records in the entire file. Right justify, zero fill.
		06	036-040 	005 	Numeric 	Record Count 00-09 										Y		Number of records that begin with 0. Right justify, zero fill. 	 
		07	041-045 	005 	Numeric 	Record Count 10-19 										Y		Number of records that begin with 1. Right justify, zero fill. 	 
		08	046-050 	005 	Numeric 	Record Count 20-29 										Y		Number of records that begin with 2. Right justify, zero fill. 	 
		09	051-055 	005 	Numeric 	Record Count 30-39 										Y		Number of records that begin with 3. Right justify, zero fill. 	 
		10	056-060 	005 	Numeric 	Record Count 40-49 										Y		Number of records that begin with 4. Right justify, zero fill. 	 
		11	061-065 	005 	Numeric 	Record Count 50-59 										Y		Number of records that begin with 5. Right justify, zero fill. 	 
		12	066-070 	005 	Numeric 	Record Count 60-69 										Y		Number of records that begin with 6. Right justify, zero fill. 	 
		13	071-075 	005 	Numeric 	Record Count 70-79 										Y		Number of records that begin with 7. Right justify, zero fill. 	 
		14	076-080 	005 	Numeric 	Record Count 80-99 										Y		Number of records that begin with 8 and 9. Right justify, zero fill.
	*/

	[FixedLengthRecord(FixedMode.AllowMoreChars)]
	public class R90_FileTrailer
	{
		public R90_FileTrailer()
		{
			RecordCode = Enumerations.PurchaseOrders.Records.FileTrailerRecord.ToStringValue();
			TotalLineItemsInfile = 0;
			TotalPurchaseOrderRecords = 0;
			TotalUnitsOrdered = 0;
			RecordCount00_09 = 0;
			RecordCount10_19 = 0;
			RecordCount20_29 = 0;
			RecordCount30_39 = 0;
			RecordCount40_49 = 0;
			RecordCount50_59 = 0;
			RecordCount60_69 = 0;
			RecordCount70_79 = 0;
			RecordCount80_99 = 0;
		}

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
			FieldFixedLength(13),
			FieldAlign(AlignMode.Right, '0')
		]
		public short TotalLineItemsInfile { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0')
		]
		public short TotalPurchaseOrderRecords { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Right, '0')
		]
		public short TotalUnitsOrdered { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0')
		]
		public short RecordCount00_09 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0')
		]
		public short RecordCount10_19 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0')
		]
		public short RecordCount20_29 { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0')
		]
		public short RecordCount30_39 { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0')
		]
		public short RecordCount40_49 { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0')
		]
		public short RecordCount50_59 { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0')
		]
		public short RecordCount60_69 { get; set; }

		[
			FieldOrder(13),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0')
		]
		public short RecordCount70_79 { get; set; }

		[
			FieldOrder(14),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0')
		]
		public short RecordCount80_99 { get; set; }
	}
}