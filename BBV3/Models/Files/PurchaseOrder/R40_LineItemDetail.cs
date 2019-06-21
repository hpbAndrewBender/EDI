using FileHelpers;
using CommonLib.Extensions;

namespace FormatBBV3.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"40" 	
		02	003-007 	005 	Numeric 	Sequence Number 	 									Y 
		03	008-029 	022 	AlphaNum  	PO Number 												Y		Left justify, space fill. 	
		04	030-051 	022 	AlphaNum  	Line Item PO Number 									O		An additional reference number for your reconciliation of line item. This number will be sent in the POA, record type 40, position 30 – 39. 	
		05	052-071 	020 	AlphaNum  	Item Number 											Y		EAN (ISBN-13), ISBN-10, or UPC for the item. Left justify, space fill 	
		06	072-074 	003 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill. 	 
		07	075 		001 	AlphaNum  	Backorder Code - Line level 							O		If populated, this value will override the order and account level backorder instructions. "N" = No backorder.  "B" = Backorder only Not Yet Released (NYR) items. "Y" = Backorder all items that are not available to ship immediately.  "  " = Space (blank), use account profile settings. 	
		08	076-077 	002 	AlphaNum  	Special Action Code 									O		"ID" = item is to be imprinted and signifies that record type 45 is present  "  " = Space (blank), not applicable 	
		09	078			001 	AlphaNum  	DDC Fulfillment or "Split Line Ordering" – Line level 	Y		This overrides the order level. 		"Y" = Yes, split lines for best fill.  "N" = No, do not split lines.  "  " = Space (blank), use order level setting in record type 10. 	
		10	079-080 	002 	AlphaNum 	Item Number Type 										O		This code tells Ingram what item type to send in the confirmation files, e.g., if you send an ISBN but want EAN back. Code is returned in POA, record type 44.   "BN" = ISBN10  "EN" = EAN  "UP" = UPC  "  " = Space (blank), not applicable. Ingram will use "EN" as the default. 	
	*/

	[FixedLengthRecord(FixedMode.AllowMoreChars)]
	public class R40_LineItemDetail
	{
		public R40_LineItemDetail()
		{
			RecordCode = Enumerations.PurchaseOrders.Records.LineItemDetailRecord.ToStringValue();
			Reserved072_074 = string.Empty;
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
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both)
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string LineItemPONumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string ItemNumber { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved072_074 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char BackorderCode_Linelevel { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(2)
		]
		public string SpecialActionCode { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " ")
		]
		public char DDCFulfillmentorSplitLineOrdering_Linelevel { get; set; }
	
		[
			FieldOrder(10),
			FieldFixedLength(2)
		]
		public string ItemNumberType { get; set; }
	}
}