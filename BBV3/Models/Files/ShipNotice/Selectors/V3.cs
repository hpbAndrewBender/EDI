using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatBBV3.Models.Files.ShipNotice.Selectors
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
					type = typeof(CR_ASNCompany);
					break;

				case "OP":
					type = typeof(OP_ASNPack);
					break;

				case "OR":
					type = typeof(OR_ASNShipment);
					break;

				case "OD":
					type = typeof(OD_ASNShipmentDetail);
					break;

			}
			return type;
		}
	}
}
