using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseAcknowledgement
{
	public static class ToR40
	{
		public static Models.SQL.PurchaseAcknowledgement.R40_LineItem ToSQL(this Models.Files.PurchaseAcknowledgement.R40_LineItem current)
		{
			Models.SQL.PurchaseAcknowledgement.R40_LineItem to = new Models.SQL.PurchaseAcknowledgement.R40_LineItem()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R40_LineItem ToFiles(this Models.SQL.PurchaseAcknowledgement.R40_LineItem current)
		{
			Models.Files.PurchaseAcknowledgement.R40_LineItem to = new Models.Files.PurchaseAcknowledgement.R40_LineItem()
			{

			};
			return to;
		}

	}
}
