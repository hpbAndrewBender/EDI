using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseAcknowledgement
{
	public static class ToR91
	{
		public static Models.SQL.PurchaseAcknowledgement.R91_FileTrailer ToSQL(this Models.Files.PurchaseAcknowledgement.R91_FileTrailer current)
		{
			Models.SQL.PurchaseAcknowledgement.R91_FileTrailer to = new Models.SQL.PurchaseAcknowledgement.R91_FileTrailer()
			{

			};
			return to;
		}

		public static Models.Files.PurchaseAcknowledgement.R91_FileTrailer ToFiles(this Models.SQL.PurchaseAcknowledgement.R91_FileTrailer current)
		{
			Models.Files.PurchaseAcknowledgement.R91_FileTrailer to = new Models.Files.PurchaseAcknowledgement.R91_FileTrailer()
			{

			};
			return to;
		}

	}
}
