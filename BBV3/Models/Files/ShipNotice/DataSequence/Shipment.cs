using System;
using System.Collections.Generic;

namespace FormatBBV3.Models.Files.ShipNotice.DataSequence
{
	public class Shipment : IDisposable
	{
		public Shipment()
		{
			ShipmentRecord = new OR_ASNShipment();
			LineItemDetailRecords = new List<OD_ASNShipmentDetail>();
			Initialized = true;
		}

		public bool Initialized { get; private set; }
		//
		public OR_ASNShipment ShipmentRecord { get; set; }
		public List<OD_ASNShipmentDetail> LineItemDetailRecords { get; set; }

		public void Dispose()
		{
			ShipmentRecord = null;
			LineItemDetailRecords = null;
			Initialized = false;
		}
	}
}