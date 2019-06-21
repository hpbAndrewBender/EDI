using FileHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CommonLib.Converters.Dates
{
	public class YYMMDD : ConverterBase
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public override object StringToField(string from)
		{
			DateTime dt = default(DateTime);

			try
			{
				if(from.Length  == 6)
				{
					if (!DateTime.TryParseExact(from, "yyMMdd",  CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
					{
						dt = default(DateTime);
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				dt = default(DateTime);
			}
			return dt;
		}

		public override string FieldToString(object from)
		{
			string result;

			try
			{
				if (from.GetType() == typeof(DateTime))
				{
					if (!DateTime.TryParse(from.ToString(), out DateTime dt1))
					{
						log.Warn("ERR01-Could not parse");
						result = "%ER01%";
					}
					else
					{
						if (dt1 == default(DateTime))
						{
							result = string.Empty;
						}
						else
						{
							result = $"{dt1.Year.ToString().Substring(2, 2)}{dt1.Month.ToString("00")}{dt1.Day.ToString("00")}";
						}
					}
				}
				else
				{
					if (!DateTime.TryParseExact(from.ToString(), "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out DateTime dt2))
					{
						log.Warn("ERR02-Could not parse");
						result = "%ER02%";
					}
					else
					{
						result = $"{dt2.Year.ToString().Substring(2, 2)}{dt2.Month.ToString("00")}{dt2.Day.ToString("00")}";
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				result = "%ER00%";
			}
			return result;
		}
	}
}
