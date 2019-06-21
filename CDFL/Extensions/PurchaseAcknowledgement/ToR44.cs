using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseAcknowledgement
{
	public static class ToR44
	{
		public static Models.SQL.PurchaseAcknowledgement.R44_ItemNumberOrPrice ToSQL(this Models.Files.PurchaseAcknowledgement.R44_ItemNumberOrPrice current)
		{
			Models.SQL.PurchaseAcknowledgement.R44_ItemNumberOrPrice to = new Models.SQL.PurchaseAcknowledgement.R44_ItemNumberOrPrice()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R44_ItemNumberOrPrice ToFiles(this Models.SQL.PurchaseAcknowledgement.R44_ItemNumberOrPrice current)
		{
			Models.Files.PurchaseAcknowledgement.R44_ItemNumberOrPrice to = new Models.Files.PurchaseAcknowledgement.R44_ItemNumberOrPrice()
			{

			};
			return to;
		}

	}
}
