using System;

namespace IngramContent.Models.PurchaseOrd
{
	public class Details
	{
		public int Id { get; set; }

		public int ClientId { get; set; }

		public string SpecialHandling_SpecialHandlingCodes { get; set; }

		public string Options_ShipToAccount { get; set; }

		public short Options_POType { get; set; }

		public short Options_OrderType { get; set; }

		public short Options_DCCode { get; set; }

		public bool Options_Greenlight { get; set; }

		public short Options_POAType { get; set; }

		public string Options_ShipToPassword { get; set; }

		public string Options_CarrierShiping { get; set; }

		public decimal Options_SplitOrder { get; set; }

		public decimal Cost_SalesTaxPercent { get; set; }

		public decimal Cost_FreightTaxPercent { get; set; }

		public decimal Cost_FreightAmount { get; set; }

		public string Consumer_Name { get; set; }

		public string Consumer_PhoneNumber { get; set; }

		public string Consumer_Address { get; set; }

		public string Consumer_City { get; set; }

		public string Consumer_State { get; set; }

		public string Consumer_PostalCode { get; set; }

		public string Consumer_Country { get; set; }

		public string Recipient_Name { get; set; }

		public short Recipient_Validation { get; set; }

		public string Recipient_Phone { get; set; }

		public string Recipient_Address { get; set; }

		public string Recipient_City { get; set; }

		public string Recipient_State { get; set; }

		public string Recipient_PostCode { get; set; }

		public string Recipient_Country { get; set; }

		public decimal Drop_GiftWrapFeeAmount { get; set; }

		public bool Drop_SendConsumerEmail { get; set; }

		public short Drop_OrderLevelGift { get; set; }

		public short Drop_SupressPrice {get;set;}

		public short Drop_OrderLevelGiftWrapCode { get; set; }

		public string Delivery_SpecialDeliveryInstructions { get; set; }

		public string Marketing_Message { get; set; }

		public string Gift_Message { get; set; }

		public string Item1_ReferenceNumber { get; set; }

		public string Item1_Number { get; set; }

		public short Item1_LineLevelBackorder { get; set; }

		public short Item1_SpecialActionCode { get; set; }

		public short Item1_NumberType { get; set; }

		public decimal Item2_ClientListPrice { get; set; }

		public DateTime Item2_BackOrderCancelDate { get; set; }

		public short Item2_GiftWrapCode { get; set; }

		public short Item2_OrderQuantity { get; set; }

		public string Item3_GiftMessage { get; set; }

		public short Imprint1_IndexCode {get;set;}
		
		public short Imprint1_Text { get; set; }

		public short Imprint1_Font { get; set; }

		public short Imprint1_Color { get; set; }

		public short Imprint1_Position { get; set; }

		public short Imprint2_IndexCode { get; set; }

		public short Imprint2_Text { get; set; }

		public short Imprint2_Font { get; set; }

		public short Imprint2_Color { get; set; }

		public short Imprint2_Position { get; set; }

		public short Imprint3_IndexCode { get; set; }

		public short Imprint3_Text { get; set; }

		public short Imprint3_Font { get; set; }

		public short Imprint3_Color { get; set; }

		public short Imprint3_Position { get; set; }
	}
}