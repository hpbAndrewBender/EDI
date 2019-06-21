using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Extensions.PurchaseOrder
{
	public static class ToR00
	{
		public static Models.SQL.PurchaseOrder.R00_FileHeader ToSQL(this  Models.Files.PurchaseOrder.R00_FileHeader current)
		{
			Models.SQL.PurchaseOrder.R00_FileHeader to = new Models.SQL.PurchaseOrder.R00_FileHeader()
			{
				CreationDate = current.CreationDate,
				FIleName = current.FileName,
				FileSourceName = current.FileSourceName,
				FileSourceSAN = current.FileSourceSAN,
				FormatVersion = current.FormatVersion,
				IngramSAN = current.IngramSAN,
				ProductDescription = current.ProductDescription,
				RecordCode = current.RecordCode,
				SequenceNumber = current.SequenceNumber,
				VendorNameFlag = current.VendorNameFlag,				
			}; 
			return to;
		}


		public static Models.Files.PurchaseOrder.R00_FileHeader ToFiles(this Models.SQL.PurchaseOrder.R00_FileHeader current, short sequence)
		{
			Models.Files.PurchaseOrder.R00_FileHeader to = new Models.Files.PurchaseOrder.R00_FileHeader()
			{
				CreationDate = current.CreationDate,
				FileName = current.FIleName,
				FileSourceName = current.FileSourceName,
				FileSourceSAN = current.FileSourceSAN,
				FormatVersion = current.FormatVersion,
				IngramSAN = current.IngramSAN,
				ProductDescription = current.ProductDescription,
				RecordCode = current.RecordCode,
				SequenceNumber = sequence > 0 ? sequence : current.SequenceNumber,
				VendorNameFlag = current.VendorNameFlag
			};
			return to;
		}

	}
}
