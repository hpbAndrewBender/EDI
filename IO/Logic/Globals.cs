using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonLib.Logic
{
	public static class Globals
	{
		public static string Delimiter = "|";

		public static string ConnectStringDelims { get; set; }
		public static string ConnectStringEDI { get; set; }		
		public static string Env { get; set; }
		public static List<(DateTime Date, string Location, string ErrorLEvel, string Message)> Message { get; set; }

		public static int CreateBatch(string method, string filename, string vendor, byte batchitem)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			int result = 0;

			try
			{
				using (SQL.Access access = new SQL.Access())
				{
					result = access.Scalar<int>
					(
						SQL.Tools.dbConn[$"EDI-{Globals.Env}"],
						new List<string>()
						{
							"EDI.uspCreateBatch"
						},
						new List<System.Data.SqlClient.SqlParameter>()
						{
							new System.Data.SqlClient.SqlParameter() { ParameterName = "@method", SqlDbType = System.Data.SqlDbType.VarChar, Value = method },
							new System.Data.SqlClient.SqlParameter() { ParameterName = "@file", SqlDbType = System.Data.SqlDbType.VarChar, Value = filename },
							new System.Data.SqlClient.SqlParameter() { ParameterName = "@vend", SqlDbType = System.Data.SqlDbType.VarChar, Value = vendor },
							new System.Data.SqlClient.SqlParameter() { ParameterName = "@type", SqlDbType = System.Data.SqlDbType.TinyInt, Value = batchitem }
						},
						-1
					);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				result = -1;

			}
			return result;
		} 
			   
		public static List<(string name, string env, string server, string catalog, string security, string user, string password)> GenerateConnections()
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			List<(string name, string env, string server, string catalog, string security, string user, string password)> connections = new List<(string name, string env, string server, string catalog, string security, string user, string password)>();
			try
			{
				connections.AddRange(ToConnection("EDI", ConnectStringEDI));
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			//connections.AddRange(ToConnection("SIPS", ConnectStringSIPS));
			return connections;
		}

		private static (string name, string env, string server, string catalog, string security, string user, string password) DelimitedToTuple(string type, string start)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			(string name, string env, string server, string catalog, string security, string user, string password) result = ("", "", "", "", "", "", "");
			List<string> specificItems;

			try
			{
				specificItems = start.Split((char)Globals.ConnectStringDelims[1]).ToList();
				if (specificItems != null && specificItems.Count == 6)
				{
					result = (type, specificItems[0], specificItems[1], specificItems[2], specificItems[3], specificItems[4], specificItems[5]);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		private static List<(string name, string env, string server, string catalog, string security, string user, string password)> ToConnection(string type, string str)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			List<string> list;
			List<(string name, string env, string server, string catalog, string security, string user, string password)> connections = new List<(string name, string env, string server, string catalog, string security, string user, string password)>();

			try
			{
				if (!string.IsNullOrEmpty(str))
				{
					list = str.Split((char)Globals.ConnectStringDelims[0]).ToList();
					foreach (string item in list)
					{
						if (!string.IsNullOrEmpty(item))
						{
							connections.Add(DelimitedToTuple(type, item));
						}
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return connections;
		}
	}
}