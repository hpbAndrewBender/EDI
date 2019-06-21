using FileHelpers;
using System;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"02" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		A sequence number for each record in the file. Starts with "00001" and increments for each record.  
		03	008-014 	007 	AlphaNum 	File Source SAN 										Y		"1697978" 	
		04	015-019 	005 	AlphaNum 	Reserved 												Y		Blank 	
		05	020-032 	013 	AlphaNum 	File Source Name 										Y		"I"= ICG 	
		06	033-038 	006 	Date 		POA Creation Date 										Y		Format YYMMDD 	
		07	039-043 	005 	AlphaNum 	Electronic Control Unit 								Y		The electronic control unit (ECU) is a read-only value assigned to an order by Ingram. You may be asked for this number if you contact Customer Care about your order 	
		08	044-060 	017 	AlphaNum 	Filename 												Y		Name of the file being sent to you including the file extension .fbc 	
		09	061-063 	003 	AlphaNum 	Format Version 											Y		"F03" 
		10	064-070 	007 	AlphaNum 	Destination SAN 										Y		Standard Address Number (SAN) or the Bill To Account Number 
		11	071-075 	005 	AlphaNum 	Reserved 												Y		Blank 	Y 
		12	076			001 	AlphaNum 	POA Type 												Y		Please see PO File Overview for more information.  Same as confirmation type in PO record 21  
		13	077-080 	004 	AlphaNum 	Reserved 												Y		Blank 	Y 
	*/

	[FixedLengthRecord]
	public class R02_FileHeader
	{
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
			FieldConverter(ConverterKind.Int16),
		]
		public short SequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(7),
		]
		public string FileSourceSAN { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
		]
		public string Reserved015_019 { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(13),
		]
		public string FileSourceName { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
		]
		public DateTime POACreationDate { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(5),
		]
		public string ElectronicControlUnit { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(17),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Filename { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(3),
		]
		public string FormatVersion { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(7),
		]
		public string DestinationSAN { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved071_075 { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(1),
		]
		public char POAType { get; set; }

		[
			FieldOrder(13),
			FieldFixedLength(4),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved077_080 { get; set; }
	}
}
 