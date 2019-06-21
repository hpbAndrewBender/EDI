using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class AK3
	{
		public AK3()
		{
			Meta_ErrorCodes = new List<MetaCodes>
			{
				new MetaCodes("1","Unrecognized segment ID"),
				new MetaCodes("2","Unexpected segment"),
				new MetaCodes("3","Mandatory segment missing"),
				new MetaCodes("4","Loop Occurs Over Maximum Times"),
				new MetaCodes("5","Segment Exceeds Maximum Use"),
				new MetaCodes("6","Segment Not in Defined Transaction Set"),
				new MetaCodes("7","Segment Not in Proper Sequence"),
				new MetaCodes("8","Segment Has Data Element Errors"),
			};
			Meta_Data = new List<MetaData>
			{
				new MetaData("AK301",   "721",  "M",    "ID",   2, 3,   MetaData.UsageName.Required, string.Empty,   "Segment ID Code",                      "SegmentIDCode",                   null),
				new MetaData("AK302",   "719",  "M",    "N0",   1, 6,   MetaData.UsageName.Used,     string.Empty,   "Segment Position in Transaction Set",  "SegmentPositionInTransactionSet", null),
				new MetaData("AK303",   "447",  "O",    "AN",   1, 6,   MetaData.UsageName.Required, string.Empty,   "Loop Identifier Code",                 "LoopIdentifierCode",              null),
				new MetaData("AK304",   "720",  "O",    "ID",   1, 3,   MetaData.UsageName.Used,     string.Empty,   "Segment Syntax Error Code",            "SegmentSyntaxErrorCode",           Meta_ErrorCodes),
			};
		}
		public virtual List<MetaCodes> Meta_ErrorCodes { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }
		
		/// <summary>
		///	AK301 721 Segment ID Code M ID 2/3 
		/// </summary>
		public virtual string SegmentIDCode { get; set; }

		/// <summary>
		/// AK302 719 Segment Position in Transaction Set M N0 1/6
		/// </summary>
		public virtual string SegmentPositionInTransactionSet { get; set; }


		/// <summary>
		/// AK303 447 Loop Identifier Code O AN 1/6
		/// </summary>
		public virtual string LoopIdentifierCode { get; set; }


		/// <summary>
		/// AK304 720 Segment Syntax Error Code O ID 1/3
		/// </summary>
		public virtual string SegmentSyntaxErrorCode { get; set; }
	}
}
