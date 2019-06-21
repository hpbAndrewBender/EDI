using System;
using System.Collections.Generic;

namespace FormatBBV3.Models.Files.PurchaseOrder.DataSequence
{
	public class PurchaseOrder : IDisposable
	{
		public PurchaseOrder()
		{
			ClientHeaderRecord = new R10_ClientHeader();
			FixedHandlingInstructionsRecord = new R20_FixedSpecialHandlingInstructions();
			PurchaseOrderOptionsRecord = new R21_PurchaseOrderOptions();
			PurchaseOrderDetails = new List<PurchaseOrderDetail>();
			Initialized = true;
		}

		public bool Initialized { get; private set; }
		//
		public R10_ClientHeader ClientHeaderRecord { get; set; }
		public R20_FixedSpecialHandlingInstructions FixedHandlingInstructionsRecord { get; set; }
		public R21_PurchaseOrderOptions PurchaseOrderOptionsRecord { get; set; }
		public List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
	

		public void Dispose()
		{
			ClientHeaderRecord = null;
			FixedHandlingInstructionsRecord = null;
			PurchaseOrderOptionsRecord = null;
			PurchaseOrderDetails = null;
			Initialized = false;
		}
	}
}