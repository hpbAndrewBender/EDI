using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseAcknowledgement
{
	public static class ToR43
	{
		public static Models.SQL.PurchaseAcknowledgement.R43_AdditionalLineItem ToSQL(this Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem current)
		{
			Models.SQL.PurchaseAcknowledgement.R43_AdditionalLineItem to = new Models.SQL.PurchaseAcknowledgement.R43_AdditionalLineItem()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem ToFiles(this Models.SQL.PurchaseAcknowledgement.R43_AdditionalLineItem current)
		{
			Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem to = new Models.Files.PurchaseAcknowledgement.R43_AdditionalLineItem()
			{

			};
			return to;
		}

	}
}
