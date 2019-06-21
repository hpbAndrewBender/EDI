using FileHelpers;
using System;

namespace FormatBBV3.Models.Files.ShipNotice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Alpha 		Pack Record Identifier   					"OP" 
		02	003-004 	002 	Alpha 		Shipping DC Code 							DC where the order has been shipped. Please see DC codes for list of valid codes. 
		03	005-024 	020 	AlphaNum 	SSL 										Secondary Tracking number supplied when a tracking number is not available, e.g., "00000388083885099678." 
		04	025-049 	025 	AlphaNum 	Tracking Number 							This field contains tracking or delivery confirmation codes for applicable shipping methods. If one is not assigned, we will supply the Ingram SSL in this field. 
		05	050-054 	005 	 			SCAC 										Standard Carrier Address Code assigned to each carrier. 
		06	055-059 	005 	AlphaNum 	Carrier Actual Number 						Number assigned to the carrier. 
		07	060-068 	009 	Numeric 	Weight 										Actual weight in pounds, field contains an implied decimal point with four positions to the right of the decimal point,  e.g., 2.39 pounds = "000000239". 
		08	069-074 	006 	Numeric 	Number of Units in Box 	 
		09	075-082 	008 	Date	 	Shipment Date 								Date that this order shipped, format is YYYYMMDD. 
		10	083-200 	118 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
 */
	[FixedLengthRecord]
	public class OP_ASNPack
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string PackRecordIdentifier { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(2),
		]
		public string ShippingDCCode { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(20),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string SSL { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(25),
			FieldAlign(AlignMode.Left,' '),
			FieldTrim(TrimMode.Both)

		]
		public string TrackingNumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(5),
		]
		public string SCAC { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(5),
		]
		public string CarrierActualNumber { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(9),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Decimals.NoDec2))
		]
		public decimal Weight { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Right, '0'),
		]
		public short NumberofUnitsinBox { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYYYMMDD)),
		]
		public DateTime ShipmentDate { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(118),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved083_200 { get; set; }
	}
}