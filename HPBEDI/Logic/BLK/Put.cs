﻿using CommonLib.Logic;
using CommonLib.SQL;
using CommonLib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Linq;

namespace DataHPBEDI.Logic.BLK
{
	public class Input : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public bool Invoice(List<(Models.BLK.Invoice.Header header, List<Models.BLK.Invoice.Detail> details)> invoices, byte version)
		{
			bool result = false;
			bool returnresult = false;
			List<string> invoiceignores = new List<string>
			{
				"invoiceid",
				"invoiceitemid",
				"reserved016_020",
				"reserved016_021",
				"reserved036_080",
				"reserved038_055",
				"reserved056",
				"reserved057_080",
				"reserved061",
				"reserved061_080",
				"reserved063_065",
				"reserved068_080",
				"reserved070_080",
				"reserved074",
				"reserved079_080"
			};

			try
			{
				foreach ((Models.BLK.Invoice.Header header, List<Models.BLK.Invoice.Detail> detail) in invoices)
				{
					using (CommonLib.SQL.Access data = new Access())
					{
						result = data.NonQuery
						(
							Tools.dbConn[$"EDI-{Globals.Env}"],
							new List<string>()
							{
								"BLK.uspInvoice_Insert"
							},
							new List<SqlParameter>()
							{
								new SqlParameter()
								{
									ParameterName = "@header",
									SqlDbType = SqlDbType.Structured,
									Value = (new List<Models.BLK.Invoice.Header> { header }).ToDataTable<Models.BLK.Invoice.Header>("TypeInvoiceHeader", invoiceignores)
								},
								new SqlParameter()
								{
									ParameterName = "@detail",
									SqlDbType = SqlDbType.Structured,
									Value = detail.ToDataTable<Models.BLK.Invoice.Detail>("TypeInvoiceDetail", invoiceignores)
								},
								new SqlParameter()
								{
									ParameterName = "@ediver",
									SqlDbType = SqlDbType.TinyInt,
									Value = version
								}
							},
							CommandType.StoredProcedure
						);
					}
				}
				returnresult = true;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				returnresult = false;
			}
			return returnresult;
		}

		public bool Acknowledge(List<(Models.BLK.Acknowledge.Header header, List<Models.BLK.Acknowledge.Detail> details)> acks, byte version)
		{
			bool result = false;
			List<string> acknowledgeignores = new List<string>
			{
				"ackid",
				"ackitemid",
				"reserved008_080",
				"reserved015_019",
				"reserved030_032",
				"reserved030_080",
				"reserved040_080",
				"reserved050_080",
				"reserved059_062",
				"reserved060_067",
				"reserved071_075",
				"reserved072_076",
				"reserved075_080",
				"reserved076_080",
				"reserved077_080",
				"reserved080",
				"edisourcetypeid"
			};

			try
			{
				foreach ((Models.BLK.Acknowledge.Header header, List<Models.BLK.Acknowledge.Detail> detail) in acks)
				{
					using (CommonLib.SQL.Access data = new Access())
					{
						result = data.Scalar<bool>
						(
							Tools.dbConn[$"EDI-{Globals.Env}"],
							new List<string>()
							{
								"BLK.uspAcknowledge_Insert"
							},
							new List<SqlParameter>()
							{
								new SqlParameter()
								{
									ParameterName = "@header",
									SqlDbType = SqlDbType.Structured,
									Value = (new List<Models.BLK.Acknowledge.Header> { header }).ToDataTable<Models.BLK.Acknowledge.Header>("TypeAcknowledgeHeader",acknowledgeignores)
								},
								new SqlParameter()
								{
									ParameterName = "@detail",
									SqlDbType = SqlDbType.Structured,
									Value = detail.ToDataTable<Models.BLK.Acknowledge.Detail>("TypeAcknowledgeDetail",acknowledgeignores)
								},
								new SqlParameter()
								{
									ParameterName = "@ediver",
									SqlDbType = SqlDbType.TinyInt,
									Value = version
								}
							},
							false
						);
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				result = false;
			}
			return result;
		}

		public bool Shipment(List<(Models.BLK.Shipment.Header header, List<Models.BLK.Shipment.Detail> details)> ships, byte version)
		{
			bool result = false;
			List<string> shipmentignores = new List<string>
			{
				"shipmentid",
				"shipmentitemid"
			};

			try
			{
				foreach ((Models.BLK.Shipment.Header header, List<Models.BLK.Shipment.Detail> detail) in ships)
				{
					using (CommonLib.SQL.Access data = new Access())
					{
						result = data.Scalar<bool>
						(
							Tools.dbConn[$"EDI-{Globals.Env}"],
							new List<string>()
							{
								"BLK.uspShipment_Insert"
							},
							new List<SqlParameter>()
							{
								new SqlParameter()
								{
									ParameterName = "@header",
									SqlDbType = SqlDbType.Structured,
									Value = (new List<Models.BLK.Shipment.Header> { header }).ToDataTable("TypeShipmentHeader", shipmentignores)
								},
								new SqlParameter()
								{
									ParameterName = "@detail",
									SqlDbType = SqlDbType.Structured,
									Value = detail.ToDataTable<Models.BLK.Shipment.Detail>("TypeShipmentDetail", shipmentignores)
								},
								new SqlParameter()
								{
									ParameterName = "@ediver",
									SqlDbType = SqlDbType.TinyInt,
									Value = version
								} 
							},
							false
						);
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				result = false;
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
		// ~Put() {
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