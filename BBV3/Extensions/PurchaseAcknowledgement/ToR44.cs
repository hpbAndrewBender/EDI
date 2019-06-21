using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseAcknowledgement
{
	public static class ToR44
	{
		public static Models.SQL.PurchaseAcknowledgement.R44_Item_NumberOrPrice ToSQL(this Models.Files.PurchaseAcknowledgement.R44_Item_NumberOrPrice current)
		{
			Models.SQL.PurchaseAcknowledgement.R44_Item_NumberOrPrice to = new Models.SQL.PurchaseAcknowledgement.R44_Item_NumberOrPrice()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R44_Item_NumberOrPrice ToFiles(this Models.SQL.PurchaseAcknowledgement.R44_Item_NumberOrPrice current)
		{
			Models.Files.PurchaseAcknowledgement.R44_Item_NumberOrPrice to = new Models.Files.PurchaseAcknowledgement.R44_Item_NumberOrPrice()
			{

			};
			return to;
		}

	}
}
