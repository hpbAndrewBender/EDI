using FileHelpers;
using System;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"41" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 02, this field 
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Order level PO number 
		04	030-033 	004 	AlphaNum 	Reserved 												Y		Blank 	
		05	034-039 	006 	Date 		Availability Date 										O		This is the date the title will be available for shipment.  Format YYMMDD 
		06	040 		001 	AlphaNum 	Reserved 												Y		Blank 	
		07	041-080 	040 	AlphaNum 	DC Inventory Information 								O		If the item is out of stock, this field provides inventory information for all DC's - up to seven five position concatenated fields. Format: X#### where "X" = DC code and "#" = OnHand Quantity.  Ignore if DC is blank or inactive. Example: N0000E0054M0000C0000K0000D0005 0000 	O 
	*/

	[FixedLengthRecord(FixedMode.AllowMoreChars)]
	public class R41_AdditionalDetail
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
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(4),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved030_033 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(6),
			//FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
		]
		public string AvailabilityDate { get; set; }
		//++ {
		//++ 	get
		//++ 	{
		//++ 		return AvailabilityDate;
		//++ 	}
		//++ 	set
		//++ 	{
		//++ 		AvailabilityDate = DateTime.TryParse(value.ToString(), out _) ? value : default(DateTime);
		//++ 	}
		//++ }

		[
			FieldOrder(6),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved040 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(40),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string DCInventoryInformation { get; set; }
	}
}