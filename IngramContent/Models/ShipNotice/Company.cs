using System;
using System.Collections.Generic;
using System.Text;

namespace IngramContent.Models.ShipNotice
{
	public class Company
	{

		public int Id { get; set; }

		public bool CDF { get; set; }

		public string CompanyAccountID { get; set; }

		public short TotalOrderCount { get; set; }

		public string FileVersionNumber { get; set; }

		public string FileName { get; set; }
	}
}
