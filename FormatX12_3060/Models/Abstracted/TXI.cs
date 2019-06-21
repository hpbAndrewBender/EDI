using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{

	public abstract class TXI
	{
		public TXI()
		{
			Meta_TaxTypes = new List<MetaCodes>
			{
				new MetaCodes("GS","Goods and Services Tax (Canadian value-added tax)"),
				new MetaCodes("LS","State and Local Sales Tax"),
				new MetaCodes("TX","All Taxes (All Taxes Applicable - To be used for harmonization of provincial and GST in Canada.)"),
			};

			Meta_Data = new List<MetaData>
			{
				new MetaData("TXI01",   "963",  "M",    "ID",   2, 2,   MetaData.UsageName.Required,    string.Empty,   "Tax Type Code",                        "TaxTypeCode",                  Meta_TaxTypes),
				new MetaData("TXI02",   "782",  "C",    "R",    1,15,   MetaData.UsageName.Used,        string.Empty,   "Monetary Amount",                      "MonetaryAmount",               null),
				new MetaData("TXI03",   "954",  "C",    "R",    1,10,   MetaData.UsageName.Used,        string.Empty,   "Percent",                              "Percent",                      null),
			};
		}

		public virtual List<MetaCodes> Meta_TaxTypes { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code specifying the type of tax
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TXI01	963		M	ID		2	2	Requ'd			Tax Type Code
		///		
		///															Code	Name
		///															----	---------------
		///															GS		Goods and Services Tax (Canadian value-added tax)
		///															LS		State and Local Sales Tax
		///															TX		All Taxes (All Taxes Applicable - To be used for harmonization of provincial and GST in Canada.)
		/// </summary>
		virtual public object TaxTypeCode { get; set; }

		/// <summary>
		/// Monetary amount
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TXI02	782		C	R		1	15	Used			Monetary Amount
		/// </summary>
		virtual public object MonetaryAmount { get; set; }

		/// <summary>
		/// Percentage expressed as a decimal
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		TXI03	954		C	R		1	10	Used			Percent
		/// </summary>
		virtual public object Percent { get; set; }
	}
}