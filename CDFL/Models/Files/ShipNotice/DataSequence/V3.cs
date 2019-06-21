using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Models.Files.ShipNotice.DataSequence
{
	public class V3: IDisposable
	{
		public V3()
		{
			CompanyRecord = new CR_CompanyRecord();
			Shipments = new List<Shipment>();
			Initialized = true;

		}
		public Dictionary<string, byte> Maxes = new Dictionary<string, byte>()
		{
			{ "OR_OrderRecord", 0},
			{ "OD_OrderDetailRecord", 0 }
		};

		public bool Initialized { get; private set; }
		//
		public CR_CompanyRecord CompanyRecord {get;set;}
		public List<Shipment> Shipments { get; set; }

		public void Dispose()
		{
			CompanyRecord = null;
			Shipments = null;
			//--OrderRecord = null;
			//--OrderDetailRecord = null;
			Initialized = false;

		}
	}
}
