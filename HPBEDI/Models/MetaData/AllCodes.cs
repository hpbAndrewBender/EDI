using System;
using System.Collections.Generic;
using System.Text;

namespace DataHPBEDI.Models.MetaData
{
	public class AllCodes
	{
		public byte FileFormatId { get; set; }
		public short CodesTypeId { get; set; }
		public short CodesdId { get; set; }
		public string FileFormat { get; set; }
		public string Vers { get; set; }
		public bool Active { get; set; }
		public string VendorId { get; set; }
		public string CodeType { get; set; }
		public string AssociatedColumn { get; set; }
		public byte MaxChars { get; set; } 
		public string Code { get; set; }
		public string CodeName { get; set; }
		public string CodeDescription { get; set; }
	}
}
