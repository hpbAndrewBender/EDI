using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Converters.Integers
{
	public class Int16s : ConverterBase
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public override object StringToField(string from)
		{
			short result = 0;
			try
			{
				if (string.IsNullOrEmpty(from))
				{
					result = 0;
				}
				else if (!short.TryParse(from, out result))
				{
					result = 0;
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
				if (from == null)
				{
					result = 0.ToString();
				}
				else
				{
					result = base.FieldToString(from);
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
