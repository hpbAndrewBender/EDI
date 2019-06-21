using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Models.Files.ShipNotice.DataSequence
{
	public class Shipment : IDisposable
	{

		public Shipment()
		{
			OrderRecord = new OR_OrderRecord();
			OrderDetail = new List<OD_OrderDetailRecord>();
			Initialized = true;
		}

		public bool Initialized { get; private set; }

		public OR_OrderRecord OrderRecord { get; set; }
		public List<OD_OrderDetailRecord> OrderDetail { get; set; }


		public void Dispose()
		{
			OrderRecord = null;
			OrderDetail = null;
			Initialized = false;
		}
	}
}