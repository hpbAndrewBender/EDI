using CommonLib.Extensions;
using FileHelpers;
using System;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code												Y		"00" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		A sequence number for each record in the file. Start with 00001 and increment for all following records. 
		03	008-014 	007 	Numeric 	File Source SAN 										Y		Enter 0000000. 
		04	015-019 	005 	AlphaNum 	Reserved 												Y		Reserved – enter spaces to fill. 
		05	020-032 	013 	AlphaNum 	File Source Name 										Y		Enter Software/Vendor name.  Left justify, space fill. 
		06	033-038 	006 	Date 		Creation Date 											Y		YYMMDD – Date the file was created.
		07	039-060 	022 	AlphaNum 	Filename 												Y		Name of the file being sent including the file extension.  The file extension for the order is .fbo. The file extension you will receive for the confirmation (Purchase Order Acknowledgement) is .fbc
		08	061-063 	003 	AlphaNum 	Format Version 											Y		"F03" 	
		09	064-070 	007 	Numeric 	Ingram SAN 												Y		"1697978"  
		10	071-075 	005 	AlphaNum 	Reserved 												Y		Reserved – enter spaces to fill. 	
		11	076			001 	AlphaNum 	Vendor Name Flag 										Y		"I" = Ingram 	
		12	077-080 	004 	AlphaNum 	Product Description 									Y		"CDFL" for CDF-Lite. 	
	 */

	[FixedLengthRecord]
	public class R00_FileHeader
	{
		public R00_FileHeader()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.FileHeaderRecord;
			FormatVersion = Enumerations.PurchaseOrders.Format.Version3.ToStringValue();
			Reserved015_019 = string.Empty;
			Reserved071_075 = string.Empty;
		}

		[
			FieldOrder(1),
			FieldFixedLength(2),
			FieldConverter(ConverterKind.Byte),
			FieldAlign(AlignMode.Right, '0'),
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
			FieldFixedLength(7)
		]
		public string FileSourceSAN { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved015_019 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(13),
			FieldAlign(AlignMode.Left, ' ')
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
			FieldAlign(AlignMode.Left, ' ')
		]
		public string FileName { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(3)
		]
		public string FormatVersion { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(7)
		]
		public string IngramSAN { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved071_075 {get;set;}

		[
			FieldOrder(11),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char VendorNameFlag { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(4)
		]
		public string ProductDescription { get; set; }
	}
}