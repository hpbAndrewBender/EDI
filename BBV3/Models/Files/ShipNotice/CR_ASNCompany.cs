using FileHelpers;

namespace FormatBBV3.Models.Files.ShipNotice
{
	/*
		#	Position 	Length 	Format 		Field Name 									Description 
		--	----------	-------	-----------	----------------------------------------	-------------------------------------------------------
		01	001-002 	002 	Alpha	 	Company Record Identifier  					"CR" 
		02	003-009 	007 	AlphaNum 	Ingram Ship To Account Number 				Your Ingram ship to account number 
		03	010-200 	191 	AlphaNum 	Reserved 									Reserved – left justified, space filled. 
	 */
	[FixedLengthRecord]
	public class CR_ASNCompany
	{
		[
			FieldOrder(1),
			FieldFixedLength(2),
		]
		public string CompanyRecordIdentifier { get; set; }

		[
			FieldOrder(2),
			FieldFixedLength(7),
			FieldAlign(AlignMode.Right, '0'),
		]
		public string IngramShipToAccountNumber { get; set; }

		[
			FieldOrder(3),
			FieldFixedLength(191),
			FieldAlign(AlignMode.Left, ' ')
		]
		public string Reserved010_200 { get; set; }
	}
}