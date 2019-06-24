using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Logic.Data.PurchaseOrder
{
	public class SQL : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private string ActionType { get; set; } = "PurchaseOrder";
		private string FileFormat { get; set; } = "CDFL";
		public bool Successful { private set; get; }

		public SQL
		(
			int batchnumber,
			List<Models.Files.PurchaseOrder.R00_FileHeader> items00 ,
			List<Models.Files.PurchaseOrder.R10_ClientHeader> items10 ,
			List<Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions> items20 ,
			List<Models.Files.PurchaseOrder.R21_PurchaseOrderOptions> items21,
			List<Models.Files.PurchaseOrder.R24_CustomerCost> items24,
			List<Models.Files.PurchaseOrder.R25_CustomerBillToName> items25,
			List<Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber> items26 ,
			List<Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine> items27,
			List<Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip> items29,
			List<Models.Files.PurchaseOrder.R30_RecipientShipToName> items30,
			List<Models.Files.PurchaseOrder.R31_RecipientShipToPhone> items31,
			List<Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine> items32,
			List<Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip> items34,
			List<Models.Files.PurchaseOrder.R35_DropShipDetail> items35,
			List<Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions> items36,
			List<Models.Files.PurchaseOrder.R37_MarketingMessage> items37,
			List<Models.Files.PurchaseOrder.R38_GiftMessage> items38,
			List<Models.Files.PurchaseOrder.R40_LineItem> items40,
			List<Models.Files.PurchaseOrder.R41_AdditionalLineItem> items41,
			List<Models.Files.PurchaseOrder.R42_LineItemGiftMessage> items42,
			List<Models.Files.PurchaseOrder.R45_Imprint> items45,
			List<Models.Files.PurchaseOrder.R50_PurchaseOrderControl> items50,
			List<Models.Files.PurchaseOrder.R90_FileTrailer> items90
		)
		{
			bool result = false;
			try
			{
				if(items00 != null && items00.Count > 0) { SaveR00_FileHeader(items00, batchnumber); }
				if(items10 != null && items10.Count > 0) { SaveR10_ClientHeader(items10,batchnumber); } 			
				if(items20 != null && items20.Count > 0) { SaveR20_FixedSpecialHandlingInstructions(items20,batchnumber); }
				if(items21 != null && items21.Count > 0) { SaveR21_PurchaseOrderOptions(items21,batchnumber); }
				if(items24 != null && items24.Count > 0) { SaveR24_CustomerCost(items24,batchnumber); }
				if(items25 != null && items25.Count > 0) { SaveR25_CustomerBillToName(items25,batchnumber); }
				if(items26 != null && items26.Count > 0) { SaveR26_CustomerBillToPhoneNumber(items26,batchnumber); }
				if(items27 != null && items27.Count > 0) { SaveR27_CustomerBillToAddressLine(items27,batchnumber); }
				if(items29 != null && items29.Count > 0) { SaveR29_CustomerBillToCityStateZip(items29,batchnumber); }
				if(items30 != null && items30.Count > 0) { SaveR30_RecipientShipToName(items30,batchnumber); }
				if(items31 != null && items31.Count > 0) { SaveR31_RecipientShipToPhone(items31,batchnumber); }
				if(items32 != null && items32.Count > 0) { SaveR32_ShippingRecordRecipientAddressLine(items32,batchnumber); }
				if(items34 != null && items34.Count > 0) { SaveR34_RecipientShippingRecordCityStateZip(items34,batchnumber); }
				if(items35 != null && items35.Count > 0) { SaveR35_DropShipDetail(items35,batchnumber); }
				if(items36 != null && items36.Count > 0) { SaveR36_SpecialDeliveryInstructions(items36,batchnumber); }
				if(items37 != null && items37.Count > 0) { SaveR37_MarketingMessage(items37,batchnumber); }
				if(items38 != null && items38.Count > 0) { SaveR38_GiftMessage(items38,batchnumber); }
				if(items40 != null && items40.Count > 0) { SaveR40_LineItem(items40,batchnumber); }
				if(items41 != null && items41.Count > 0) { SaveR41_AdditionalLineItem(items41,batchnumber); }
				if(items42 != null && items42.Count > 0) { SaveR42_LineItemGiftMessage(items42,batchnumber); }
				if(items45 != null && items45.Count > 0) { SaveR45_Imprint(items45,batchnumber); }
				if(items50 != null && items50.Count > 0) { SaveR50_PurchaseOrderControl(items50,batchnumber); }
				if(items90 != null && items90.Count > 0) { SaveR90_FileTrailer(items90,batchnumber); }



			}
			catch (Exception ex)
			{
				log.Error(ex);
				result = false;
			}
			Successful = result;
		}

		public bool SaveR00_FileHeader(List<Models.Files.PurchaseOrder.R00_FileHeader> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R00_FileHeader>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "RecordCode","RecordCode"),
							( 3, "SequenceNumber", "RecordSequence"),
							( 4, "FileSourceSAN","FileSourceSAN"),
							( 5, "FileSourceName","FileSourceName"),
							( 6, "CreationDate","CreationDate"),
							( 7, "FIleName","FIleName"),
							( 8, "FormatVersion","FormatVersion"),
							( 9, "IngramSAN","IngramSAN"),
							(10, "VendorNameFlag","VendorNameFlag"),
							(11, "ProductDescription","ProductDescription"),							
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR10_ClientHeader(List<Models.Files.PurchaseOrder.R10_ClientHeader> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R10_ClientHeader>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "RecordCode","RecordCode"),
							( 3, "SequenceNumber", "RecordSequence"),
							( 4, "PONumber","PONumber"),
							( 5, "IngramBillToAccountNumber","IngramBillToAccountNumber"),
							( 6, "VendorSAN","VendorSAN"),
							( 7, "OrderDate","OrderDate"),
							( 8, "BackorderCancelDate","BackorderCancelDate"),
							( 9, "BackorderCode","BackorderCode"),
							(10, "DDCFulfillmentOrSplitLineOrdering","DDCFulfillmentOrSplitLineOrdering"),
							(11, "ShipToIndicator","ShipToIndicator"),
							(12, "BillToIndicator","BillToIndicator"),							
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR20_FixedSpecialHandlingInstructions(List<Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "SpecialHandlingCodes","SpecialHandlingCodes"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR21_PurchaseOrderOptions(List<Models.Files.PurchaseOrder.R21_PurchaseOrderOptions> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R21_PurchaseOrderOptions>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "RecordCode","RecordCode"),
							( 3, "SequenceNumber", "RecordSequence"),
							( 4, "PONumber","PONumber"),
							( 5, "IngramShipToAccountNumber","IngramShipToAccountNumber"),
							( 6, "POType","POType"),
							( 7, "OrderType","OrderType"),
							( 8, "DCCode","DCCode"),
							( 9, "Greenlight","Greenlight"),
							(10, "POAType","POAType"),
							(11, "ShipToPassword","ShipToPassword"),
							(12, "CarrierOrShippingMethod","CarrierOrShippingMethod"),
							(13, "SplitOrderAcrossDCsAllowed","SplitOrderAcrossDCsAllowed"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR24_CustomerCost(List<Models.Files.PurchaseOrder.R24_CustomerCost> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R24_CustomerCost>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "SalesTaxPercent","SalesTaxPercent"),
							(6, "FreightTaxPercent","FreightTaxPercent"),
							(7, "FreightAmount","FreightAmount"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR25_CustomerBillToName(List<Models.Files.PurchaseOrder.R25_CustomerBillToName> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R25_CustomerBillToName>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "PurchasingConsumerName","PurchasingConsumerName"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR26_CustomerBillToPhoneNumber(List<Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber", "PONumber"),
							(5, "PurchaserPhonenumber","PurchaserPhonenumber"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR27_CustomerBillToAddressLine(List<Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "PurchaserAddressLine","PurchaserAddressLine"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR29_CustomerBillToCityStateZip(List<Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "PurchaserCity","PurchaserCity"),
							(6, "PurchaserStateOrProvince","PurchaserStateOrProvince"),
							(7, "PurchaserPostalCode","PurchaserPostalCode"),
							(8, "PurchaserCountry","PurchaserCountry"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR30_RecipientShipToName(List<Models.Files.PurchaseOrder.R30_RecipientShipToName> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R30_RecipientShipToName>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "RecipientConsumerName","RecipientConsumerName"),
							(6, "AddressValidation","AddressValidation"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR31_RecipientShipToPhone(List<Models.Files.PurchaseOrder.R31_RecipientShipToPhone> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R31_RecipientShipToPhone>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber", "PONumber"),
							(5, "RecipientPhone#","RecipientPhone"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR32_ShippingRecordRecipientAddressLine(List<Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "RecipientAddressLine","RecipientAddressLine"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR34_RecipientShippingRecordCityStateZip(List<Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber" ),
							(5, "RecipientCity","RecipientCity"),
							(6, "RecipientStateOrProvince","RecipientStateOrProvince"),
							(7, "RecipientPostalCode","RecipientPostalCode"),
							(8, "Country","Country"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR35_DropShipDetail(List<Models.Files.PurchaseOrder.R35_DropShipDetail> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R35_DropShipDetail>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "GiftWrapFeeAmount","GiftWrapFeeAmount"),
							(6, "SendConsumerEmail","SendConsumerEmail"),
							(7, "OrderLevelGiftIndicator","OrderLevelGiftIndicator"),
							(8, "SuppressPriceIndicator","SuppressPriceIndicator"),
							(9, "OrderLevelGiftWrapCode","OrderLevelGiftWrapCode"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR36_SpecialDeliveryInstructions(List<Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "SpecialDeliveryInstructions","SpecialDeliveryInstructions"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR37_MarketingMessage(List<Models.Files.PurchaseOrder.R37_MarketingMessage> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R37_MarketingMessage>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "MarketingMessage","MarketingMessage"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR38_GiftMessage(List<Models.Files.PurchaseOrder.R38_GiftMessage> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R38_GiftMessage>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "GiftMessage","GiftMessage"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR40_LineItem(List<Models.Files.PurchaseOrder.R40_LineItem> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R40_LineItem>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "LineItemPONumber","LineItemPONumber"),
							(6, "ItemNumber","ItemNumber"),
							(7, "LineLevelBackorderCode","LineLevelBackorderCode"),
							(8, "SpecialActionCode","SpecialActionCode"),
							(9, "ItemNumberType","ItemNumberType"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR41_AdditionalLineItem(List<Models.Files.PurchaseOrder.R41_AdditionalLineItem> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R41_AdditionalLineItem>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							//41:
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "ClientItemListPrice","ClientItemListPrice"),
							(6, "LineLevelBackorderCancelDate","LineLevelBackorderCancelDate"),
							(7, "LineLevelGiftWrapCode","LineLevelGiftWrapCode"),
							(8, "OrderQuantity","OrderQuantity"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR42_LineItemGiftMessage(List<Models.Files.PurchaseOrder.R42_LineItemGiftMessage> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R42_LineItemGiftMessage>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "LineLevelGiftMessage","LineLevelGiftMessage"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR45_Imprint(List<Models.Files.PurchaseOrder.R45_Imprint> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R45_Imprint>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "RecordCode","RecordCode"),
							( 3, "SequenceNumber", "RecordSequence"),
							( 4, "PONumber","PONumber"),
							( 5, "ImprintOrIndexCode","ImprintOrIndexCode"),
							( 6, "ImprintTextandSymbols","ImprintTextandSymbols"),
							( 7, "ImprintFontCode","ImprintFontCode"),
							( 8, "ImprintColorCode","ImprintColorCode"),
							( 9, "ImprintPositionCode","ImprintPositionCode"),
							(10, "ImprintAppendCode","ImprintAppendCode"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
		
		public bool SaveR50_PurchaseOrderControl(List<Models.Files.PurchaseOrder.R50_PurchaseOrderControl> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R50_PurchaseOrderControl>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber", "RecordSequence"),
							(4, "PONumber","PONumber"),
							(5, "TotalPurchaseOrderRecords","TotalPurchaseOrderRecords"),
							(6, "TotalLineItemsinfile","TotalLineItemsinfile"),
							(7, "TotalUnitsOrdered","TotalUnitsOrdered"),
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR90_FileTrailer(List<Models.Files.PurchaseOrder.R90_FileTrailer> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R90_FileTrailer>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "RecordCode","RecordCode"),
							( 3, "SequenceNumber", "RecordSequence"),
							( 4, "TotalLineItemsinfile","TotalLineItemsinfile"),
							( 5, "TotalPurchaseOrderRecords","TotalPurchaseOrderRecords"),
							( 6, "TotalUnitsOrdered","TotalUnitsOrdered"),
							( 7, "RecordCount00To09","RecordCount00To09"),
							( 8, "RecordCount10To19","RecordCount10To19"),
							( 9, "RecordCount20To29","RecordCount20To29"),
							(10, "RecordCount30To39","RecordCount30To39"),
							(11, "RecordCount40To49","RecordCount40To49"),
							(12, "RecordCount50To59","RecordCount50To59"),
							(13, "RecordCount60To69","RecordCount60To69"),
							(14, "RecordCount70To79","RecordCount70To79"),
							(15, "RecordCount80To99","RecordCount80To99")
						},
						new List<string> { "" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~SQL() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion

	}
}
