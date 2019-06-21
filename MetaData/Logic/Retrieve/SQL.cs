using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CommonLib.SQL;
using CommonLib.Logic;

namespace DataMetaData.Logic.Retrieve
{
	public class SQL
	{
		private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();

		private (List<Models.BBV3.CodeTypes>, List<Models.BBV3.Codes>, List<Models.BBV3.CodeTypesCodes>) AllCodes()
		{
			List<Models.BBV3.CodeTypes> ct = new List<Models.BBV3.CodeTypes>();
			List<Models.BBV3.Codes> c = new List<Models.BBV3.Codes>();
			List<Models.BBV3.CodeTypesCodes> ctc = new List<Models.BBV3.CodeTypesCodes>();

			try
			{
				using (CommonLib.SQL.Access access = new CommonLib.SQL.Access())
				{
					DataSet ds = access.Set
					(
						Tools.dbConn[$"EDI-{Globals.Env}"],
						new List<string>() { "MetaData.GetAllCodes" }, 
						null
					);

					if (ds != null && ds.Tables.Count == 3)
					{
						if (ds.Tables[0].Rows.Count > 0)
						{
							ct = (from s in ds.Tables[0].AsEnumerable()
								  select new Models.BBV3.CodeTypes
								  {
									  Id = s["Id"] != null ? (short)s["Id"] : default(short),
									  VendorID = s["VendorID"].ToString(),
									  CodeType = s["CodeType"].ToString(),
									  AssociatedColumn = s["AssociatedColumn"].ToString(),
									  MaxChars = s["MaxChars"] != null ? (byte)s["MaxChars"] : default(byte),
								  }).ToList();
						}
						if (ds.Tables[1].Rows.Count > 0)
						{
							c = (from s in ds.Tables[1].AsEnumerable()
								 select new Models.BBV3.Codes
								 {
									 Id = s["Id"] != null ? (int)s["Id"] : default(int),
									 CodeId = s["CodeId"] != null ? (short)s["CodeId"] : default(short),
									 Code = s["Code"].ToString(),
									 CodeName = s["CodeName"].ToString(),
									 CodeDescription = s["CodeDescription"].ToString()
								 }).ToList();
						}
						if (ds.Tables[2].Rows.Count > 0)
						{
							ctc = (from s in ds.Tables[2].AsEnumerable()
								   select new Models.BBV3.CodeTypesCodes
								   {
									   CodeTypesId = s["CodeTypeID"] != null ? (short)s["CodeTypeID"] : default(short),
									   VendorID = s["VendorID"].ToString(),
									   CodeType = s["CodeType"].ToString(),
									   AssociatedColumn = s["AssociatedColumn"].ToString(),
									   MaxChars = s["MaxChars"] != null ? (byte)s["MaxChars"] : default(byte),
									   CodesId = s["CodesId"] != null ? (int)s["CodesId"] : default(int),
									   Code = s["Code"].ToString(),
									   CodeName = s["CodeName"].ToString(),
									   CodeDescription = s["CodeDescription"].ToString()
								   }).ToList();
						}
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return (ct, c, ctc);
		}

		public List<Models.BBV3.Codes> Codes()
		{
			List<Models.BBV3.Codes> codes = null;

			try
			{
				using (CommonLib.SQL.Access access = new CommonLib.SQL.Access())
				{
					codes = (from s in (access.Table("hpb_edi", new List<string>() { "select * from MetaData.Codes" }, null, CommandType.Text)).AsEnumerable()
							 select new Models.BBV3.Codes()
							 {
								 Code = s["Code"].ToString(),
								 CodeDescription = s["CodeDescription"].ToString(),
								 CodeId = s["CodeID"] != null ? (short)s["CodeID"] : default(short),
								 CodeName = s["CodeName"].ToString(),
								 Id = s["Id"] != null ? (int)s["Id"] : default(int)
							 }
						).ToList();
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return codes;
		}

		List<Models.BBV3.CodeTypes> CodeTypes()
		{
			List<Models.BBV3.CodeTypes> codetypes = null;

			try
			{
				using (CommonLib.SQL.Access access = new CommonLib.SQL.Access())
				{
					codetypes = (from s in (access.Table("hpb_edi", new List<string>() { "select * from MetaData.CodeTypes" }, null, CommandType.Text)).AsEnumerable()
								 select new Models.BBV3.CodeTypes()
								 {
									 Id = s["Id"] != null ? (short)s["Id"] : default(short),
									 VendorID = s["VendorID"].ToString(),
									 CodeType = s["CodeType"].ToString(),
									 AssociatedColumn = s["AssociatedColumn"].ToString(),
									 MaxChars = s["MaxChars"] != null ? (byte)s["MaxChars"] : default(byte)
								 }).ToList();
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
			return codetypes;
		}
	}
}