using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class SE
	{
		public SE()
		{
			Meta_Data = new List<MetaData>
			{
				new MetaData("SE01",    "96" ,  "M",    "N0",   1,10,   MetaData.UsageName.Required, string.Empty,   "Number of Included Segments",         "NumberOfIncludedSegments",     null),
				new MetaData("SE02",    "329",  "M",    "AN",   4, 9,   MetaData.UsageName.Required, string.Empty,   "Transaction Set Control Number",      "TransactionSetControlNumber",  null),
			};
		}

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Total number of segments included in a transaction set including ST and SE segments 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SE01	96		M	N0		001	010	Req'rd			Number of Included Segments
		/// </summary>
		virtual public object NumberOfIncludedSegments { get; set; }

		/// <summary>
		/// Identifying control number that must be unique within the transaction set functional group assigned by the originator for a transaction set 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SE02	329		M	AN		004	009	Req'rd			Transaction Set Control Number								
		/// </summary>
		virtual public object TransactionSetControlNumber { get; set; }
	}
}