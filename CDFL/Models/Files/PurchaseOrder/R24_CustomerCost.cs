using CommonLib.Extensions;
using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"24" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field 	
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Left justify, space fill 
		04	030-037 	008 	Numeric 	Sales Tax Percent 										O		This field is used if you need to charge your consumer sales tax.  Right justify, zero fill.  Explicit (required) decimal, max 4 decimal places to the right of the decimal.  Example:  "006.7500".
		05	038-044 	007 	Numeric 	Freight Tax Percent 									O		Used when your state/country requires you to charge tax on shipping/freight charges. Right justify, zero fill.  Explicit (required) decimal, max 3 decimal places to the right of the decimal.  Example:  "006.750". 	
		06	045-052 	008 	Numeric 	Freight Amount 											O		00000.00, right justify, zero fill. Explicit (required) decimal, max 2 decimal places to the right of the decimal.   Example:  "00006.75". 
		07	053-080 	028 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill  
	*/ 	 	 	 	 	 

	[FixedLengthRecord]
	public class R24_CustomerCost
	{
		public R24_CustomerCost()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.CustomerCostRecord;
			Reserved053_080 = string.Empty;
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
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.ExplicitDec4)),
		]
		public decimal SalesTaxPercent { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.ExplicitDec3)),
		]
		public decimal FreightTaxPercent { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.ExplicitDec2)),
		]
		public decimal FreightAmount { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(28),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved053_080 { get; set; }
	}
}
 
 
 
 