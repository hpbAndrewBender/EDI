using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.ShipNotice
{
	public static class ToOP
	{
		public static Models.SQL.ShipNotice.OP_ASNPack ToSQL(this Models.Files.ShipNotice.OP_ASNPack current)
		{
			Models.SQL.ShipNotice.OP_ASNPack to = new Models.SQL.ShipNotice.OP_ASNPack()
			{

			};
			return to;
		}

		public static Models.Files.ShipNotice.OP_ASNPack ToFiles(this Models.SQL.ShipNotice.OP_ASNPack current)
		{
			Models.Files.ShipNotice.OP_ASNPack to = new Models.Files.ShipNotice.OP_ASNPack()
			{

			};
			return to;
		}

	}
}
