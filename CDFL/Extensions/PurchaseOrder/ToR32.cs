using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR32
	{
		public static Models.SQL.PurchaseOrder.R32_ShippingRecordRecipientAddressLine ToSQL(this Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine current)
		{
			Models.SQL.PurchaseOrder.R32_ShippingRecordRecipientAddressLine to = new Models.SQL.PurchaseOrder.R32_ShippingRecordRecipientAddressLine()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine ToFiles(this Models.SQL.PurchaseOrder.R32_ShippingRecordRecipientAddressLine current)
		{
			Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine to = new Models.Files.PurchaseOrder.R32_ShippingRecordRecipientAddressLine()
			{

			};
			return to;
		}
	}
}
