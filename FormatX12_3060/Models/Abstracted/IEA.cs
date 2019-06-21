using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class IEA
	{
		public IEA()
		{
			Meta_Data=new List<MetaData>
			{
				new MetaData("IEA01",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown, string.Empty,   "Number of Included Functional Groups", "NumberOfIncludedFunctionalGroups",     null),
				new MetaData("IEA02",   "???",  "?",    "??",   0, 0,   MetaData.UsageName.Unknown, string.Empty,   "Interchange Control Number",           "InterchangeControlNumber",             null),
			};
		}

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		///  Number of functional groups in this ISA/IEA pairing
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IEA01												Number of Included Functional Groups
		/// </summary>
		virtual public object NumberOfIncludedFunctionalGroups { get; set; }

		/// <summary>
		/// Number that must match ISA13 - Interchange Control Number
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IEA02												Interchange Control Number
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object InterchangeControlNumber { get; set; }
	}
}
