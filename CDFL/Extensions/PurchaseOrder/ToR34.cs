using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR34
	{

		public static Models.SQL.PurchaseOrder.R34_RecipientShippingRecordCityStateZip ToSQL(this Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip current)
		{
			Models.SQL.PurchaseOrder.R34_RecipientShippingRecordCityStateZip to = new Models.SQL.PurchaseOrder.R34_RecipientShippingRecordCityStateZip()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip ToFiles(this Models.SQL.PurchaseOrder.R34_RecipientShippingRecordCityStateZip current)
		{
			Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip to = new Models.Files.PurchaseOrder.R34_RecipientShippingRecordCityStateZip()
			{

			};
			return to;
		}
	}
}
