using System;

namespace CommonLib.Extensions
{
	public static partial class Extension
	{
		public static string InnerMostMessage(this Exception ex)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

			string InnerMessage = string.Empty;
			if (ex.InnerException != null)
			{
				InnerMessage = ex.InnerException.Message;
			}
			else
			{
				InnerMessage = ex.Message;
			}
			return InnerMessage;
		}
	}
}