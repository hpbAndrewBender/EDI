using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseOrder
{
	public static class ToR50
	{
		public static Models.SQL.PurchaseOrder.R50_PurchaseOrderTrailer ToSQL(this Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer current)
		{
			Models.SQL.PurchaseOrder.R50_PurchaseOrderTrailer to = new Models.SQL.PurchaseOrder.R50_PurchaseOrderTrailer()
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer ToFiles(this Models.SQL.PurchaseOrder.R50_PurchaseOrderTrailer current)
		{
			Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer to = new Models.Files.PurchaseOrder.R50_PurchaseOrderTrailer()
			{

			};
			return to;
		}
	}
}
