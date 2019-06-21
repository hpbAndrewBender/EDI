using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Converters.Decimals
{
	public class ExplicitDec4 : ConverterBase
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public override object StringToField(string from)
		{
			object result = null;

			try
			{
				result = Convert.ToDecimal(Decimal.Parse(from));
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
				if (!decimal.TryParse(from.ToString(), out decimal dec))
				{
					result = "0.0000";
				}
				else
				{
					result = (dec).ToString("0.0000");
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
