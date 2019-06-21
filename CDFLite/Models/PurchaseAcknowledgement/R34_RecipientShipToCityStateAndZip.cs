﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CDFLite.Models.PurchaseAcknowledgement
{
	class R34_RecipientShipToCityStateAndZip
	{
		public int Id { get; set; }

		public byte RecordCode { get; set; }

		public short SequenceNumber { get; set; }

		public string PONumber { get; set; }

		public string RecipientCity { get; set; }

		public string RecipientStateOrProvince { get; set; }

		public string ZipOrPostalCode { get; set; }

		public string Country { get; set; }
	}
}
