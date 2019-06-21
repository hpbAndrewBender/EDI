using System;

namespace IngramContent.Models.Invoice
{
	public class Files
	{
		public int Id { get; set; }

		public string FileName { get; set; }

		public bool CDF { get; set; }

		public short Head_SequenceNumber { get; set; }

		public string Head_IngramSAN { get; set; }

		public string Head_FileSource { get; set; }

		public DateTime Head_CreationDate { get; set; }

		public string Head_Filename { get; set; }

		public short Foot_TotalTitles { get; set; }

		public short Foot_TotalInvoices { get; set; }

		public short Foot_TotalUnits { get; set; }
	}
}