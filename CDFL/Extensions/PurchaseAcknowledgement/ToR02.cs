using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseAcknowledgement
{
	public static class ToR02
	{
		public static Models.SQL.PurchaseAcknowledgement.R02_FileHeader ToSQL(this Models.Files.PurchaseAcknowledgement.R02_FileHeader current)
		{
			Models.SQL.PurchaseAcknowledgement.R02_FileHeader to = new Models.SQL.PurchaseAcknowledgement.R02_FileHeader()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R02_FileHeader ToFiles(this Models.SQL.PurchaseAcknowledgement.R02_FileHeader current)
		{
			Models.Files.PurchaseAcknowledgement.R02_FileHeader to = new Models.Files.PurchaseAcknowledgement.R02_FileHeader()
			{

			};
			return to;
		}

	}
}
