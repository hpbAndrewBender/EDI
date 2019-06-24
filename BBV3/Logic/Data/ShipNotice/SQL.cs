using System;
using System.Collections.Generic;

namespace FormatBBV3.Logic.Data.ShipNotice
{
	public class SQL : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private string ActionType { get; set; } = "ShipNotice";
		private string FileFormat { get; set; } = "BBV3";
		public bool Successful { private set; get; }

		public SQL
		(
			int batchnumber,
			List<Models.Files.ShipNotice.CR_ASNCompany> itemsCR,
			List<Models.Files.ShipNotice.OD_ASNShipmentDetail> itemsOD,
			List<Models.Files.ShipNotice.OP_ASNPack> itemsOP,
			List<Models.Files.ShipNotice.OR_ASNShipment> itemsOR
		)
		{
			bool result = false;
			try
			{
				if (itemsCR != null && itemsCR.Count > 0) { SaveCR_ASNCompany(itemsCR,batchnumber); };
				if (itemsOD != null && itemsOD.Count > 0) { SaveOD_ASNShipmentDetail(itemsOD,batchnumber); };
				if (itemsOP != null && itemsOP.Count > 0) { SaveOP_ASNPack(itemsOP,batchnumber); };
				if (itemsOR != null && itemsOR.Count > 0) { SaveOR_ASNShipment(itemsOR,batchnumber); };															   
				result = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				result = false;
			}
			Successful =  result;
		}

		public bool SaveCR_ASNCompany(List<Models.Files.ShipNotice.CR_ASNCompany> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.ShipNotice.CR_ASNCompany>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "CompanyRecordIdentifier","CompanyRecordIdentifier"),
							(3, "IngramShipToAccountNumber","IngramShipToAccountNumber"),
						},
						new List<string> { "reserved010_200" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveOD_ASNShipmentDetail(List<Models.Files.ShipNotice.OD_ASNShipmentDetail> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.ShipNotice.OD_ASNShipmentDetail>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "DetailRecordIdentifier","DetailRecordIdentifier"),
							(3, "LineItemIdNumber","LineItemIdNumber"),
							(4, "ISBN13OrEAN","ISBN13OrEAN"),
							(5, "QuantityPredictedtoShip","QuantityPredictedtoShip"),
							(6, "QuantityShipped","QuantityShipped"),
							(7, "IngramItemListPrice","IngramItemListPrice"),
							(8, "NetOrDiscountedPrice","NetOrDiscountedPrice"),
						},
						new List<string> { "reserved040_062", "reserved067_200" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveOP_ASNPack(List<Models.Files.ShipNotice.OP_ASNPack> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.ShipNotice.OP_ASNPack>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							( 1, "BatchId","BatchId"),
							( 2, "PackRecordIdentifier","PackRecordIdentifier"),
							( 3, "ShippingDCCode","ShippingDCCode"),
							( 4, "SSL","SSL"),
							( 5, "TrackingNumber","TrackingNumber"),
							( 6, "SCAC","SCAC"),
							( 7, "CarrierActualNumber","CarrierActualNumber"),
							( 8, "Weight","Weight"),
							( 9, "NumberofUnitsinBox","NumberofUnitsinBox"),
							(10, "ShipmentDate","ShipmentDate"),
						},
						new List<string> { "reserved038_200" }
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public bool SaveOR_ASNShipment(List<Models.Files.ShipNotice.OR_ASNShipment> items, int batchnumber)
		{
			bool result = false;

			try
			{
				using (SaveTableSql save = new SaveTableSql())
				{
					result = save.SaveTable<Models.Files.ShipNotice.OR_ASNShipment>
					(
						batchnumber, items, FileFormat, ActionType, items.GetType().Name,
						new List<(int order, string source, string dest)>
						{
							(1, "BatchId","BatchId"),
							(2, "ShipmentRecordIdentifier","ShipmentRecordIdentifier"),
							(3, "PONumber","PONumber"),
							(4, "IngramOrderEntryNumber","IngramOrderEntryNumber"),
						},
						new List<string> { "reserved026_046", "reserved052_200" }
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