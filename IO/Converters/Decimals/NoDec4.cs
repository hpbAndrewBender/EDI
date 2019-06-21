using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Converters.Decimals
{
	public class NoDec4 : ConverterBase
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private readonly decimal factor = 100;

		public override object StringToField(string from)
		{
			object result = null;

			try
			{
				result = Convert.ToDecimal(Decimal.Parse(from) / factor);
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
				result = ((decimal)from * factor).ToString("#.####").Replace(".", "");
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
	}
}
