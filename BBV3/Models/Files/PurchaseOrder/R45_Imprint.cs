using FileHelpers;
using CommonLib.Extensions;

namespace FormatBBV3.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"45" 	
		02	003-007 	005 	Numeric 	Sequence Number 	 									Y 
		03	008-029 	022 	AlphaNum  	PO Number 												Y		Left justify, space fill.
		04	030 		001 	AlphaNum  	Imprint Code 											Y		"I" = Index item "P" = Imprint on item  "B" = Index and imprint item 	
		05	031-060 	030 	AlphaNum 	Imprint Text and Symbols 								Y		Left justified, space filled. Please note: Do NOT use carriage returns, line feeds, apostrophes, asterisks, quotation marks, or other special characters in this message field. See Additional Services for the valid codes for symbols. 	
		06	061 		001 	AlphaNum 	Imprint Font Code 										O		See Additional Services for valid codes. 	
		07	062 		001 	AlphaNum 	Imprint Color Code 										O		See Additional Services for valid codes. 	
		08	063 		001 	AlphaNum 	Imprint Position Code 									O		See Additional Services for valid codes. 	O 
		09	064 		001 	AlphaNum 	Imprint Append Code 									O		Use to designate that additional imprint text and symbols lines are to follow  "Y" – additional record 45 to follow (maximum of four additional permitted) 
		10	065-080 	016 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill. 	Y 
	*/
	[FixedLengthRecord(FixedMode.AllowMoreChars)]
	public class R45_Imprint // (up to 4 occurrences)
	{
		public R45_Imprint()
		{
			RecordCode = Enumerations.PurchaseOrders.Records.ImprintRecord.ToStringValue();
			Reserved065_080 = string.Empty;
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
			FieldFixedLength(1)
		]
		public char ImprintCode { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(30),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string ImprintTextandSymbols { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(1)
		]
		public char ImprintFontCode { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(1)
		]
		public char ImprintColorCode { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(1)
		]
		public char ImprintPositionCode { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(1)
		]
		public char ImprintAppendCode { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(16),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved065_080 { get; set; }
	}
}