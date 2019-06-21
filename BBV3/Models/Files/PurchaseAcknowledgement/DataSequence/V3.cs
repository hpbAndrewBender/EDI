using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement.DataSequence
{
	public class V3 : IDisposable
	{
		public Dictionary<string, byte> Maxes = new Dictionary<string, byte>()
		{
			{ "R21_FREEFORMVENDOR", 3},
		};

		public V3()
		{
			FileHeaderRecord = new R02_FileHeader();
			PurchaseOrderHeaderRecord = new R11_PurchaseOrderHeader();
			FreeFormVendor = new List<R21_FreeFormVendor>();
			AcknowledgementItems = new List<AcknowledgementItem>();
			PurchaseOrderControlTotalsRecord = new R59_PurchaseOrderControlTotals();
			FileTrailerRecord = new R91_FileTrailer();
			Initialized = true;
		}
		public bool Initialized { get; private set; }
		//
		public R02_FileHeader FileHeaderRecord { get; set; }
		public R11_PurchaseOrderHeader PurchaseOrderHeaderRecord { get; set; }
		public List<R21_FreeFormVendor> FreeFormVendor { get; set; }
		public List<AcknowledgementItem> AcknowledgementItems { get; set; }
		public R59_PurchaseOrderControlTotals PurchaseOrderControlTotalsRecord { get; set; }
		public R91_FileTrailer FileTrailerRecord { get; set; }

		public void Dispose()
		{
			FileHeaderRecord = null;
			PurchaseOrderHeaderRecord = null;
			FreeFormVendor = null;
			AcknowledgementItems = null;
			PurchaseOrderControlTotalsRecord = null;
			FileTrailerRecord = null;
			Initialized = false;
		}
	}
}
