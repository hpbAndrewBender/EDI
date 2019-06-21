using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Attributes
{
	public class StringValueAttribute : System.Attribute
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
		private string _value;

		public StringValueAttribute(string value)
		{
			try
			{
				_value = value;
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
		}

		public string Value
		{
			get { return _value; }
		}
	}
}
