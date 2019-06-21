using System;
using System.Collections.Generic;

namespace FormatCDFL.Models.Files.PurchaseOrder.DataSequence
{
	public class V3 : IDisposable
	{
		/// <summary></summary>
		public Dictionary<string, byte> Maxes = new Dictionary<string, byte>()
		{
			{ "R27_CUSTOMERBILLTOADDRESSLINE", 3},
			{ "R32_SHIPPINGRECORDRECIPIENTADDRESSLINE", 3 },
			{ "R36_SPECIALDELIVERYINSTRUCTIONS", 2 },
			{ "R37_MARKETINGMESSAGE", 5 },
			{ "R38_GIFTMESSAGE", 5 },
			{ "R42_LINEITEMGIFTMESSAGE", 5 },
			{ "R45_IMPRINT", 3 }
		};

		/// <summary></summary>
		public V3()
		{
			FileHeaderRecord = new R00_FileHeader();
			PurchaseOrders = new List<PurchaseOrder>();
			FileTrailerRecord = new R90_FileTrailer();
			Initialized = true;
		}
		
		/// <summary></summary>
		public bool Initialized { get; private set; }

		/// <summary></summary>
		public R00_FileHeader FileHeaderRecord { get; set; }
		/// <summary></summary>
		public List<PurchaseOrder> PurchaseOrders = new List<PurchaseOrder>();
		/// <summary></summary>
		public R90_FileTrailer FileTrailerRecord { get; set; }

		/// <summary></summary>
		public void Dispose()
		{
			FileHeaderRecord = null;
			PurchaseOrders = null;
			FileTrailerRecord = null;
			Initialized = false;
		}
	}
}