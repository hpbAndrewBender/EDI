using System;
using System.Collections.Generic;
using System.Text;

namespace CDFLite.Models.PurchaseAcknowledgement
{
	class R30_RecipientShipToNameAndAddress
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string RecipientName { get; set; }
	}
}
