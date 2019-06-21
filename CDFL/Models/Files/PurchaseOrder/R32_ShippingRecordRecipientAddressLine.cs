﻿using CommonLib.Extensions;
using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"32" 
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field 	
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Left justify, space fill
		04	030-064 	035 	AlphaNum 	Recipient Address Line									Y		Left justify, space fill
		05	065-080 	016 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill 
	*/

	[FixedLengthRecord]
	public class R32_ShippingRecordRecipientAddressLine
	{
		public R32_ShippingRecordRecipientAddressLine()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.RecipientShipToAddressLineRecord;
			Resrved065_080 = string.Empty;
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
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(35),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string RecipientAddressLine { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(16),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Resrved065_080 { get; set; }
	}
}
 