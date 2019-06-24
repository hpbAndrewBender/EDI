using System;
using System.Collections.Generic;
using System.Text;

namespace DataHPBEDI.Models.EDI.Transactions
{
	public class ProcessLog
	{
		public int Id { get; set; }
		public string VendorId { get; set; }
		public byte SourceTypeId { get; set; }
		public byte TransactionId { get; set; }
		public string OrderNumber { get; set; }
		public bool Processed { get; set; }
		public DateTime ProcessedDateTime { get; set; }
	}
}
