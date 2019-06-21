using System;

namespace IngramContent.Models.Invoice
{
	public class Header
	{
		public int Id { get; set; }

		public int FileID { get; set; }

		public string Head_InvoiceNumber { get; set; }

		public string Head_CompanyAccountID { get; set; }

		public string Head_WarehouseSAN { get; set; }

		public DateTime Head_InvoiceDate { get; set; }

		public short Totals_InvoiceRecordCount { get; set; }

		public short Totals_NumberOfTitles { get; set; }

		public short Totals_TotalNumberUnits { get; set; }

		public string Totals_BillOfLading { get; set; }

		public decimal Totals_TotalInvoiceWeight { get; set; }

		public decimal Foot_TotalNetPrice { get; set; }

		public decimal Foot_TotalShipping { get; set; }

		public decimal Foot_TotalHandling { get; set; }

		public decimal Foot_TotalGiftWrap { get; set; }

		public decimal Foot_TotalInvoice { get; set; }
	}
}