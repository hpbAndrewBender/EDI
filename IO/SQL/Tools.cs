using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using CommonLib.Extensions;

namespace CommonLib.SQL
{
	public static class Tools
	{
		public static Dictionary<string, string> dbConn = new Dictionary<string, string>();
		static NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		
		public static string GenerateConnect(string server, string catalog, string security, string user, string password)
		{			
			string connect = string.Empty;
			try
			{
				if (user == "" && password == "")
				{
					connect = $"Data Source={server};Initial Catalog={catalog};Persist Security Info={security};Integrated Security=true";
				}
				else
				{
					connect = $"Data Source={server};Initial Catalog={catalog};Persist Security Info={security};User ID={user};Password={password}";
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return connect;
		}

		public static void InsertServer(List<(string name, string env, string server, string catalog, string security, string user, string password)> dbservers)
		{
			try
			{
				NLog.Logger eventlog = NLog.LogManager.GetCurrentClassLogger();
				foreach (var (name, env, server, catalog, security, user, password) in dbservers)
				{
					if (security.ToLower() == "trusted")
					{
						dbConn.Update
						  (
							  $"{name}-{env.Trim()}",
							  GenerateConnect
							  (
								  server.Trim(),
								  catalog.Trim(),
								  "True",
								  "",
								  ""
							  )
						  );
					}
					else
					{
						dbConn.Update
						  (
							  $"{name}-{env.Trim()}",
							  GenerateConnect
							  (
								  server.Trim(),
								  catalog.Trim(),
								  security.Trim(),
								  user,
								  password
							  )
						  );
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
		}

		public static DataTable CreateDataTable(List<(string FullName, string Name, Type DataType)> props)
		{
			DataTable table = new DataTable();
			DataColumn column = null;

			try
			{
				foreach ((string FullName, string Name, Type DataType) in props)
				{
					column = new DataColumn
					{
						ColumnName = Name,
						DataType = DataType,
					};
					table.Columns.Add(column);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return table;
		}

		public static DataTable CreateDataTable(List<(string FullName, string Name, Type DataType)> props, DataTable ordinals)
		{
			DataTable table = new DataTable();
			try
			{
				table = CreateDataTable(props);
				if (ordinals != null && ordinals.Rows.Count > 0)
				{
					string fieldname = string.Empty;
					int ordinalnum = 0;
					foreach (DataRow row in ordinals.Rows)
					{
						fieldname = row["name"].ToString();
						ordinalnum = (int)row["column_id"] - 1; // zero base the array
						if (table.Columns.Contains(fieldname))
						{
							table.Columns[fieldname].SetOrdinal(ordinalnum);
							//Globals.AddMessage(current, "Info", $"    Setting ordinal {ordinalnum} to {fieldname}");
						}
						else
						{
							log.Info($"Missing field name={fieldname}");
						}
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return table;
		}	
	}
}