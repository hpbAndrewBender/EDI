using System;
using System.Collections.Generic;
using System.Text;

namespace VendorIngramContent.Models.FTP
{
	public class Site
	{
		public string DataType { get; set; }
		public string Env { get; set; }
		public string Url { get; set; }
		public (string Name, string Pass) User { get; set; }
		public string DirPut { get; set; }
		public string DirGet { get; set; }		
	}
}
