using System;
using System.Collections.Generic;

namespace FormatBBV3.Models.Files.PurchaseOrder.DataSequence
{
	public class V3 : IDisposable
	{
		public Dictionary<string, byte> Maxes = new Dictionary<string, byte>()
		{
			{ "R45_IMPRINT", 4},
			{ "R46_STICKERTEXTLINES", 3 }
		};

		public V3()
		{
			FileHeaderRecord = new R00_ClientFileHeader();
			PurchaseOrders = new List<PurchaseOrder>();
			FileTrailerRecord = new R90_FileTrailer();
			PurchaseOrderTrailerRecord = new R50_PurchaseOrderTrailer();
			Initialized = true;
		}

		public bool Initialized { get; private set; }
		//
		public R00_ClientFileHeader FileHeaderRecord { get; set; }
		public List<PurchaseOrder> PurchaseOrders = new List<PurchaseOrder>();
		public R50_PurchaseOrderTrailer PurchaseOrderTrailerRecord { get; set; }
		public R90_FileTrailer FileTrailerRecord { get; set; }


		public void Dispose()
		{
			FileHeaderRecord = null;
			PurchaseOrders = null;
			FileTrailerRecord = null;
			PurchaseOrderTrailerRecord = null;
			Initialized = false;
		}
	}
}