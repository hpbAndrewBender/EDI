﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CDFLite.Models.PurchaseOrder
{
	class R36_SpecialDeliveryInstructions
	{
	
		public int Id {get;set;}

		public byte RecordCode {get;set;}

		public short SequenceNumber {get;set;}

		public string PONumber {get;set;}

		public string SpecialDeliveryInstructions {get;set;}
	}
}
