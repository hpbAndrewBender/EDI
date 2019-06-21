using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class AK4
	{
		public AK4()
		{
			Meta_ErrorCodes=new List<MetaCodes>
			{
				new MetaCodes("1","Mandatory data element missing"),
				new MetaCodes("2","Conditional required data element missing."),
				new MetaCodes("3","Too many data elements."),
				new MetaCodes("4","Data element too short."),
				new MetaCodes("5","Data element too long."),
				new MetaCodes("6","Invalid character in data element."),
				new MetaCodes("7","Invalid code value."),
				new MetaCodes("8","Invalid Date"),
				new MetaCodes("9","Invalid Time"),
				new MetaCodes("10","Exclusion Condition Violated"),
			};
			Meta_Data=new List<MetaData>
			{
				new MetaData("AK401",   "C030",  "M",    "  ",   0, 0,   MetaData.UsageName.Required, string.Empty,   "Position in Segment",             "PositionInSegment",           null),
				new MetaData("AK402",   "725",   "O",    "N0",   1, 4,   MetaData.UsageName.Used,     string.Empty,   "Data Element Reference Number",   "DataElementReferenceNumber",  null),
				new MetaData("AK403",   "723",   "M",    "ID",   1, 3,   MetaData.UsageName.Required, string.Empty,   "Data Element Syntax Error Code",  "DataElementSyntaxErrorCode",  Meta_ErrorCodes),
				new MetaData("AK404",   "724",   "O",    "AN",   1,99,   MetaData.UsageName.Used,     string.Empty,   "Copy of Bad Data Element",        "CopyOfBadDataElement",        null),
			};
		}

		public virtual List<MetaCodes> Meta_ErrorCodes { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		///	AK401 C030 Position in Segment M
		///		C03001 722 Element Position in Segment M N0 1/2
		///		C03002 1528 Component Data Element Position in Composite O N0 1/2
		/// </summary>
		public virtual string PositionInSegment { get; set; }

		/// <summary>
		/// AK402 725 Data Element Reference Number O N0 1/4
		/// </summary>
		public virtual string DataElementReferenceNumber { get; set; }


		/// <summary>
		/// AK403 723 Data Element Syntax Error Code M ID 1/3
		/// </summary>
		public virtual string DataElementSyntaxErrorCode { get; set; }


		/// <summary>
		/// AK404 724 Copy of Bad Data Element O AN 1/99
		/// </summary>
		public virtual string CopyOfBadDataElement { get; set; }
	}
}
/*
AK401 C030 Position in Segment M
	C03001 722 Element Position in Segment M N0 1/2
	C03002 1528 Component Data Element Position in Composite O N0 1/2
AK402 725 Data Element Reference Number O N0 1/4
AK403 723 Data Element Syntax Error Code M ID 1/3
	1 Mandatory data element missing
	2 Conditional required data element missing.
	3 Too many data elements.
	4 Data element too short.
	5 Data element too long.
	6 Invalid character in data element.
	7 Invalid code value.
	8 Invalid Date
	9 Invalid Time
	10 Exclusion Condition Violated
AK404 724 Copy of Bad Data Element O AN 1/99
*/
