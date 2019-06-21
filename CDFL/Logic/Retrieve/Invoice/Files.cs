using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDFL.Logic.Retrieve.Invoice
{
	public class Files
	{
		private const int DefaultBuffer = 4096;
		private const FileOptions DefaultOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;

		public static List<string> ReadAllLines(string path)
		{
			return null;
		//	return Task.Run(() => manager.GEtReadAllLinesAsync(path));
		}


		public static Task<List<string>> ReadAllLinesAsync(string path)
		{
			return ReadAllLinesAsync(path, Encoding.UTF8);
		}

		public static async Task<List<string>> ReadAllLinesAsync(string path, Encoding encoding)
		{
			var lines = new List<string>();

			// Open the FileStream with the same FileMode, FileAccess and FileShare as a call to File.OpenText would've done.
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, DefaultBuffer, DefaultOptions))
			{
				using (var reader = new StreamReader(stream, encoding))
				{
					string line;
					while ((line = await reader.ReadLineAsync()) != null)
					{
						lines.Add(line);
					}
				}
			}
			return lines;
		}





	}
}
