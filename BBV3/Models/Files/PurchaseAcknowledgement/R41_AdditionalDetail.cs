using FileHelpers;
using System;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 								"41" 
		02	003-007 	005 	Numeric 	Sequence Number 	 
		03	008-029 	022 	AlphaNum 	PO Number 	 
		04	030-032 	003 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
		05	033 		001 	AlphaNum 	DC Code, Secondary DC 						See DC codes for list of valid codes. 
		06	034-039 	006 	Date		Availability Date 							Unused at this time. 
		07	040 		001 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
		08	041-080 	040 	AlphaNum 	DC Inventory Information 					If the item is out of stock, this field provides inventory information for all DC's - up to seven, five position concatenated fields. Format: X#### where "X" = DC code and "#" = on hand quantity. Ignore if DC is blank or inactive, e.g., "N0000E0054M0000C0000K0000D0005 0000". 
	*/
	[
		FixedLengthRecord(FixedMode.AllowMoreChars)
	]
	public class R41_AdditionalDetail
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
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved030_032 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char DCCodeOrSecondaryDC { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(6),
			FieldTrim(TrimMode.Both, " "),
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
			FieldOrder(7),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved040_080 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(40),
			FieldTrim(TrimMode.Both, " "),
		]
		public string DCInventoryInformation { get; set; }
	}
}