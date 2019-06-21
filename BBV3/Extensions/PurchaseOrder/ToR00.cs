using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Extensions.PurchaseOrder
{
	public static class ToR00
	{
		public static Models.SQL.PurchaseOrder.R00_ClientFileHeader ToSQL(this  Models.Files.PurchaseOrder.R00_ClientFileHeader current)
		{
			Models.SQL.PurchaseOrder.R00_ClientFileHeader to = new Models.SQL.PurchaseOrder.R00_ClientFileHeader()
			{
				CreationDate = current.CreationDate,
				Filename = current.Filename,
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


		public static Models.Files.PurchaseOrder.R00_ClientFileHeader ToFiles(this Models.SQL.PurchaseOrder.R00_ClientFileHeader current, short sequence)
		{
			Models.Files.PurchaseOrder.R00_ClientFileHeader to = new Models.Files.PurchaseOrder.R00_ClientFileHeader()
			{
				CreationDate = current.CreationDate,
				Filename = current.Filename,
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
