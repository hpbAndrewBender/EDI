using FormatBBV3;
using FormatCDFL;
using System;
using System.Collections.Generic;
using System.Linq;
using CommonLib.Extensions;

namespace UserConsole
{
	public class Program
	{
		public static List<DataHPBEDI.Models.MetaData.AllCodes> Codes { get; set; } = new List<DataHPBEDI.Models.MetaData.AllCodes>();

		static void Main(string[] args)
		{
			string currentvendor = "IDINGRAMDI";
			const byte ediVersion = 3; // BBV3
			string dir = string.Empty;
			string ext = ""; //".TXT";
			string sendvia = "FTP";
			List<(bool successful, string filename)> files = new List<(bool successful, string filename)>();
			//
			CommonLib.Logic.Globals.ConnectStringDelims = UserConsole.Default.ConStrgs_Delims;
			CommonLib.Logic.Globals.ConnectStringEDI = UserConsole.Default.ConStrgs_HPBEDI;
			CommonLib.Logic.Globals.Env = UserConsole.Default.Env;
			CommonLib.SQL.Tools.InsertServer(CommonLib.Logic.Globals.GenerateConnections());
			//
			using (DataHPBEDI.Logic.MetaData.Retreive codelist = new DataHPBEDI.Logic.MetaData.Retreive())
			{
				Codes = codelist.AllCodes();
			}
			List<(string type,string read,string write, bool transup, bool transdown)> doit = new List<(string title,string read,string write, bool transup, bool transdown)>()
			{
				("BBV3", "N", "Y", false, true),
				("CDFL", "Y", "N", false, true)
			};

			if ((from d in doit.AsEnumerable() where d.type.ToUpper() == "BBV3" && d.write.ToUpper() == "Y" select d.read).Count() > 0)
			{
				using (DataHPBEDI.Logic.EDI.Retrieve ret = new DataHPBEDI.Logic.EDI.Retrieve())
				{
					dir = @"c:\temp\IC_EDI\BBV3\";
					using (VendorIngramContent.Logic.PurchaseOrder.Create fileoutput = new VendorIngramContent.Logic.PurchaseOrder.Create((from c in Codes where c.FileFormat == "BBV3" && c.VendorId.ToLower() == currentvendor.ToLower() select c).ToList()))
					{
						foreach (string ponumber in new List<string> { "268698", "266892", "270974" }) //   { "270974", "253992", "253983", "253950" })
						{
							files.Add(fileoutput.BBV3(dir, ext, currentvendor, new List<string> { "20" }, ret.PurchaseOrder(ponumber)));
						}
						switch (sendvia.ToLower())
						{
							case "ftp":
								List<VendorIngramContent.Models.FTP.Results> sendfiles = new List<VendorIngramContent.Models.FTP.Results>();
								List<VendorIngramContent.Models.FTP.Results> recvfiles = new List<VendorIngramContent.Models.FTP.Results>();
								using (VendorIngramContent.Transfers.FTP ftp = new VendorIngramContent.Transfers.FTP())
								{
									if ((from d in doit.AsEnumerable() where d.type.ToUpper() == "BBV3" && d.transup select d.transup).Count() > 0)
									{
										sendfiles = ftp.Upload
										(
											"BBV3",
											(from f in files
											 where f.successful == true
											 select f.filename).ToList()
										);
									}
									if ((from d in doit.AsEnumerable() where d.type.ToUpper() == "BBV3" && d.transdown select d.transdown).Count() > 0)
									{
										recvfiles = ftp.Download
										(
											"BBV3",
											@"C:\temp\IC_EDI\BBV3\in",
											true
										);
									}
								}
								break;
							case "webservice":
								break;
						}

					}
				}
			}
			//
			if ((from d in doit.AsEnumerable() where d.type.ToUpper() == "BBV3" && d.read.ToUpper() == "Y" select d.read).Count() > 0)
			{
				using (DataHPBEDI.Logic.EDI.Input input = new DataHPBEDI.Logic.EDI.Input())
				{
					using (VendorIngramContent.Logic.Invoice.Retrieve inputinv = new VendorIngramContent.Logic.Invoice.Retrieve())
					{
						input.Invoice(inputinv.BBV3(@"c:\temp\ic_edi\bbv3\V3_SMPL_INV_BIN.txt", "IDINGRAMDI"), ediVersion);
					}
					using (VendorIngramContent.Logic.PurchaseAcknowledgement.Retrieve inputack = new VendorIngramContent.Logic.PurchaseAcknowledgement.Retrieve())
					{
						input.Acknowledge(inputack.BBV3(@"c:\temp\ic_edi\bbv3\V3_SMPL_POA_FBC_CRLF.txt", "IDINGRAMDI"), ediVersion);
					}
					using (VendorIngramContent.Logic.ShipNotice.Retrieve inputship = new VendorIngramContent.Logic.ShipNotice.Retrieve())
					{
						input.Shipment(inputship.BBV3(@"c:\temp\ic_edi\bbv3\V3_SMPL_ASN_PBS.txt", "IDINGRAMDI"), ediVersion);
					}
				}
			}
			/*
			 * 
			 */
			if ((from d in doit.AsEnumerable() where d.type.ToUpper() == "CDFL" && d.write.ToUpper() == "Y" select d.read).Count() > 0)
			{
				using (DataHPBEDI.Logic.EDI.Retrieve ret = new DataHPBEDI.Logic.EDI.Retrieve())
				{
					dir = @"c:\temp\IC_EDI\CDFL\";
					using (VendorIngramContent.Logic.PurchaseOrder.Create fileoutput = new VendorIngramContent.Logic.PurchaseOrder.Create((from c in Codes where c.FileFormat == "CDFL" && c.VendorId.ToLower() == currentvendor.ToLower() select c).ToList()))
					{
						foreach (string ponumber in new List<string> { "268698", "266892", "270974" }) //   { "270974", "253992", "253983", "253950" })
						{
							files.Add(fileoutput.CDFL(dir, ext, currentvendor, ret.PurchaseOrder(ponumber)));
						}
						switch (sendvia.ToLower())
						{
							case "ftp":
								List<VendorIngramContent.Models.FTP.Results> sendfiles = new List<VendorIngramContent.Models.FTP.Results>();
								List<VendorIngramContent.Models.FTP.Results> recvfiles = new List<VendorIngramContent.Models.FTP.Results>();
								using (VendorIngramContent.Transfers.FTP ftp = new VendorIngramContent.Transfers.FTP())
								{
									sendfiles = ftp.Upload
									(
										"CDFL",
										(from f in files
										 where f.successful == true
										 select f.filename).ToList()
									);
									recvfiles = ftp.Download
									(
										"CDFL",
										@"C:\temp\IC_EDI\BBV3\in",
										true
									);

								}
								break;
							case "webservice":
								break;
						}

					}
				}
			}
			//
			if ((from d in doit.AsEnumerable() where d.type.ToUpper() == "CDFL" && d.read.ToUpper() == "Y" select d.read).Count() > 0)
			{
				using (DataHPBEDI.Logic.EDI.Input input = new DataHPBEDI.Logic.EDI.Input())
				{
					using (VendorIngramContent.Logic.Invoice.Retrieve inputinv = new VendorIngramContent.Logic.Invoice.Retrieve())
					{
						input.Invoice(inputinv.CDFL(@"c:\temp\ic_edi\cdfl\INV Vers 03.txt", "IDINGRAMDI"), ediVersion);
					}
					using (VendorIngramContent.Logic.PurchaseAcknowledgement.Retrieve inputack = new VendorIngramContent.Logic.PurchaseAcknowledgement.Retrieve())
					{
						input.Acknowledge(inputack.CDFL(@"c:\temp\ic_edi\cdfl\CDFL POA Example 2 Vers 03.txt", "IDINGRAMDI"), ediVersion);
					}
					using (VendorIngramContent.Logic.ShipNotice.Retrieve inputship = new VendorIngramContent.Logic.ShipNotice.Retrieve())
					{
						input.Shipment(inputship.CDFL(@"c:\temp\ic_edi\cdfl\ASN1 Vers 03.txt", "IDINGRAMDI"), ediVersion);
					}
				}
			}


		
			System.Console.WriteLine("Application completed all tasks.");
			System.Console.Write(">");
			System.Console.ReadLine();
		}
	}
}
