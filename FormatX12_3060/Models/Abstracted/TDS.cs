using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class TDS
	{
		public TDS()
		{
			Meta_Data = new List<MetaData>
			{
				new MetaData("TDS01",   "610",  "M",    "N2",   1,15,   MetaData.UsageName.Required,    string.Empty,   "Amount",                               "Amount_01",                    null),
				new MetaData("TDS02",   "610",  "O",    "N2",   1,15,   MetaData.UsageName.Used,        string.Empty,   "Amount",                               "Amount_02",                    null),
				new MetaData("TDS03",   "610",  "O",    "N2",   1,15,   MetaData.UsageName.Used,        string.Empty,   "Amount",                               "Amount_02",                    null),
			};
		}

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Monetary amount
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TDS01	610		M	N2		1	15	Requ'd			Amount
		/// </summary>
		virtual public object Amount_01 { get; set; }

		/// <summary>
		/// Monetary amount
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TDS02	610		O	N2		1	15	Used			Amount
		/// </summary>
		virtual public object Amount_02 { get; set; }

		/// <summary>
		/// Monetary amount
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TDS03	610		O	N2		1	15	Used			Amount
		/// </summary>
		virtual public object Amount_03 { get; set; }
	}
}