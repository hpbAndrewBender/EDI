using System;
using System.Collections.Generic;

namespace FormatCDFL.Logic.Data.ShipNotice
{
	public class SQL
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private string ActionType { get; set; } = "ShipNotice";
		private string FileFormat { get; set; } = "CDFL";

		public bool Save
		(
			int batchnumber,
			List<Models.Files.ShipNotice.CR_CompanyRecord> itemscr,
			List<Models.Files.ShipNotice.OD_OrderDetailRecord> itemsod,
			List<Models.Files.ShipNotice.OR_OrderRecord> itemsor
		)
		{
			bool success = false;
			try
			{
				if (itemscr != null && itemscr.Count > 0) { SaveCR_CompanyRecord(itemscr, batchnumber); }
				if (itemsod != null && itemsod.Count > 0) { SaveOD_OrderDetailRecord(itemsod, batchnumber); }
				if (itemsor != null && itemsor.Count > 0) { SaveOR_OrderRecord(itemsor, batchnumber); }
				success = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				success = false;
			}
			return success;
		}

		public bool SaveCR_CompanyRecord(List<Models.Files.ShipNotice.CR_CompanyRecord> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.ShipNotice.CR_CompanyRecord>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "CompanyRecordIdentifier","CompanyRecordIdentifier"),
							(3, "CompanyAccountIDNumber","CompanyAccountIDNumber"),
							(4, "TotalOrderCount","TotalOrderCount"),
							(5, "FileVersionNumber","FileVersionNumber"),
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

		public bool SaveOD_OrderDetailRecord(List<Models.Files.ShipNotice.OD_OrderDetailRecord> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.ShipNotice.OD_OrderDetailRecord>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "OrderRecordIdentifier",""),
							( 3, "ClientOrderID",""),
							( 4, "ShippingWarehouseCode",""),
							( 5, "IngramOrderEntryNumber",""),
							( 6, "QuantityCancelled",""),
							( 7, "ISBN10Ordered",""),
							( 8, "ISBN10Shipped",""),
							( 9, "QuantityPredicted",""),
							(10, "QuantitySlashed",""),
							(11, "QuantityShipped",""),
							(12, "ItemDetailStatusCode",""),
							(13, "TrackingNumber",""),
							(14, "SCAC",""),
							(15, "IngramItemListPrice",""),
							(16, "NetOrDiscountedPrice","NetOrDiscountedPrice"),
							(17, "LineItemIDNumber","LineItemIDNumber"),
							(18, "SSL","SSL"),
							(19, "Weight","Weight"),
							(20, "ShippingMethodCodeorSlashOrCancelReasonCode","ShippingMethodCodeorSlashOrCancelReasonCode"),
							(21, "ISBN13OrEAN","ISBN13OrEAN"),
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

		public bool SaveOR_OrderRecord(List<Models.Files.ShipNotice.OR_OrderRecord> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.ShipNotice.OR_OrderRecord>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "OrderRecordIdentifier","OrderRecordIdentifier"),
							( 3, "ClientOrderID","ClientOrderID"),
							( 4, "OrderStatusCode","OrderStatusCode"),
							( 5, "OrderSubtotal","OrderSubtotal"),
							( 6, "OrderDiscountAmount","OrderDiscountAmount"),
							( 7, "SalesTax","SalesTax"),
							( 8, "ShippingandHandling","ShippingandHandling"),
							( 9, "OrderTotal","OrderTotal"),
							(10, "FreightCharge","FreightCharge"),
							(11, "TotalItemDetailCount","TotalItemDetailCount"),
							(12, "ShipmentDate","ShipmentDate"),
							(13, "ConsumerPONumber","ConsumerPONumber")
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