using System;

namespace FormatBBV3.Models.SQL.ShipNotice
{
	public class OP_ASNPack
	{
		public int Id { get; set; }

		public string PackRecordIdentifier { get; set; }

		public string ShippingDCCode { get; set; }

		public string SSL { get; set; }

		public string TrackingNumber { get; set; }

		public string SCAC { get; set; }

		public string CarrierActualNumber { get; set; }

		public decimal Weight { get; set; }

		public short NumberofUnitsinBox { get; set; }

		public DateTime ShipmentDate { get; set; }
	}
}