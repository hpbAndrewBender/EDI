using FileHelpers;
using System;
using CommonLib.Extensions;

namespace FormatBBV3.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"00"
		02	003-007 	005 	Numeric 	Sequence Number 										Y		A sequence number for each record in the file. Start with "00001" and increment the number for all following records. 	
		03	008-014 	007 	Numeric 	File Source SAN 										Y		"0000000" 	
		04	015-019 	005 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill.
		05	020-032 	013 	AlphaNum 	File Source Name 										Y		This field should contain the name of your company name. Left justify, space fill. 
		06	033-038 	006 	Date	 	Creation Date 											Y		The date the file was created, YYMMDD. 
		07	039-060 	022 	AlphaNum 	Filename 												Y		Name of the file being sent including the file extension. Left justify, space fill. 
		08	061-063 	003 	AlphaNum 	Format Version 											Y		"F03" 
		09	064-070 	007 	Numeric 	Ingram SAN 												Y		"1697978"  
		10	071–075 	005 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill. 
		11	076 		001 	AlphaNum 	Vendor Name Flag 										Y		"I" = Ingram. "P" = IPS (requires a unique ship to password). 
		12	077-080 	004 	AlphaNum 	Product Description 									Y		"BULK" = Ingram bulk order fulfillment. 
	*/

	[FixedLengthRecord]
	public class R00_ClientFileHeader
	{

		public R00_ClientFileHeader()
		{
			RecordCode = Enumerations.PurchaseOrders.Records.FileHeaderRecord.ToStringValue();
			FormatVersion = Enumerations.PurchaseOrders.Format.Version3.ToStringValue();
			Reserved015_019 = string.Empty;
			Reserved071_075 = string.Empty;
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
			FieldFixedLength(7),
			FieldTrim(TrimMode.Both)
		]
		public string FileSourceSAN { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, ' ')
		]
		public string Reserved015_019 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(13),
			FieldTrim(TrimMode.Both)
		]
		public string FileSourceName { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD))
		]
		public DateTime CreationDate { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both)
		]
		public string Filename { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(3)
		]
		public string FormatVersion { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(7),
			FieldTrim(TrimMode.Both)
		]
		public string IngramSAN { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved071_075 { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(1)
		]
		public char VendorNameFlag { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(4)
		]
		public string ProductDescription { get; set; }
	}
}