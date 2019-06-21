using System;
using System.Collections.Generic;
using System.Text;

namespace DataHPBEDI.Models.MetaData.BBV3
{
	public class Codes
	{
		public int Id { get; set; }
		public short CodeTypeId { get; set; }
		public string Code { get; set; }
		public string CodeName { get; set; }
		public string CodeDescription { get; set; }
	}
}
