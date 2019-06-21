using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.ShipNotice
{
	public static class ToOR
	{ 
		public static Models.SQL.ShipNotice.OR_OrderRecord ToSQL(this Models.Files.ShipNotice.OR_OrderRecord current)
		{
			Models.SQL.ShipNotice.OR_OrderRecord to = new Models.SQL.ShipNotice.OR_OrderRecord()
			{

			};
			return to;
		}

		public static Models.Files.ShipNotice.OR_OrderRecord ToFiles(this Models.SQL.ShipNotice.OR_OrderRecord current)
		{
			Models.Files.ShipNotice.OR_OrderRecord to = new Models.Files.ShipNotice.OR_OrderRecord()
			{

			};
			return to;
		}
	}
}
