using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class IT8
	{
		public IT8()
		{
			Meta_SalesRequirements=new List<MetaCodes>
			{
				new MetaCodes("B","Back Order Only If New Item"),
				new MetaCodes("N","No Back Order"),
				new MetaCodes("O","Back Order If Items Are Out of Stock or Not Yet Published"),
				new MetaCodes("Y","Back Order if Out of Stock"),
			};
			Meta_DoNoteExceedActions = new List<MetaCodes>
			{
				new MetaCodes("0","Cancel Balance of Order/Item that Exceeds Value Specified in Data Element 610"),
				new MetaCodes("1","Cancel Entire Order/Item"),
			};
			Meta_Data = new List<MetaData>
			{
				new MetaData("IT801",   "563",  "C",    "ID",   1, 2,   MetaData.UsageName.Used,     string.Empty,   "Sales Requirement Code",               "		",						Meta_SalesRequirements),
				new MetaData("IT802",   "564",  "C",    "ID",   1, 1,   MetaData.UsageName.Used,     string.Empty,   "Do-Not-Exceed Action Code",            "Do_Not_ExceedActionCode",     Meta_DoNoteExceedActions),
				new MetaData("IT803",   "610",  "C",    "N2",   1,15,   MetaData.UsageName.Used,     string.Empty,   "Amount",                               "Amount",                      null),
			};
		}

		public virtual List<MetaCodes> Meta_SalesRequirements { get; internal set; }

		public virtual List<MetaCodes> Meta_DoNoteExceedActions { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code to identify a specific requirement or agreement of sale
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT801	563		C	ID		001	002	Used			Sales Requirement Code
		///		
		///															Code	Name
		///															----	---------------
		///															B		Back Order Only If New Item
		///															N		No Back Order
		///															O		Back Order If Items Are Out of Stock or Not Yet Published
		///															Y		Back Order if Out of Stock
		///															
		/// </summary>

		virtual public object SalesRequirementCode { get; set; }

		/// <summary>
		/// Code indicating the action to be taken if the order amount exceeds the value of Do-Not-Exceed Amount(565) 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT802	564		C	ID		001	001	Used			Do-Not-Exceed Action Code
		///		
		///															Code	Name
		///															----	---------------
		///															0		Cancel Balance of Order/Item that Exceeds Value Specified in Data Element 610
		///															1		Cancel Entire Order/Item
		/// </summary>
		virtual public object Do_Not_ExceedActionCode { get; set; }

		/// <summary>
		/// Monetary amount 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		IT803	610		C	N2		001	015	Used			Amount
		/// </summary>
		virtual public object Amount { get; set; } 	
	}
}