using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Converters.Bools
{
	public class YN : ConverterBase
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		public override object StringToField(string from)
		{
			bool result = false;

			try
			{
				if (from.ToUpper() == "Y")
				{
					result = true;
				}
				else if (from.ToUpper() == "N")
				{
					result = false;
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
				result = (bool)from ? "Y" : "N";
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return result;
		}
	}
}
