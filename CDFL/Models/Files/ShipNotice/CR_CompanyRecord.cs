using FileHelpers;

namespace FormatCDFL.Models.Files.ShipNotice
{
	/*
		#	Position 	Length 	Format 		Field Name 												Req'd	Description 
		--	----------	-------	-----------	------------------------------------------------------	-----	-------------------------------------------------------
		01	001-002 	002 	Alpha	 	Company Record Identifier  								Y		Must contain "CR" 	
		02	003-012 	010 	AlphaNum 	Company Account ID Number  								Y		IFSI assigned account number. 	
		03	013-020 	008 	Numeric 	Total Order Count  										Y		Count of OR records occurring in file.	
		04	021-030 	010 	AlphaNum 	File Version Number  									Y		"4".  The version number of the current ASCII ASN specification is 4. 
		05	031-200 	170 	AlphaNum 	Reserved												Y		Blank 
	*/

	[FixedLengthRecord]
	public class CR_CompanyRecord
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string CompanyRecordIdentifier { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string CompanyAccountIDNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(8),
			FieldAlign(AlignMode.Right, '0'),
			FieldConverter(ConverterKind.Int16),
		]
		public short TotalOrderCount { get; set; }

		[
			FieldOrder(4),
			FieldFixedLength(10),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string FileVersionNumber { get; set; }

		[
			FieldOrder(5),
			FieldFixedLength(170),
			FieldAlign(AlignMode.Left, ' '),
		]
		public string Resrved031_200 { get; set; }
	}
}
 