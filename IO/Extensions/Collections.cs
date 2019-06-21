using CommonLib.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CommonLib.Extensions
{
	public static partial class Extensions
	{
		public static T LastItem<T>(this List<T> collection)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			T result = default(T);

			try
			{
				if (collection != null)
				{
					result = collection[collection.Count - 1];
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public static SqlBulkCopyColumnMappingCollection AddRange(this SqlBulkCopyColumnMappingCollection collection, List<(string ColumnSource, string ColumnDest)> Mappings)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

			try
			{
				foreach ((string ColumnSource, string ColumnDest) in Mappings)
				{
					collection.Add(ColumnSource, ColumnDest);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return collection;
		}

		public static T ForEnvironment<T>(this string ItemList, string Environment = "", string Delimiter = "")
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

			string[] Items;
			dynamic EnvValue = null;
			string temp = string.Empty;
			string Env = string.Empty;
			string Del = string.Empty;

			try
			{
				Env = string.IsNullOrEmpty(Environment) ? Globals.Env : Environment;
				Del = string.IsNullOrEmpty(Delimiter) ? Globals.Delimiter : Delimiter;
				Items = ItemList.Split(Del[0]);
				if (Items.Length > 0)
				{
					temp = (from f in Items.AsEnumerable()
							where f.StartsWith($"{Env.ToUpper()}=")
							select f).First().ToString();
					if (temp.Length > 0)
					{
						temp = temp.Replace($"{Env.ToUpper()}=", "");

						if (temp.StartsWith("{") && temp.EndsWith("}") && temp.Length > 2)
						{
							temp = temp.Substring(1, temp.Length - 2);
						}
						else if (temp.StartsWith("{") && temp.EndsWith("}") && temp.Length == 2)
						{
							temp = string.Empty;
						}
					}
					if (typeof(T) == typeof(string))
					{
						EnvValue = temp;
					}
					else if (typeof(T) == typeof(bool))
					{
						if (temp != "")
						{
							if (bool.TryParse(temp, out bool t))
							{
								EnvValue = t;
							}
							else
							{
								EnvValue = false;
							}
						}
						else
						{
							EnvValue = default(bool);
						}
					}
					else if (typeof(T) == typeof(int))
					{
						if (temp != "")
						{
							if (int.TryParse(temp, out int t))
							{
								EnvValue = t;
							}
							else
							{
								EnvValue = default(int);
							}
						}
						else
						{
							EnvValue = default(int);
						}
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex, $"ItemList: {ItemList}, Env: {Env}, Del: {Del}");
			}
			return (T)EnvValue;
		}

		public static bool ItemInList(this string ItemsInList, string Find, char Delimiter)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

			bool InList = false;
			try
			{
				string[] items = ItemsInList.ToUpper().Split(',');
				InList = items.Where(find => find == Find).Count() > 0;
			}
			catch (Exception ex)
			{
				log.Error(ex, $"Items: {ItemsInList}, Find: {Find}, Delimiter: {Delimiter}");
				InList = false;
			}
			return InList;
		}

		public static bool ItemsInList(this string ItemsInList, List<string> Find, char Delimiter)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

			bool InList = false;
			try
			{
				string[] items = ItemsInList.ToUpper().Split(',');
				InList = items.Where(find => Find.Contains(find)).Count() > 0;
			}
			catch (Exception ex)
			{
				log.Error(ex, $"Items: {ItemsInList}, Find: {Find}, Delimiter: {Delimiter}");
				InList = false;
			}
			return InList;
		}

		public static Dictionary<string, string> Update(this Dictionary<string, string> dict, string key, string value)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

			try
			{
				if (dict.ContainsKey(key))
				{
					dict[key] = value;
				}
				else
				{
					dict.Add(key, value);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex, $"Key: {key}, Value: {value}");
			}
			return dict;
		}

		public static List<(int Order, string User, string Pass)> UserSplit(this string ItemList)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

			int Ord = 0;
			int SetCount = 0;
			string Usr = "";
			string Pwd = "";

			string[] items1 = ItemList.Split(new string[] { "][" }, StringSplitOptions.None);
			List<string> items2 = new List<string>();
			List<(int Order, string User, string Pass)> list = new List<(int Order, string User, string Pass)>();
			foreach (string item in items1)
			{
				if (item.StartsWith("[") && !item.EndsWith("]"))
				{
					items2.Add(item.Substring(item.IndexOf("[") + 1));
				}
				else if (item.EndsWith("]") && !item.StartsWith("["))
				{
					items2.Add(item.Substring(0, item.Length - 1));
				}
			}
			string[] param;
			foreach (string item in items2)
			{
				param = item.Split(',');
				if (param.Length == 3)
				{
					SetCount = 0;
					Ord = -1;
					Usr = string.Empty;
					Pwd = string.Empty;
					for (int i = 0; i < param.Length; i++)
					{
						if (param[i].Contains("="))
						{
							switch (param[i].Substring(0, param[i].IndexOf("=")))
							{
								case "ORDER":
									Ord = int.Parse(param[i].Substring(param[i].IndexOf("=") + 1));
									SetCount++;
									break;

								case "USER":
									Usr = param[i].Substring(param[i].IndexOf("=") + 1);
									if (Usr.StartsWith("\"") && Usr.EndsWith("\""))
									{
										Usr = Usr.Substring(1, Usr.Length - 2);
									}
									SetCount++;
									break;

								case "PASSWORD":
									Pwd = param[i].Substring(param[i].IndexOf("=") + 1);
									if (Pwd.StartsWith("\"") && Pwd.EndsWith("\""))
									{
										Pwd = Pwd.Substring(1, Pwd.Length - 2);
									}
									SetCount++;
									break;
							}
						}
						if (SetCount == 3)
						{
							list.Add((Ord, Usr, Pwd));
						}
					}
				}
			}
			return list;
		}

		public static System.Data.DataTable ToDataTable(this List<string> enumerable, string tablename, (string name, Type type) newcolumns)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			System.Data.DataTable newtable = new System.Data.DataTable();

			try
			{
				newtable = new System.Data.DataTable
				{
					TableName = tablename,
				};
				newtable.Columns.Add(newcolumns.name, newcolumns.type);
				foreach(string item in enumerable)
				{
					newtable.Rows.Add(item);
				}

			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return newtable;

		}



		public static System.Data.DataTable ToDataTable<T1>(this IEnumerable<T1> enumerable, string tablename, List<(string name, object value, Type type)> newcolumns, List<string> ignorelist)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			System.Data.DataTable newtable = new System.Data.DataTable();

			try
			{
				newtable = enumerable.ToDataTable<T1>(tablename, ignorelist);
				if(newcolumns != null && newcolumns.Count > 0)
				{
					foreach((string name, object value, Type type) in newcolumns )
					{
						newtable.Columns.Add(name, type);
						foreach (System.Data.DataRow row in newtable.Rows)
						{
							row[name] = value;
						}
					}

				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return newtable;
		}
		
		public static System.Data.DataTable ToDataTable<T>(this IEnumerable<T> enumerable, string tablename, List<string> ignorelist)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			Type type;
			System.Data.DataTable table;
			List<int> ignoreitems = new List<int>();
			int ignorecounter = 0;

			try
			{
				type = typeof(T);
				var properties = type.GetProperties();
				table = new System.Data.DataTable
				{
					TableName = tablename
				};
				foreach (System.Reflection.PropertyInfo pi in properties)
				{
					if (!ignorelist.Contains(pi.Name.ToLower()))
					{
						table.Columns.Add(new System.Data.DataColumn(pi.Name, Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType));
					}
					else
					{
						ignoreitems.Add(ignorecounter);
					}
					ignorecounter++;
				}
				foreach (T item in enumerable)
				{
					List<object> valuelist = new List<object>();
					foreach(var property in properties)
					{
						if(!ignorelist.Contains(property.Name.ToLower()))
						{
							valuelist.Add(property.GetValue(item));
						}
					}
					table.Rows.Add(valuelist.ToArray());
					//--int nonreserved = properties.Length - ignoreitems.Count;
					//--object[] values = new object[nonreserved];
					//--int actual = 0;
					//--for (int i = 0; i < nonreserved; i++)
					//--{
					//--	if (!ignoreitems.Contains(i))
					//--	{
					//--		values[actual++] = properties[i].GetValue(item);
					//--	}
					//--}
					//--table.Rows.Add(values);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				table = new System.Data.DataTable();
			}
			return table;
		}

		public static System.Data.DataTable SetColumnsOrder(this System.Data.DataTable table, params string[] columns)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			int index = 0;
			string currentcolumn = string.Empty;

			try
			{
				if (table != null && table.Rows.Count > 0)
				{
					foreach (var name in columns)
					{
						currentcolumn = name;
						table.Columns[name].SetOrdinal(index++);
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex, $"{table.TableName}-{currentcolumn}");
			}
			return table;
		}
	}
}