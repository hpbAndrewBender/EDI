using CommonLib.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CommonLib.Extensions
{
	public static class Attrbutes
	{
		public static string ToStringValue(this Enum value)
		{
			NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
			string result = string.Empty;
			Type type;

			try
			{
				type = value.GetType();

				FieldInfo fi = type.GetField(value.ToString());
				StringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
				if (attrs.Length > 0)
				{
					result = attrs[0].Value;
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
