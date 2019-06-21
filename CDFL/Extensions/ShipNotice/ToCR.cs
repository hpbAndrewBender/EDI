using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.ShipNotice
{
	public static class ToCR
	{
		public static Models.SQL.ShipNotice.CR_CompanyRecord ToSQL(this Models.Files.ShipNotice.CR_CompanyRecord current)
		{
			Models.SQL.ShipNotice.CR_CompanyRecord to = new Models.SQL.ShipNotice.CR_CompanyRecord()
			{

			};
			return to;
		}

		public static Models.Files.ShipNotice.CR_CompanyRecord ToFiles(this Models.SQL.ShipNotice.CR_CompanyRecord current)
		{
			Models.Files.ShipNotice.CR_CompanyRecord to = new Models.Files.ShipNotice.CR_CompanyRecord()
			{

			};
			return to;
		}

	}
}
