using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatCDFL.Models.Files.PurchaseOrder.Selectors
{
	public class V3
	{
		public static Type Custom(MultiRecordEngine engine, string recordLine)
		{
			Console.WriteLine(recordLine);
			Type type = null;
			switch(recordLine.Substring(0,2))
			{
				case "00":
					type = typeof(R00_FileHeader);
					break;

				case "10":
					type = typeof(R10_ClientHeader);
					break;

				case "20":
					type = typeof(R20_FixedSpecialHandlingInstructions);
					break;

				case "21":
					type = typeof(R21_PurchaseOrderOptions);
					break;

				case "24":
					type = typeof(R24_CustomerCost);
					break;

				case "25":
					type = typeof(R25_CustomerBillToName);
					break;

				case "26":
					type = typeof(R26_CustomerBillToPhoneNumber);
					break;

				case "27":
					type = typeof(R27_CustomerBillToAddressLine);
					break;

				case "29":
					type = typeof(R29_CustomerBillToCityStateZip);
					break;

				case "30":
					type = typeof(R30_RecipientShipToName);
					break;

				case "31":
					type = typeof(R31_RecipientShipToPhone);
					break;

				case "32":
					type = typeof(R32_ShippingRecordRecipientAddressLine);
					break;

				case "34":
					type = typeof(R34_RecipientShippingRecordCityStateZip);
					break;

				case "35":
					type = typeof(R35_DropShipDetail);
					break;

				case "36":
					type = typeof(R36_SpecialDeliveryInstructions);
					break;

				case "37":
					type = typeof(R37_MarketingMessage);
					break;

				case "38":
					type = typeof(R38_GiftMessage);
					break;

				case "40":
					type = typeof(R40_LineItem);
					break;

				case "41":
					type = typeof(R41_AdditionalLineItem);
					break;

				case "42":
					type = typeof(R42_LineItemGiftMessage);
					break;

				case "45":
					type = typeof(R45_Imprint);
					break;

				case "50":
					type = typeof(R50_PurchaseOrderControl);
					break;

				case "90":
					type = typeof(R90_FileTrailer);
					break;
			}
			return type;
			
		}
	}
}
