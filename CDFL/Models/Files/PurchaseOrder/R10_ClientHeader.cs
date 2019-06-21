using CommonLib.Extensions;
using FileHelpers;
using System;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code 											Y		"10" 	
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field. 
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Left justify, space fill. 
		04	030-036 	007 	AlphaNum 	Ingram Bill To Account Number 							Y		Bill To Account Number from the Ingram Electronic Ordering (EO) profile. Please contact EO if you are not sure what to put in this field. 	
		05	037-043 	007 	Numeric 	Vendor SAN 												Y		"1697978" 	
		06	044-049 	006 	Date 		Order Date 												Y		YYMMDD 	
		07	050-055 	006 	Date 		Backorder Cancel Date 									Y		Order Level Backorder Cancellation Date.  YYMMDD. 	
		08	056		 	001 	AlphaNum 	Backorder Code 											Y		"N" = Do Not Backorder. "B" = Backorder only Not Yet Released (NYR) items.   "Y" = Backorder all items that are not available to ship.  Blank = Default. 
		09	057	 		001 	AlphaNum 	DDC Fulfillment or "Split Line Ordering" 				Y		Must be "N"  
		10	058-064 	007 	AlphaNum 	Reserved 												Y		Reserved – enter spaces to fill. 	Y 
		11	065-066 	002 	AlphaNum 	Reserved 												Y		Reserved – enter spaces to fill. 	Y 
		12	067		 	001 	AlphaNum 	Ship To Indicator 										Y		Must be "Y" -  Indicates presence of  records 30 through 38. 	Y 
		13	068		 	001 	AlphaNum 	Bill To Indicator 										Y		Must be "Y"  	Y 
		14	069-074 	006 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill. 	Y 
		15	075		 	001 	AlphaNum 	Reserved 												Y		Must be "N"   	Y 
		16	076-080 	005 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill. 	Y 

	*/
	[FixedLengthRecord]
	public class R10_ClientHeader
	{
		public R10_ClientHeader()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.ClientHeaderRecord;
			Reserved058_064 = string.Empty;
			Reserved065_066 = string.Empty;
			Reserved069_074 = string.Empty;
			Reserved075 = string.Empty;
			Reserved076_080 = string.Empty;
		}

		[
			FieldOrder(1),
			FieldFixedLength(2),
			FieldConverter(ConverterKind.Int16),
		]
		public byte RecordCode { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int32),
		]
		public int SequenceNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(22),
			FieldAlign(AlignMode.Left, ' '),
			FieldTrim(TrimMode.Both, " "),
		]
		public string PONumber { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string IngramBillToAccountNumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(7),
		]
		public string VendorSAN { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
		]
		public DateTime OrderDate { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(6),
			FieldConverter(typeof(CommonLib.Converters.Dates.YYMMDD)),
			FieldNullValue(typeof(DateTime), "01/01/0001")
		]
		public DateTime BackorderCancelDate { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(1),
			FieldNullValue(typeof(char),  " "),
		]
		public char BackorderCode { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char DDCFulfillmentOrSplitLineOrdering { get; set; }

		[
			FieldOrder(10),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved058_064 { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(2),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved065_066 { get; set; }
		
		[
			FieldOrder(12),
			FieldFixedLength(1),
			FieldConverter(typeof(CommonLib.Converters.Bools.YN)),
		]
		public bool ShipToIndicator { get; set; }

		[
			FieldOrder(13),
			FieldFixedLength(1),
			FieldConverter(typeof(CommonLib.Converters.Bools.YN)),
		]
		public bool BillToIndicator { get; set; }

		[
			FieldOrder(14),
			FieldFixedLength(6),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved069_074 { get; set; }

		[
			FieldOrder(15),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved075 { get; set; }

		[
			FieldOrder(16),
			FieldFixedLength(5),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved076_080 { get; set; }

	}
}
 