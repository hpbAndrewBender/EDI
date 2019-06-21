using System.Collections.Generic;

namespace DataMetaData.Models.X12_3060
{
	public class MetaData
	{
		public enum UsageName
		{
			Unknown,
			Depends,
			Required,
			Used,
			Must,
			NotRequired,
			Received,
		}

		public MetaData(string dataRef,string dataId,string dataReq,string dataType,int dataMin,int dataMax,UsageName dataUsage,string dataDefault,string dataElementName,
					string dataOrdinalName,List<MetaCodes> dataCodes)
		{
			this.Ref=dataRef;
			this.Id=dataId;
			this.Req=dataReq;
			this.Type=dataType;
			this.Min=dataMin;
			this.Max=dataMax;
			this.Usage=dataUsage;
			this.Default=dataDefault;
			this.ElementName=dataElementName;
			this.OrdinalName=dataOrdinalName;
			this.Codes=dataCodes;
		}

		public string Ref { get; set; }
		public string Id { get; set; }
		public string Req { get; set; }
		public string Type { get; set; }
		public int Min { get; set; }
		public int Max { get; set; }
		public UsageName Usage { get; set; }
		public string Default { get; set; }
		public string ElementName { get; set; }
		public string OrdinalName { get; set; }
		public List<MetaCodes> Codes { get; set; }
	}
}