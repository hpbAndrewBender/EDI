using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.ShipNotice
{
	public static class ToCR
	{
		public static Models.SQL.ShipNotice.CR_ASNCompany ToSQL(this Models.Files.ShipNotice.CR_ASNCompany current)
		{
			Models.SQL.ShipNotice.CR_ASNCompany to = new Models.SQL.ShipNotice.CR_ASNCompany()
			{

			};
			return to;
		}

		public static Models.Files.ShipNotice.CR_ASNCompany ToFiles(this Models.SQL.ShipNotice.CR_ASNCompany current)
		{
			Models.Files.ShipNotice.CR_ASNCompany to = new Models.Files.ShipNotice.CR_ASNCompany()
			{

			};
			return to;
		}

	}
}
