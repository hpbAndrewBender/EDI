using FileHelpers;
using System;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"43" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 02, this field 	
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Order level PO number 	
		04	030-049 	020 	AlphaNum 	Publisher Name 	 										O 
		05	050-053 	004 	Date 		Publication/Release Date 								O		MMYY 	
		06	054-058 	005 	AlphaNum 	Original Seq. Number 									Y		This line item's original Sequence Number from the PO file, Record 40 	
		07	059-062 	004 	AlphaNum 	Reserved 												Y		Blank 	
		08	063-069 	007 	AlphaNum 	Total Qty Predicted to Ship Primary 					Y		Total quantity predicted to ship from primary warehouse. 
		09	070-080 	011 	AlphaNum 	Reserved 												Y		Blank 
	*/

	[FixedLengthRecord]
	public class R43_AdditionalLineItem
	{
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
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string PublisherName { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(4),
		]
		public string PublicationOrReleaseDate { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string OriginalSeqNumber { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(4),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved059_062 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(7),
		]
		public string TotalQtyPredictedtoShipPrimary { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(11),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved070_080 { get; set; }
	}
}