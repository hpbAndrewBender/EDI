using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class N3
	{
		public N3()
		{
			Meta_Data = new List<MetaData>
			{
				new MetaData("N301",    "166",  "M",    "AN",   1,35,   MetaData.UsageName.Required,    string.Empty,   "Address information",                  "AddressInformation_01",        null),
				new MetaData("N302",    "166",  "M",    "AN",   1,35,   MetaData.UsageName.Required,    string.Empty,   "Address information",                  "AddressInformation_02",        null),
			};
		}

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Address information
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N301	166		M	AN		001	035	Requ'd	Address information
		/// </summary>
		virtual public object AddressInformation_01 { get; set; }


		/// <summary>
		/// Address information
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		N302	166		M	AN		001	035	Requ'd	Address information
		/// </summary>
		virtual public object AddressInformation_02 { get; set; }
	}
}