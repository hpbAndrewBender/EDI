using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseAcknowledgement
{
	public static class ToR42
	{
		public static Models.SQL.PurchaseAcknowledgement.R42_AdditionalLineItem ToSQL(this Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem current)
		{
			Models.SQL.PurchaseAcknowledgement.R42_AdditionalLineItem to = new Models.SQL.PurchaseAcknowledgement.R42_AdditionalLineItem()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem ToFiles(this Models.SQL.PurchaseAcknowledgement.R42_AdditionalLineItem current)
		{
			Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem to = new Models.Files.PurchaseAcknowledgement.R42_AdditionalLineItem()
			{

			};
			return to;
		}

	}
}
