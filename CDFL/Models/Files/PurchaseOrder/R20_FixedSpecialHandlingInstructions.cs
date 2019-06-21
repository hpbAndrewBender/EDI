﻿using CommonLib.Extensions;
using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
	 	#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"20" 
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field.
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Left justify, space fill. 
		04	030-059 	030 	AlphaNum 	Special Handling Codes 									Y		This field supplies the Special Project or Promo Codes (5XXXX) for Order Processing. 
		05	060-080 	021 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill. 
	 */
	[FixedLengthRecord]
	public class R20_FixedSpecialHandlingInstructions
	{
		public R20_FixedSpecialHandlingInstructions()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.FixedSpecialHandlingInstructionsRecord;
			Reserved060_080 = string.Empty;
		}

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
			FieldConverter(ConverterKind.Int32),
		]
		public int SequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(30),
		]
		public string SpecialHandlingCodes { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(21),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved060_080 { get; set; }

	}
}