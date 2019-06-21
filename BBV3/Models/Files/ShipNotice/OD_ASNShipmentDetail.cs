using FileHelpers;

namespace FormatBBV3.Models.Files.ShipNotice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Alpha	 	Detail Record Identifier   					"OD" 
		02	003-024 	022 	AlphaNum 	Line Item ID Number  	 
		03	025-037 	013 	AlphaNum 	ISBN-13/EAN  	 
		04	038-042 	005 	Numeric 	Quantity Predicted to Ship 					 
		05	043-047 	005 	Numeric 	Quantity Shipped  	 
		06	048-052 	005 	Numeric 	Reserved 									Reserved – right justified, zero filled 
		07	053-059 	007 	Numeric 	Ingram Item List Price  					Contains an implied decimal point with two positions to the right of the decimal point, e.g., $13.95 = "0001395". 
		08	060-066 	007 	Numeric 	Net/Discounted Price  						Contains an implied decimal point with 2 positions to the right of the decimal point, e.g., $9.49 = "0000949". 
		09	067-200 	134 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
 */
	[FixedLengthRecord]
	public class OD_ASNShipmentDetail
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string DetailRecordIdentifier { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string LineItemIDNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(13),
		]
		public string ISBN13OrEAN { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right,'0'),
		]
		public short QuantityPredictedtoShip { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
		]
		public short QuantityShipped { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved048_062 { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal IngramItemListPrice { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal NetOrDiscountedPrice { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(134),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved067_200 { get; set; }
	}
}