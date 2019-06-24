using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CommonLib.SQL;
using System.Data.SqlClient;
using System.Linq;
using CommonLib.Logic;
using CommonLib.Extensions;
using Bulk = DataHPBEDI.Models.BLK;

namespace DataHPBEDI.Logic.BLK
{
	public class Retrieve : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public (Bulk.PurchaseOrder.Header header, List<Bulk.PurchaseOrder.Detail> details) PurchaseOrder(string ordernumber)
		{
			Bulk.PurchaseOrder.Header header = null;
			List<Bulk.PurchaseOrder.Detail> details = null;
			DataSet data = null;
			try
			{
				using (Access read = new Access())
				{
					data = read.Set
					(
						Tools.dbConn[$"EDI-{Globals.Env}"],
						new List<string>() { "BLK.uspPurchaseOrder_Retrieve" },
						new List<SqlParameter>
						{
							new SqlParameter() { ParameterName="PONumber", SqlDbType = SqlDbType.VarChar, Value = ordernumber}
						}
					);
					if (data != null)
					{
						if (data.Tables.Count == 2)
						{
							if (data.Tables[0] != null && data.Tables[0].Rows.Count == 1)
							{
								header = (from DataRow row in data.Tables[0].Rows
										  select new Bulk.PurchaseOrder.Header()
										  {
											  BillToLoc = row.Field<string>("BillToLoc").ToString(),
											  BillToSAN = row.Field<string>("BillToSAN").ToString(),
											  InsertDateTime = row.Field<DateTime>("InsertDateTime"),
											  IssueDate = row.Field<DateTime>("IssueDate"),
											  OrderId = row.Field<int>("OrderId"),
											  PONumber = row.Field<string>("PONumber"),
											  Processed = row.Field<bool>("Processed"),
											  ProcessedDateTime = row.Field<DateTime>("ProcessedDateTime"),
											  ShipFromLoc = row.Field<string>("ShipFromLoc"),
											  ShipFromSAN = row.Field<string>("ShipFromSAN"),
											  ShipToLoc = row.Field<string>("ShipToLoc"),
											  ShipToSAN = row.Field<string>("ShipToSAN"),
											  TotalLines =row.Field<int>("TotalLines"),
											  TotalQuantity = row.Field<int>("TotalQuantity"),
											  VendorID = row.Field<string>("VendorID"),
										  }
										  ).First();
							};
							if (data.Tables[1] != null && data.Tables[1].Rows.Count > 0)
							{
								details = (from DataRow row in data.Tables[1].Rows
										   select new Bulk.PurchaseOrder.Detail
										   {
											   FillAmount = row.Field<string>("FillAmount"),
											   ItemFillTerms = row.Field<string>("ItemFillTerms"),
											   ItemIDCode = row.Field<string>("ItemIDCode"),
											   ItemIdentifier = row.Field<string>("ItemIdentifier"),
											   LineNo = row.Field<string>("LineNo"),
											   OrderId = row.Field<int>("OrderId"),
											   OrderItemId = row.Field<long>("OrderItemId"),
											   PriceCode = row.Field<string>("PriceCode"),
											   Quantity = row.Field<short>("Quantity"),
											   UnitOfMeasure = row.Field<string>("UnitOfMeasure"),
											   UnitPrice = row.Field<decimal>("UnitPrice"),
											   XActionCode = row.Field<string>("XActionCode")
										   }).ToList();
									
							}

						}
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return (header, details);
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
		// ~Retrieve() {
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