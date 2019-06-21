using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLib.Logic;
using CommonLib.Extensions;
using System.Linq;

namespace FormatCDFL.Logic.Data.ShipNotice
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

		public bool WriteFile(string filename, List<Models.Files.ShipNotice.DataSequence.V3> data)
		{
			List<object> writelist = new List<object>();
			bool success = false;
			string ClientOrderNumber = string.Empty;

			try
			{
				//build list
				foreach (Models.Files.ShipNotice.DataSequence.V3 dataitem in data)
				{
					writelist.Add(dataitem.CompanyRecord);
					if (dataitem.Shipments != null && dataitem.Shipments.Count > 0)
					{
						foreach (Models.Files.ShipNotice.DataSequence.Shipment item in dataitem.Shipments)
						{
							if (Common.IsValid(item.OrderRecord, false))
							{
								writelist.Add(item.OrderRecord);
								ClientOrderNumber = item.OrderDetail.LastItem().ClientOrderID;
							}

							foreach (Models.Files.ShipNotice.OD_OrderDetailRecord detail in (from od in item.OrderDetail.AsEnumerable() where od.ClientOrderID == ClientOrderNumber select od))
							{
								if (Common.IsValid(detail, false)) { writelist.Add(detail); }
							}
						}
					}
				}
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.ShipNotice.CR_CompanyRecord),
					typeof(Models.Files.ShipNotice.OD_OrderDetailRecord),
					typeof(Models.Files.ShipNotice.OR_OrderRecord)
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

		public List<Models.Files.ShipNotice.DataSequence.V3> ReadFile(string filename, int batchnumber)
		{
			List<Models.Files.ShipNotice.CR_CompanyRecord> saveRCR = null;
			List<Models.Files.ShipNotice.OR_OrderRecord> saveROR = null;
			List<Models.Files.ShipNotice.OD_OrderDetailRecord> saveROD = null;
			//
			List<Models.Files.ShipNotice.DataSequence.V3> file = null;
			Models.Files.ShipNotice.DataSequence.V3 notice = null;
			Models.Files.ShipNotice.DataSequence.Shipment shipment = new Models.Files.ShipNotice.DataSequence.Shipment();
			List<Models.Files.ShipNotice.OD_OrderDetailRecord> detail = new List<Models.Files.ShipNotice.OD_OrderDetailRecord>();
			string typename = string.Empty;
			int shipmentCount = 0;
			int detailCount = 0;
			int noticeCount = 0;

			try
			{
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.ShipNotice.CR_CompanyRecord),
					typeof(Models.Files.ShipNotice.OD_OrderDetailRecord),
					typeof(Models.Files.ShipNotice.OR_OrderRecord)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.ShipNotice.Selectors.V3.Custom)
				};
				var res = engine.ReadFile(filename);
				if (res != null && res.Length > 0)
				{
					file = new List<Models.Files.ShipNotice.DataSequence.V3>();
					foreach (var rec in res)
					{
						typename = rec.GetType().Name.ToUpper();
						switch (typename)
						{
							case "CR_COMPANYRECORD":
								Common.Initialize(ref saveRCR);
								saveRCR.Add((Models.Files.ShipNotice.CR_CompanyRecord)rec);
								if (noticeCount > 0)
								{
									if (detailCount > 0)
									{
										if (detail != null)
										{
											shipment.OrderDetail = detail;
											shipment.OrderRecord = saveROR.LastItem();
											detail = null;
											detailCount = 0;
										}
									}
									if (shipment != null)
									{
										if (notice.Shipments == null) { notice.Shipments = new List<Models.Files.ShipNotice.DataSequence.Shipment>(); }
										notice.Shipments.Add(shipment);
										shipment = null;
										shipmentCount = 0;
									}
									if (notice != null)
									{
										file.Add(notice);
										notice = null;
									}
								}
								noticeCount++;
								notice = new Models.Files.ShipNotice.DataSequence.V3()
								{
									CompanyRecord = saveRCR.LastItem()
								};
								break;

							case "OR_ORDERRECORD":
								Common.Initialize(ref saveROR);
								saveROR.Add((Models.Files.ShipNotice.OR_OrderRecord)rec);
								shipmentCount++;
								if (shipment == null)
								{
									shipment = new Models.Files.ShipNotice.DataSequence.Shipment()
									{
										OrderRecord = new Models.Files.ShipNotice.OR_OrderRecord(),
										OrderDetail = new List<Models.Files.ShipNotice.OD_OrderDetailRecord>()
									};
								}
								shipment.OrderRecord = saveROR.LastItem();
								break;

							case "OD_ORDERDETAILRECORD":
								Common.Initialize(ref saveROD);
								saveROD.Add((Models.Files.ShipNotice.OD_OrderDetailRecord)rec);
								if (detailCount == 0)
								{
									detail = new List<Models.Files.ShipNotice.OD_OrderDetailRecord>();
								}
								detailCount++;
								detail.Add(saveROD.LastItem());
								break;
						}
					}
					if (detail != null)
					{
						shipment.OrderDetail.AddRange(detail);
						detail = null;
						detailCount = 0;
						notice.Shipments.Add(shipment);
					}
					if(notice != null)
					{
						file.Add(notice);
						notice = null;
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


