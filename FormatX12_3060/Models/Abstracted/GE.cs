using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class GE
	{
		public GE()
		{
			Meta_Data=new List<MetaData>
			{
				new MetaData("GE01",    "???",  "?",    "??",   0, 0,   MetaData.UsageName.Required, string.Empty,   "Number of Included Functional Groups", "NumberOfIncludedFunctionalGroups", null),
				new MetaData("GE02",    "???",  "?",    "??",   0, 0,   MetaData.UsageName.Required, string.Empty,   "Control Group Number [See GS06]",      "ControlGroupNumber",               null),
			};
		}

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		GE01												Number of Included Functional Groups
		/// </summary>
		virtual public object NumberOfIncludedFunctionalGroups { get; set; }


		/// <summary>
		/// 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		GE02												Group Control Number (same as GS06)
		/// </summary>
		virtual public object GroupControlNumber { get; set; }
		}
}