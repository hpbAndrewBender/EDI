using FileHelpers;

namespace FormatCDFL.Models.Files.ShipNotice
{
	/*
			#	Position 	Length 	Format 		Field Name 												Req'd	Description 
			--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
			01	001-002 	002 	Alpha	 	Order Record Identifier   								Y		Must contain "OD" 	Y 
			02	003-024 	022 	AlphaNum 	Client Order ID  										Y		Unique ID number (e.g. PO Number)	Y 
			03	025-026 	002 	Alpha	 	Shipping Warehouse Code  								Y 
			04	027-036 	010 	AlphaNum 	Ingram Order Entry Number  								Y		 Order Entry number assigned by Ingram (internal  tracking number) per DC
			05	037-041 	005 	Numeric 	Quantity Cancelled 	 									Y     
			06	042-051 	010 	AlphaNum 	ISBN-10 Ordered 	 									Y 			
			07	052-061 	010 	AlphaNum 	ISBN-10 Shipped  	 									Y 
			08	062-066 	005 	Numeric 	Quantity Predicted 	 									Y 
			09	067-071 	005 	Numeric 	Quantity Slashed 	 									Y 
			10	072-076 	005 	Numeric 	Quantity Shipped  	 									Y 
			11	077-078 	002 	AlphaNum 	Item Detail Status Code  								Y		Please see ASN Order and Item Status Codes in Appendix D. 	
			12	079-103 	025 	AlphaNum 	Tracking Number  	  									Y 
			13	104-108 	005 	 			SCAC 													Y		Standard Carrier Address code	
			14	109-123 	015 	AlphaNum 	Reserved 												Y		Blank 
			15	124-130 	007 	Numeric 	Ingram Item List Price  								Y		Contains an implied decimal point with 2 positions to the right of the decimal point. 	 Example: "0001395"	Y 
			16	131-137 	007 	Numeric 	Net/Discounted Price  									Y		Contains an implied decimal point with 2 positions to the right of the decimal point. 	 Example: "0000949"	Y 
			17	138-147 	010 	AlphaNum 	Line Item ID Number  	 								Y 
			18	148-167 	020 	AlphaNum 	SSL 													Y		Secondary Tracking number supplied when a  tracking number is not available	Y 
			19	168-176 	009 	Numeric 	Weight  												Y		Unit of measure is pounds. Contains an implied decimal point with 2 positions to the right of the 	 decimal point.  Example: 2.39 pounds "000000239"	Y 
			20	177-178 	002 	AlphaNum 	Shipping Method Code or Slash/Cancel Reason Code 	 	Y 
			21	179-193 	015 	AlphaNum 	ISBN-13/EAN  	 										Y		
			22	194-200 	007 	AlphaNum 	Reserved 												Y		Blank 	
	*/

	[FixedLengthRecord]
	public class OD_OrderDetailRecord
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string OrderRecordIdentifier { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string ClientOrderID { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(2),
		]
		public string ShippingWarehouseCode { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Left,' '),
		]
		public string IngramOrderEntryNumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(5),
			FieldConverter(typeof(CommonLib.Converters.Integers.Int16String)),
			FieldAlign(AlignMode.Right, ' '),
		]
		public string QuantityCancelled { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string ISBN10Ordered { get; set; }
		
		[
			FieldOrder(7),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string ISBN10Shipped { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(5),
			FieldConverter(typeof(CommonLib.Converters.Integers.Int16s)),
			FieldAlign(AlignMode.Right, '0'),		
		]
		public short QuantityPredicted { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, ' '),
			FieldConverter(typeof(CommonLib.Converters.Integers.Int16String)),
		]
		public string QuantitySlashed { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short QuantityShipped { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(2),
		]
		public string ItemDetailStatusCode { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(25),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string TrackingNumber { get; set; }

		[
			FieldOrder(13),
			FieldFixedLength(5),
		]
		public string SCAC { get; set; }

		[
			FieldOrder(14),
			FieldFixedLength(15),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved109_123 { get; set; }

		[
			FieldOrder(15),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal IngramItemListPrice { get; set; }

		[
			FieldOrder(16),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal NetOrDiscountedPrice { get; set; }

		[
			FieldOrder(17),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string LineItemIDNumber { get; set; }

		[
			FieldOrder(18),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string SSL { get; set; }

		[
			FieldOrder(19),
			FieldFixedLength(9),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2)),
		]
		public decimal Weight { get; set; }

		[
			FieldOrder(20),
			FieldFixedLength(2),
		]
		public string ShippingMethodCodeorSlashOrCancelReasonCode { get; set; }

		[
			FieldOrder(21),
			FieldFixedLength(15),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string ISBN13OrEANv { get; set; }

		[
			FieldOrder(22),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved194_200 { get; set; }
	}
}
 