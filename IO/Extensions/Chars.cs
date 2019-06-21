using System;

namespace CommonLib.Extensions
{
	public static class Chars
	{
		public static char FirstChar(this string s)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			char result = ' ';

			try
			{
				if (!string.IsNullOrEmpty(s))
				{
					result = s[0];
				}
				else
				{
					result = ' ';
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}

		public static char ToSingleChar(this string s, int location)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			char result = ' ';
			try
			{
				if (location < s.Length)
				{
					result = s[location];
				}
				else
				{
					result = s[s.Length - 1];
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