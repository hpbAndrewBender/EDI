using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using CommonLib.Logic;
using CommonLib.Extensions;

namespace FormatBBV3.Logic.Data.ShipNotice
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

		public bool WriteFile(string filename, Models.Files.ShipNotice.DataSequence.V3 data)
		{
			List<object> writelist = new List<object>();
			bool success = false;
			try
			{
				//build list
				writelist.Add(data.FileHeaderRecord);
				if (Common.IsValid(data.PackRecord, false)) { writelist.Add(data.PackRecord); }
				if (data.Shipments != null && data.Shipments.Count > 0)
				{
					foreach (Models.Files.ShipNotice.DataSequence.Shipment item in data.Shipments)
					{
						if (Common.IsValid(item.ShipmentRecord, false)) { writelist.Add(item.ShipmentRecord); }
						foreach (Models.Files.ShipNotice.OD_ASNShipmentDetail detail in item.LineItemDetailRecords)
						{
							if (Common.IsValid(detail, false)) { writelist.Add(detail); }
						}
					}
				}
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.ShipNotice.CR_ASNCompany),
					typeof(Models.Files.ShipNotice.OP_ASNPack),
					typeof(Models.Files.ShipNotice.OR_ASNShipment),
					typeof(Models.Files.ShipNotice.OD_ASNShipmentDetail)
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

		public Models.Files.ShipNotice.DataSequence.V3 ReadFile(string filename, int batchnumber)
		{
			List<Models.Files.ShipNotice.CR_ASNCompany> cr = null;
			List<Models.Files.ShipNotice.OP_ASNPack> op = null;
			List<Models.Files.ShipNotice.OR_ASNShipment> or = null;
			List<Models.Files.ShipNotice.OD_ASNShipmentDetail> od = null;
			//
			Models.Files.ShipNotice.DataSequence.V3 file = null;
			List<Models.Files.ShipNotice.DataSequence.Shipment>  allShipments = new List<Models.Files.ShipNotice.DataSequence.Shipment>();
			Models.Files.ShipNotice.DataSequence.Shipment singleShipment = new Models.Files.ShipNotice.DataSequence.Shipment();
			List<Models.Files.ShipNotice.OD_ASNShipmentDetail> details = new List<Models.Files.ShipNotice.OD_ASNShipmentDetail>();
			//
			string typename = string.Empty;
			int shipmentsCount = 0;
			int detailsCount = 0;

			try
			{
				MultiRecordEngine engine = new MultiRecordEngine
				(
					typeof(Models.Files.ShipNotice.CR_ASNCompany),
					typeof(Models.Files.ShipNotice.OP_ASNPack),
					typeof(Models.Files.ShipNotice.OR_ASNShipment),
					typeof(Models.Files.ShipNotice.OD_ASNShipmentDetail)
				)
				{
					RecordSelector = new RecordTypeSelector(Models.Files.ShipNotice.Selectors.V3.Custom)
				};

				var res = engine.ReadFile(filename);
				if (res != null && res.Length > 0)
				{
					file = new Models.Files.ShipNotice.DataSequence.V3();
					foreach (var rec in res)
					{
						typename = rec.GetType().Name.ToUpper();
						switch (typename)
						{
							case "CR_ASNCOMPANY":
								Common.Initialize(ref cr);
								cr.Add((Models.Files.ShipNotice.CR_ASNCompany)rec);
								file.FileHeaderRecord = cr.LastItem();
								break;

							case "OP_ASNPACK":
								Common.Initialize(ref op) ;
								op.Add((Models.Files.ShipNotice.OP_ASNPack)rec);
								file.PackRecord = op.LastItem();
								break;

							case "OR_ASNSHIPMENT":
								Common.Initialize(ref or);
								or.Add((Models.Files.ShipNotice.OR_ASNShipment)rec);
								if(shipmentsCount > 0)
								{
									if(details!=null)
									{
										singleShipment.LineItemDetailRecords.AddRange(details);
										details = null;
										detailsCount = 0;
									}
									if(file.Shipments==null) { file.Shipments = new List<Models.Files.ShipNotice.DataSequence.Shipment>(); }
									file.Shipments.Add(singleShipment);
								}
								shipmentsCount++;
								singleShipment = new Models.Files.ShipNotice.DataSequence.Shipment()
								{
									ShipmentRecord = new Models.Files.ShipNotice.OR_ASNShipment(),
									LineItemDetailRecords = new List<Models.Files.ShipNotice.OD_ASNShipmentDetail>()
								};
								singleShipment.ShipmentRecord = or.LastItem();
								break;

							case "OD_ASNSHIPMENTDETAIL":
								Common.Initialize(ref od);
								od.Add((Models.Files.ShipNotice.OD_ASNShipmentDetail)rec);
								if (detailsCount == 0)
								{
									details = new List<Models.Files.ShipNotice.OD_ASNShipmentDetail>();
								}
								detailsCount++;
								details.Add(od.LastItem());
								break;
						}
					}
					if (details != null)
					{
						singleShipment.LineItemDetailRecords.AddRange(details);
						details = null;
						detailsCount = 0;
						file.Shipments.Add(singleShipment);
					}
					using (SQL sql = new SQL())
					{
						// add batch info
						sql.SaveCR_ASNCompany(cr, batchnumber);
						sql.SaveOD_ASNShipmentDetail(od, batchnumber);
						sql.SaveOP_ASNPack(op, batchnumber);
						sql.SaveOR_ASNShipment(or, batchnumber);
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
