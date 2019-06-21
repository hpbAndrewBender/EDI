using FileHelpers;
using System;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 								"43" 
		02	003-007 	005 	Numeric 	Sequence Number 	 
		03	008-029 	022 	AlphaNum 	PO Number 	 
		04	030-049 	020 	AlphaNum 	Publisher Alpha Code 						Please see the publisher alpha code translation file for a list of valid codes. 
		05	050-053 	004 	Date	 	Publication/Release Date 					MMYY 
		06	054-058 	005 	AlphaNum 	Original Sequence Number 					This line item's original sequence number from the PO file, record type 40. 
		07	059-062 	004 	AlphaNum 	Reserved 									Reserved  
		08	063-069 	007 	AlphaNum 	Total Quantity Predicted to Ship Primary 	Total quantity predicted to ship from primary warehouse 
		09	070-076 	007 	AlphaNum 	Total Quantity Predicted to Ship Secondary 	Total quantity predicted to ship from the secondary warehouse 
		10	077-080 	004 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
	*/
	[FixedLengthRecord]
	public class R43_AdditionalLineItem
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
			FieldTrim(TrimMode.Both, " "),
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
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(20),
			FieldTrim(TrimMode.Both, " "),
		]
		public string PublisherAlphaCode { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(4),
			FieldTrim(TrimMode.Both, " "),
		]
		public string PublicationOrReleaseDate { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
		]
		public short OriginalSequenceNumber { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(4),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved059_062 { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(7),
			FieldTrim(TrimMode.Both, " "),
		]
		public string TotalQuantityPredictedtoShipPrimary { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(7),
			FieldTrim(TrimMode.Both, " "),
		]
		public string TotalQuantityPredictedtoShipSecondary { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(4),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved077_080 { get; set; }
	}
}