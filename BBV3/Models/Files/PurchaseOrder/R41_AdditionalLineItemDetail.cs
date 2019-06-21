using FileHelpers;
using System;
using CommonLib.Extensions;

namespace FormatBBV3.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"41" 
		02	003-007 	005 	Numeric 	Sequence Number 	 									Y 
		03	008-029 	022 	AlphaNum  	PO Number 												Y		Left justify, space fill. 	
		04	030-037 	008 	AlphaNum 	Reserved 												O		Reserved – left justify, space fill. 	
		05	038-043 	006 	Date	 	Backorder Cancellation Date - Line Level 				O		If populated, this value will override the order and account level backorder instructions.  (YYMMDD) 	
		06	044-046 	003 	AlphaNum 	Reserved 												O		Reserved – left justify, space fill. 	
		07	047-053 	007 	Numeric 	Order Quantity 	 										Y 
		08	054-073 	020 	AlphaNum 	Client Item Number 										O		Your assigned item number that will be passed back in confirmation files. 	
		09	074-080 	007 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill. 	
	*/

	[FixedLengthRecord(FixedMode.AllowMoreChars)]
	public class R41_AdditionalLineItemDetail
	{
		public R41_AdditionalLineItemDetail()
		{
			RecordCode = Enumerations.PurchaseOrders.Records.AdditionalLineItemDetailRecord.ToStringValue();
			Reserved030_037 = string.Empty;
			Reserved044_046 = string.Empty;
			Reserved074_080 = string.Empty;
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
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved030_037 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
			FieldNullValue(typeof(DateTime), "01/01/0001") // defaultdatetime
		]
		public DateTime BackorderCancellationDate_LineLevel { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved044_046 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0')
		]
		public short OrderQuantity { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string ClientItemNumber { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved074_080 { get; set; }
	}
}