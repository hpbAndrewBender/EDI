using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatBBV3.Models.Files.PurchaseOrder.Selectors
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
					type = typeof(R00_ClientFileHeader);
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

				case "40":
					type = typeof(R40_LineItemDetail);
					break;

				case "41":
					type = typeof(R41_AdditionalLineItemDetail);
					break;

				case "45":
					type = typeof(R45_Imprint);
					break;

				case "46":
					List<string> barcodeformat = new List<string>()
					{
						"UP",
						"EN",
						"ZZ",
						"SK"
					};
					if((from f in barcodeformat.AsEnumerable() where f.Contains(recordLine.Substring(29,2)) select f).Count() > 0)
					{
						// Sticker Barcode data
						type = typeof(R46_StickerBarcodeData);
					}
					else
					{
						type = typeof(R46_StickerTextLines);
					}
					break;

				case "50":
					type = typeof(R50_PurchaseOrderTrailer);
					break;

				case "90":
					type = typeof(R90_FileTrailer);
					break;
			}
			return type;
			
		}
	}
}
