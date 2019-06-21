using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class BIG : FormatX12_3060.Models.Abstracted.BIG
	{
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public string Command { get; set; }
		public List<int> RequiredFields { get; set; }		
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long BIGId { get; set; }
		public enum Ordinal
		{
			Command = 0,
			BIG01 = 1, Date_01 = BIG01,
			BIG02 = 2, InvoiceNumber = BIG02,
			BIG03 = 3, Date_02 = BIG03,
			BIG04 = 4, PurchaseOrderNumber = BIG04,
			BIG05 = 5, ReleaseNumber = BIG05,
			BIG06 = 6, ChangeOrderSquenceNumber = BIG06,
			BIG07 = 7, TransactionTypeCode = BIG07,
			BIG08 = 8, TransactionSetPurposeCode = BIG08,
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "Date_01" ,(int)Ordinal.Date_01 },
			{ "InvoiceNumber",(int)Ordinal.InvoiceNumber },
			{ "Date_02",(int)Ordinal.Date_02 },
			{ "PurchaseOrderNumber",(int)Ordinal.PurchaseOrderNumber },
			{ "ReleaseNumber" ,(int) Ordinal.ReleaseNumber },
			{ "ChangeOrderSquenceNumber",(int) Ordinal.ChangeOrderSquenceNumber },
			{ "TransactionTypeCode" ,(int) Ordinal.TransactionTypeCode },
			{ "TransactionSetPurposeCode" ,(int) Ordinal.TransactionSetPurposeCode },
		};
	}
}