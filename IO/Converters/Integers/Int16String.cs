using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Converters.Integers
{
	public class Int16String : ConverterBase
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public override object StringToField(string from)
		{
			string result = string.Empty;

			try
			{
				if (string.IsNullOrEmpty(from))
				{
					result = string.Empty;
				}
				else
				{
					if (!short.TryParse(from, out short shortresult))
					{
						result = string.Empty;
					}
					else
					{
						result = shortresult > 0 ? shortresult.ToString() : string.Empty;
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;

		}

		public override string FieldToString(object from)
		{
			string result = string.Empty;

			try
			{
				if (from == null || string.IsNullOrEmpty(from.ToString()))
				{
					result = string.Empty;
				}
				else
				{
					if (!short.TryParse(from.ToString(), out short shortresult))
					{
						result = string.Empty;
					}
					else
					{
						result = shortresult > 0 ? shortresult.ToString() : string.Empty;
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