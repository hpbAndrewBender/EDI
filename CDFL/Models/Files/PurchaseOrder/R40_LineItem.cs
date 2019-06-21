using CommonLib.Extensions;
using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"40" 
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field 	
		03	008-029 	022 	AlphaNum  	PO Number 												Y		Left justify, space fill 	
		04	030-039 	010 	AlphaNum  	Line Item PO Number  									y		An additional reference number for reconciliation of line item(s) per PO. This number will be sent in the POA and Shipment Confirmation email, and will print on the Packing Slip.  Left justify, space fill
		05	040-051 	012 	AlphaNum  	Reserved 												Y		Blank 	
		06	052-071 	020 	AlphaNum  	Item Number 											Y		EAN (ISBN-13), ISBN-10, or UPC for the item.  Left justify, space fill 	
		07	072-074 	003 	Numeric 	Reserved 												Y		Reserved – Enter zeroes to fill  	
		08	075 		001 	AlphaNum  	Line Level Backorder Code 								O		"N" = Do Not Backorder "B" = Backorder Not Yet Released (NYR) items only.  "Y" = Backorder all items that are not available to ship Blank=Default determined at set up 
		09	076-077 	002 	AlphaNum  	Special Action Code 									O		"ID" = item is to be imprinted and signifies that record 45 is present Blank = not applicable 	
		10	078 		001 	AlphaNum  	Reserved 												Y		Must be "N"
		11	079-080 	002 	AlphaNum 	Item Number Type 										O		Any value given is returned in POA, record 44.  Below are some examples "BN" = ISBN10 "EN"= EAN "UP" = UPC Blank = not applicable 	 
	*/

	[FixedLengthRecord]
	public class R40_LineItem
	{
		public R40_LineItem()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.LineItemRecord;
			Reserved040_051 = string.Empty;
			Reserved072_074 = string.Empty;
			Reserved078 = string.Empty;
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
			FieldFixedLength(10),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string LineItemPONumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(12),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved040_051 { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string ItemNumber { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved072_074 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char LineLevelBackorderCode { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(2),
		]
		public string SpecialActionCode { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved078 { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(2),
		]
		public string ItemNumberType { get; set; }
	}
}
 