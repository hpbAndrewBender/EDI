using FluentFTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendorIngramContent.Models.FTP
{
	public class Results
	{
		public string FileName { get; set; }
		public long Size { get; set; }
		public DateTime Time { get; set; }
		public FtpHash Hash { get; set; }
		public bool Successful { get; set; }

		public Results()
		{
			FileName = string.Empty;
			Size = -1;
			Time = default(DateTime);
			Hash = null;
			Successful = false;
		}

		public Results(string filename)
		{
			FileName = filename;
			Size = -1;
			Time = default(DateTime);
			Hash = null;
			Successful = false;

		}

		public Results(string filename, long size, DateTime time, FtpHash hash, bool successful)
		{
			FileName = filename;
			Size = size;
			Time = time;
			Hash = hash;
			Successful = successful;
		}

	}
}
