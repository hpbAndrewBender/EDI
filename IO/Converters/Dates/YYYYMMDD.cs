using FileHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CommonLib.Converters.Dates
{
	public class YYYYMMDD : ConverterBase
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public override object StringToField(string from)
		{
			DateTime dt = default(DateTime);

			try
			{
				if (from.Length == 8)
				{
					if (!DateTime.TryParseExact(from, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
					{
						dt = DateTime.Parse("1/1/1900");
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
				dt = DateTime.Parse("1/1/1900");
			}
			return dt;
		}

		public override string FieldToString(object from)
		{
			DateTime dt;
			string result = string.Empty;

			try
			{
				if (DateTime.TryParse(from.ToString(), out dt))
				{
					result = $"{dt.Year.ToString("0000")}{dt.Month.ToString("00")}{dt.Day.ToString("00")}";
				}
				else
				{
					result = string.Empty;
				}

			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
	}
}