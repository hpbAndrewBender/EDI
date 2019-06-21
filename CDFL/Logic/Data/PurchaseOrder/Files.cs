using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLib.Logic;
using CommonLib.Extensions;

namespace FormatCDFL.Logic.Data.PurchaseOrder
{
	public class Files : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public int CreateBatch(string filename, string vendor)
		{
			int batchnumber = 0;
			try
			{
				batchnumber = CommonLib.Logic.Globals.CreateBatch(filename, vendor, 4);
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return batchnumber;
		}

		public bool WriteFileAddingSequence(string filename, Models.Files.PurchaseOrder.DataSequence.V3 data, bool checkseq)
		{
			List<object> writelist = new List<object>();
			bool success = false;
			short seqnum = 1;
			try
			{
				//build list

				data.FileHeaderRecord.SequenceNumber = seqnum++;
				writelist.Add(data.FileHeaderRecord);
				if (data.PurchaseOrders != null && data.PurchaseOrders.Count > 0)
				{
					foreach (Models.Files.PurchaseOrder.DataSequence.PurchaseOrder item in data.PurchaseOrders)
					{
						item.ClientHeaderRecord.SequenceNumber = seqnum++;
						writelist.Add(item.ClientHeaderRecord);
						if (Common.IsValid(item.FixedHandlingInstructionsRecord, checkseq))
						{
							item.FixedHandlingInstructionsRecord.SequenceNumber = seqnum++;
							writelist.Add(item.FixedHandlingInstructionsRecord);
						}
						if (Common.IsValid(item.PurchaseOrderOptionsRecord, checkseq))
						{
							item.PurchaseOrderOptionsRecord.SequenceNumber = seqnum++;
							writelist.Add(item.PurchaseOrderOptionsRecord);
						}
						//?? if (item.PurchaseOrderDetails != null && item.PurchaseOrderDetails.Count > 0)
						//?? {
						//?? 	foreach (Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail detail in item.PurchaseOrderDetails)
						//?? 	{
						//?? 		if (Common.IsValid(detail.LineItemDetail, checkseq))
						//?? 		{
						//?? 			detail.LineItemDetail.SequenceNumber = seqnum++;
						//?? 			writelist.Add(detail.LineItemDetail);
						//?? 		}
						//?? 		if (Common.IsValid(detail.AdditionalLineItemDetail, checkseq))
						//?? 		{
						//?? 			detail.AdditionalLineItemDetail.SequenceNumber = seqnum++;
						//?? 			writelist.Add(detail.AdditionalLineItemDetail);
						//?? 		}
						//?? 		if (detail.Imprint != null && detail.Imprint.Count > 0)
						//?? 		{
						//?? 			foreach (Models.Files.PurchaseOrder.R45_Imprint imprint in detail.Imprint)
						//?? 			{
						//?? 				if (Common.IsValid(imprint, checkseq) && !string.IsNullOrEmpty(imprint.PONumber))
						//?? 				{
						//?? 					imprint.SequenceNumber = seqnum++;
						//?? 					writelist.Add(imprint);
						//?? 				}
						//?? 			}
						//?? 		}
						//?? 		if (Common.IsValid(detail.StickerBarcodeDataRecord, checkseq) && !string.IsNullOrEmpty(detail.StickerBarcodeDataRecord.PONumber))
						//?? 		{
						//?? 			detail.StickerBarcodeDataRecord.SequenceNumber = seqnum++;
						//?? 			writelist.Add(detail.StickerBarcodeDataRecord);
						//?? 		}
						//?? 		//--if (detail.StickerTextLines != null && detail.StickerTextLines.Count > 0)
						//?? 		//--{
						//?? 		//--	foreach (Models.Files.PurchaseOrder.r46 text in detail.StickerTextLines)
						//?? 		//--	{
						//?? 		//--		if (Common.IsValid(text, checkseq) && !string.IsNullOrEmpty(text.PONumber))
						//?? 		//--		{
						//?? 		//--			text.SequenceNumber = seqnum++;
						//?? 		//--			writelist.Add(text);
						//?? 		//--		}
						//?? 		//--	}
						//?? 		//--}
						//?? 
						//?? 	}
						//?? }
					}
				}
				//?? if (Common.IsValid(data.PurchaseOrderTrailerRecord, checkseq))
				//?? {
				//?? 	data.PurchaseOrderTrailerRecord.SequenceNumber = seqnum++;
				//?? 	writelist.Add(data.PurchaseOrderTrailerRecord);
				//?? }
				if (Common.IsValid(data.FileTrailerRecord, checkseq))
				{
					data.FileTrailerRecord.SequenceNumber = seqnum++;
					writelist.Add(data.FileTrailerRecord);
				}
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.PurchaseOrder.R00_FileHeader),
					typeof(Models.Files.PurchaseOrder.R10_ClientHeader),
					typeof(Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions),
					typeof(Models.Files.PurchaseOrder.R21_PurchaseOrderOptions),
					typeof(Models.Files.PurchaseOrder.R24_CustomerCost),
					typeof(Models.Files.PurchaseOrder.R25_CustomerBillToName),
					typeof(Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber),
					typeof(Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine),
					typeof(Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip),
					typeof(Models.Files.PurchaseOrder.R30_RecipientShipToName),
					typeof(Models.Files.PurchaseOrder.R31_RecipientShipToPhone),
					typeof(Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine),
					typeof(Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip),
					typeof(Models.Files.PurchaseOrder.R35_DropShipDetail),
					typeof(Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions),
					typeof(Models.Files.PurchaseOrder.R37_MarketingMessage),
					typeof(Models.Files.PurchaseOrder.R38_GiftMessage),
					typeof(Models.Files.PurchaseOrder.R40_LineItem),
					typeof(Models.Files.PurchaseOrder.R41_AdditionalLineItem),
					typeof(Models.Files.PurchaseOrder.R45_Imprint),
					typeof(Models.Files.PurchaseOrder.R50_PurchaseOrderControl),
					typeof(Models.Files.PurchaseOrder.R90_FileTrailer)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.Invoice.Selectors.V3.Custom)
				};
				engine.WriteFile(filename, writelist.ToArray());
				success = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				success = false;
			}
			return success;
		}


		public bool WriteFile(string filename, Models.Files.PurchaseOrder.DataSequence.V3 data)
		{
			List<object> writelist = new List<object>();
			bool success = false;

			try
			{
				//build list
				writelist.Add(data.FileHeaderRecord);
				if(data.PurchaseOrders != null && data.PurchaseOrders.Count > 0)
				{
					foreach(Models.Files.PurchaseOrder.DataSequence.PurchaseOrder item in data.PurchaseOrders)
					{
						writelist.Add(item.ClientHeaderRecord);
						if (Common.IsValid(item.FixedHandlingInstructionsRecord)) { writelist.Add(item.FixedHandlingInstructionsRecord); }
						if (Common.IsValid(item.PurchaseOrderOptionsRecord)) { writelist.Add(item.PurchaseOrderOptionsRecord); }
						if (Common.IsValid(item.CustomerCostRecord)) { writelist.Add(item.CustomerCostRecord); }
						if (Common.IsValid(item.CustomerBillToNameRecord)) { writelist.Add(item.CustomerBillToNameRecord); }
						if (Common.IsValid(item.CustomerBillToPhoneNumberRecord)) { writelist.Add(item.CustomerBillToPhoneNumberRecord); }
						if (item.CustomerBillToAddressLine != null && item.CustomerBillToAddressLine.Count > 0)
						{
							foreach (Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine detail in item.CustomerBillToAddressLine)
							{
								if (Common.IsValid(detail)) { writelist.Add(detail); }
							}
						}
						if (Common.IsValid(item.CustomerBillToCityStateZipRecord)) { writelist.Add(item.CustomerBillToCityStateZipRecord); }
						if (Common.IsValid(item.RecipientShipToNameRecord)) { writelist.Add(item.RecipientShipToNameRecord); }
						if (Common.IsValid(item.RecipientShipToPhoneRecord)) { writelist.Add(item.RecipientShipToPhoneRecord); }
						if (item.ShipRecordRecipientAddressLine != null && item.ShipRecordRecipientAddressLine.Count > 0)
						{
							foreach (Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine detail in item.ShipRecordRecipientAddressLine)
							{
								if (Common.IsValid(detail)) { writelist.Add(detail); }
							}
						}
						if (Common.IsValid(item.RecipShippingRecordCityStateZipRecord)) { writelist.Add(item.RecipShippingRecordCityStateZipRecord); }
						if (Common.IsValid(item.DropShipDetailRecord)) { writelist.Add(item.DropShipDetailRecord); }
						if (item.SpecialDeliveryInstructions != null && item.SpecialDeliveryInstructions.Count > 0)
						{
							foreach (Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions detail in item.SpecialDeliveryInstructions)
							{
								if (Common.IsValid(detail)) { writelist.Add(detail); }
							}
						}
						if (item.MarketingMessage != null && item.MarketingMessage.Count > 0)
						{
							foreach (Models.Files.PurchaseOrder.R37_MarketingMessage detail in item.MarketingMessage)
							{
								if (Common.IsValid(detail)) { writelist.Add(detail); }
							}
						}
						if (item.GiftMessage != null && item.GiftMessage.Count > 0)
						{
							foreach (Models.Files.PurchaseOrder.R38_GiftMessage detail in item.GiftMessage)
							{
								if (Common.IsValid(detail)) { writelist.Add(detail); }
							}
						}
						if (item.Items != null && item.Items.Count > 0)
						{
							foreach(Models.Files.PurchaseOrder.DataSequence.Item lineitem in item.Items)
							{
								if (Common.IsValid(lineitem.LineItemRecord)) { writelist.Add(lineitem.LineItemRecord); }
								if (Common.IsValid(lineitem.AdditionalLineItemRecord)) { writelist.Add(lineitem.AdditionalLineItemRecord); }
								if (lineitem.LineItemGiftMessage != null && lineitem.LineItemGiftMessage.Count > 0)
								{
									foreach (Models.Files.PurchaseOrder.R42_LineItemGiftMessage detail in lineitem.LineItemGiftMessage)
									{
										if (Common.IsValid(detail)) { writelist.Add(detail); }
									}
								}
								if (lineitem.Imprint != null && lineitem.Imprint.Count > 0)
								{
									foreach (Models.Files.PurchaseOrder.R45_Imprint detail in lineitem.Imprint)
									{
										if (Common.IsValid(detail)) { writelist.Add(detail); }
									}
								}
							}
						}
						if (Common.IsValid(item.PurchaseOrderControlRecord)) { writelist.Add(item.PurchaseOrderControlRecord); }
					}
				}
				if (Common.IsValid(data.FileTrailerRecord)) { writelist.Add(data.FileTrailerRecord); }
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.PurchaseOrder.R00_FileHeader),
					typeof(Models.Files.PurchaseOrder.R10_ClientHeader),
					typeof(Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions),
					typeof(Models.Files.PurchaseOrder.R21_PurchaseOrderOptions),
					typeof(Models.Files.PurchaseOrder.R24_CustomerCost),
					typeof(Models.Files.PurchaseOrder.R25_CustomerBillToName),
					typeof(Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber),
					typeof(Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine),
					typeof(Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip),
					typeof(Models.Files.PurchaseOrder.R30_RecipientShipToName),
					typeof(Models.Files.PurchaseOrder.R31_RecipientShipToPhone),
					typeof(Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine),
					typeof(Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip),
					typeof(Models.Files.PurchaseOrder.R35_DropShipDetail),
					typeof(Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions),
					typeof(Models.Files.PurchaseOrder.R37_MarketingMessage),
					typeof(Models.Files.PurchaseOrder.R38_GiftMessage),
					typeof(Models.Files.PurchaseOrder.R40_LineItem),
					typeof(Models.Files.PurchaseOrder.R41_AdditionalLineItem),
					typeof(Models.Files.PurchaseOrder.R42_LineItemGiftMessage),
					typeof(Models.Files.PurchaseOrder.R45_Imprint),
					typeof(Models.Files.PurchaseOrder.R50_PurchaseOrderControl),
					typeof(Models.Files.PurchaseOrder.R90_FileTrailer)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.Invoice.Selectors.V3.Custom)
				};
				engine.WriteFile(filename, writelist.ToArray());
				success = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				success = false;
			}
			return success;
		}

		public Models.Files.PurchaseOrder.DataSequence.V3 ReadFile(string filename)
		{
			List<Models.Files.PurchaseOrder.R00_FileHeader> saveR00 = null;
			List<Models.Files.PurchaseOrder.R10_ClientHeader> saveR10 = null;
			List<Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions> saveR20 = null;
			List<Models.Files.PurchaseOrder.R21_PurchaseOrderOptions> saveR21 = null;
			List<Models.Files.PurchaseOrder.R24_CustomerCost> saveR24 = null;
			List<Models.Files.PurchaseOrder.R25_CustomerBillToName> saveR25 = null;
			List<Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber> saveR26 = null;
			List<Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine> saveR27 = null;
			List<Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip> saveR29 = null;
			List<Models.Files.PurchaseOrder.R30_RecipientShipToName> saveR30 = null;
			List<Models.Files.PurchaseOrder.R31_RecipientShipToPhone> saveR31 = null;
			List<Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine> saveR32 = null;
			List<Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip> saveR34 = null;
			List<Models.Files.PurchaseOrder.R35_DropShipDetail> saveR35 = null;
			List<Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions> saveR36 = null;
			List<Models.Files.PurchaseOrder.R37_MarketingMessage> saveR37 = null;
			List<Models.Files.PurchaseOrder.R38_GiftMessage> saveR38 = null;
			List<Models.Files.PurchaseOrder.R40_LineItem> saveR40 = null;
			List<Models.Files.PurchaseOrder.R41_AdditionalLineItem> saveR41 = null;
			List<Models.Files.PurchaseOrder.R42_LineItemGiftMessage> saveR42 = null;
			List<Models.Files.PurchaseOrder.R45_Imprint> saveR45 = null;
			List<Models.Files.PurchaseOrder.R50_PurchaseOrderControl> saveR50 = null;
			List<Models.Files.PurchaseOrder.R90_FileTrailer> saveR90 = null;
			//
			Models.Files.PurchaseOrder.DataSequence.V3 file = null;
			Models.Files.PurchaseOrder.DataSequence.PurchaseOrder order = null;
			Models.Files.PurchaseOrder.DataSequence.Item item = null;
			//
			string typename = string.Empty;
			int orderCount = 0;
			int itemCount = 0;

			try
			{
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.PurchaseOrder.R00_FileHeader),
					typeof(Models.Files.PurchaseOrder.R10_ClientHeader),
					typeof(Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions),
					typeof(Models.Files.PurchaseOrder.R21_PurchaseOrderOptions),
					typeof(Models.Files.PurchaseOrder.R24_CustomerCost),
					typeof(Models.Files.PurchaseOrder.R25_CustomerBillToName),
					typeof(Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber),
					typeof(Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine),
					typeof(Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip),
					typeof(Models.Files.PurchaseOrder.R30_RecipientShipToName),
					typeof(Models.Files.PurchaseOrder.R31_RecipientShipToPhone),
					typeof(Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine),
					typeof(Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip),
					typeof(Models.Files.PurchaseOrder.R35_DropShipDetail),
					typeof(Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions),
					typeof(Models.Files.PurchaseOrder.R37_MarketingMessage),
					typeof(Models.Files.PurchaseOrder.R38_GiftMessage),
					typeof(Models.Files.PurchaseOrder.R40_LineItem),
					typeof(Models.Files.PurchaseOrder.R41_AdditionalLineItem),
					typeof(Models.Files.PurchaseOrder.R42_LineItemGiftMessage),
					typeof(Models.Files.PurchaseOrder.R45_Imprint),
					typeof(Models.Files.PurchaseOrder.R50_PurchaseOrderControl),
					typeof(Models.Files.PurchaseOrder.R90_FileTrailer)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.PurchaseOrder.Selectors.V3.Custom)
				};
				var res = engine.ReadFile(filename);
				if (res != null && res.Length > 0)
				{
					file = new Models.Files.PurchaseOrder.DataSequence.V3();
					foreach (var rec in res)
					{
						typename = rec.GetType().Name.ToUpper();
						switch (typename)
						{
							case "R00_FILEHEADER":
								Common.Initialize(ref saveR00);
								saveR00.Add((Models.Files.PurchaseOrder.R00_FileHeader)rec);
								file.FileHeaderRecord = saveR00.LastItem();
								break;

							case "R10_CLIENTHEADER":
								Common.Initialize(ref saveR10);
								saveR10.Add((Models.Files.PurchaseOrder.R10_ClientHeader)rec);
								if (orderCount > 0)
								{
									if (file.PurchaseOrders == null) { file.PurchaseOrders = new List<Models.Files.PurchaseOrder.DataSequence.PurchaseOrder>(); }
									if (order != null)
									{
										file.PurchaseOrders.Add(order);
										order = null;
									}
								}
								orderCount++;
								order = new Models.Files.PurchaseOrder.DataSequence.PurchaseOrder
								{
									ClientHeaderRecord = saveR10.LastItem()
								};
								break;

							case "R20_FIXEDSPECIALHANDLINGINSTRUCTIONS":
								Common.Initialize(ref saveR20);
								saveR20.Add((Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions)rec);
								order.FixedHandlingInstructionsRecord = saveR20.LastItem();
								break;

							case "R21_PURCHASEORDEROPTIONS":
								Common.Initialize(ref saveR21);
								saveR21.Add((Models.Files.PurchaseOrder.R21_PurchaseOrderOptions)rec);
								order.PurchaseOrderOptionsRecord = saveR21.LastItem();
								break;

							case "R24_CUSTOMERCOST":
								Common.Initialize(ref saveR24);
								saveR24.Add((Models.Files.PurchaseOrder.R24_CustomerCost)rec);
								order.CustomerCostRecord = saveR24.LastItem();
								break;

							case "R25_CUSTOMERBILLTONAME":
								Common.Initialize(ref saveR25);
								saveR25.Add((Models.Files.PurchaseOrder.R25_CustomerBillToName)rec);
								order.CustomerBillToNameRecord = saveR25.LastItem();
								break;

							case "R26_CUSTOMERBILLTOPHONENUMBER":
								Common.Initialize(ref saveR26);
								saveR26.Add((Models.Files.PurchaseOrder.R26_CustomerBillToPhoneNumber)rec);
								order.CustomerBillToPhoneNumberRecord = saveR26.LastItem();
								break;

							case "R27_CUSTOMERBILLTOADDRESSLINE":
								Common.Initialize(ref saveR27);
								saveR27.Add((Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine)rec);
								if (order.CustomerBillToAddressLine == null) { order.CustomerBillToAddressLine = new List<Models.Files.PurchaseOrder.R27_CustomerBillToAddressLine>(); }
								if(order.CustomerBillToAddressLine.Count < file.Maxes[typename])
								{
									order.CustomerBillToAddressLine.Add(saveR27.LastItem());
								}
								break;

							case "R29_CUSTOMERBILLTOCITYSTATEZIP":
								Common.Initialize(ref saveR29);
								saveR29.Add((Models.Files.PurchaseOrder.R29_CustomerBillToCityStateZip)rec);
								order.CustomerBillToCityStateZipRecord = saveR29.LastItem();
								break;

							case "R30_RECIPIENTSHIPTONAME":
								Common.Initialize(ref saveR30);
								saveR30.Add((Models.Files.PurchaseOrder.R30_RecipientShipToName)rec);
								order.RecipientShipToNameRecord = saveR30.LastItem();
								break;

							case "R31_RECIPIENTSHIPTOPHONE":
								Common.Initialize(ref saveR31);
								saveR31.Add((Models.Files.PurchaseOrder.R31_RecipientShipToPhone)rec);
								order.RecipientShipToPhoneRecord = saveR31.LastItem();
								break;

							case "R32_SHIPPINGRECORDRECIPIENTADDRESSLINE":
								Common.Initialize(ref saveR32);
								saveR32.Add((Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine)rec);
								if (order.ShipRecordRecipientAddressLine == null) { order.ShipRecordRecipientAddressLine = new List<Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine>(); }
								if(order.ShipRecordRecipientAddressLine.Count < file.Maxes[typename])
								{
									order.ShipRecordRecipientAddressLine.Add(saveR32.LastItem());
								}								
								break;

							case "R34_RECIPIENTSHIPPINGRECORDCITYSTATEZIP":
								Common.Initialize(ref saveR34);
								saveR34.Add((Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip)rec);
								order.RecipShippingRecordCityStateZipRecord = saveR34.LastItem();
								break;

							case "R35_DROPSHIPDETAIL":
								Common.Initialize(ref saveR35);
								saveR35.Add((Models.Files.PurchaseOrder.R35_DropShipDetail)rec);
								order.DropShipDetailRecord = saveR35.LastItem();
								break;

							case "R36_SPECIALDELIVERYINSTRUCTIONS":
								Common.Initialize(ref saveR36);
								saveR36.Add((Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions)rec);
								if(order.SpecialDeliveryInstructions == null) { order.SpecialDeliveryInstructions = new List<Models.Files.PurchaseOrder.R36_SpecialDeliveryInstructions>(); }
								if (order.SpecialDeliveryInstructions.Count < file.Maxes[typename])
								{
									order.SpecialDeliveryInstructions.Add(saveR36.LastItem());
								}
								break;

							case "R37_MARKETINGMESSAGE":
								Common.Initialize(ref saveR37);
								saveR37.Add((Models.Files.PurchaseOrder.R37_MarketingMessage)rec);
								if(order.MarketingMessage == null) { order.MarketingMessage = new List<Models.Files.PurchaseOrder.R37_MarketingMessage>(); }
								if(order.MarketingMessage.Count < file.Maxes[typename])
								{
									order.MarketingMessage.Add(saveR37.LastItem());
								}
								break;

							case "R38_GIFTMESSAGE":
								Common.Initialize(ref saveR38);
								saveR38.Add((Models.Files.PurchaseOrder.R38_GiftMessage)rec);
								if(order.GiftMessage == null) { order.GiftMessage = new List<Models.Files.PurchaseOrder.R38_GiftMessage>(); }
								if(order.GiftMessage.Count < file.Maxes[typename])
								{
									order.GiftMessage.Add(saveR38.LastItem());
								}
								break;

							case "R40_LINEITEM":
								Common.Initialize(ref saveR40);
								saveR40.Add((Models.Files.PurchaseOrder.R40_LineItem)rec);
								if (itemCount > 0)
								{
									if (order.Items == null) { order.Items = new List<Models.Files.PurchaseOrder.DataSequence.Item>(); }
									if (item != null)
									{
										order.Items.Add(item);
										item= null;
									}
								}
								itemCount++;
								item = new Models.Files.PurchaseOrder.DataSequence.Item
								{
									LineItemRecord = saveR40.LastItem()
								};
								break;

							case "R41_ADDITIONALLINEITEM":
								Common.Initialize(ref saveR41);
								saveR41.Add((Models.Files.PurchaseOrder.R41_AdditionalLineItem)rec);
								item.AdditionalLineItemRecord = saveR41.LastItem();
								break;

							case "R42_LINEITEMGIFTMESSAGE":
								Common.Initialize(ref saveR42);
								saveR42.Add((Models.Files.PurchaseOrder.R42_LineItemGiftMessage)rec);
								if (item.LineItemGiftMessage.Count < file.Maxes[typename])
								{
									item.LineItemGiftMessage.Add(saveR42.LastItem());
								}
								break;

							case "R45_IMPRINT":
								Common.Initialize(ref saveR45);
								saveR45.Add((Models.Files.PurchaseOrder.R45_Imprint)rec);
								if(item.Imprint == null) { item.Imprint = new List<Models.Files.PurchaseOrder.R45_Imprint>(); }
								if(item.Imprint.Count < file.Maxes[typename])
								{
									item.Imprint.Add(saveR45.LastItem());
								}
								break;
						
							case "R50_PURCHASEORDERCONTROL":
								Common.Initialize(ref saveR50);
								saveR50.Add((Models.Files.PurchaseOrder.R50_PurchaseOrderControl)rec);
								order.PurchaseOrderControlRecord = saveR50.LastItem();
								file.PurchaseOrders.Add(order);
								if(item !=null)
								{
									if (file.PurchaseOrders[file.PurchaseOrders.Count - 1].Items == null) { file.PurchaseOrders[file.PurchaseOrders.Count - 1].Items = new List<Models.Files.PurchaseOrder.DataSequence.Item>(); }
									file.PurchaseOrders[file.PurchaseOrders.Count - 1].Items.Add(item);
									item = null;
								}
								order = null;
								break;

							case "R90_FILETRAILER":
								Common.Initialize(ref saveR90);
								saveR90.Add((Models.Files.PurchaseOrder.R90_FileTrailer)rec);
								file.FileTrailerRecord = saveR90.LastItem();
								break;
						}
					}
					if (order != null)
					{
						file.PurchaseOrders.Add(order);
						if (item != null)
						{
							if (file.PurchaseOrders[file.PurchaseOrders.Count - 1].Items == null) { file.PurchaseOrders[file.PurchaseOrders.Count - 1].Items = new List<Models.Files.PurchaseOrder.DataSequence.Item>(); }
							file.PurchaseOrders[file.PurchaseOrders.Count - 1].Items.Add(item);
							item = null;
						}
						order = null;
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return file;
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
		// ~Files() {
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