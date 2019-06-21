using CommonLib.Extensions;
using FileHelpers;
	
namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"31" 
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field 	
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Left justify, space fill 	
		04	030-054 	025 	AlphaNum 	Recipient Phone # 										Y		NOTE: The Carrier/Shipping method may require a phone number for delivery.  Left justify, space fill 
		05	055-080 	026 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill  	
	*/
	[FixedLengthRecord]
	public class R31_RecipientShipToPhone
	{
		public R31_RecipientShipToPhone()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.RecipientShipToPhoneNumberRecord;
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
			FieldFixedLength(25),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string RecipientPhone { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(26),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved055_080 { get; set; }
	}
}
 