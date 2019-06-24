using System;
using System.Collections.Generic;
using System.Text;

namespace DataHPBEDI.Models.EDI.Transactions
{
	public class ProcessTransaction
	{
		public byte Id { get; set; }
		public string TransactionName { get; set; }
		public string TransactionDescription { get; set; }
		public bool Active { get; set; }
	}
}
