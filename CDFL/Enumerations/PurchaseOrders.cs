using CommonLib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Enumerations
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

			[StringValue("24")]
			CustomerCostRecord = 24,

			[StringValue("25")]
			CustomerBillToNameRecord= 25,

			[StringValue("26")]
			CustomerBillToPhoneNumberRecord = 26,

			[StringValue("27")]
			ConsumerBillToAddressLineRecord = 27,

			[StringValue("29")]
			CustomerBillToCityStateZipRecord = 29,

			[StringValue("30")]
			RecipientShipToNameRecord = 30,

			[StringValue("31")]
			RecipientShipToPhoneNumberRecord = 31,

			[StringValue("32")]
			RecipientShipToAddressLineRecord = 32,

			[StringValue("34")]
			RecipientShipToCityStateZipRecord = 34,

			[StringValue("35")]
			DropShipDetailRecord = 35,

			[StringValue("36")]
			SpecialDeliveryInstructionsRecord = 36,

			[StringValue("37")]
			MarketingMessageRecord = 37,

			[StringValue("38")]
			GiftMessageRecord = 38,

			[StringValue("40")]
			LineItemRecord = 40,

			[StringValue("41")]
			AdditionalLineItemRecord = 41,

			[StringValue("42")]
			LineItemGiftMessageRecord = 42,

			[StringValue("45")]
			ImprintRecord = 45,

			[StringValue("50")]
			PurchaseOrderControlTrailerRecord = 50,

			[StringValue("90")]
			FileTrailerRecord = 90,
		}


		public enum Format
		{
			[StringValue("F03")]
			Version3 = 3
		}

		public enum Ingram
		{
			[StringValue("1697978")]
			IngramSAN = 0,

			[StringValue("20P9387")]
			BillToAccount = 1,

			[StringValue("20R1158")]
			ShipToAccount = 2,

			[StringValue("HALFPF03")]
			ShipToPassword = 3,

			[StringValue("I")]
			VendorFlagIngram = 4,

			[StringValue("P")]
			VendorFlagIPS 

		}


		public enum BackOrderCodes
		{
			[StringValue("N")]
			NoBackOrders = 0,

			[StringValue("B")]
			BackOrderOnlyNotYetReleased = 1,

			[StringValue("B")]
			NYR = 1,

			[StringValue("Y")]
			BackorderAll = 2,

			[StringValue(" ")]
			UseAccountProfileSetting = 3
		}


		public enum DDCFulfillment

		{
			[StringValue("Y")]
			Split_BestFill =  1,
				
			[StringValue("N")]
			DoNotSplit = 1,

			[StringValue(" ")]
			UseAccountProfileSettings = 2
		}

		public enum YesNo
		{
			[StringValue("N")]
			No = 0,

			[StringValue("Y")]
			Yes = 1,

			[StringValue(" ")]
			UseAccountProfileSetttings= 2
		}

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

		public enum PurchaseOrderType
		{
			[StringValue("0")]
			PurchaseOrder = 0,

			[StringValue("1")]
			POARequest = 1,

			[StringValue("3")]
			StockStatusRequest = 3,

			[StringValue("5")]
			POARequest_SpecificPO = 5,

			[StringValue("7")]
			POARequest_WebServiceOnly = 7
		}

		public enum OrderTypeCodes
		{
			[StringValue("CE")]
			SingleHoldingOrder = 0,

			[StringValue("EF")]
			FutureShip = 1,

			[StringValue("EH")]
			ElectornicOrderCombineShip_SeparateInvoice = 2,

			[StringValue("EI")]
			ElectronicTradeImmediateRelease = 3,

			[StringValue("EL")]
			ElectronicOrderNonCombining = 4,

			[StringValue("EO")]
			ElectronicCombining = 5,

			[StringValue("LS")]
			DualShipment = 6,

			[StringValue("RF")]
			ReleaseWhenFull = 7
		}

		public enum DistributionCenterCodes
		{

			[StringValue(" ")]
			UseAccountProfileSettings = 0,

			[StringValue("C")]
			PA_Chambersburg = 1,

			[StringValue("D")]
			IN_FortWayne = 2,

			[StringValue("E")]
			OR_Roseburg = 3,

			[StringValue("N")]
			TN_LaVergne = 4,

			[StringValue("J")]
			CA_Fresno = 5,

			[StringValue("B")]
			PA_Allentown = 6
		}


		public enum BackorderHoldAndRelease
		{
			[StringValue(" ")]
			UseAccountProfileSettings = 0,

			[StringValue("H")]
			HoldAllBackordersUntilAnotherOrder =1,

			[StringValue("R")]
			ReleaseUponReceiptOfBackorderedItems =2
		}

		public enum ShippingCodes
		{
			[StringValue(" ")]
			UseAccountProfileSettings = 0,

			[StringValue("SI PRIORITY MAIL USA")]
			USPS_PriorityMail = 1,

			[StringValue("SI USPS MEDIA MAIL")]
			USPS_MediaMail = 2,

			[StringValue("SI UPS 3-DAY SELECT")]
			UPS_3DaySelect_1 = 3,

			[StringValue("SI NEXT DAY AIR COLL")]
			UPS_NextDayAir_Coll = 4,

			[StringValue("SI WILL PICKUP")]
			WillPickUp = 5,

			[StringValue("SI UPS SAT DEL AIR")]
			UPS_SaturdayDelivery = 6,

			[StringValue("SI NEXT DAY AIR")]
			UPS_NextDayAir = 7,

			[StringValue("SI 2ND DAY AIR")]
			UPS_2ndDayAir = 8,

			[StringValue("SI 3 DAY SELECT")]
			UPS_3DaySelect_2 = 9
		}
	}
}
