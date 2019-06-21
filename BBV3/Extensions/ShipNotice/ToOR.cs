using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.ShipNotice
{
	public static class ToOR
	{ 
		public static Models.SQL.ShipNotice.OR_ASNShipment ToSQL(this Models.Files.ShipNotice.OR_ASNShipment current)
		{
			Models.SQL.ShipNotice.OR_ASNShipment to = new Models.SQL.ShipNotice.OR_ASNShipment()
			{

			};
			return to;
		}

		public static Models.Files.ShipNotice.OR_ASNShipment ToFiles(this Models.SQL.ShipNotice.OR_ASNShipment current)
		{
			Models.Files.ShipNotice.OR_ASNShipment to = new Models.Files.ShipNotice.OR_ASNShipment()
			{

			};
			return to;
		}
	}
}
