using System;
using System.Collections.Generic;
using System.Text;

namespace IngramContent.Models.PurchaseAck
{
	public class Purchase
	{
		public int Id { get; set; }

		public int FileId { get; set; }

		public string TerminalOrderControl { get; set; }

		public string PONumber { get; set; }

		public string IGCShipToAccount { get; set; }

		public string IGCSAN { get; set; }

		public short POStatus { get; set; }

		public DateTime AckDate { get; set; }

		public DateTime PODate { get; set; }

		public DateTime POCancellationDate { get; set; }

		public string VendorMessage { get; set; }

		public string ShipTo_RecipientName { get; set; }

		public string ShipTo_RecipientAddress { get; set; }

		public string ShipTo_City { get; set; }

		public string ShipTo_StateOrProvince { get; set; }

		public string ShipTo_PostCode { get; set; }

		public string ShipTo_Country { get; set; }

		public short OrderControl_RecordCount { get; set; }

		public short OrderControl_TotalLineItems { get; set; }

		public short OrderControl_TotalUnitsAck { get; set; }
	}
}
