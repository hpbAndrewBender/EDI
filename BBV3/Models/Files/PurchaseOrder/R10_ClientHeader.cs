using FileHelpers;
using System;
using CommonLib.Extensions;

namespace FormatBBV3.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"10" 	
		02	003-007 	005 	Numeric 	Sequence Number 	 									Y 
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Order level PO number. Left justify, space fill. 	
		04	030-036 	007 	AlphaNum 	Ingram Bill To Account Number 							Y		This field should contain the bill to account number from your Ingram electronic order (EO) profile. Please contact the Ingram integration team if you are not sure what to put in this field. 	
		05	037-043 	007 	Numeric 	Vendor SAN 												Y		"1697978"  
		06	044-049 	006 	Date	 	Order Date 												Y		This field should contain that the PO file was created. YYMMDD 	
		07	050-055 	006 	Date	 	Backorder Cancellation Date 							O		Order level backorder cancellation date. If backorder code is populated and this field is blank, we will use the default on the account profile. 	
		08	056 		001 	AlphaNum 	Backorder Code 											Y		"N" = No backorder. "B" = Backorder only not yet released (NYR) items. "Y" = Backorder all items that are not available to ship immediately. "  " = Space (blank), use account profile settings.
		09	057 		001 	AlphaNum 	DDC Fulfillment or "Split Line Ordering" - Order level	Y	 	"Y" = Yes, split order for the best fill. "N" = No, do not split order. "  " = Space (blank), use account profile settings. 
		10	058-066 	010 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill. 
		11	067			001 	AlphaNum 	Recipient / Ship to Address Indicator							“N" . (For Consumer Direct Fullfillment please see “DTH_Implementation guide”) 	 
		12	068			001 	AlphaNum 	Purchasing Consumer / Ordered By Address Indicator 				“N" . (For Consumer Direct Fullfillment please see “DTH_Implementation guide”) 	 
		13	069-074 	006 	Date	 	Do Not Ship before date 								O		Start ship date, Ingram will hold the order and start shipping on date specified. This is not available for the "EF" or "RF", please see order types for more information. 	
		14	075-080 	006 	AlphaNum 	Reserved 												Y		Reserved – left justify, space fill. 	 
	*/
	[FixedLengthRecord(FixedMode.AllowVariableLength)]
	public class R10_ClientHeader
	{
		public R10_ClientHeader()
		{
			RecordCode = Enumerations.PurchaseOrders.Records.ClientHeaderRecord.ToStringValue();
			Reserved058_066 = string.Empty;
			Reserved075_080 = string.Empty;
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
			FieldFixedLength(7),
			FieldTrim(TrimMode.Both)
		]
		public string IngramBillToAccountNumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(7),
			FieldTrim(TrimMode.Both),
		]
		public string VendorSAN { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD))
		]
		public DateTime OrderDate { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
			FieldNullValue(typeof(DateTime), "01/01/0001") // Default DateTime
		]
		public DateTime BackorderCancellationDate { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(1)
		]
		public string BackorderCode { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char DDCFulfillmentorSplitLineOrdering_Orderlevel { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(9), // was 10
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved058_066 { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")

		]
		public char RecipientOrShiptoAddressIndicator { get; set; }
	

		[
			FieldOrder(12),
			FieldFixedLength(1),
			FieldNullValue(typeof(char)," ")
		]
		public char PurchasingConsumerOrOrderedByAddressIndicator { get; set; }

		[
			FieldOrder(13),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
			FieldNullValue(typeof(DateTime), "01/01/0001") // default datetime
		]
		public DateTime DoNotShipBeforeDate { get; set; }

		[
			FieldOrder(14),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Left, ' '),
			
		]
		public string Reserved075_080 { get; set; }
	}
}