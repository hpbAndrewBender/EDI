using CommonLib.Extensions;
using FileHelpers;
namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"45" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field 	
		03	008-029 	022 	AlphaNum  	PO Number 												Y		Left justify, space fill 
		04	030 		001 	AlphaNum  	Imprint / Index Code 									Y		"P" – imprint on item  "I" - index on item "B" - both imprint and index
		05	031-060 	030 	AlphaNum 	Imprint Text and Symbols 								O		See Appendix C for valid codes 
		06	061 		001 	AlphaNum 	Imprint Font Code 										O		See Appendix C 
		07	062 		001 	AlphaNum 	Imprint Color Code 										O		See Appendix C 
		08	063 		001 	AlphaNum 	Imprint Position Code 									O		See Appendix C 	O 
		09	064 		001 	AlphaNum 	Imprint Append Code 									O		Use to designate that additional Imprint Text and Symbols lines are to follow "Y" – additional Record 45 to follow (maximum of three (3) additional permitted)
		10	065-080 	016 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill 
	*/
	[FixedLengthRecord]
	public class R45_Imprint
	{
		public R45_Imprint()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.ImprintRecord;
			Reserved065_080 = string.Empty;
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
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char ImprintOrIndexCode { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(30),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string ImprintTextandSymbols { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char ImprintFontCode { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char ImprintColorCode { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char ImprintPositionCode { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char ImprintAppendCode { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(16),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved065_080 { get; set; }
	}
}