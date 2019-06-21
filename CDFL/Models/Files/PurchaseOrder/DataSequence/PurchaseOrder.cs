using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Models.Files.PurchaseOrder.DataSequence
{
	public class PurchaseOrder : IDisposable
	{
		public PurchaseOrder()
		{
			ClientHeaderRecord = new R10_ClientHeader();
			FixedHandlingInstructionsRecord = new R20_FixedSpecialHandlingInstructions();
			PurchaseOrderOptionsRecord = new R21_PurchaseOrderOptions();
			CustomerCostRecord = new R24_CustomerCost();
			CustomerBillToNameRecord = new R25_CustomerBillToName();
			CustomerBillToPhoneNumberRecord = new R26_CustomerBillToPhoneNumber();
			CustomerBillToAddressLine = new List<R27_CustomerBillToAddressLine>();
			CustomerBillToCityStateZipRecord = new R29_CustomerBillToCityStateZip();
			RecipientShipToNameRecord = new R30_RecipientShipToName();
			RecipientShipToPhoneRecord = new R31_RecipientShipToPhone();
			ShipRecordRecipientAddressLine = new List<R32_ShippingRecordRecipientAddressLine>();
			RecipShippingRecordCityStateZipRecord = new R34_RecipientShippingRecordCityStateZip();
			DropShipDetailRecord = new R35_DropShipDetail();
			SpecialDeliveryInstructions = new List<R36_SpecialDeliveryInstructions>();
			MarketingMessage = new List<R37_MarketingMessage>();
			GiftMessage = new List<R38_GiftMessage>();
			PurchaseOrderControlRecord = new R50_PurchaseOrderControl();
			Initialized = true;
		}

		public bool Initialized { get; private set; }

		public R10_ClientHeader ClientHeaderRecord { get; set; }

		public R20_FixedSpecialHandlingInstructions FixedHandlingInstructionsRecord { get; set; }

		public R21_PurchaseOrderOptions PurchaseOrderOptionsRecord { get; set; }

		public R24_CustomerCost CustomerCostRecord { get; set; }

		public R25_CustomerBillToName CustomerBillToNameRecord { get; set; }

		public R26_CustomerBillToPhoneNumber CustomerBillToPhoneNumberRecord { get; set; }

		public List<R27_CustomerBillToAddressLine> CustomerBillToAddressLine { get; set; }

		public R29_CustomerBillToCityStateZip CustomerBillToCityStateZipRecord { get; set; }

		public R30_RecipientShipToName RecipientShipToNameRecord { get; set; }

		public R31_RecipientShipToPhone RecipientShipToPhoneRecord { get; set; }

		public List<R32_ShippingRecordRecipientAddressLine> ShipRecordRecipientAddressLine { get; set; }

		public R34_RecipientShippingRecordCityStateZip RecipShippingRecordCityStateZipRecord { get; set; }

		public R35_DropShipDetail DropShipDetailRecord { get; set; }

		public List<R36_SpecialDeliveryInstructions> SpecialDeliveryInstructions { get; set; }

		public List<R37_MarketingMessage> MarketingMessage { get; set; }

		public List<R38_GiftMessage> GiftMessage { get; set; }

		public List<Item> Items { get; set; }

		public R50_PurchaseOrderControl PurchaseOrderControlRecord { get; set; }

		public void Dispose()
		{
			ClientHeaderRecord = null;
			FixedHandlingInstructionsRecord = null;
			PurchaseOrderOptionsRecord = null;
			CustomerCostRecord = null;
			CustomerBillToNameRecord = null;
			CustomerBillToPhoneNumberRecord = null;
			CustomerBillToAddressLine = null;
			CustomerBillToCityStateZipRecord = null;
			RecipientShipToNameRecord = null;
			RecipientShipToPhoneRecord = null;
			ShipRecordRecipientAddressLine = null;
			RecipShippingRecordCityStateZipRecord = null;
			DropShipDetailRecord = null;
			SpecialDeliveryInstructions = null;
			MarketingMessage = null;
			GiftMessage = null;
			Items = null;
			PurchaseOrderControlRecord = null;
			Initialized = false;
		}
	}
}
