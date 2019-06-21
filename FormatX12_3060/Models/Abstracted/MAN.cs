using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class MAN
	{
		public MAN()
		{
			Meta_MarksAndNumbersQualifiers=new List<MetaCodes>
			{
				new MetaCodes("GM","UCC/EAN-128 Serial Shipping Container Code Format"),
			};
			Meta_Data=new List<MetaData>
			{
				new MetaData("MAN01",   "88",   "M",    "ID",   1, 2,   MetaData.UsageName.Required,     string.Empty,   "Marks and Numbers Qualifier",  "MarksAndNumbersQualifier_01",  Meta_MarksAndNumbersQualifiers),
				new MetaData("MAN02",   "87",   "M",    "AN",   1,48,   MetaData.UsageName.Required,     string.Empty,   "Marks and Numbers",            "MarksAndNumbers_01",           null),
				new MetaData("MAN03",   "00",   "N",    "AN",   1, 2,   MetaData.UsageName.NotRequired,  string.Empty,   "MAN03",                        "MAN03",                        null),
				new MetaData("MAN04",   "00",   "N",    "ID",   1, 2,   MetaData.UsageName.NotRequired,  string.Empty,   "Marks and Numbers Qualifier",  "MarksAndNumbersQualifer_02",   null),
				new MetaData("MAN05",   "00",   "N",    "AN",   1,48,   MetaData.UsageName.NotRequired,  string.Empty,   "Marks and Numbers",            "MarksAndNumbers_02",           null)
			};
		}

		public virtual List<MetaCodes> Meta_MarksAndNumbersQualifiers { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code specifying the application or source of Marks and Numbers (87)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		MAN01	88		M	ID		001	002	Requ'd			Marks and Numbers Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															GM		UCC/EAN-128 Serial Shipping Container Code Format
		/// </summary>
		virtual public object MarksAndNumbersQualifier_01 { get; set; }

		/// <summary>
		/// Marks and numbers used to identify a shipment or parts of a shipment
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		MAN02	87		M	AN		001	048	Requ'd			Marks and Numbers
		/// </summary>
		virtual public object MarksAndNumbers_01 { get; set; }

		virtual public object MAN03 { get; set; }

		/// <summary>
		/// Code specifying the application or source of Marks and Numbers (87)
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		MAN01	88		M	ID		001	002	Used			Marks and Numbers Qualifier
		///		
		///															Code	Name
		///															----	---------------
		///															CP		????
		/// </summary>
		virtual public object MarksAndNumbersQualifier_02 { get; set; }

		/// <summary>
		/// Marks and numbers used to identify a shipment or parts of a shipment
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		MAN02	87		M	AN		001	048	Used			Marks and Numbers
		/// </summary>
		virtual public object MarksAndNumbers_02 { get; set; }



	}
}