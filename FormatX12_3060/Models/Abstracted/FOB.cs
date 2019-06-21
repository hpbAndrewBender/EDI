using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class FOB
	{
		public FOB()
		{
			Meta_ShipmentMethodOfPayments = new List<MetaCodes>
			{
				new MetaCodes("BP","Paid by Buyer(The buyer agrees to the transportation payment term requiring the buyer to pay transportation charges to a specified location[origin or destination  location]"),
				new MetaCodes("CA","Advance Collect"),
				new MetaCodes("CC","Collect"),
				new MetaCodes("MX","Mixed"),
				new MetaCodes("PA","Advance Prepaid"),
				new MetaCodes("PC","Prepaid but Charged to Customer"),
				new MetaCodes("PP","Prepaid(by Seller)"),
				new MetaCodes("PS","Paid by Seller(The seller agrees to the transportation payment term requiring the seller to pay transportation charges to a specified location[origin or destination location])"),
				new MetaCodes("TP","Third Party Pay"),
			};

			Meta_Data = new List<MetaData>
			{
				new MetaData("FOB01",   "146",  "M",    "ID",   2, 2,   MetaData.UsageName.Must,     string.Empty,   "Shipment Method of Payment",           "ShipmentMethodOfPayment",      Meta_ShipmentMethodOfPayments),
			};
		}

		public virtual List<MetaCodes> Meta_ShipmentMethodOfPayments { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Method of Payment for Shipments
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		FOB01	146		M	ID		002	002 Must			Shipment Method of Payment 
		///															Code	Name
		///															----	---------------
		///															BP		Paid by Buyer (The buyer agrees to the transportation payment term requiring the buyer to pay transportation 
		///																	charges to a specified location [origin or destination	location])
		///															CA		Advance Collect
		///															CC		Collect
		///															MX		Mixed
		///															PA		Advance Prepaid
		///															PC		Prepaid but Charged to Customer
		///															PP		Prepaid (by Seller)
		///															PS		Paid by Seller (The seller agrees to the transportation payment term requiring the seller to pay transportation 
		///																	charges to a specified location [origin or destination location])
		///															TP		Third Party Pay
		/// </summary>
		virtual public object ShipmentMethodOfPayment { get; set; }
	}
}