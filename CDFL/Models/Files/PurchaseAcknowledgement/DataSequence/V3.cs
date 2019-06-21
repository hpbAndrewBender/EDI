using System;
using System.Collections.Generic;
using System.Text;

namespace FormatCDFL.Models.Files.PurchaseAcknowledgement.DataSequence
{
	public class V3 : IDisposable
	{
		public Dictionary<string, byte> Maxes = new Dictionary<string, byte>()
		{
			{ "R21_FREEFORMVENDOR", 3},
			{ "R32_RECIPIENTSHIPTOADDITIONALSHIPPINGINFORMATION", 3 }
		};

		public V3()
		{
			FileHeaderRecord = new R02_FileHeader();
			PurchaseOrderHeaderRecord = new R11_PurchaseOrderHeader();
			FreeFormVendor = new List<R21_FreeFormVendor>();
			RecipShipToNameAndAddressRecord = new R30_RecipientShipToNameAndAddress();
			RecipShipToAdditionalShippingInfo = new List<R32_RecipientShipToAdditionalShippingInformation>();
			RecipShipToCityStateAndZipRecord = new R34_RecipientShipToCityStateAndZip();
			LineItems = new List<LineItem>();
			PurchaseOrderControlTotalsRecord = new R59_PurchaseOrderControlTotals();
			FileTrailerRecord = new R91_FileTrailer();
			Initialized = false;
		}

		public bool Initialized { get; private set; }
		//
		public R02_FileHeader FileHeaderRecord { get; set; }
		public R11_PurchaseOrderHeader PurchaseOrderHeaderRecord { get; set; }
		public List<R21_FreeFormVendor> FreeFormVendor { get; set; }
		public R30_RecipientShipToNameAndAddress RecipShipToNameAndAddressRecord { get; set; }
		public List<R32_RecipientShipToAdditionalShippingInformation> RecipShipToAdditionalShippingInfo { get; set; }
		public R34_RecipientShipToCityStateAndZip RecipShipToCityStateAndZipRecord { get; set; }
		public List<LineItem> LineItems { get; set; }
		public R59_PurchaseOrderControlTotals PurchaseOrderControlTotalsRecord { get; set; }
		public R91_FileTrailer FileTrailerRecord { get; set; }

		public void Dispose()
		{
			FileHeaderRecord = null;
			PurchaseOrderHeaderRecord = null;
			FreeFormVendor = null;
			RecipShipToNameAndAddressRecord = null;
			RecipShipToAdditionalShippingInfo = null;
			RecipShipToCityStateAndZipRecord = null;
			LineItems = null;
			PurchaseOrderControlTotalsRecord = null;
			FileTrailerRecord = null;
			Initialized = false;
		}
	}
}
