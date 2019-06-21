using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseAcknowledgement
{
	public static class ToR59
	{
		public static Models.SQL.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals ToSQL(this Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals current)
		{
			Models.SQL.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals to = new Models.SQL.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals ToFiles(this Models.SQL.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals current)
		{
			Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals to = new Models.Files.PurchaseAcknowledgement.R59_PurchaseOrderControlTotals()
			{

			};
			return to;
		}

	}
}
