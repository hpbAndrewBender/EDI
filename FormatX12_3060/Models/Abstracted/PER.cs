using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class PER
	{
		public PER()
		{
			Meta_ContactFunctions = new List<MetaCodes>
			{
				new MetaCodes("DC","Delivery Contact"),
				new MetaCodes("OC","Order Contact"),
				new MetaCodes("SU","Supplier Contact"),
			};
			Meta_CommunicationNumberQualifiers = new List<MetaCodes>
			{
				new MetaCodes("BN","Beeper Number"),
				new MetaCodes("CP","Cellular Phone"),
				new MetaCodes("EM","Electronic Mail"),
				new MetaCodes("EX","Telephone Extension"),
				new MetaCodes("FX","Facsimile"),
				new MetaCodes("TE","Telephone"),
			};
			Meta_Data = new List<MetaData>
			{
				new MetaData("PER01",   "366",  "M",    "ID",   2, 2,   MetaData.UsageName.Required,    string.Empty,   "Contact Function Code",                "									ContactFunctionCode",               Meta_ContactFunctions),
				new MetaData("PER02",   "93",   "O",    "AN",   1,35,   MetaData.UsageName.Used,        string.Empty,   "Name",                                 "									Name",                              null),
				new MetaData("PER03",   "365",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Communication Number Qualifier",       "									CommunicationNumberQualifier_01",   Meta_CommunicationNumberQualifiers),
				new MetaData("PER04",   "364",  "C",    "AN",   1,80,   MetaData.UsageName.Used,        string.Empty,   "Communication Number",                 "									CommunicationNumber_01",           null),
				new MetaData("PER05",   "365",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Communication Number Qualifier",       "									CommunicationNumberQualifier_02",   Meta_CommunicationNumberQualifiers),
				new MetaData("PER06",   "364",  "C",    "AN",   1,80,   MetaData.UsageName.Used,        string.Empty,   "Communication Number",                 "									CommunicationNumber_02",            null),
				new MetaData("PER07",   "365",  "C",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Communication Number Qualifier",       "									CommunicationNumberQualifier_03",   Meta_CommunicationNumberQualifiers),
				new MetaData("PER08",   "364",  "C",    "AN",   1,80,   MetaData.UsageName.Used,        string.Empty,   "Communication Number",                 "									CommunicationNumber_03",           null),
			};
		}

		public virtual List<MetaCodes> Meta_ContactFunctions { get; internal set; }

		public virtual List<MetaCodes> Meta_CommunicationNumberQualifiers { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

	/// <summary>
	/// Code identifying the major duty or responsibility of the person or group named
	///		
	///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
	///		-------	-------	---	-------	---	---	-----	-------	-------------
	///		PER01	366		M	ID		002	002	Requ'd			Contact Function Code
	///		
	///															Code	Name
	///															----	---------------
	///															DC		Delivery Contact
	///															OC		Order Contact
	///															SU		Supplier Contact
	/// </summary>
		virtual public object ContactFunctionCode { get; set; }

		/// <summary>
		/// Free-form name
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PER02	93		O	AN		001	035	Used			Name
		/// </summary>
		virtual public object Name { get; set; }

		/// <summary>
		/// Code identifying the type of communication number
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PER03	365	C	ID	2/2	Used	Communication Number Qualifier
		///		
		///															Code	Name															
		///															----	---------------
		///															BN		Beeper Number
		///															CP		Cellular Phone
		///															EM		Electronic Mail
		///															EX		Telephone Extension
		///															FX		Facsimile
		///															TE		Telephone
		/// </summary>
		virtual public object CommunicationNumberQualifier_01 { get; set; }

		/// <summary>
		/// Complete communications number including country or area code when applicable
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PER04	364		C	AN	1/80	Used	Communication Number	
		///															Code	Name
		///															----	---------------
		/// </summary>
		virtual public object CommunicationNumber_01 { get; set; }

		/// <summary>
		/// Code identifying the type of communication number
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PER05	365		C	ID	2/2	Used		Communication Number Qualifier
		///		
		///															Code	Name															
		///															----	---------------
		///															BN		Beeper Number
		///															CP		Cellular Phone
		///															EM		Electronic Mail
		///															EX		Telephone Extension
		///															FX		Facsimile
		///															TE		Telephone
		/// </summary>
		virtual public object CommunicationNumberQualifier_02 { get; set; }

		/// <summary>
		/// Complete communications number including country or area code when applicable
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PER06	364	C	AN	1/80	Used	Communication Number
		/// </summary>
		virtual public object CommunicationNumber_02 { get; set; }

		/// <summary>
		/// Code identifying the type of communication number
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PER07	365		C	ID	2/2	Used		Communication Number Qualifier
		///		
		///															Code	Name															
		///															----	---------------
		///															BN		Beeper Number
		///															CP		Cellular Phone
		///															EM		Electronic Mail
		///															EX		Telephone Extension
		///															FX		Facsimile
		///															TE		Telephone
		/// </summary>
		virtual public object CommunicationNumberQualifier_03 { get; set; }

		/// <summary>
		/// Complete communications number including country or area code when applicable
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		PER08	364		C	AN	1/80	UsedCommunication Number
		/// </summary>
		virtual public object CommunicationNumber_03 { get; set; }
	}
}