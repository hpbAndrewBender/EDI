using CommonLib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FormatBBV3.Enumerations;
using Bulk = DataHPBEDI.Models.BLK;
using Direct = DataHPBEDI.Models.CDF;

namespace VendorIngramContent.Logic.PurchaseOrder
{
	public class Create :IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		public static List<DataHPBEDI.Models.MetaData.AllCodes> CodesBBV3 { get; set; }
		public static Dictionary<string, string> AccessedCodes = new Dictionary<string, string>();

		public Create(List<DataHPBEDI.Models.MetaData.AllCodes> codes)
		{
			CodesBBV3 = codes;
		}

		private string GetCode(string codetype, string codename, bool refresh=false)
		{
			string result = string.Empty;
			string key = string.Empty;
			try
			{
				key = $"{codetype.ToLower()}/{codename.ToLower()}";
				if (AccessedCodes.ContainsKey(key)&&refresh==false)
				{
					result = AccessedCodes[key];
				}
				else
				{
					result = (from c in CodesBBV3
							  where c.CodeType.ToLower() == codetype.ToLower() && c.CodeName.ToLower() == codename.ToLower()
							  select c.Code).First();
					AccessedCodes.TryAdd(key, result);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public (bool status, string file) BBV3(string directory, string extension, string vendor, List<string> excludeoptionals, (Bulk.PurchaseOrder.Header header, List<Bulk.PurchaseOrder.Detail> details) purchaseorder)
		{
			bool success = false;
			string outputfilename = string.Empty;
			string filename;
			
			try
			{
				DateTime filecreation = DateTime.Now;
				filename = $"P{purchaseorder.header.PONumber.PadLeft(8,'0')}_{filecreation.ForFilesSecondsSinceMidnight()}.fbo";
				List<DataHPBEDI.Models.MetaData.VendorStoreData> VendorStore;
				using (FormatBBV3.Logic.Data.PurchaseOrder.Files bbv = new FormatBBV3.Logic.Data.PurchaseOrder.Files())
				{
					bbv.CreateBatch(filename, vendor);
				}
				using (DataHPBEDI.Logic.MetaData.Retreive meta = new DataHPBEDI.Logic.MetaData.Retreive())
				{
					VendorStore = meta.VendorStoreData(vendor, new List<string> { purchaseorder.header.ShipToLoc } ).ToList();
				}
				List < FormatBBV3.Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail > items = new List<FormatBBV3.Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail>();
				foreach (Bulk.PurchaseOrder.Detail detail in purchaseorder.details.OrderBy(f => f.LineNo))
				{
					items.Add
					(
						new FormatBBV3.Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail()
						{
							LineItemDetail = new FormatBBV3.Models.Files.PurchaseOrder.R40_LineItemDetail()
							{
								PONumber = purchaseorder.header.PONumber,
								LineItemPONumber = detail.LineNo,
								ItemNumber = detail.ItemIdentifier,
								BackorderCode_Linelevel = GetCode("backordercodes","no back orders").FirstChar(),
								SpecialActionCode = " ", // no imprint
								DDCFulfillmentorSplitLineOrdering_Linelevel = GetCode("YesNo","No").FirstChar(), // do not split
								ItemNumberType = detail.ItemIDCode
							},
							AdditionalLineItemDetail = new FormatBBV3.Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail()
							{
								PONumber = purchaseorder.header.PONumber,
								// OPT: BackorderCancellationDate_LineLevel
								OrderQuantity = detail.Quantity,
								ClientItemNumber = $"{purchaseorder.header.OrderId}.{detail.OrderItemId}"
							},
							// OPT: Imprint = "",
							// OPT: StickerBarcodeDataRecord = "",
							// OPT: StickerTextLines = "",
						}
					);
				}
				FormatBBV3.Models.Files.PurchaseOrder.DataSequence.V3 order = new FormatBBV3.Models.Files.PurchaseOrder.DataSequence.V3
				{
					FileHeaderRecord = new FormatBBV3.Models.Files.PurchaseOrder.R00_ClientFileHeader()
					{
						FileSourceSAN = "0".Replicate(7),
						FileSourceName = "HPB",
						CreationDate = DateTime.Now,
						Filename = filename,
						IngramSAN = GetCode("Accounts","Ingram SAN"),
						VendorNameFlag = GetCode("VendorFlags","Ingram").FirstChar(),						
						ProductDescription = "BULK",
					},
					PurchaseOrders = new List<FormatBBV3.Models.Files.PurchaseOrder.DataSequence.PurchaseOrder>(),
					PurchaseOrderTrailerRecord = new FormatBBV3.Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer
					{
						PONumber = purchaseorder.header.PONumber,
						TotalPurchaseOrderRecords = 1,
						TotalLineItemsInFile = (short)(from f in purchaseorder.details select f).Count(),
						TotalUnitsOrdered = (short)((from f in purchaseorder.details select (int)(short)f.Quantity).Sum()),					
					},
					FileTrailerRecord = new FormatBBV3.Models.Files.PurchaseOrder.R90_FileTrailer()
				};
				FormatBBV3.Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions special;
				if (excludeoptionals.Contains("20"))
				{
					special = new FormatBBV3.Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions();
				}
				else
				{
					special = new FormatBBV3.Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions
					{
						PONumber = purchaseorder.header.PONumber,
						SpecialHandlingPrefix = PurchaseOrders.SpecialHandlingPrefix.Standard.ToStringValue().FirstChar(),
						SpecialHandlingCodes = PurchaseOrders.SpecialHandlingCodes.Default.ToStringValue(),
					};
				}
				order.PurchaseOrders.Add
				(
					new FormatBBV3.Models.Files.PurchaseOrder.DataSequence.PurchaseOrder()
					{
						ClientHeaderRecord = new FormatBBV3.Models.Files.PurchaseOrder.R10_ClientHeader()
						{
							PONumber = purchaseorder.header.PONumber,
							IngramBillToAccountNumber = GetCode("Accounts", "BillToAccount"),							
							VendorSAN = GetCode("Accounts","Ingram SAN"),
							OrderDate = purchaseorder.header.IssueDate,
							// OPT: BackorderCancellationDate= 
							BackorderCode =  GetCode("BackOrderCodes","No Back Orders"),
							DDCFulfillmentorSplitLineOrdering_Orderlevel =  GetCode("Distribution Center Fullfillment", "Do Not Split").FirstChar(),
							RecipientOrShiptoAddressIndicator = GetCode("YesNo","No").FirstChar(),
							PurchasingConsumerOrOrderedByAddressIndicator = GetCode("YesNo","No").FirstChar(),
							// OPT: DoNotShipBeforeDate=
						},
						FixedHandlingInstructionsRecord = special,
						PurchaseOrderOptionsRecord = new FormatBBV3.Models.Files.PurchaseOrder.R21_PurchaseOrderOptions()
						{
							PONumber = purchaseorder.header.PONumber,
							IngramShipToAccountNumber = VendorStore[0].VendorShipTo,
							POType = GetCode("Purchase Order Type", "Purchase Order"),
							OrderTypeCode = GetCode("Backorder Hold and Release", "Account Profile Setting"),
							DCCode =GetCode("Distribution Center Codes", "Account Profile Setting").FirstChar(),
							BackorderHoldAndReleaseIndicator =  GetCode("Backorder Hold and Release", "Account Profile Setting").FirstChar(),  //-- PurchaseOrders.BackorderHoldAndRelease.UseAccountProfileSettings.ToStringValue().FirstChar(),
							ExtendedPOAStatusCodes = GetCode("YesNo", "Yes").FirstChar(),
							DCPairs = GetCode("YesNo", "Account Profile Setting").FirstChar(),
							POATypeCode = '1', // need to change this
							IngramShipToAccountPassword = order.FileHeaderRecord.VendorNameFlag == GetCode("VendorFlags", "IPS").FirstChar() ? GetCode("Accounts", "ShipToPassword") : "",
							// OPT: CarrierOrShippingMethod = "",
							SplitLineIndicator_OrderLevel = GetCode("YesNo", "Account Profile Setting").FirstChar(), //-- PurchaseOrders.YesNo.UseAccountProfileSetttings.ToStringValue().FirstChar(),
							CarrierOrShippingMethod = GetCode("Shipping Codes", "Acocunt Default"), //-- PurchaseOrders.ShippingCodes.UseAccountProfileSettings.ToStringValue(),
						},
						PurchaseOrderDetails = items,
					}
				);
				// generate total counts
				order.FileTrailerRecord.TotalUnitsOrdered = (short)((from f in purchaseorder.details select (int)(short)f.Quantity).Sum());
				order.FileTrailerRecord.RecordCount00_09 = (short)(order.FileHeaderRecord != null ? 1 : 0); // should only be 1 
				order.FileTrailerRecord.RecordCount10_19 = (short)(order.PurchaseOrders.Count()); // 1 record per po
				order.FileTrailerRecord.RecordCount20_29 = (short)(order.PurchaseOrders.Count() + order.PurchaseOrders.Count()); // 2 per each PO
				order.FileTrailerRecord.RecordCount30_39 = 0;  // No record types 30-39 for this file format
				order.FileTrailerRecord.RecordCount40_49 = (short)(purchaseorder.details.Count() * 2); // 2 lines per each item
				order.FileTrailerRecord.RecordCount50_59 = (short)(order.PurchaseOrders.Count()); // 1 record per PO
				order.FileTrailerRecord.RecordCount60_69 = 0; // No record types 60-69 for this file format
				order.FileTrailerRecord.RecordCount70_79 = 0; // No record types 70-79 for this file format
				order.FileTrailerRecord.RecordCount80_99 = (short)(order.FileTrailerRecord != null ? 1 : 0); // should only be 1
				using (FormatBBV3.Logic.Data.PurchaseOrder.Files bbvPO = new FormatBBV3.Logic.Data.PurchaseOrder.Files())
				{
					if (order != null)
					{
						outputfilename = $@"{directory}out\{filecreation.ForFilesCCYYMMDD()}\{filename}{extension}";
						if (!System.IO.Directory.Exists($@"{directory}\out\{filecreation.ForFilesCCYYMMDD()}\"))
						{
							System.IO.Directory.CreateDirectory($@"{directory}\out\{filecreation.ForFilesCCYYMMDD()}\");
						}
						bbvPO.WriteFileAddingSequence(outputfilename, order, false);						
					}
				}
				success = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				success = false;
			}
			return(success, outputfilename);
		}

		public (bool status, string file) CDFL(string directory, string extension, string vendor, (Direct.PurchaseOrder.Header header, List<Direct.PurchaseOrder.Detail> details) purchaseorder)
		{
			bool success = false;
			string outputfilename = string.Empty;
			string filename;

			try
			{
				DateTime filecreation = DateTime.Now;
				filename = $"P{purchaseorder.header.PONumber.PadLeft(8, '0')}_{filecreation.ForFilesSecondsSinceMidnight()}.fbo";
				List<DataHPBEDI.Models.MetaData.VendorStoreData> VendorStore;
				using (FormatCDFL.Logic.Data.PurchaseOrder.Files cdfl = new FormatCDFL.Logic.Data.PurchaseOrder.Files())
				{
					cdfl.CreateBatch(filename, vendor);
				}
				using (DataHPBEDI.Logic.MetaData.Retreive meta = new DataHPBEDI.Logic.MetaData.Retreive())
				{
					VendorStore = meta.VendorStoreData(vendor, new List<string> { purchaseorder.header.ShipToLoc }).ToList();
				}
				//?? List<FormatCDFL.Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail> items = new List<FormatCDFL.Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail>();
				foreach (Direct.PurchaseOrder.Detail detail in purchaseorder.details.OrderBy(f => f.LineNo))
				{
					//?? items.Add
					//?? (
					//?? 	new FormatCDFL.Models.Files.PurchaseOrder.DataSequence.PurchaseOrderDetail()
					//?? 	{
					//?? 		LineItemDetail = new FormatCDFL.Models.Files.PurchaseOrder.R40_LineItem()
					//?? 		{
					//?? 			PONumber = purchaseorder.header.PONumber,
					//?? 			LineItemPONumber = detail.LineNo,
					//?? 			ItemNumber = detail.ItemIdentifier,
					//?? 			LineLevelBackorderCode = PurchaseOrders.BackOrderCodes.NoBackOrders.ToStringValue().FirstChar(),
					//?? 			SpecialActionCode = " ", // no imprint
					//?? 			//?? DDCFulfillmentorSplitLineOrdering_Linelevel = PurchaseOrders.YesNo.No.ToStringValue().FirstChar(), // do not split
					//?? 			ItemNumberType = detail.ItemIDCode
					//?? 		},
					//?? 		AdditionalLineItemDetail = new FormatCDFL.Models.Files.PurchaseOrder.R41_AdditionalLineItem()
					//?? 		{
					//?? 			PONumber = purchaseorder.header.PONumber,
					//?? 			// OPT: BackorderCancellationDate_LineLevel
					//?? 			OrderQuantity = detail.Quantity,
					//?? 			ClientItemListPrice = 0,
					//?? 			LineLevelBackorderCancelDate  =default(DateTime),
					//?? 			LineLevelGiftWrapCode = string.Empty ,								
					//?? 			//?? ClientItemNumber = $"{purchaseorder.header.OrderId}.{detail.OrderItemId}"
					//?? 		},
					//?? 		// OPT: Imprint = "",
					//?? 		// OPT: StickerBarcodeDataRecord = "",
					//?? 		// OPT: StickerTextLines = "",
					//?? 	}
					//?? );
				}
				FormatCDFL.Models.Files.PurchaseOrder.DataSequence.V3 order = new FormatCDFL.Models.Files.PurchaseOrder.DataSequence.V3
				{
					FileHeaderRecord = new FormatCDFL.Models.Files.PurchaseOrder.R00_FileHeader()
					{
						FileSourceSAN = "0".Replicate(7),
						FileSourceName = "HPB",
						CreationDate = DateTime.Now,
						FileName= filename,
						IngramSAN = GetCode("Accounts", "Ingram SAN"),  //--  PurchaseOrders.Ingram.IngramSAN.ToStringValue(),
						VendorNameFlag = GetCode("VendorFlags","Ingram").FirstChar(), //-- PurchaseOrders.Ingram.VendorFlagIngram.ToString().FirstChar(),
						ProductDescription = "BULK",
					},
					PurchaseOrders = new List<FormatCDFL.Models.Files.PurchaseOrder.DataSequence.PurchaseOrder>(),
					//?? PurchaseOrderTrailerRecord = new FormatCDFL.Models.Files.PurchaseOrder.R50_PurchaseOrderControl
					//?? {
					//?? 	PONumber = purchaseorder.header.PONumber,
					//?? 	TotalPurchaseOrderRecords = 1,
					//?? 	TotalLineItemsInfile = (short)(from f in purchaseorder.details select f).Count(),
					//?? 	TotalUnitsOrdered = (short)((from f in purchaseorder.details select (int)(short)f.Quantity).Sum()),
					//?? },
					FileTrailerRecord = new FormatCDFL.Models.Files.PurchaseOrder.R90_FileTrailer()
				};
				order.PurchaseOrders.Add
				(
					new FormatCDFL.Models.Files.PurchaseOrder.DataSequence.PurchaseOrder()
					{
						ClientHeaderRecord = new FormatCDFL.Models.Files.PurchaseOrder.R10_ClientHeader()
						{
							PONumber = purchaseorder.header.PONumber,
							IngramBillToAccountNumber = GetCode("Accounts", "BillToAccount"), //--PurchaseOrders.Ingram.BillToAccount.ToStringValue(),
							VendorSAN = GetCode("Accounts","Ingram SAN"), //--PurchaseOrders.Ingram.IngramSAN.ToStringValue(),
							OrderDate = purchaseorder.header.IssueDate,
							// OPT: BackorderCancellationDate= 
							BackorderCode = GetCode("BackOrderCodes", "No Back Orders").FirstChar(), //--  PurchaseOrders.BackOrderCodes.NoBackOrders.ToStringValue().FirstChar(),
							DDCFulfillmentOrSplitLineOrdering =  GetCode("Distribution Center Fullfillment", "Do Not Split").FirstChar(), //-- PurchaseOrders.DDCFulfillment.DoNotSplit.ToStringValue().FirstChar(),
							ShipToIndicator = GetCode("YesNo", "No").FirstChar() == 'Y' ? true : false,//--(PurchaseOrders.YesNo.No.ToStringValue().ToUpper().FirstChar() == 'Y' ? true : false),
							BillToIndicator = GetCode("YesNo", "No").FirstChar() == 'Y' ? true : false,//--(PurchaseOrders.YesNo.No.ToStringValue().ToUpper().FirstChar() == 'Y' ? true : false),
							// OPT: DoNotShipBeforeDate=
						},
						FixedHandlingInstructionsRecord = new FormatCDFL.Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions()
						{
							PONumber = purchaseorder.header.PONumber,							
							//?? SpecialHandlingPrefix = PurchaseOrders.SpecialHandlingPrefix.Standard.ToStringValue().FirstChar(),
							SpecialHandlingCodes = PurchaseOrders.SpecialHandlingCodes.Default.ToStringValue(),
						},
						PurchaseOrderOptionsRecord = new FormatCDFL.Models.Files.PurchaseOrder.R21_PurchaseOrderOptions()
						{
							//?? PONumber = purchaseorder.header.PONumber,
							//?? IngramShipToAccountNumber = VendorStore[0].VendorShipTo,
							//?? POType = PurchaseOrders.PurchaseOrderType.PurchaseOrder.ToStringValue().FirstChar(),
							//?? OrderTypeCode = PurchaseOrders.OrderTypeCodes.SingleHoldingOrder.ToStringValue(),
							//?? DCCode = PurchaseOrders.DistributionCenterCodes.UseAccountProfileSettings.ToStringValue().FirstChar(),
							//?? BackorderHoldAndReleaseIndicator = PurchaseOrders.BackorderHoldAndRelease.UseAccountProfileSettings.ToStringValue().FirstChar(),
							//?? ExtendedPOAStatusCodes = PurchaseOrders.YesNo.Yes.ToStringValue().FirstChar(),
							//?? DCPairs = PurchaseOrders.YesNo.UseAccountProfileSetttings.ToStringValue().FirstChar(),
							//?? POATypeCode = '1', // need to change this
							//?? IngramShipToAccountPassword = order.FileHeaderRecord.VendorNameFlag == 'P' ? PurchaseOrders.Ingram.ShipToPassword.ToStringValue() : "",
							//?? // OPT: CarrierOrShippingMethod = "",
							//?? SplitLineIndicator_OrderLevel = PurchaseOrders.YesNo.UseAccountProfileSetttings.ToStringValue().FirstChar(),
							//?? CarrierOrShippingMethod = PurchaseOrders.ShippingCodes.UseAccountProfileSettings.ToStringValue(),
						},
						//?? PurchaseOrderDetails = items,
					}
				);
				// generate total counts
				order.FileTrailerRecord.TotalUnitsOrdered = (short)((from f in purchaseorder.details select (int)(short)f.Quantity).Sum());
				order.FileTrailerRecord.RecordCount00To09 = (short)(order.FileHeaderRecord != null ? 1 : 0); // should only be 1 
				order.FileTrailerRecord.RecordCount10To19 = (short)(order.PurchaseOrders.Count()); // 1 record per po
				order.FileTrailerRecord.RecordCount20To29 = (short)(order.PurchaseOrders.Count() + order.PurchaseOrders.Count()); // 2 per each PO
				order.FileTrailerRecord.RecordCount30To39 = 0;  // No record types 30-39 for this file format
				order.FileTrailerRecord.RecordCount40To49 = (short)(purchaseorder.details.Count() * 2); // 2 lines per each item
				order.FileTrailerRecord.RecordCount50To59 = (short)(order.PurchaseOrders.Count()); // 1 record per PO
				order.FileTrailerRecord.RecordCount60To69 = 0; // No record types 60-69 for this file format
				order.FileTrailerRecord.RecordCount70To79 = 0; // No record types 70-79 for this file format
				order.FileTrailerRecord.RecordCount80To99 = (short)(order.FileTrailerRecord != null ? 1 : 0); // should only be 1
				using (FormatCDFL.Logic.Data.PurchaseOrder.Files cdflPO = new FormatCDFL.Logic.Data.PurchaseOrder.Files())
				{
					if (order != null)
					{
						outputfilename = $@"{directory}out\{filecreation.ForFilesCCYYMMDD()}\{filename}{extension}";
						if (!System.IO.Directory.Exists($@"{directory}\out\{filecreation.ForFilesCCYYMMDD()}\"))
						{
							System.IO.Directory.CreateDirectory($@"{directory}\out\{filecreation.ForFilesCCYYMMDD()}\");
						}
						cdflPO.WriteFileAddingSequence(outputfilename, order, false);					
					}

				}
				success = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				success = false;
			}
			return (success, outputfilename);
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
		// ~Create() {
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
