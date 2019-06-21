using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatCDFL.Models.Files.ShipNotice.Selectors
{
	public class V3
	{
		public static Type Custom(MultiRecordEngine engine, string recordLine)
		{
			Console.WriteLine(recordLine);
			Type type = null;
			switch (recordLine.Substring(0, 2))
			{
				case "CR":
					type = typeof(CR_CompanyRecord);
					break;

				case "OR":
					type = typeof(OR_OrderRecord);
					break;

				case "OD":
					type = typeof(OD_OrderDetailRecord);
					break;

			}
			return type;
		}
	}
}
