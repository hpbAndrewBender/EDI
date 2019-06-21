using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Logic.Data.PurchaseOrder
{
	public class SQL
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private string ActionType { get; set; } = "PurchaseOrder";
		private string FileFormat { get; set; } = "CDFL";

		Models.Files.PurchaseOrder.R00_FileHeader x01;
		public bool SaveA(List<Models.Files.PurchaseOrder.R00_FileHeader> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R10_ClientHeader x02;
		public bool SaveA(List<Models.Files.PurchaseOrder.R10_ClientHeader> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions x03;
		public bool SaveA(List<Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R21_PurchaseOrderOptions x04;
		public bool SaveA(List<Models.Files.PurchaseOrder.R21_PurchaseOrderOptions> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R24_CustomerCost x05;
		public bool SaveA(List<Models.Files.PurchaseOrder.R24_CustomerCost> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R25_CustomerBillToName x06;
		public bool SaveA(List<Models.Files.PurchaseOrder.R25_CustomerBillToName> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber x07;
		public bool SaveA(List<Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine x08;
		public bool SaveA(List<Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip x09;
		public bool SaveA(List<Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R30_RecipientShipToName x10;
		public bool SaveA(List<Models.Files.PurchaseOrder.R30_RecipientShipToName> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R31_RecipientShipToPhone x11;
		public bool SaveA(List<Models.Files.PurchaseOrder.R31_RecipientShipToPhone> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine x12;
		public bool SaveA(List<Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip x13;
		public bool SaveA(List<Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R35_DropShipDetail x14;
		public bool SaveA(List<Models.Files.PurchaseOrder.R35_DropShipDetail> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions x15;
		public bool SaveA(List<Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R37_MarketingMessage x16;
		public bool SaveA(List<Models.Files.PurchaseOrder.R37_MarketingMessage> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R38_GiftMessage x17;
		public bool SaveA(List<Models.Files.PurchaseOrder.R38_GiftMessage> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R40_LineItem x18;
		public bool SaveA(List<Models.Files.PurchaseOrder.R40_LineItem> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R41_AdditionalLineItem x19;
		public bool SaveA(List<Models.Files.PurchaseOrder.R41_AdditionalLineItem> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R42_LineItemGiftMessage x20;
		public bool SaveA(List<Models.Files.PurchaseOrder.R42_LineItemGiftMessage> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R45_Imprint x21;
		public bool SaveA(List<Models.Files.PurchaseOrder.R45_Imprint> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R50_PurchaseOrderControl x22;
		public bool SaveA(List<Models.Files.PurchaseOrder.R50_PurchaseOrderControl> items, int batchnumber)
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
		Models.Files.PurchaseOrder.R90_FileTrailer x23;
		public bool SaveA(List<Models.Files.PurchaseOrder.R90_FileTrailer> items, int batchnumber)
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

	}
}
