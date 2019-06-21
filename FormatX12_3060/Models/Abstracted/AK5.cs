namespace FormatX12_3060.Models.Abstracted
{
	public abstract class AK5
	{
		/// <summary>
		/// AK501 717 Transaction Set Acknowledgment Code M ID 1/1
		/// </summary>
		public virtual string TransactionSetAcknowledgmentCode { get; set; }

		/// <summary>
		/// AK502 718 Transaction Set Syntax Error Code O ID 1/3
		///		1 Transaction Set Not Supported
		///		2 Transaction Set Trailer Missing
		///		3 Transaction Set Control Number in Header and Trailer Do Not Match
		///		4 Number of Included Segments Does Not Match Actual Count
		///		5 One or More Segments in Error
		///		6 Missing or Invalid Transaction Set Identifier
		///		7 Missing or Invalid Transaction Set Control Number
		///		8 Authentication Key Name Unknown
		///		9 Encryption Key Name Unknown
		///		10 Requested Service(Authentication or Encrypted) Not Available	
		///		11 Unknown Security Recipient
		///		12 Incorrect Message Length(Encryption Only)
		///		13 Message Authentication Code Failed
		///		15 Unknown Security Originator
		///		16 Syntax Error in Decrypted Text
		///		17 Security Not Supported
		///		19 S1E Security End Segment Missing for S1S Security Start Segment
		///		20 S1S Security Start Segment Missing for S1E Security End Segment
		///		21 S2E Security End Segment Missing for S2S Security Start Segment
		///		22 S2S Security Start Segment Missing for S2E Security End Segment
		///		23 Transaction Set Control Number Not Unique within the Functional Group
		///		24 S3E Security End Segment Missing for S3S Security Start Segment
		///		25 S3S Security Start Segment Missing for S3E Security End Segment
		///		26 S4E Security End Segment Missing for S4S Security Start Segment
		///		27 S4S Security Start Segment Missing for S4E Security End Segment
		/// </summary>
		public virtual string TransactionSetSyntaxErrorCode_01 { get; set; }

		/// <summary>
		/// AK503 718 Transaction Set Syntax Error Code O ID 1/3
		///		Refer To Code List In AK502
		/// </summary>
		public virtual string TransactionSetSyntaxErrorCode_02 { get; set; }

		/// <summary>
		/// AK504 718 Transaction Set Syntax Error Code O ID 1/3
		///		Refer To Code List In AK502
		/// </summary>
		public virtual string TransactionSetSyntaxErrorCode_03 { get; set; }


		/// <summary>
		/// AK505 718 Transaction Set Syntax Error Code O ID 1/3
		///		Refer To Code List In AK502
		/// </summary>
		public virtual string TransactionSetSyntaxErrorCode_04 { get; set; }

		/// <summary>
		/// AK506 718 Transaction Set Syntax Error Code O ID 1/3
		///		Refer To Code List In AK502
		/// </summary>
		public virtual string TransactionSetSyntaxErrorCode_05 { get; set; }
	}
}
