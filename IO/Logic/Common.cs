using System;
using System.Collections.Generic;

namespace CommonLib.Logic
{
	public static class Common
	{
		public static void Initialize<T>(ref List<T> collection)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

			try
			{
				if (collection == null)
				{
					collection = new List<T>();
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
		}

		public static bool IsValid(dynamic collection, bool checkSequence = true)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			bool result = false;

			try
			{
				if (collection != null)
				{
					if (checkSequence)
					{
						if (collection.SequenceNumber.GetType() != typeof(string))
						{
							if (collection.SequenceNumber > 0)
							{
								result = true;
							}
							else
							{
								result = false;
							}
						}
						else
						{
							if (!string.IsNullOrEmpty(collection.SequenceNumber))
							{
								result = true;
							}
							else
							{
								result = false;
							}
						}
					}
					else
					{
						result = true;
					}
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