using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class ITD : FormatX12_3060.Models.Abstracted.ITD
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string  Command { get; set; }
		public List<int> RequiredFields { get; set; }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long ITDId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			ITD01 = 1, TermsTypeCode = ITD01,
			ITD02 = 2, TermsBasisDateCode = ITD02,
			ITD03 = 3, TermsDiscountPercent = ITD03,
			ITD04 = 4, TermsDiscountDueDate = ITD04,
			ITD05 = 5, TermsDiscountDaysDue = ITD05,
			ITD06 = 6, TermsNetDueDate = ITD06,
			ITD07 = 7, TermsNetDays = ITD07,
			ITD08 = 8, TermsDiscountAmount = ITD08,
			ITD14 = 14, PaymentMethodCode = ITD14,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "TermsTypeCode", (int)Ordinal.TermsTypeCode },
			{ "TermsBasisDateCode",  (int)Ordinal.TermsBasisDateCode },
			{ "TermsDiscountPercent", (int)Ordinal.TermsDiscountPercent},
			{ "TermsDiscountDueDate", (int)Ordinal.TermsDiscountDueDate},
			{ "TermsDiscountDaysDue", (int)Ordinal.TermsDiscountDaysDue},
			{ "TermsNetDueDate", (int)Ordinal.TermsNetDueDate},
			{ "TermsNetDays", (int)Ordinal.TermsNetDays },
			{ "TermsDiscountAmount", (int)Ordinal.TermsDiscountAmount},
			{ "PaymentMethodCode", (int)Ordinal.PaymentMethodCode},
		};
	}
}