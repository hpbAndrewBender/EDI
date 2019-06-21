using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class SN1
	{
		public SN1()
		{
			Meta_Units = new List<MetaCodes>
			{
				new MetaCodes("UN","Units"),
			};

			Meta_Data = new List<MetaData>
			{
				new MetaData("SN101",   "350",  "O",    "AN",   1,20,   MetaData.UsageName.Used    ,    string.Empty,   "Assigned Identification",              "AssignedIdentification",           null),
				new MetaData("SN102",   "382",  "M",    "R" ,   1,10,   MetaData.UsageName.Required,    string.Empty,   "Number of Units Shipped",              "NumberOfUnitsShipped",             null),
				new MetaData("SN103",   "355",  "M",    "ID",   2, 2,   MetaData.UsageName.Required,    string.Empty,   "Unit or Basis for Measurement Code",   "UnitOrBasisForMeasurementCode_01", Meta_Units),
				new MetaData("SN104",   "646",  "O",    "R" ,   1, 9,   MetaData.UsageName.Used    ,    string.Empty,   "Quantity Shipped to Date",             "QuantityShippedToDate",            null),
				new MetaData("SN105",   "330",  "C",    "R" ,   1, 9,   MetaData.UsageName.Used    ,    string.Empty,   "Quantity Ordered",                     "QuantityOrdered",                  null),
				new MetaData("SN106",   "355",  "C",    "ID",   2, 2,   MetaData.UsageName.Used    ,    string.Empty,   "Unit or Basis for Measurement Code",   "UnitOrBasisForMeasurementCode_02", Meta_Units),
			};
		}

		public virtual List<MetaCodes> Meta_Units { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Alphanumeric characters assigned for differentiation within a transaction set 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SN101	350		O	AN		001	020	Used			Assigned Identification
		/// </summary>
		virtual public object AssignedIdentification { get; set; }

		/// <summary>
		/// Numeric value of units shipped in manufacturer's shipping units for a line item or transaction set 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SN102	382		M	R		001	010	Requ'd			Number of Units Shipped
		/// </summary>
		virtual public object NumberOfUnitsShipped { get; set; }

		/// <summary>
		/// Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken$ 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SN103	355		M	ID		002	002	Requ'd			Unit or Basis for Measurement Code
		///		
		///															Code	Name
		///															----	---------------
		///															UN		Unit
		/// </summary>
		virtual public object UnitOrBasisForMeasurementCode_01 { get; set; }

		/// <summary>
		/// Number of units shipped to date 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SN104	646		O	R		001	009	Used			Quantity Shipped to Date	
		/// </summary>
		virtual public object QuantityShippedToDate { get; set; }

		/// <summary>
		/// Quantity ordered
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SN105	330		C	R		001	009	Used			Quantity Ordered
		/// </summary>
		virtual public object QuantityOrdered { get; set; }

		/// <summary>
		/// Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken 
		///		
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		SN106	355		C	ID		002	002	Used
		///		
		///															Code	Name
		///															----	---------------
		///															UN		Unit
		/// </summary>
		virtual public object UnitOrBasisForMeasurementCode_02 { get; set; }
	}
}