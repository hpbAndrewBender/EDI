using System;

namespace DataHPBEDI.Models.EDI.Transactions
{
	public class Transactions
	{
		public int Id { get; set; }
		public long ProcessLogId { get; set; }
		public int SourceLocationId { get; set; }
		public string LineNumer { get; set; }
		public int OrderLogId { get; set; }
		public int AcknowledgementLogId { get; set; }
		public int ShipLogId { get; set; }
		public int InvoiceLogId { get; set; }
		public DateTime DateIssued { get; set; }
		public string PurposeCode { get; set; }
		public string CountryCode { get; set; }
		public string FillTermsCode { get; set; }
		public string TotalPayable { get; set; }
		public string OrderStatus { get; set; }
		public string BuyerIdType { get; set; }
		public string BuyerId { get; set; }
		public string SourceIdType { get; set; }
		public string SourceId { get; set; }
		public string SellerIdType { get; set; }
		public string SellerId { get; set; }
		public string ShipToName { get; set; }
		public string ShipToAddress1 { get; set; }
		public string ShipToAddress2 { get; set; }
		public string ShipToCity { get; set; }
		public string ShipToState { get; set; }
		public string ShipToZip { get; set; }
		public string ShipToCountryCode { get; set; }
		public string BillToName { get; set; }
		public string BillToAddress1 { get; set; }
		public string BillToAddress2 { get; set; }
		public string BillToCity { get; set; }
		public string BillToState { get; set; }
		public string BillToZip { get; set; }
		public string BillToCountryCode { get; set; }
		public string TransportIdType { get; set; }
		public string TransportId { get; set; }
		public string TextMessage { get; set; }
		public string ProductIdType { get; set; }
		public string ProductId { get; set; }
		public string ItemDescription { get; set; }
		public decimal UnitPrice { get; set; }
		public int QuantityOrdered { get; set; }
		public int QuantityConfirmed { get; set; }
		public int QuantityBackOrdered { get; set; }
		public int QuantityCancelled { get; set; }
		public int QuantityShipped { get; set; }
		public int QuantityInvoiced { get; set; }
		private string OrderLineStatus { get; set; }
		private string LineStatusDescription { get; set; }
		public DateTime DateShipStatus { get; set; }
		public DateTime DateShipNotice { get; set; }
		public string CarrierNameCodeType { get; set; }
		public string CarrierNameCode { get; set; }
		public string CustomerOrderReference { get; set; }
		public string PackageNumber { get; set; }
		public string PackageMarkTypeCode { get; set; }
		public string PackageMarkValue { get; set; }
		public string ChargeTypeCode { get; set; }
		public string ChargeTypeDescripton { get; set; }
		public decimal ChargeAmount { get; set; }
		public DateTime DateTimeInsertedUTC { get; set; }
	}
}