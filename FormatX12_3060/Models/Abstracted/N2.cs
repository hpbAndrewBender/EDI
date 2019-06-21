using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class N2
	{
		public N2()
		{
			Meta_Data = new List<MetaData>
			{
				new MetaData("N202",    "93",   "M",    "AN",   1,35,   MetaData.UsageName.Required, string.Empty,  "Name",                                 "Name_01",                      null),
				new MetaData("N201",    "93",   "M",    "AN",   1,35,   MetaData.UsageName.Required, string.Empty,  "Name",                                 "Name_02",                      null),
			};
		}

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Free-form name 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N201	93		M	AN		001	035	Requ'd			Name
		/// </summary>
		virtual public object Name_01 { get; set; }

		/// <summary>
		/// Free-form name
		/// 
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N202	93		M	AN		001	035	Requ'd			Name
		/// </summary>
		virtual public object Name_02 { get; set; }
	}
}