using System;
using System.Collections.Generic;

namespace FormatBBV3.Logic.Data.PurchaseOrder
{
	public class SQL : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private string ActionType { get; set; } = "PurchaseOrder";
		private string FileFormat { get; set; } = "BBV3";
		public bool Successful { private set; get; }

		public SQL
		(
			int batchnumber,
			List<Models.Files.PurchaseOrder.R00_ClientFileHeader> items00,
			List<Models.Files.PurchaseOrder.R10_ClientHeader> items10,
			List<Models.Files.PurchaseOrder.R20_FixedSpecialHandlingInstructions> items20,
			List<Models.Files.PurchaseOrder.R21_PurchaseOrderOptions> items21,
			List<Models.Files.PurchaseOrder.R40_LineItemDetail> items40,
			List<Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail> items41,
			List<Models.Files.PurchaseOrder.R45_Imprint> items45,
			List<Models.Files.PurchaseOrder.R46_StickerBarcodeData> items46data,
			List<Models.Files.PurchaseOrder.R46_StickerTextLines> items46text,
			List<Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer> items50,
			List<Models.Files.PurchaseOrder.R90_FileTrailer> items90
		)
		{
			bool result = false;
			try
			{
				if (items00 != null && items00.Count > 0) { SaveR00_ClientFileHeader(items00, batchnumber);  }
				if (items10 != null && items10.Count > 0) { SaveR10_ClientHeader(items10, batchnumber); }
				if (items20 != null && items20.Count > 0) { SaveR20_FixedSpecialHandlingInstructions(items20, batchnumber); }
				if (items21 != null && items21.Count > 0) { SaveR21_PurchaseOrderOptions(items21, batchnumber); }
				if (items40 != null && items40.Count > 0) { SaveR40_LineItemDetail(items40, batchnumber); }
				if (items41 != null && items41.Count > 0) { SaveR41_AdditionalLineItemDetail(items41, batchnumber); }
				if (items45 != null && items45.Count > 0) { SaveR45_Imprint(items45, batchnumber); }
				if (items46data != null && items46data.Count > 0) { SaveR46_StickerBarcode(items46data, batchnumber); }
				if (items46text != null && items46text.Count > 0) { SaveR46_StickerTextLines(items46text, batchnumber); }
				if (items50 != null && items50.Count > 0) { SaveR50_PurchaseOrderTrailer(items50, batchnumber); }
				if (items90 != null && items90.Count > 0) { SaveR90_FileTrailer(items90, batchnumber); }
				result = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				result = false;
			}
			Successful= result;
		}

		public bool SaveR00_ClientFileHeader(List<Models.Files.PurchaseOrder.R00_ClientFileHeader> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R00_ClientFileHeader>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "RecordCode","RecordCode"),
							( 3, "SequenceNumber","SequenceNumber"),
							( 4, "FileSourceSAN","FileSourceSAN"),
							( 5, "FileSourceName","FileSourceName"),
							( 6, "CreationDate","CreationDate"),
							( 7, "Filename","Filename"),
							( 8, "FormatVersion","FormatVersion"),
							( 9, "IngramSAN","IngramSAN"),
							(10, "VendorNameFlag","VendorNameFlag"),
							(11, "ProductDescription","ProductDescription"),
						},
						new List<string> { "reserved015_019", "reserved071_075" }
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
							( 3, "SequenceNumber","SequenceNumber"),
							( 4, "PONumber","PONumber"),
							( 5, "IngramBillToAccountNumber","IngramBillToAccountNumber"),
							( 6, "VendorSAN","VendorSAN"),
							( 7, "OrderDate","OrderDate"),
							( 8, "BackorderCancellationDate","BackorderCancellationDate"),
							( 9, "BackorderCode","BackorderCode"),
							(10, "DDCFulfillmentorSplitLineOrderingOrderlevel","DDCFulfillmentorSplitLineOrderingOrderlevel"),
							(11, "RecipientOrShiptoAddressIndicator","RecipientOrShiptoAddressIndicator"),
							(12, "PurchasingConsumerOrOrderedByAddressIndicator","PurchasingConsumerOrOrderedByAddressIndicator"),
							(13, "DoNotShipbeforedate","DoNotShipbeforedate"),
						},
						new List<string> { "reserved058_066", "reserved075_080" }
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
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),
							(5, "SpecialHandlingPrefix","SpecialHandlingPrefix"),
							(6, "SpecialHandlingCodes","SpecialHandlingCodes"),
						},
						new List<string> { "reserved035_080" }
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
							( 3, "SequenceNumber","SequenceNumber"),
							( 4, "PONumber","PONumber"),
							( 5, "IngramShipToAccountNumber","IngramShipToAccountNumber"),
							( 6, "POType","POType"),
							( 7, "OrderTypeCode","OrderTypeCode"),
							( 8, "DCCode","DCCode"),
							( 9, "BackorderHoldAndReleaseIndicator","BackorderHoldAndReleaseIndicator"),
							(10, "ExtendedPOAStatusCodes","ExtendedPOAStatusCodes"),
							(11, "DCPairs","DCPairs"),
							(12, "POATypeCode","POATypeCode"),
							(13, "IngramShipToAccountPassword","IngramShipToAccountPassword"),
							(14, "CarrierOrShippingMethod","CarrierOrShippingMethod"),
							(15, "SplitLineIndicatorOrderLevel","SplitLineIndicatorOrderLevel"),
						},
						new List<string> { "reserved078", "reserved080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR40_LineItemDetail(List<Models.Files.PurchaseOrder.R40_LineItemDetail> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R40_LineItemDetail>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "RecordCode","RecordCode"),
							( 3, "SequenceNumber","SequenceNumber"),
							( 4, "PONumber","PONumber"),
							( 5, "LineItemPONumber","LineItemPONumber"),
							( 6, "ItemNumber","ItemNumber"),
							( 7, "BackorderCodeLinelevel","BackorderCodeLinelevel"),
							( 8, "SpecialActionCode","SpecialActionCode"),
							( 9, "DDCFulfillmentorSplitLineOrderingLinelevel","DDCFulfillmentorSplitLineOrderingLinelevel"),
							(10, "ItemNumberType","ItemNumberType"),
						},
						new List<string> { "reserved072_074" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR41_AdditionalLineItemDetail(List<Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R41_AdditionalLineItemDetail>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),
							(5, "BackorderCancellationDate_LineLevel","BackorderCancellationDate_LineLevel"),
							(6, "OrderQuantity","OrderQuantity"),
							(7, "ClientItemNumber","ClientItemNumber"),
						},
						new List<string> { "reserved030_037", "reserved044_046", "reserved074_080" }
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
							( 3, "SequenceNumber","SequenceNumber"),
							( 4, "PONumber","PONumber"),
							( 5, "ImprintCode","ImprintCode"),
							( 6, "ImprintTextandSymbols","ImprintTextandSymbols"),
							( 7, "ImprintFontCode","ImprintFontCode"),
							( 8, "ImprintColorCode","ImprintColorCode"),
							( 9, "ImprintPositionCode","ImprintPositionCode"),
							(10, "ImprintAppendCode","ImprintAppendCode")
						},
						new List<string> { "reserved065_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR46_StickerBarcode(List<Models.Files.PurchaseOrder.R46_StickerBarcodeData> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R46_StickerBarcodeData>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),
							(5, "BarcodeTypeCode","BarcodeTypeCode"),
							(6, "StringforBarcode","StringforBarcode"),
						},
						new List<string> { "reserved050_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR46_StickerTextLines(List<Models.Files.PurchaseOrder.R46_StickerTextLines> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R46_StickerTextLines>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),
							(5, "StickerTextLine","StickerTextLine"),
						},
						new List<string> { "reserved064_080" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveR50_PurchaseOrderTrailer(List<Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "RecordCode","RecordCode"),
							(3, "SequenceNumber","SequenceNumber"),
							(4, "PONumber","PONumber"),
							(5, "TotalPurchaseOrderRecords","TotalPurchaseOrderRecords"),
							(6, "TotalLineItemsinfile","TotalLineItemsinfile"),
							(7, "TotalUnitsOrdered","TotalUnitsOrdered"),
						},
						new List<string> { "reserved055_080" }
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
							( 3, "SequenceNumber","SequenceNumber"),
							( 4, "TotalLineItemsinfile","TotalLineItemsinfile"),
							( 5, "TotalPurchaseOrderRecords","TotalPurchaseOrderRecords"),
							( 6, "TotalUnitsOrdered","TotalUnitsOrdered"),
							( 7, "RecordCount00_09","RecordCount00_09"),
							( 8, "RecordCount10_19","RecordCount10_19"),
							( 9, "RecordCount20_29","RecordCount20_29"),
							(10, "RecordCount30_39","RecordCount30_39"),
							(11, "RecordCount40_49","RecordCount40_49"),
							(12, "RecordCount50_59","RecordCount50_59"),
							(13, "RecordCount60_69","RecordCount60_69"),
							(14, "RecordCount70_79","RecordCount70_79"),
							(15, "RecordCount80_99","RecordCount80_99"),
						},
						new List<string> { }
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

		#endregion IDisposable Support
	}
}