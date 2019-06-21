using FileHelpers;
using CommonLib.Extensions;

namespace FormatBBV3.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"21" 	
		02	003-007 	005 	Numeric 	Sequence Number 	 									Y 
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Left justify, space fill. 	 
		04	030-036 	007 	AlphaNum 	Ingram Ship To Account Number 							Y		This field should contain the ship to account number from your Ingram EO profile. Please contact the Ingram integration team if you are not sure what to put in this field
		05	037 		001 	AlphaNum 	PO Type 												Y		Please see the PO types for more information. 
		06	038-039 	002 	AlphaNum 	Order Type Code 										Y		Please see the order type codes for more information. 	
		07	040 		001 	AlphaNum 	DC Code 												O		You may use the DC's that are assigned on the account profile or specify the DC.  "  " = Space (blank), use account profile settings. Please see DC codes for valid codes. 	
		08	041 		001 	AlphaNum 	Backorder Hold & Release Indicator 						Y		"H" = Hold all backorders until another order is placed. "R" = Release upon receipt of backordered item. "  " = Space (blank), use account profile settings. 	
		09	042 		001 	AlphaNum 	Extended POA Status Codes 								Y		"Y" = Yes, this ensure that Ingram will use all of the POA status codes available for this ordering method. 	
		10	043  		001 	AlphaNum 	DC Pairs 												Y		Please see the DC pairs section for more information about this field.  "Y" = Yes, shop DC pairs. "N" = No, do not shop DC pairs. "  " = Space (blank), use account profile settings. 	
		11	044 		001 	AlphaNum 	POA Type Code 											Y		Please see POA type table for valid options. This field controls the amount of detail that is sent in the POA. Please use option "1" while testing to assist with troubleshooting. 	 
		12	045-052 	008 	AlphaNum 	Ingram Ship To Account Password 						Y		This field should contain the ship to password your Ingram EO profile. Please contact the Ingram integration team if you are not sure what to put in this field. 	
		13	053-077 	025 	AlphaNum 	Carrier/Shipping Method 								O		If you leave this field blank, we will use the shipping method that is set up in your account profile. Please see Shipping Options for valid codes. 	
		14	078 		001 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill. 	
		15	079 		001 	AlphaNum 	Split Line Indicator - Order Level 						Y		"Y" = Yes "N" = No "  " = Space (blank), use account profile settings. 	
		16	080 		001 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill. 	Y 
	*/
	[FixedLengthRecord(FixedMode.AllowMoreChars)]
	public class R21_PurchaseOrderOptions
	{
		public R21_PurchaseOrderOptions()
		{
			RecordCode = Enumerations.PurchaseOrders.Records.PurchaseOrderOptionsRecord.ToStringValue();
			Reserved078 = string.Empty;
			Reserved080 = string.Empty;
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
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both)
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(7)
		]
		public string IngramShipToAccountNumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(1)
		]
		public string POType { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(2)
		]
		public string OrderTypeCode { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " ")
		]
		public char DCCode { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char BackorderHoldAndReleaseIndicator { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char ExtendedPOAStatusCodes { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char DCPairs { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char POATypeCode { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(8)
		]
		public string IngramShipToAccountPassword { get; set; }

		[
			FieldOrder(13),
			FieldFixedLength(25)
		]
		public string CarrierOrShippingMethod { get; set; }

		[
			FieldOrder(14),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved078 { get; set; }

		[
			FieldOrder(15),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char SplitLineIndicator_OrderLevel { get; set; }
		
		[
			FieldOrder(16),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved080 { get; set; }
	}
}