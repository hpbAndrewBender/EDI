using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class PAL
	{
		public PAL()
		{
			Meta_PalletTypes = new List<MetaCodes>
			{
				new MetaCodes("4","Standard"),
				new MetaCodes("6","Wood"),
			};

			Meta_Data = new List<MetaData>
			{
				new MetaData("PAL01",   "883",  "O",    "ID",   1, 2,   MetaData.UsageName.Used,        string.Empty,   "Pallet Type Code",                     "PalletTypeCode",               Meta_PalletTypes),
			};
		}

		public virtual List<MetaCodes> Meta_PalletTypes { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code indicating the type of pallet
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PAL01	883		O	ID		001	002	Used			Pallet Type Code
		///		
		///															Code	Name
		///															----	---------------
		///															4		Standard
		///															6		Wood
		/// </summary>
		virtual public object PalletTypeCode { get; set; }
	}
}