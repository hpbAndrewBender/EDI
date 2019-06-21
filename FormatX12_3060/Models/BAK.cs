using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public abstract class BAK : FormatX12_3060.Models.Abstracted.BAK
	{
		public virtual string Command { get; set; }
		public virtual string ControlNumberGroup { get; set; }
		public virtual string ControlNumberTransaction { get; set; }
		public virtual List<int> RequiredFields { get; set; }
		public virtual long LineNumber { get; set; }
		public virtual int EDIFileID { get; set; }
		public virtual long BAKId { get; set; }

		public enum Ordinal
		{
			Command = 0,
			BAK01 = 1, TransactionSetPurposeCode = BAK01,
			BAK02 = 2, AcknowledgmentType = BAK02,
			BAK03 = 3, PurchaseOrderNumber = BAK03,
			BAK04 = 4, Date_01 = BAK04,
			BAK05 = 5, ReleaseNumber = BAK05,
			BAK06 = 6, RequestReferenceNumber = BAK06,
			BAK07 = 7, ContractNumber = BAK07,
			BAK08 = 8, Reserved_ForFutureUse_01 = BAK08,
			BAK09 = 9, Date_02 = BAK09
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command},
			{ "TransactionSetPurposeCode",(int)Ordinal.TransactionSetPurposeCode},
			{ "AcknowledgmentType",(int)Ordinal.AcknowledgmentType},
			{ "PurchaseOrderNumber",(int)Ordinal.PurchaseOrderNumber},
			{ "Date_01",(int)Ordinal.Date_01},
			{ "ReleaseNumber",(int)Ordinal.ReleaseNumber},
			{ "RequestReferenceNumber",(int)Ordinal.RequestReferenceNumber},
			{ "ContractNumber",(int)Ordinal.ContractNumber},
			{ "Date_02",(int)Ordinal.Date_02},
		};
	}
}