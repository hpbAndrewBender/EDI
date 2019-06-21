using System;
using System.Collections.Generic;
using System.Text;

namespace DataMetaData.Models.BBV3
{
	public class Codes
	{
		public int Id { get; set; }
		public short CodeId { get; set; }
		public string Code { get; set; }
		public string CodeName { get; set; }
		public string CodeDescription { get; set; }
	}
}
