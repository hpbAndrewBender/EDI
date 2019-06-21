using System;
using System.Collections.Generic;
using System.Text;

namespace DataHPBEDI.Models.MetaData.CDFL
{
	class CodeTypes
	{
		public short Id { get; set; }

		public string VendorID { get; set; }

		public string CodeType { get; set; }

		public string AssociatedColumn { get; set; }

		public byte MaxChars { get; set; }
	}
}
