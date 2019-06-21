using System;
using System.Collections.Generic;

namespace FormatBBV3.Models.Files.ShipNotice.DataSequence
{
	public class V3 : IDisposable
	{
		public V3()
		{
			FileHeaderRecord = new CR_ASNCompany();
			PackRecord = new OP_ASNPack();
			Shipments = new List<Shipment>();
			Initialized = true;
		}

		public bool Initialized { get; private set; }
		public CR_ASNCompany FileHeaderRecord { get; set; }
		public OP_ASNPack PackRecord { get; set; }
		public List<Shipment> Shipments { get; set; }

		public void Dispose()
		{
			FileHeaderRecord = null;
			PackRecord = null;
			Shipments = null;
			Initialized = false;
		}
	}
}