using CommonLib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Enumerations
{
	public static class PurchaseOrders
	{
		public enum Records
		{ 
			[ StringValue("00") ]
			FileHeaderRecord = 0,

			[ StringValue("10")]
			ClientHeaderRecord = 10,

			[ StringValue("20")]
			FixedSpecialHandlingInstructionsRecord =20,

			[StringValue("21")]
			PurchaseOrderOptionsRecord = 21,

			[StringValue("40")]
			LineItemDetailRecord = 40,

			[StringValue("41")]
			AdditionalLineItemDetailRecord = 41,

			[StringValue("45")]
			ImprintRecord = 45,

			[StringValue("46")]
			StickerTextLinesRecord = 46,

			[StringValue("50")]
			PurchaseOrderTrailerRecord = 50,

			[StringValue("90")]
			FileTrailerRecord = 90,
		}


		public enum Format
		{
			[StringValue("F03")]
			Version3 = 3
		}

//--		public enum Ingram
//--		{
//--			[StringValue("1697978")]
//--			IngramSAN = 0,
//--
//--			[StringValue("20P9387")]
//--			BillToAccount = 1,
//--
//--			[StringValue("20R1158")]
//--			ShipToAccount = 2,
//--
//--			[StringValue("HALFPF03")]
//--			ShipToPassword = 3,
//--
//--			[StringValue("I")]
//--			VendorFlagIngram = 4,
//--
//--			[StringValue("P")]
//--			VendorFlagIPS 
//--
//--		}


//--		public enum BackOrderCodes
//--		{
//--			[StringValue("N")]
//--			NoBackOrders = 0,
//--
//--			[StringValue("B")]
//--			BackOrderOnlyNotYetReleased = 1,
//--
//--			[StringValue("B")]
//--			NYR = 1,
//--
//--			[StringValue("Y")]
//--			BackorderAll = 2,
//--
//--			[StringValue(" ")]
//--			UseAccountProfileSetting = 3
//--		}
//--
//--
//--		public enum DDCFulfillment
//--
//--		{
//--			[StringValue("Y")]
//--			Split_BestFill =  1,
//--				
//--			[StringValue("N")]
//--			DoNotSplit = 1,
//--
//--			[StringValue(" ")]
//--			UseAccountProfileSettings = 2
//--		}

//--		public enum YesNo
//--		{
//--			[StringValue("N")]
//--			No = 0,
//--
//--			[StringValue("Y")]
//--			Yes = 1,
//--
//--			[StringValue(" ")]
//--			UseAccountProfileSetttings= 2
//--		}

		public enum SpecialHandlingPrefix
		{
			[StringValue("5")]
			Standard =5
		}

		public enum SpecialHandlingCodes
		{
			[StringValue("XXXX")]
			Default = 0
		}

//--		public enum PurchaseOrderType
//--		{
//--			[StringValue("0")]
//--			PurchaseOrder = 0,
//--
//--			[StringValue("1")]
//--			POARequest = 1,
//--
//--			[StringValue("3")]
//--			StockStatusRequest = 3,
//--
//--			[StringValue("5")]
//--			POARequest_SpecificPO = 5,
//--
//--			[StringValue("7")]
//--			POARequest_WebServiceOnly = 7
//--		}

//--		public enum OrderTypeCodes
//--		{
//--			[StringValue("CE")]
//--			SingleHoldingOrder = 0,
//--
//--			[StringValue("EF")]
//--			FutureShip = 1,
//--
//--			[StringValue("EH")]
//--			ElectornicOrderCombineShip_SeparateInvoice = 2,
//--
//--			[StringValue("EI")]
//--			ElectronicTradeImmediateRelease = 3,
//--
//--			[StringValue("EL")]
//--			ElectronicOrderNonCombining = 4,
//--
//--			[StringValue("EO")]
//--			ElectronicCombining = 5,
//--
//--			[StringValue("LS")]
//--			DualShipment = 6,
//--
//--			[StringValue("RF")]
//--			ReleaseWhenFull = 7
//--		}

//--		public enum DistributionCenterCodes
//--		{
//--
//--			[StringValue(" ")]
//--			UseAccountProfileSettings = 0,
//--
//--			[StringValue("C")]
//--			PA_Chambersburg = 1,
//--
//--			[StringValue("D")]
//--			IN_FortWayne = 2,
//--
//--			[StringValue("E")]
//--			OR_Roseburg = 3,
//--
//--			[StringValue("N")]
//--			TN_LaVergne = 4,
//--
//--			[StringValue("J")]
//--			CA_Fresno = 5,
//--
//--			[StringValue("B")]
//--			PA_Allentown = 6
//--		}


//--		public enum BackorderHoldAndRelease
//--		{
//--			[StringValue(" ")]
//--			UseAccountProfileSettings = 0,
//--
//--			[StringValue("H")]
//--			HoldAllBackordersUntilAnotherOrder =1,
//--
//--			[StringValue("R")]
//--			ReleaseUponReceiptOfBackorderedItems =2
//--		}

//--		public enum ShippingCodes
//--		{
//--			[StringValue(" ")]
//--			UseAccountProfileSettings = 0,
//--
//--			[StringValue("SI PRIORITY MAIL USA")]
//--			USPS_PriorityMail = 1,
//--
//--			[StringValue("SI USPS MEDIA MAIL")]
//--			USPS_MediaMail = 2,
//--
//--			[StringValue("SI UPS 3-DAY SELECT")]
//--			UPS_3DaySelect_1 = 3,
//--
//--			[StringValue("SI NEXT DAY AIR COLL")]
//--			UPS_NextDayAir_Coll = 4,
//--
//--			[StringValue("SI WILL PICKUP")]
//--			WillPickUp = 5,
//--
//--			[StringValue("SI UPS SAT DEL AIR")]
//--			UPS_SaturdayDelivery = 6,
//--
//--			[StringValue("SI NEXT DAY AIR")]
//--			UPS_NextDayAir = 7,
//--
//--			[StringValue("SI 2ND DAY AIR")]
//--			UPS_2ndDayAir = 8,
//--
//--			[StringValue("SI 3 DAY SELECT")]
//--			UPS_3DaySelect_2 = 9
//--		}
	}
}
