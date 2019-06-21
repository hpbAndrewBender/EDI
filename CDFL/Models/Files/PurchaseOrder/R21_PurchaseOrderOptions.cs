using CommonLib.Extensions;
using FileHelpers;

namespace FormatCDFL.Models.Files.PurchaseOrder
{
	/*
	 	#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Numeric 	Record Code												Y		"21"
		02	003-007 	005 	Numeric 	Sequence Number 										Y		See record type 00, this field. 
		03	008-029 	022 	AlphaNum 	PO Number 												Y		Left justify, space fill. 	
		04	030-036 	007 	AlphaNum 	Ingram Ship To Account Number 							Y		Ship To Account Number from EO profile. Please contact EO if you are not sure what to put in this field. 	
		05	037		 	001 	AlphaNum 	PO Type 												Y		Please see Appendix D for valid codes. 	
		06	038-039 	002 	AlphaNum 	Order Type 												Y		The available order types are EL, RF, and LS.  See Order Type Definitions for more information.   	
		07	040		 	001 	AlphaNum 	DC Code 												O		See Appendix D for a list of distribution center codes.  You may indicate a specific warehouse from which to ship the order or leave the field blank to use the warehouse shopping logic you requested when you were set up on the program.  
		08	041		 	001 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill. 	
		09	042		 	001 	AlphaNum 	Greenlight 												Y		"Y" or "N". Greenlight titles are usually low demand titles with a short-discount (less than 35%). 	
		10	043		  	001 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill. 	
		11	044		 	001 	AlphaNum 	POA Type 												Y		Please see Appendix D for a table of POA types.  This field allows you to define the amount of detail that will be returned to you in the order acknowledgement. 	
		12	045-052 	008 	AlphaNum 	Ship To Password 										Y		Password from EO profile. Please contact EO if you are not sure what to put in this field.  Left justify, blank fill. 	
		13	053-077 	025 	AlphaNum 	Carrier/Shipping Method 								Y		Please see Appendix B for valid codes. 	
		14	078 		001 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill 
		15	079 		001 	AlphaNum 	Split Order Across DCs Allowed 							Y		"Y"=Yes  "N"=No  Space (blank)=Use my default 
		16	080 		001 	AlphaNum 	Reserved 												Y		Reserved - Enter spaces to fill  
	*/

	[FixedLengthRecord]
	public class R21_PurchaseOrderOptions
	{
		public R21_PurchaseOrderOptions()
		{
			RecordCode = (byte)Enumerations.PurchaseOrders.Records.PurchaseOrderOptionsRecord;
			Reserved041 = string.Empty;
			Reserved043 = string.Empty;
			Reserved078 = string.Empty;
			Reserved080 = string.Empty;
		}

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
		]
		public string IngramShipToAccountNumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char POType { get; set; }

		[
			FieldOrder(6),
			FieldFixedLength(2),
		]
		public string OrderType { get; set; }

		[
			FieldOrder(7),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char DCCode { get; set; }

		[
			FieldOrder(8),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved041 { get; set; }

		[
			FieldOrder(9),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char Greenlight { get; set; }

		[
			FieldFixedLength(1),
			FieldOrder(10),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved043 { get; set; }

		[
			FieldOrder(11),
			FieldFixedLength(1),
			FieldNullValue(typeof(char), " "),
		]
		public char POAType { get; set; }

		[
			FieldOrder(12),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string ShipToPassword { get; set; }

		[
			FieldOrder(13),
			FieldFixedLength(25),
		]
		public string CarrierOrShippingMethod { get; set; }

		[
			FieldOrder(14),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left	, ' '),
		]
		public string Reserved078 { get; set; }

		[
			FieldOrder(15),
			FieldFixedLength(1),
			FieldConverter(typeof(CommonLib.Converters.Bools.YN)),
		]
		public bool SplitOrderAcrossDCsAllowed { get; set; }

		[
			FieldOrder(16),
			FieldFixedLength(1),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Reserved080 { get; set; }
	}
}
 