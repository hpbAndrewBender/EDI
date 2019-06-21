using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatBBV3.Models.Files.PurchaseAcknowledgement.Selectors
{
	public class V3
	{
		public static Type Custom(MultiRecordEngine engine, string recordLine)
		{
			Console.WriteLine(recordLine);
			Type type = null;
			switch(recordLine.Substring(0,2))
			{
				case "02":
					type = typeof(R02_FileHeader);
					break;

				case "11":
					type = typeof(R11_PurchaseOrderHeader);
					break;

				case "21":
					type = typeof(R21_FreeFormVendor);
					break;

				case "40":
					type = typeof(R40_LineItem);
					break;

				case "41":
					type = typeof(R41_AdditionalDetail);
					break;

				case "42":
					type = typeof(R42_AdditionalLineItem);
					break;

				case "43":
					type = typeof(R43_AdditionalLineItem);
					break;

				case "44":
					type = typeof(R44_Item_NumberOrPrice);
					break;

				case "45":
					type = typeof(R45_AdditionalLineItem);
					break;

				case "59":
					type = typeof(R59_PurchaseOrderControlTotals);
					break;

				case "91":
					type = typeof(R91_FileTrailer);
					break;
			}
			return type;
			
		}
	}
}
