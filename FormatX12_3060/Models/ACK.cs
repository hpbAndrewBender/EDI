using System;
using System.Collections.Generic;

namespace FormatX12_3060.Models
{
	public class ACK : FormatX12_3060.Models.Abstracted.ACK 
	{
		public string Command { get; set; }
		public string ControlNumberGroup { get; set; }
		public string ControlNumberTransaction { get; set; }
		public List<int> RequiredFields { get => throw new NotImplementedException(); internal set => throw new NotImplementedException(); }
		public long LineNumber { get; set; }
		public int EDIFileID { get; set; }
		public long ACKId { get; set; }
		
		public enum Ordinal
		{
			Command = 0,
			ACK01 = 1, LineItemStatusCode = ACK01,
			ACK02 = 2, Quantity = ACK02,
			ACK03 = 3, UnitOrBasisForMeasurementCode = ACK03,
			ACK04 = 4, DateTimeQualifier = ACK04,
			ACK05 = 5, Date = ACK05,
			ACK06 = 6, Reserved_ForFutureUse_01 = ACK06,
			ACK07 = 7, ProductServiceIDQualifier_01 = ACK07,
			ACK08 = 8, ProductServiceID_01 = ACK08,
			ACK09 = 9, ProductServiceIDQualifier_02 = ACK09,
			ACK10 = 10, ProductServiceID_02 = ACK10,
			ACK11 = 11, ProductServiceIDQualifier_03 = ACK11,
			ACK12 = 12, ProductServiceID_03 = ACK12,
			ACK13 = 13, Reserved_ForFutureUse_02 = ACK13,
			ACK14 = 14, Reserved_ForFutureUse_03 = ACK14,
			ACK15 = 15, Reserved_ForFutureUse_04 = ACK15,
			ACK16 = 16, Reserved_ForFutureUse_05 = ACK16,
			ACK17 = 17, Reserved_ForFutureUse_06 = ACK17,
			ACK18 = 18, Reserved_ForFutureUse_07 = ACK18,
			ACK19 = 19, Reserved_ForFutureUse_08 = ACK19,
			ACK20 = 20, Reserved_ForFutureUse_09 = ACK20,
			ACK21 = 21, Reserved_ForFutureUse_10 = ACK21,
			ACK22 = 22, Reserved_ForFutureUse_11 = ACK22,
			ACK23 = 23, Reserved_ForFutureUse_12 = ACK23,
			ACK24 = 24, Reserved_ForFutureUse_13 = ACK25,
			ACK25 = 25, Reserved_ForFutureUse_14 = ACK25,
			ACK26 = 26, Reserved_ForFutureUse_15 = ACK26,
			ACK27 = 27, Reserved_ForFutureUse_16 = ACK27,
			ACK28 = 28, Reserved_ForFutureUse_17 = ACK28,
			ACK29 = 29, IndustryCode = ACK29
		}

		public static Dictionary<string,int> Ordinals = new Dictionary<string,int>
		{
			{ "Command", (int)Ordinal.Command },
			{ "LineItemStatusCode", (int)Ordinal.LineItemStatusCode},
			{ "Quantity", (int)Ordinal.Quantity },
			{ "UnitOrBasisForMeasurementCode", (int)Ordinal.UnitOrBasisForMeasurementCode },
			{ "DateTimeQualifier", (int)Ordinal.DateTimeQualifier},
			{ "Date", (int)Ordinal.Date},
			{ "ProductServiceIDQualifier_01", (int)Ordinal.ProductServiceIDQualifier_01},
			{ "ProductServiceID_01", (int)Ordinal.ProductServiceID_01},
			{ "ProductServiceIDQualifier_02", (int)Ordinal.ProductServiceIDQualifier_02},
			{ "ProductServiceID_02", (int)Ordinal.ProductServiceID_02},
			{ "ProductServiceIDQualifier_03", (int)Ordinal.ProductServiceIDQualifier_03},
			{ "ProductServiceID_03", (int)Ordinal.ProductServiceID_03},
			{ "IndustryCode", (int)Ordinal.IndustryCode}
		};
	}
}