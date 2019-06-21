using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.ShipNotice
{
	public static class ToOD
	{

		public static Models.SQL.ShipNotice.OD_ASNShipmentDetail ToSQL(this Models.Files.ShipNotice.OD_ASNShipmentDetail current)
		{
			Models.SQL.ShipNotice.OD_ASNShipmentDetail to = new Models.SQL.ShipNotice.OD_ASNShipmentDetail()
			{

			};
			return to;
		}

		public static Models.Files.ShipNotice.OD_ASNShipmentDetail ToFiles(this Models.SQL.ShipNotice.OD_ASNShipmentDetail current)
		{
			Models.Files.ShipNotice.OD_ASNShipmentDetail to = new Models.Files.ShipNotice.OD_ASNShipmentDetail()
			{

			};
			return to;
		}

	}
}
