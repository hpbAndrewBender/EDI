using System;
using System.Collections.Generic;
using System.Text;

namespace CDFLite.Models.PurchaseOrder
{
	class R37_MArketingMessage
	{
		public int Id {get; set;}

		public byte RecordCode {get; set;}

		public short SequenceNumber  {get; set;}

		public string PONumber  {get; set;}

		public string MarketingMessage  {get; set;}
	}
}
