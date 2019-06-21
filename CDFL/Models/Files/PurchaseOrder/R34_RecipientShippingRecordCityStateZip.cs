using CommonLib.Extensions;
using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"34"
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field 	
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Left justify, space fill 	
		04	030-054 	025 	AlphaNum 	Recipient City 											Y		Recipients' City.  Left justify, space fill 	
		05	055-057 	003 	AlphaNum 	Recipient State/Province 								Y		Recipients' state code or province. US state and Canadian province codes are validated. See Appendix D for valid codes, although ISO 3166-2 alpha 3 will have the most upto-date codes 
		06	058-068 	011 	AlphaNum 	Recipient Postal Code 									Y		U.S. zip codes are required to be numeric. For International Shipments, free-format entry is allowed.  Left justify, space fill 	
		07	069-071 	003 	AlphaNum 	Country 												Y		See Appendix D for valid codes.  Left justify, space fill 	
		08	072-080 	009 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill  	
	*/
	[FixedLengthRecord]
	public class R34_RecipientShippingRecordCityStateZip
	{
		public R34_RecipientShippingRecordCityStateZip()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.RecipientShipToCityStateZipRecord;
			Reserved072_080 = string.Empty;
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
		public string RecipientCity { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string RecipientStateOrProvince { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(11),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string RecipientPostalCode { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(3),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Country { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(9),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved072_080 { get; set; }
	}
}
 