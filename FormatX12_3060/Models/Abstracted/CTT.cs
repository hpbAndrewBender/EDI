using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class CTT
	{
		public CTT()
		{
			Meta_Data = new List<MetaData>
			{
				new MetaData("CTT01",   "354",  "N",    "N0",   1, 6,   MetaData.UsageName.Required, string.Empty,   "Number of Line Items",                 "NumberOfLineItems",            null),
				new MetaData("CTT02",   "347",  "O",    "R",    1,10,   MetaData.UsageName.Used,     string.Empty,   "Hash Total",                           "HashTotal",                    null),
			};
		}

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Total number of line items in the transaction set 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CTT01	354		N	N0		001	006	Reqr'd			Number of Line Items						
		/// </summary>
		virtual public object NumberOfLineItems { get; set; }

		/// <summary>
		/// Sum of values of the specified data element. All values in the data element will be summed without regard to decimal points (explicit or implicit) 
		/// or signs. Truncation will occur on the left most digits if the sum is greater than the maximum size of the hash total of the data element.
		/// Example:-.0018 First occurrence of value being hashed. .18 Second occurrence of value being hashed. 1.8 Third occurrence of value being hashed. 
		/// 18.01 Fourth occurrence of value being hashed. ------- 1855 Hash total prior to truncation. 855 Hash total after truncation to three-digit field. 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		CTT02	347		O	R		001	010	Used			Hash Total								
		/// </summary>
		virtual public object HashTotal { get; set; }
	}
}