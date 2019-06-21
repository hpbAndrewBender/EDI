using CommonLib.Logic;
using FluentFTP;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VendorIngramContent.Transfers
{
	public class FTP : IDisposable
	{
		//public (string name, string pass) user { get; set; } = ("b20R1158", "btzi5uyyzn");
		public List<Models.FTP.Site> ftpsite { get; set; } = new List<Models.FTP.Site>
		{
			new Models.FTP.Site
			{
				DataType = "BBV3",
				Env = "dev",
				Url = "ftptest.ingramcontent.com",
				User = ("b20R1158", "btzi5uyyzn"),
				DirPut = "/incoming",
				DirGet = "/outgoing"
			},
			new Models.FTP.Site
			{
				DataType = "CDFL",
				Env = "dev",
				Url = "ftp.ingramcontent.com",
				User = ("c20W0714",""),
				DirPut = "/incoming",
				DirGet = "/outgoing"
			}
		};

		public string ftpsavedir { get; set; } = "test";
		public string ftpgetdir { get; set; } = "";

		private List<Models.FTP.Site> GetFtpSite(string datatype)
		{
			return (from f in ftpsite where f.DataType.ToLower() == datatype.ToLower() && f.Env.ToLower() == Globals.Env.ToLower() select f).ToList();
		}

		public List<Models.FTP.Results> Upload(string datatype, List<string> files)
		{
			List<Models.FTP.Site> sites = new List<Models.FTP.Site>();
			List<Models.FTP.Results> results = new List<Models.FTP.Results>();
			Models.FTP.Results currentresult;

			try
			{
				sites = GetFtpSite(datatype);
				FtpClient client = new FtpClient(sites.First().Url);
				client.Credentials = new System.Net.NetworkCredential(sites.First().User.Name, sites.First().User.Pass);
				client.Connect();
				client.SetWorkingDirectory(sites.First().DirPut); //?? client.SetWorkingDirectory((sites.First().DirPut + (sites.First().DirPut.EndsWith("/") ? "" : "/")));
				foreach (string file in files)
				{
					currentresult = new Models.FTP.Results($"/{sites.First().DirPut}/{file}");
					if (client.UploadFile(file, $"{System.IO.Path.GetFileName(file)}", FtpExists.Overwrite, false, FtpVerify.OnlyChecksum))
					{
						currentresult.Successful = true;
					}
					results.Add(currentresult);
				}
			}
			catch (Exception ex)
			{
			}
			return results;
		}

		public List<Models.FTP.Results> Download(string datatype, string savepath, bool deletesuccessful)
		{
			List<Models.FTP.Site> sites = new List<Models.FTP.Site>();
			List<Models.FTP.Results> results = new List<Models.FTP.Results>();
			Models.FTP.Results currentresult;

			try
			{
				sites = GetFtpSite(datatype);
				FtpClient client = new FtpClient(sites.First().Url);
				client.Credentials = new System.Net.NetworkCredential(sites.First().User.Name, sites.First().User.Pass);
				client.Connect();
				client.SetWorkingDirectory(sites.First().DirGet);
				foreach (FtpListItem item in client.GetListing(client.GetWorkingDirectory()))
				{
					if (item.Type == FtpFileSystemObjectType.File)
					{
						currentresult = new Models.FTP.Results(item.FullName, client.GetFileSize(item.FullName), client.GetModifiedTime(item.FullName), null, false);
						if (client.DownloadFile($"{savepath}\\{System.IO.Path.GetFileName(item.FullName)}",  item.Name, FtpLocalExists.Overwrite))
						{
							client.DeleteFile(item.Name);
							currentresult.Successful = true;
						}
						results.Add(currentresult);
					}
				}
			}
			catch (Exception ex)
			{
			}
			return results;
		}

		#region IDisposable Support

		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~Send() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}

		#endregion IDisposable Support
	}
}