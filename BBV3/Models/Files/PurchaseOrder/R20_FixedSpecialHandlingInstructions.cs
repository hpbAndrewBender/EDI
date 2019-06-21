using FileHelpers;
using CommonLib.Extensions;

namespace FormatBBV3.Models.Files.PurchaseOrder
{
	/*
		Position 	Length 	Format 		Field Name 												Req'd	Description 
		----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		001-002 	002 	Numeric 	Record Code 											Y		"20" 	
		003-007 	005 	Numeric 	Sequence Number 	 									Y		
		008-029 	022 	AlphaNum 	PO Number 												Y		Left justify, space fill. 			 
		030	  		001 	Numeric 	Special Handling Prefix 								Y		5 	
		031-034 	004 	AlphaNum 	Special Handling Codes 									Y		This field supplies the special project or promo codes (XXXX) for order processing. If applicable, this code is usually supplied by an Ingram sales representative.
		035-080 	036 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill. 
	*/

	[FixedLengthRecord(FixedMode.AllowMoreChars)]
	public class R20_FixedSpecialHandlingInstructions
	{
		public R20_FixedSpecialHandlingInstructions()
		{
			RecordCode = Enumerations.PurchaseOrders.Records.FixedSpecialHandlingInstructionsRecord.ToStringValue();
			Reserved035_080 = string.Empty;
		}


		[
			FieldFixedLength(2)
		]
		public string RecordCode { get; set; }

		[
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short SequenceNumber { get; set; }

		[
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both)
		]
		public string PONumber { get; set; }

		[
			FieldFixedLength(1)
		]
		public char SpecialHandlingPrefix { get; set; }

		[
			FieldFixedLength(4)
		]
		public string SpecialHandlingCodes { get; set; }

		[
			FieldFixedLength(36),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved035_080 { get; set; }
	}
}