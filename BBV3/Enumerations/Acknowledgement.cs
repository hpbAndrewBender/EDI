using CommonLib.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FormatBBV3.Enumerations
{
	public static class Acknowledgement
	{

		public static IngramPOAStatus ValueToString( string  value)
		{
			IngramPOAStatus result=0;
			switch(value)
			{
				case "00":
					result = IngramPOAStatus.Ship_AllProduct_PrimaryDC;
					break;

				case "01":
					result = IngramPOAStatus.Cancel_NotStocked;
					break;

				case "02":
					result = IngramPOAStatus.Cancel_TempOutOfStock;
					break;

				case "03":
					result = IngramPOAStatus.Backorder_OutOfStock;
					break;

				case "04":
					result = IngramPOAStatus.Ship_AllProduct;
					break;

				case "05":
					result = IngramPOAStatus.Cancel_Invalid;
					break;

				case "06":
					result = IngramPOAStatus.PartialBO;
					break;

				case "07":
					result = IngramPOAStatus.Backorder;
					break;

				case "08":
					result = IngramPOAStatus.Cancel_InvalidQuantity;
					break;

				case "09":
					result = IngramPOAStatus.PartialBO_SecondaryDC_ReaminderBackordered;
					break;

				case "10":
					result = IngramPOAStatus.Cancel;
					break;

				case "11":
					result = IngramPOAStatus.Cancel_Secondary_ResendLaterDate;
					break;

				case "12":
					result = IngramPOAStatus.Backorder_NotYetReceived_Primary_DC;
					break;

				case "13":
					result = IngramPOAStatus.Cancel_OutofStock_NoBackorder;
					break;

				case "14":
					result = IngramPOAStatus.Cancel_OutOfPrint;
					break;

				case "15":
					result = IngramPOAStatus.Cancel_Secondary;
					break;

				case "20":
					result = IngramPOAStatus.Backorder_NotYetReceived;
					break;

				case "22":
					result = IngramPOAStatus.Cancel_InvalidBackorderCancellationDate;
					break;

				case "23":
					result = IngramPOAStatus.Cancel_InvalidBackorderCode;
					break;

				case "24":
					result = IngramPOAStatus.PartialCAN_PartialShipment_PrimaryDC;
					break;

				case "25":
					result = IngramPOAStatus.PartialCAN_PartialShipment_SecondaryDC;
					break;

				case "26":
					result = IngramPOAStatus.Cancel_NotYetReceived_PrimaryDC;
					break;

				case "28":
					result = IngramPOAStatus.Cancel_NotYetReceived_SecondaryDC;
					break;

				case "30":
					result = IngramPOAStatus.Ship_AllProduct_AllDCs;
					break;

				case "31":
					result = IngramPOAStatus.PartialBO_Remainder_PrimaryDC;
					break;

				case "32":
					result = IngramPOAStatus.PartialBO_Remainder_SecondaryDC;
					break;

				case "33":
					result = IngramPOAStatus.PartialCAN_Remainder_Cancelled;
					break;

				case "35":
					result = IngramPOAStatus.Ship_AllProduct_SecondaryDC_Delayed;
					break;

				case "37":
					result = IngramPOAStatus.PartialBO_Secondary_NotYetReceived_RemainderBackordered;
					break;

				case "38":
					result = IngramPOAStatus.PartialCAN_Secondary_NotYetReceived_RemainderCancelled;
					break;

				case "46":
					result = IngramPOAStatus.Cancel_OrderSpendingLimitExceeded;
					break;

				case "47":
					result = IngramPOAStatus.PartialCAN_Primary_OrderSpendingLimitExceeded_RemainderCancelled;
					break;
				case "48":
					result = IngramPOAStatus.PartialCAN_Secondary_OrderSpendingLimitExceeded_RemainderCancelled;
					break;

				case "49":
					result = IngramPOAStatus.PartialCAN_PrimaryAndSecondary_OrderSpendingLimitExceeded_RemainderCancelled;
					break;

			}
			return result;
		}

		public enum IngramPOAStatus
		{
			[StringValue("Predicted to Ship 100% of ordered product, Primary DC")]
			Ship_AllProduct_PrimaryDC = 0,

			[StringValue("Item Not Stocked by Ingram")]
			Cancel_NotStocked = 1,

			[StringValue("Temporarily Out of Stock, on order with the publisher, no backorder -- Resend order on a later date or backorder")]
			Cancel_TempOutOfStock = 2,

			[StringValue("Out of Stock, backordered per Client request")]
			Backorder_OutOfStock = 3,

			[StringValue("Predicted to Ship 100% of ordered product, Secondary DC")]
			Ship_AllProduct = 4,

			[StringValue("Cancelled, Invalid Item Number, Item is Restricted,Fix and resend order")]
			Cancel_Invalid =5,

			[StringValue("Partial Shipment, Primary DC, remainder backordered per Client request")]
			PartialBO = 6,

			[StringValue("Secondary DC, backordered")]
			Backorder = 7,

			[StringValue("Invalid Quantity (Order Quantity = zero or value is not numeric) -- Fix and Resend")]
			Cancel_InvalidQuantity = 8,

			[StringValue("Partial Shipment, Secondary DC, remainder backordered per Client request")]
			PartialBO_SecondaryDC_ReaminderBackordered=9,

			[StringValue("Cancelled, Not Stocked--Fix and resend order")]
			Cancel=10,

			[StringValue("Secondary DC Title, no backorder--Resend order on a later date")]
			Cancel_Secondary_ResendLaterDate=11,

			[StringValue("Not Yet Received, Primary DC, backordered per Client request")]
			Backorder_NotYetReceived_Primary_DC=12,

			[StringValue("Out of Stock Indefinitely, no backorder allowed")]
			Cancel_OutofStock_NoBackorder=13,

			[StringValue("Out Of Print")]
			Cancel_OutOfPrint=14,

			[StringValue("Secondary, Out Of Stock, no backorder--Resend order on a later date or backorder")]
			Cancel_Secondary =15,

			[StringValue("Not Yet Received, Secondary DC, backordered per Client request")]
			Backorder_NotYetReceived=20,

			[StringValue("Invalid Backorder Cancellation Date--Fix and resend order")]
			Cancel_InvalidBackorderCancellationDate=22,

			[StringValue("Invalid Backorder Code, Fix and resend order")]
			Cancel_InvalidBackorderCode= 23, 

			[StringValue("Partial Shipment, Primary DC, no backorder, remainder cancelled--Reshop remainder")]
			PartialCAN_PartialShipment_PrimaryDC= 24,

			[StringValue("Partial Shipment, Secondary DC, no backorder, remainder cancelled--Reshop remainder")]
			PartialCAN_PartialShipment_SecondaryDC=25,

			[StringValue("Not Yet Received, Primary DC, no backorder--Resend order on a later date or backorder")]
			Cancel_NotYetReceived_PrimaryDC=26,

			[StringValue("Not Yet Received, Secondary DC, no backorder--Resend order on a later date or backorder")]
			Cancel_NotYetReceived_SecondaryDC=28,

			[StringValue("Predicted to Ship 100% of ordered product, Primary and Secondary DC's")]
			Ship_AllProduct_AllDCs=30,

			[StringValue("Partial Shipment, Primary and Secondary DC's, remainder backordered in Primary DC")]
			PartialBO_Remainder_PrimaryDC=31,

			[StringValue("Partial Shipment, Primary and Secondary DC's, remainder backordered in Secondary DC")]
			PartialBO_Remainder_SecondaryDC=32,

			[StringValue("Partial Ship, Primary and Secondary DC's, no backorder, remainder cancelled--Resend order on a alter date or backorder")]			
			PartialCAN_Remainder_Cancelled=33,

			[StringValue("Predicted to Ship 100% of ordered product, Secondary DC, add 1 day delay for shipment")]
			Ship_AllProduct_SecondaryDC_Delayed=35,

			[StringValue("Partial Shipment, Secondary, Not Yet Received, remainder backordered")]
			PartialBO_Secondary_NotYetReceived_RemainderBackordered=37,

			[StringValue("Partial Shipment, Secondary, Not Yet Received, no backorder, remainder cancelled")]
			PartialCAN_Secondary_NotYetReceived_RemainderCancelled = 38,

			[StringValue("Order spending limit exceeded")]
			Cancel_OrderSpendingLimitExceeded = 46,

			[StringValue("Partial shipment from Primary, order spending limit exceeded, remainder canceled")]
			PartialCAN_Primary_OrderSpendingLimitExceeded_RemainderCancelled = 47,

			[StringValue("Partial shipment from Secondary, order spending limit exceeded, remainder cancelled")]
			PartialCAN_Secondary_OrderSpendingLimitExceeded_RemainderCancelled = 48,

			[StringValue("Partial Shipment from Primary and Secondary, remainder cancelled, order spending limit exceeded")]
			PartialCAN_PrimaryAndSecondary_OrderSpendingLimitExceeded_RemainderCancelled = 49,


		}


	}
}
