using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseAcknowledgement
{
	public static class ToR45
	{
		public static Models.SQL.PurchaseAcknowledgement.R45_AdditionalLineItem ToSQL(this Models.Files.PurchaseAcknowledgement.R45_AdditionalLineItem current)
		{
			Models.SQL.PurchaseAcknowledgement.R45_AdditionalLineItem to = new Models.SQL.PurchaseAcknowledgement.R45_AdditionalLineItem()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R45_AdditionalLineItem ToFiles(this Models.SQL.PurchaseAcknowledgement.R45_AdditionalLineItem current)
		{
			Models.Files.PurchaseAcknowledgement.R45_AdditionalLineItem to = new Models.Files.PurchaseAcknowledgement.R45_AdditionalLineItem()
			{

			};
			return to;
		}

	}
}
