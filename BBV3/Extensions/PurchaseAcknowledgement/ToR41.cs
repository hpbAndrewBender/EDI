using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseAcknowledgement
{
	public static class ToR41
	{
		public static Models.SQL.PurchaseAcknowledgement.R41_AdditionalDetail ToSQL(this Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail current)
		{
			Models.SQL.PurchaseAcknowledgement.R41_AdditionalDetail to = new Models.SQL.PurchaseAcknowledgement.R41_AdditionalDetail()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail ToFiles(this Models.SQL.PurchaseAcknowledgement.R41_AdditionalDetail current)
		{
			Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail to = new Models.Files.PurchaseAcknowledgement.R41_AdditionalDetail()
			{

			};
			return to;
		}

	}
}
