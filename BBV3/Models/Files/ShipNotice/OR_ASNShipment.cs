using FileHelpers;

namespace FormatBBV3.Models.Files.ShipNotice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Alpha	 	Shipment Record Identifier  				"OR" 
		02	003-024 	022 	AlphaNum 	PO Number 									Order level PO number. 
		03	025-046 	022 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
		04	047-051 	005 	AlphaNum 	Ingram Order Entry Number 					Order number assigned by Ingram as an internal tracking number.  
		05	052-200 	149 	AlphaNum  	Reserved 									Reserved – left justified, space filled. 
	 */
	[FixedLengthRecord]
	public class OR_ASNShipment
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string ShipmentRecordIdentifier { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved026_046 { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
		]
		public string IngramOrderEntryNumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(149),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved052_200 { get; set; }
	}
}