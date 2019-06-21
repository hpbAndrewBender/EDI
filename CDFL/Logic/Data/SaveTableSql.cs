using CommonLib.Extensions;
using CommonLib.Logic;
using CommonLib.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatCDFL.Logic.Data
{
	public class SaveTableSql : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public bool SaveTable<T>(int batchnumber, List<T> items, string format, string action, string table,
									 List<(int order, string source, string dest)> mapping,
									 List<string> ignores)
		{
			bool result = false;
			List<(string name, object value, Type type)> additems = new List<(string name, object value, Type type)>
			{
				("BatchId", batchnumber, typeof(byte))
			};

			try
			{
				(string schema, string table) sqlinfo = ($"Import{format}", $"{action}_{table}");
				if (items != null && items.Count > 0)
				{
					using (CommonLib.SQL.Access access = new CommonLib.SQL.Access())
					{
						access.BulkUploadTableWithMappings
						(
							Tools.dbConn[$"EDI-{Globals.Env}"],
							new List<string>() { $"{sqlinfo.schema}.{sqlinfo.table}" },
							(from m in mapping select (m.source, m.dest)).ToList(),
							null,
							items.ToDataTable<T>($"{sqlinfo.table}", additems, ignores).SetColumnsOrder((from m in mapping orderby m.order select m.dest).ToArray()),
							System.Data.CommandType.Text
						);
					}
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
		// ~CommonSql() {
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
