using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.ShipNotice
{
	public static class ToOD
	{

		public static Models.SQL.ShipNotice.OD_OrderDetailRecord ToSQL(this Models.Files.ShipNotice.OD_OrderDetailRecord current)
		{
			Models.SQL.ShipNotice.OD_OrderDetailRecord to = new Models.SQL.ShipNotice.OD_OrderDetailRecord()
			{

			};
			return to;
		}

		public static Models.Files.ShipNotice.OD_OrderDetailRecord ToFiles(this Models.SQL.ShipNotice.OD_OrderDetailRecord current)
		{
			Models.Files.ShipNotice.OD_OrderDetailRecord to = new Models.Files.ShipNotice.OD_OrderDetailRecord()
			{

			};
			return to;
		}

	}
}
