using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class ITD
	{
		public ITD()
		{
			Meta_TermsTypes = new List<MetaCodes>
			{
				new MetaCodes("01","Basic"),
				new MetaCodes("02","End of Month(EOM)"),
				new MetaCodes("03","Fixed Date"),
				new MetaCodes("05","Discount Not Applicable"),
				new MetaCodes("07","Extended"),
				new MetaCodes("12","10 Days After End of Month(10 EOM)"),
				new MetaCodes("14","Previously agreed upon"),
				new MetaCodes("18","Fixed Date, Late Payment Penalty Applies(Sales terms specifying a past due date,and a late payment percentage penalty applies to unpaid balances past this due date)"),
				new MetaCodes("22","Cash Discount Terms Apply(Contract terms specify that a cash discount is applicable)"),
				new MetaCodes("CO","Consignment"),
				new MetaCodes("NC","No Charge"),
			};

			Meta_TermsBasisDates = new List<MetaCodes>
			{
				new MetaCodes("1","Ship Date"),
				new MetaCodes("3","Invoice Date"),
				new MetaCodes("4","Specified Date"),
				new MetaCodes("8","Invoice Transmission Date"),
			};

			Meta_PaymentMethods = new List<MetaCodes>
			{
				new MetaCodes("C","Pay By Check"),
				new MetaCodes("E","Electronic Payment System"),
				new MetaCodes("L","Letter of Credit"),
			};

			Meta_Data = new List<MetaData>
			{
				new MetaData("ITD01",   "336",  "O",    "ID",   2, 2,   MetaData.UsageName.Used,     string.Empty,   "Terms Type Code",                      "TermsTypeCode",                Meta_TermsTypes),
				new MetaData("ITD02",   "333",  "O",    "ID",   1, 2,   MetaData.UsageName.Used,     string.Empty,   "Terms Basis Date Code",                "TermsBasisDateCode",           Meta_TermsBasisDates),
				new MetaData("ITD03",   "338",  "O",    "R",    1, 6,   MetaData.UsageName.Used,     string.Empty,   "Terms Discount Percent",               "TermsDiscountPercent",         null),
				new MetaData("ITD04",   "370",  "C",    "DT",   6, 6,   MetaData.UsageName.Used,     string.Empty,   "Terms Discount Due Date",              "TermsDiscountDueDate",         null),
				new MetaData("ITD05",   "351",  "C",    "N0",   1, 3,   MetaData.UsageName.Used,     string.Empty,   "Terms Discount Days Due",              "TermsDiscountDaysDue",         null),
				new MetaData("ITD06",   "446",  "O",    "DT",   6, 6,   MetaData.UsageName.Used,     string.Empty,   "Terms Net Due Date",                   "TermsNetDueDate",              null),
				new MetaData("ITD07",   "386",  "O",    "N0",   1, 3,   MetaData.UsageName.Used,     string.Empty,   "Terms Net Days",                       "TermsNetDays",                 null),
				new MetaData("ITD08",   "362",  "O",    "N2",   1,10,   MetaData.UsageName.Used,     string.Empty,   "Terms Discount Amount",                "TermsDiscountAmount",          null),
				new MetaData("ITD14",   "107",  "O",    "ID",   1, 1,   MetaData.UsageName.Used,     string.Empty,   "Payment Method Code",                  "PaymentMethodCode",            Meta_PaymentMethods),
			};
		}

		public virtual List<MetaCodes> Meta_TermsTypes { get; internal set; }

		public virtual List<MetaCodes> Meta_TermsBasisDates { get; internal set; }

		public virtual List<MetaCodes> Meta_PaymentMethods { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code identifying type of payment terms 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ITD01	336		O	ID		002	002	Used			Terms Type Code
		///		
		///															Code	Name
		///															----	---------------
		///															01		Basic
		///															02		End of Month (EOM)
		///															03		Fixed Date
		///															05		Discount Not Applicable
		///															07		Extended
		///															12		10 Days After End of Month (10 EOM)
		///															14		Previously agreed upon
		///															18		Fixed Date,Late Payment Penalty Applies
		///																	(Sales terms specifying a past due date, and a late payment percentage penalty applies to unpaid balances past this due date)
		///															22		Cash Discount Terms Apply
		///																	(Contract terms specify that a cash discount is applicable)
		///															CO		Consignment
		///															NC		No Charge
		/// </summary>
		virtual public object TermsTypeCode { get; set; }

		/// <summary>
		/// Code identifying the beginning of the terms period
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ITD02	333		O	ID		001	002	Used			Terms Basis Date Code
		///		
		///															Code	Name
		///															----	---------------
		///															1		Ship Date
		///															3		Invoice Date
		///															4		Specified Date
		///															8		Invoice Transmission Date
		/// </summary>
		virtual public object TermsBasisDateCode { get; set; }

		/// <summary>
		/// Terms discount percentage, expressed as a percent, available to the purchaser if an invoice is paid on or before the Terms Discount Due Date	 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ITD03	338		O	R		001	006	Used			Terms Discount Percent
		/// </summary>
		virtual public object TermsDiscountPercent { get; set; }

		/// <summary>
		/// Date payment is due if discount is to be earned 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ITD04	370		C	DT		006	006	Used			Terms Discount Due Date
		/// </summary>
		virtual public object TermsDiscountDueDate { get; set; }

		/// <summary>
		/// Number of days in the terms discount period by which payment is due if terms discount is earned 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ITD05	351		C	N0		001	003	Used			Terms Discount Days Due
		/// </summary>
		virtual public object TermsDiscountDaysDue { get; set; }

		/// <summary>
		/// Date when total invoice amount becomes due 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ITD06	446		O	DT		006	006	Used			Terms Net Due Date
		/// </summary>
		virtual public object TermsNetDueDate { get; set; }

		/// <summary>
		/// Number of days until total invoice amount is due (discount not applicable)	
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ITD07	386		O	N0		001	003	Used			Terms Net Days
		/// </summary>
		virtual public object TermsNetDays { get; set; }

		/// <summary>
		/// Total amount of terms discount
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ITD08	362		O	N2		001	010	Used			Terms Discount Amount
		/// </summary>
		virtual public object TermsDiscountAmount { get; set; }

		/// <summary>
		/// Code identifying type of payment procedures
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		ITD14	107		O	ID		001	001	Used			Payment Method Code
		///		
		///															Code	Name
		///															----	---------------
		///															C		Pay By Check
		///															E		Electronic Payment System
		///															L		Letter of Credit
		/// </summary>
		virtual public object PaymentMethodCode { get; set; }
	}
}