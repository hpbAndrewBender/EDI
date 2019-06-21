using CommonLib.Logic;
using CommonLib.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CommonLib.Extensions;

namespace DataHPBEDI.Logic.MetaData
{
	public class Retreive : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public List<Models.MetaData.AllCodes> AllCodes()
		{
			List<Models.MetaData.AllCodes> all = new List<Models.MetaData.AllCodes>();

			try
			{
				using (CommonLib.SQL.Access access = new CommonLib.SQL.Access())
				{
					DataTable dt = access.Table
					(
						Tools.dbConn[$"EDI-{Globals.Env}"],
						new List<string>() { "MetaData.uspGetCodes" },
						null
					);

					if (dt != null && dt.Rows.Count > 0)
					{
						all = (from DataRow r in dt.Rows
							   select new Models.MetaData.AllCodes
							   {
								   FileFormatId = r["FileFormatId"] != null ? (byte)r["FileFormatId"] : default(byte),
								   CodesTypeId = r["CodeTypeId"] != null ? (short)r["CodeTypeId"] : default(short),
								   CodesdId = r["CodesId"] != null ? (short)r["CodesId"] : default(short),
								   FileFormat = r["FileFormat"].ToString(),
								   Vers = r["Vers"].ToString(),
								   Active = r["Active"] != null ? (bool)r["Active"] : false,
								   VendorId = r["VendorID"].ToString(),
								   CodeType = r["CodeType"].ToString(),
								   AssociatedColumn = r["AssociatedColumn"].ToString(),
								   MaxChars = r["MaxChars"] != null ? (byte)r["MaxChars"] : default(byte),
								   Code = r["Code"].ToString(),
								   CodeName = r["CodeName"].ToString(),
								   CodeDescription = r["CodeDescription"].ToString()
							   }).ToList();
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return all;
		}

		public List<Models.MetaData.AllCodes> AllCodesForVendorFormatVersion(string vendor, string format, string version)
		{
			List<Models.MetaData.AllCodes> some = new List<Models.MetaData.AllCodes>();

			try
			{
				some = (from c in AllCodes()
						where c.VendorId.ToLower() == vendor.ToLower()
						&& c.FileFormat.ToLower() == format.ToLower()
						&& c.Vers.ToLower() == version.ToLower()
						select c).ToList();
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return some;
		}

		public List<Models.MetaData.AllCodes> AllCodesForVendorFormatVersion(List<Models.MetaData.AllCodes> codes, string vendor, string format, string version)
		{
			return (from c in codes
					where c.VendorId == vendor.ToLower()
					&& c.FileFormat.ToLower() == format.ToLower()
					&& c.Vers.ToLower() == version.ToLower()
					select c).ToList();
		}

		public List<Models.MetaData.AllCodes> AllCodesForVendorFormatColumn(string vendor, string format, string version, string column)
		{
			List<Models.MetaData.AllCodes> some = new List<Models.MetaData.AllCodes>();

			try
			{
				some = (from c in AllCodes()
						where c.VendorId.ToLower() == vendor.ToLower()
						&& c.FileFormat.ToLower() == format.ToLower()
						&& c.Vers.ToLower() == version.ToLower()
						&& c.AssociatedColumn.ToLower() == column.ToLower()
						select c).ToList();
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return some;
		}

		public List<Models.MetaData.AllCodes> AllCodesForVendorFormatColumn(List<Models.MetaData.AllCodes> codes, string vendor, string format, string version, string column)
		{
			return (from c in codes
					where c.VendorId.ToLower() == vendor.ToLower()
					&& c.FileFormat.ToLower() == format.ToLower()
					&& c.Vers.ToLower() == version.ToLower()
					&& c.AssociatedColumn.ToLower() == column.ToLower()
					select c).ToList();
		}

		public List<Models.MetaData.VendorStoreData> VendorStoreData(string vendorid, List<string> storelist)
		{
			List<Models.MetaData.VendorStoreData> stores = null;

			try
			{
				System.Data.DataTable table = storelist.ToDataTable("locations", ("Strings", typeof(string)));
				using (CommonLib.SQL.Access access = new Access())
				{
					stores = (from s in
								  (access.Table
									(
									  Tools.dbConn[$"EDI-{Globals.Env}"],
									  new List<string> { "MetaData.uspVendorStoreData" },
									  new List<SqlParameter>
									  {
										  new SqlParameter() {ParameterName = "@Vendor", SqlDbType = SqlDbType.VarChar, Value=vendorid},
										  new SqlParameter() {ParameterName = "@locations", SqlDbType=SqlDbType.Structured, Value= table }
									  }
									).AsEnumerable())
								select new Models.MetaData.VendorStoreData
								{
									LocationId = s["LocationId"].ToString(),
									LocationNumber = s["LocationNumber"].ToString(),
									SanAccount = s["SanAccount"].ToString(),
									VendorBillTo = s["VendorBillTo"].ToString(),
									VendorId = s["VendorId"].ToString(),
									VendorShipTo = s["VendorShipTo"].ToString()
								}
							).ToList();
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return stores;
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
		// ~Retreive() {
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
