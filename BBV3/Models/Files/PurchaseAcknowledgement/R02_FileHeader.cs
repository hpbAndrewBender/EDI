using FileHelpers;
using System;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Numeric		Record Code 								"02" 
		02	003-007 	005 	Numeric		Sequence Number								A sequence number for each record in the file.Starts with "00001" and increments for each record.   
		03	008-014 	007 	AlphaNum	File Source SAN 							"1697978" 
		04	015-019 	005 	AlphaNum	Reserved									Reserved – left justified, space filled. 
		05	020-032 	013 	AlphaNum	File Source Name 							"Ingram" = File was created by Ingram "Spring Arbor" = File was created by Spring Arbor  "  " = Space (blank), none assigned 
		06	033-038 	006 	Date 		POA Creation Date								Format YYMMDD 
		07	039-043 	005 	AlphaNum	Electronic Control Unit						The electronic control unit (ECU) is assigned to an order by Ingram. You may be asked for this number if you contact customer care about your order.
		08	044-060 	017 	AlphaNum	Filename									The first 17 characters of the PO filename from the original PO file. 
		09	061-063 	003 	AlphaNum	Format Version								"F03" = Version 3 
		10	064-070 	007 	AlphaNum	Destination									SAN Standard Address Number (SAN) or the bill to account number
		11	071-075 	005 	AlphaNum	Reserved									Reserved – left justified, space filled. 
		12	076 		001 	AlphaNum	POA Type Code								Please see POA type table for more information. Same as POA type code in the PO file, record type 21. 
		13	077-080		004 	AlphaNum	Reserved									Reserved – left justified, space filled. 
	*/

	[
		FixedLengthRecord,
		IgnoreEmptyLines
	]
	public class R02_FileHeader
	{
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
			FieldTrim(TrimMode.Both, " "),
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
			FieldTrim(TrimMode.Both, " "),
		]
		public string FileSourceName { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
			//FieldNullValue(typeof(DateTime), "01/01/0001"),
		]
		public DateTime POACreationDate { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(5),
			FieldTrim(TrimMode.Both, " "),
		]
		public string ElectronicControlUnit { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(17),
			FieldTrim(TrimMode.Both, " "),
		]
		public string Filename { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(3),
			FieldTrim(TrimMode.Both, " "),
		]
		public string FormatVersion { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(7),
			FieldTrim(TrimMode.Both, " "),
		]
		public string DestinationSAN { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved071_075 { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," " )
			
		]
		public char POATypeCode { get; set; }

		[
			FieldOrder(13),
			FieldFixedLength(4),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved077_080 { get; set; }
	}
}
 
 
 
 