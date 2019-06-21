using System;

namespace IngramContent.Models.PurchaseAck
{
	public class Files
	{
		public int Id { get; set; }

		public bool CDF { get; set; }

		public short Head_SequenceNumber { get; set; }

		public string Head_FileSourceSAN { get; set; }

		public string Head_FileSourceName { get; set; }

		public DateTime Head_POACreateDate { get; set; }

		public string Head_ElectronicControlUnit { get; set; }

		public string Head_Filename { get; set; }

		public string Head_FormatVersion { get; set; }

		public string Head_DestinationSAN { get; set; }

		public short Head_POAType { get; set; }

		public short Foot_TotalLinesInFile { get; set; }

		public short Foot_TotalPOSAcknowledged { get; set; }

		public short Foot_TotalUnitsAcknowledged { get; set; }

		public short Foot_RecCount_00to09 { get; set; }

		public short Foot_RecCount_10to19 { get; set; }

		public short Foot_RecCount_20to29 { get; set; }

		public short Foot_RecCount_30to39 { get; set; }

		public short Foot_RecCount_40to49 { get; set; }

		public short Foot_RecCount_50to59 { get; set; }

		public short Foot_RecCount_60to69 { get; set; }

		public short Foot_RecCount_70to79 { get; set; }

		public short Foot_RecCount_80to99 { get; set; }
	}
}