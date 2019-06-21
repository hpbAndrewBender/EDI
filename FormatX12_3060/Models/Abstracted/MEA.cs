using System.Collections.Generic;
using DataHPBEDI.Models.MetaData.X12_3060;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class MEA
	{
		public MEA()
		{
			Meta_MeasurementReferenceIDs = new List<MetaCodes>
			{
				new MetaCodes("PA","Pallet Dimensions"),
				new MetaCodes("PD","Physical Dimensions"),
				new MetaCodes("PK","Package Dimensions"),
			};
			Meta_MeasurementQualifiers = new List<MetaCodes>
			{
				new MetaCodes("HT","Height"),
				new MetaCodes("LN","Length"),
				new MetaCodes("SZ","Skid Height"),
				new MetaCodes("WD","Width"),
				new MetaCodes("WT","Weight"),
			};
			Meta_UnitOrBasisForMeasurements = new List<MetaCodes>
			{
				new MetaCodes("CM","Centimeter"),
				new MetaCodes("E5","Inches,Fraction--Actual"),
				new MetaCodes("E8","Inches,Decimal--Actual"),
				new MetaCodes("KG","Kilogram"),
				new MetaCodes("LB","Pound"),
				new MetaCodes("OZ","Ounce - Av"),
			};
			Meta_Data = new List<MetaData>
			{
				new MetaData("MEA01",   "737",  "O",    "ID",   2, 2,   MetaData.UsageName.Used,        string.Empty,   "Measurement Reference ID Code",        "MeasurementReferenceIDCode",   Meta_MeasurementReferenceIDs),
				new MetaData("MEA02",   "738",  "O",    "ID",   1, 3,   MetaData.UsageName.Used,        string.Empty,   "Measurement Qualifier",                "MeasurementQualifier",         Meta_MeasurementQualifiers),
				new MetaData("MEA03",   "739",  "C",    "R",    1,20,   MetaData.UsageName.Used,        string.Empty,   "Measurement Value",                    "MeasurementValue",             null),
				new MetaData("MEA04",   "C001", "Comp", "",     0, 0,   MetaData.UsageName.Used,        string.Empty,   "Composite Unit of Measure",            "CompositeUnitOfMeasure",       Meta_UnitOrBasisForMeasurements),
			};
		}

		public virtual List<MetaCodes> Meta_MeasurementReferenceIDs { get; internal set; }

		public virtual List<MetaCodes> Meta_MeasurementQualifiers { get; internal set; }

		public virtual List<MetaCodes> Meta_UnitOrBasisForMeasurements { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// Code identifying the broad category to which a measurement applies
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		MEA01	737		O	ID	2	002	002	Used			Measurement Reference ID Code
		///
		///															Code	Name
		///															----	---------------
		///															PA		Pallet Dimensions
		///															PD		Physical Dimensions
		///															PK		Package Dimensions
		/// </summary>
		virtual public object MeasurementReferenceIdCode { get; set; }

		/// <summary>
		/// Code identifying a specific product or process characteristic to which a measurement applies
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		MEA02	738		O	ID		001	003	Used			Measurement Qualifier
		///
		///															Code	Name
		///															----	---------------
		///															HT		Height
		///															LN		Length
		///															SZ		Skid Height
		///															WD		Width
		///															WT		Weight
		/// </summary>
		virtual public object MeasurementQualifier { get; set; }

		/// <summary>
		/// The value of the measurement (For all code values with the exception of the SZ qualifier, the measurement is a real decimal number.  For the SZ qualifier use the integer portion of the skid height in inches.)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		MEA03	739		C	R		001	020	Used			Measurement Value
		/// </summary>
		virtual public object MeasurementValue { get; set; }

		/// <summary>
		/// To identify a composite unit of measure(See Figures Appendix for examples of use)
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		MEA04	C001	C	Comp			Used			Composite Unit of Measure
		///				355		M	ID		002	002	Requ'd			Unit or Basis for Measurement Code
		///															(Code specifying the units in which a value is being expressed, or manner in which a measurement has been taken)
		///
		///															Code	Name
		///															----	---------------
		///															CM		Centimeter
		///															E5		Inches,Fraction--Actual
		///															E8		Inches,Decimal--Actual
		///															KG		Kilogram
		///															LB		Pound
		///															OZ		Ounce - Av
		/// </summary>
		virtual public object CompositeUnitOfMeasure { get; set; }
	}
}