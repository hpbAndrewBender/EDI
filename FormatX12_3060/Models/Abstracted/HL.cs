using DataHPBEDI.Models.MetaData.X12_3060;
using System.Collections.Generic;

namespace FormatX12_3060.Models.Abstracted
{
	public abstract class HL
	{
		public HL()
		{
			Meta_HierarchicalLevels=new List<MetaCodes>
			{
				new MetaCodes("I", "Item"),
				new MetaCodes("P", "Pack"),
				new MetaCodes("O", "Order"),
				new MetaCodes("S", "Shipment")
			};

			Meta_Data=new List<MetaData>
			{
				new MetaData("HL01",    "628",  "M",    "AN",   1,12,   MetaData.UsageName.Required, string.Empty,   "Hierarchal ID Number",                 "HierarchalIDNumber",           null),
				new MetaData("HL02",    "734",  "O",    "AN",   1,12,   MetaData.UsageName.Used,     string.Empty,   "Hierarchical Parent ID Number",        "HierarchicalParentIDNumber",   null),
				new MetaData("HL03",    "735",  "M",    "ID",   2, 2,   MetaData.UsageName.Depends,  string.Empty,   "Hierarchical Level Code",              "HierarchicalLevelCode",        Meta_HierarchicalLevels),
				new MetaData("HL04",    "736",  "O",    "ID",   1, 1,   MetaData.UsageName.Used,     string.Empty,   "Hierarchical Child Code",              "HierarchicalChildCode",        null),
			};
		}

		public virtual List<MetaCodes> Meta_HierarchicalLevels { get; internal set; }

		public virtual List<MetaData> Meta_Data { get; internal set; }

		/// <summary>
		/// A unique number assigned by the sender to identify a particular data segment in a hierarchical structure
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		HL01	628		M	AN		001	012 Requ'd			Hierarchal ID Number
		/// </summary>
		virtual public object HierarchicalIDNumber { get; set; }

		/// <summary>
		/// Identification number of the next higher hierarchical data segment that the data segment being described is subordinate to
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		HL02	734		O	AN		001	012	Used			Hierarchical Parent ID Number
		/// </summary>
		virtual public object HierarchicalParentIDNumber { get; set; }

		/// <summary>
		/// Code defining the characteristic of a level in a hierarchical structure
		///
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		HL03	735		M	ID		002	002	Requ'd			Hierarchical Level Code
		///
		///															Code	Name
		///															------	--------------
		///															I		Item
		/// </summary>
		virtual public object HierarchicalLevelCode { get; set; }

		/// <summary>
		/// Code indicating if there are hierarchical child data segments subordinate to the level being described
		///
		///		Item, Pack, Order:
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		HL04	736		O	ID		001	001	Used			Hierarchical Child Code
		///
		///		Shipment:
		///		Ref		Id		Req Type	Min	Max	Usage	Default	Element Name
		///		-------	-------	---	-------	---	---	-----	-------	-------------
		///		HL04	736		O	ID		001	001	NotUsd			Hierarchical Child Code
		/// </summary>
		virtual public object HierarchicalChildCode { get; set; }
	}
}