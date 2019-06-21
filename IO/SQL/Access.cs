using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CommonLib.SQL
{
	public class Access : IDisposable
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public bool BulkUploadTable(string connection, List<string> query, List<SqlParameter> prms, DataTable table, CommandType type = CommandType.StoredProcedure)
		{
			bool result = false;
			List<string> cn = new List<string>();
			try
			{
				using (SqlConnection connect = new SqlConnection(connection))
				{
					if (table != null && table.Rows.Count > 0)
					{
						using (SqlCommand command = new SqlCommand(string.Join(" ", query.ToArray()), connect))
						{
							command.CommandType = type;
							if (prms != null && prms.Count > 0)
							{
								command.Parameters.AddRange(prms.ToArray());
							}
							connect.Open();
							using (SqlBulkCopy bulk = new SqlBulkCopy(connect))
							{
								cn.Add($"BulkColumnMapping={string.Join(";", (from x in bulk.ColumnMappings.Cast<DataColumn>() select x.ColumnName).ToArray())}");
								cn.Add($"DataTableColumns={string.Join(";", (from x in table.Columns.Cast<DataColumn>() select $"{x.ColumnName} [{x.Ordinal}]").ToArray())}");
								bulk.DestinationTableName = string.Join(" ", query.ToArray());
								bulk.WriteToServer(table);
							}
							result = true;
						}
					}
					else
					{
						result = false;
					}
					connect.Close();
				}
			}
			catch (Exception ex)
			{
				log.Error(ex, $"{string.Join(" ", query.ToArray())} - {string.Join("|", cn.ToArray())}");
				result = false;
			}
			return result;
		}

		public bool BulkUploadTableWithMappings(string connection, List<string> query, List<(string ColumnSource, string ColumnDesc)> Mapping, List<SqlParameter> prms, DataTable table, CommandType type = CommandType.StoredProcedure)
		{
			bool result = false;

			try
			{
				using (SqlConnection connect = new SqlConnection(connection))
				{
					if (table != null && table.Rows.Count > 0)
					{
						using (SqlCommand command = new SqlCommand(string.Join(" ", query.ToArray()), connect))
						{
							command.CommandType = type;
							if (prms != null && prms.Count > 0)
							{
								command.Parameters.AddRange(prms.ToArray());
							}
							connect.Open();
							using (SqlBulkCopy bulk = new SqlBulkCopy(connect))
							{
								bulk.DestinationTableName = string.Join(" ", query.ToArray());
								if (Mapping != null && Mapping.Count > 0)
								{
									foreach ((string Source, string Dest) in Mapping)
									{
										bulk.ColumnMappings.Add(Source, Dest);
									}
								}
								bulk.WriteToServer(table);
								bulk.Close();
							}
							result = true;
						}
					}
					else
					{
						result = false;
					}
					connect.Close();
				}
			}
			catch (Exception ex)
			{
				log.Error(ex, $"{string.Join(" ", query.ToArray())}");
				result = false;
			}
			return result;
		}

		public bool NonQuery(string connection, List<string> query, List<SqlParameter> prms, CommandType type = CommandType.StoredProcedure)
		{
			bool data = false;
			SqlConnection connect = null;
			SqlCommand command = null;

			try
			{
				using (connect = new SqlConnection(connection))
				{
					command = new SqlCommand(string.Join(" ", query.ToArray()), connect)
					{
						CommandType = type
					};
					if (prms != null && prms.Count > 0)
					{
						command.Parameters.AddRange(prms.ToArray());
					}
					connect.Open();
					command.ExecuteNonQuery();
					connect.Close();
					data = true;
					connect.Close();
				}
			}
			catch (Exception ex)
			{
				log.Error(ex, string.Join(" ",query.ToArray()));
				data = false;
			}
			return data;
		}

		public List<object> OutParam(string connection, List<string> query, List<SqlParameter> prms, CommandType type = CommandType.StoredProcedure)
		{
			SqlConnection connect = null;
			SqlCommand command = null;
			List<object> data = new List<object>();
			List<string> parameterNames = new List<string>();

			try
			{
				parameterNames = (from SqlParameter p in prms
								  where p.Direction == ParameterDirection.Output
								  select p.ParameterName).ToList();
				using (connect = new SqlConnection(connection))
				{
					command = new SqlCommand(string.Join(" ", query.ToArray()), connect)
					{
						CommandType = type
					};
					if (prms != null && prms.Count > 0)
					{
						command.Parameters.AddRange(prms.ToArray());
					}
					connect.Open();
					command.ExecuteNonQuery();
					if (parameterNames.Count > 0)
					{
						foreach (string paramName in parameterNames)
						{
							data.Add(command.Parameters[paramName].Value);
						}
					}
					connect.Close();
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				data = null;
			}
			return data;
		}

		public SqlDataReader Read(string connection, List<string> query, List<SqlParameter> prms, CommandType type = CommandType.StoredProcedure)
		{
			try
			{
				using (SqlConnection connect = new SqlConnection(connection))
				{
					using (SqlCommand command = new SqlCommand(string.Join(" ", query.ToArray()), connect))
					{
						command.CommandType = type;
						if (prms != null && prms.Count > 0)
						{
							command.Parameters.AddRange(prms.ToArray());
						}
						connect.Open();
						SqlDataReader data = command.ExecuteReader(CommandBehavior.CloseConnection);
						return data;
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				return null;
			}
		}

		public int RowCount(string connection, List<string> query, List<SqlParameter> prms, CommandType type = CommandType.StoredProcedure)
		{
			int count = 0;

			try
			{
				count = Table(connection, query, prms, type).Rows.Count;
			}
			catch (Exception ex)
			{
				log.Error(ex);
				count = -1;
			}
			return count;
		}

		public T Scalar<T>(string connection, List<string> query, List<SqlParameter> prms, T defaultValue, CommandType type = CommandType.StoredProcedure)
		{
			T data = defaultValue;
			SqlConnection connect = null;
			SqlCommand command = null;

			try
			{
				using (connect = new SqlConnection(connection))
				{
					command = new SqlCommand(string.Join(" ", query.ToArray()), connect)
					{
						CommandType = type
					};
					if (prms != null && prms.Count > 0)
					{
						command.Parameters.AddRange(prms.ToArray());
					}
					connect.Open();
					data = (T)command.ExecuteScalar();
					connect.Close();
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				data = defaultValue;
			}
			return data;
		}

		public DataSet Set(string connection, List<string> query, List<SqlParameter> prms, CommandType type = CommandType.StoredProcedure)
		{
			DataSet data = null;
			SqlConnection connect = null;
			SqlCommand command = null;
			SqlDataAdapter adapter = null;
			try
			{
				using (connect = new SqlConnection(connection))
				{
					command = new SqlCommand(string.Join(" ", query.ToArray()), connect)
					{
						CommandType = type
					};
					if (prms != null && prms.Count > 0)
					{
						command.Parameters.AddRange(prms.ToArray());
					}
					connect.Open();
					adapter = new SqlDataAdapter(command);
					data = new DataSet();
					adapter.Fill(data);
					adapter.Dispose();
					connect.Close();
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				data = null;
			}
			return data;
		}

		public DataRow SingleRow(string connection, List<string> query, List<SqlParameter> prms, int rowNumber = 0, CommandType type = CommandType.StoredProcedure)
		{
			DataRow row = null;
			DataTable tbl = null;

			try
			{
				tbl = Table(connection, query, prms, type);
				if (tbl != null && tbl.Rows.Count > 0)
				{
					row = tbl.Rows[rowNumber];
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				row = null;
			}
			return row;
		}

		public DataTable Table(string connection, List<string> query, List<SqlParameter> prms, CommandType type = CommandType.StoredProcedure)
		{
			DataTable data = null;
			SqlConnection connect = null;
			SqlCommand command = null;
			SqlDataAdapter adapter = null;
			try
			{
				using (connect = new SqlConnection(connection))
				{
					command = new SqlCommand(string.Join(" ", query.ToArray()), connect)
					{
						CommandType = type
					};
					if (prms != null && prms.Count > 0)
					{
						command.Parameters.AddRange(prms.ToArray());
					}
					connect.Open();
					adapter = new SqlDataAdapter(command);
					data = new DataTable();
					adapter.Fill(data);
					adapter.Dispose();
					connect.Close();
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				data = null;
			}
			return data;
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
		// ~Access() {
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