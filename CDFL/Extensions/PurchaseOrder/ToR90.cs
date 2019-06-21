using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR90
	{
		public static Models.SQL.PurchaseOrder.R90_FileTrailer ToSQL(this Models.Files.PurchaseOrder.R90_FileTrailer current)
		{
			Models.SQL.PurchaseOrder.R90_FileTrailer to = new Models.SQL.PurchaseOrder.R90_FileTrailer
			{

			};
			return to;
		}




		public static Models.Files.PurchaseOrder.R90_FileTrailer ToFiles(this Models.SQL.PurchaseOrder.R90_FileTrailer current)
		{
			Models.Files.PurchaseOrder.R90_FileTrailer to = new Models.Files.PurchaseOrder.R90_FileTrailer()
			{

			};
			return to;
		}
	}
}
