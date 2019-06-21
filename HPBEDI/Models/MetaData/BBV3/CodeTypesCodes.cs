using System;
using System.Collections.Generic;
using System.Text;

namespace DataHPBEDI.Models.MetaData.BBV3
{
	class CodeTypesCodes
	{
		public short CodeTypesId { get; set; }
		public string VendorID { get; set; }
		public string CodeType { get; set; }
		public string AssociatedColumn { get; set; }
		public byte MaxChars { get; set; }
		public int CodesId { get; set; }
		public string Code { get; set; }
		public string CodeName { get; set; }
		public string CodeDescription { get; set; }
	}
}
