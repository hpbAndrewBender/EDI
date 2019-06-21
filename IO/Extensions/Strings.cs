using System;
using System.Text;

namespace CommonLib.Extensions
{
	public static class Strings
	{

		public static string ForFilesSecondsSinceMidnight(this DateTime datetime)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			string result = string.Empty;

			try
			{				
				TimeSpan since = datetime - DateTime.Today;
				result =  $"{(int)since.TotalSeconds}";
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public static string ForFilesCCYYMMDD_HHMMSS(this DateTime datetime)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			string result = string.Empty;

			try
			{
				result = $"{datetime.Year}{datetime.Month.ToString("00")}{datetime.Day.ToString("00")}_{datetime.Hour.ToString("00")}{datetime.Minute.ToString("00")}{datetime.Second.ToString("00")}";
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public static string ForFilesCCYYMMDD(this DateTime datetime)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			string result = string.Empty;

			try
			{
				result = $"{datetime.Year}{datetime.Month.ToString("00")}{datetime.Day.ToString("00")}";
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public static string ForFilesHHMMSS(this DateTime datetime)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			string result = string.Empty;

			try
			{
				result = $"{datetime.Hour.ToString("00")}{datetime.Minute.ToString("00")}{datetime.Second.ToString("00")}";
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public static string ForFilesYYMMDD_HHMM(this DateTime datetime)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			string result = string.Empty;
			try
			{
				result = $"{datetime.Year.ToString().Substring(2, 2)}{datetime.Month.ToString("00")}{datetime.Day.ToString("00")}_{datetime.Hour.ToString("00")}{datetime.Minute.ToString("00")}";
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public static string Replicate(this string item, int length)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			StringBuilder result = new StringBuilder();

			try
			{
				for (int i = 0; i < length; i++)
				{
					result.Append(item);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result.ToString();
		}
	}
}