using DataHPBEDI.Models.MetaData.X12_3060;
using System.Collections.Generic;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class REF
	{
		public REF()
		{
			Meta_ReferenceIdentificationQualifiers=new List<MetaCodes>
			{
				new MetaCodes("PD","Promotion/Deal Number"),
			};

			Meta_Data=new List<MetaData>
			{
				new MetaData("REF01",   "128",  "M",    "ID",   2, 3,   MetaData.UsageName.Required, string.Empty,   "Reference Identification Qualifier",   "ReferenceIdentificationQualifier",    Meta_ReferenceIdentificationQualifiers),
				new MetaData("REF02",   "127",  "C",    "AN",   1,30,   MetaData.UsageName.Required, string.Empty,   "Reference Identification",             "ReferenceIdentification",         null),
			};
		}

		public virtual List<MetaCodes> Meta_ReferenceIdentificationQualifiers { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code Qualifying the Reference Identification
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		REF01	128		M	ID		002	003	Requ'd			Reference Identification Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															PD		Promotion/Deal Number
		/// </summary>
		virtual public object ReferenceIdentificationQualifier { get; set; }

		/// <summary>
		/// Reference information as defined for a particular Transaction Set or as specified by the Reference Identification Qualifier
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		REF02	127		C	AN		001 030	Rec'd			Reference Identification
		/// </summary>
		virtual public object ReferenceIdentification { get; set; }
	}
}