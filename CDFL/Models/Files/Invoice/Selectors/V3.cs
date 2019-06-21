using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormatCDFL.Models.Files.Invoice.Selectors
{
	public class V3
	{
		public static Type Custom(MultiRecordEngine engine, string recordLine)
		{
			Console.WriteLine(recordLine);
			Type type = null;
			switch(recordLine.Substring(0,2))
			{
				case "01":
					type = typeof(R01_InvoiceFileHeader);
					break;

				case "15":
					type = typeof(R15_InvoiceHeader);
					break;			

				case "45":
					type = typeof(R45_InvoiceDetail);
					break;

				case "46":
					type = typeof(R46_InvoiceDetail);
					break;

				case "48":
					type = typeof(R48_DetailTotal);
					break;

				case "49":
					type = typeof(R49_DetailTotalOrFreightAndFees);
					break;

				case "55":
					type = typeof(R55_InvoiceTotals);
					break;

				case "57":
					type = typeof(R57_InvoiceTrailer);
					break;

				case "95":
					type = typeof(R95_InvoiceFileTrailer);
					break;
			}
			return type;
			
		}
	}
}
