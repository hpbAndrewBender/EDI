using FileHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CommonLib.Converters.Dates
{
	public class YYMM : ConverterBase
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public override object StringToField(string from)
		{
			DateTime dt = default(DateTime);
			string dated = string.Empty;

			try
			{
				if (from.Length == 4)
				{
					dated = string.Concat(from.Substring(0, 2), "01", from.Substring(2, 2)); // add the 1st to the date as all months have a 1st date, not all months have a 31st.

					if (!DateTime.TryParseExact(dated, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
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
				dt = (DateTime)from;
				result = $"{dt.Year.ToString().Substring(2, 2)}{dt.Month.ToString("00")}";
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
	}
}
