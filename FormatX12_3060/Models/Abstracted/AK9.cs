namespace FormatX12_3060.Models.Abstracted
{
	public abstract class AK9
	{
		/// <summary>
		///	AK901 715 Functional Group Acknowledge Code M ID 1/1
		///		A Accepted
		///		E Accepted, But Errors Were Noted.
		///		M Rejected, Message Authentication Code(MAC) Failed
		///		P Partially Accepted, At Least One Transaction Set Was Rejected
		///		R Rejected
		///		W Rejected, Assurance Failed Validity Tests
		///		X Rejected, Content After Decryption Could Not Be Analyzed
		///				
		/// </summary>
		public virtual string FunctionalGroupAcknowledgeCode { get; set; }

		/// <summary>
		/// >AK902 97 Number of Transaction Sets Included M N0 1/6
		/// </summary
		public virtual string NumberOfTransactionSetsIncluded { get; set; }

		/// <summary>
		/// AK903 123 Number of Received Transaction Sets M N0 1/6
		/// </summary>
		public virtual string NumberOfReceivedTransactionSets { get; set; }

		/// <summary>
		/// AK904 2 Number of Accepted Transaction Sets M N0 1/6
		/// </summary>
		public virtual string NumberOfAcceptedTransactionSets { get; set; }

		/// <summary>
		/// AK905 716 Functional Group Syntax Error Code O ID 1/3
		///		1 Functional Group Not Supported
		///		2 Functional Group Version Not Supported
		///		3 Functional Group Trailer Missing
		///		4 Group Control Number in the Functional Group Header and Trailer Do Not Agree
		///		5 Number of Included Transaction Sets Does Not Match Actual Count
		///		6 Group Control Number Violates Syntax
		///		10 Authentication Key Name Unknown
		///		11 Encryption Key Name Unknown
		///		12 Requested Service(Authentication or Encryption) Not Available
		///		13 Unknown Security Recipient
		///		14 Unknown Security Originator
		///		15 Syntax Error in Decrypted Text
		///		16 Security Not Supported
		///		17 Incorrect Message Length(Encryption Only)
		///		18 Message Authentication Code Failed
		///		19 S1E Security End Segment Missing for S1S Security Start Segment
		///		20 S1S Security Start Segment Missing for S1E End Segment
		///		21 S2E Security End Segment Missing for S2S Security Start Segment
		///		22 S2S Security Start Segment Missing for S2E Security End Segment
		///		23 S3E Security End Segment Missing for S3S Security Start Segment
		///		24 S3S Security Start Segment Missing for S3E End Segment
		///		25 S4E Security End Segment Missing for S4S Security Start Segment
		///		26 S4S Security Start Segment Missing for S4E Security End Segment
		/// </summary>
		public virtual string FunctionalGroupSyntaxErrorCode_01 { get; set; }

		/// <summary>
		/// AK906 716 Functional Group Syntax Error Code O ID 1/3
		///		1 Functional Group Not Supported
		///		2 Functional Group Version Not Supported
		///		3 Functional Group Trailer Missing
		///		4 Group Control Number in the Functional Group Header and Trailer Do Not Agree
		///		5 Number of Included Transaction Sets Does Not Match Actual Count
		///		6 Group Control Number Violates Syntax
		///		10 Authentication Key Name Unknown
		///		11 Encryption Key Name Unknown
		///		12 Requested Service(Authentication or Encryption) Not Available
		///		13 Unknown Security Recipient
		///		14 Unknown Security Originator
		///		15 Syntax Error in Decrypted Text
		///		16 Security Not Supported
		///		17 Incorrect Message Length(Encryption Only)
		///		18 Message Authentication Code Failed
		///		19 S1E Security End Segment Missing for S1S Security Start Segment
		///		20 S1S Security Start Segment Missing for S1E End Segment
		///		21 S2E Security End Segment Missing for S2S Security Start Segment
		///		22 S2S Security Start Segment Missing for S2E Security End Segment
		///		23 S3E Security End Segment Missing for S3S Security Start Segment
		///		24 S3S Security Start Segment Missing for S3E End Segment
		///		25 S4E Security End Segment Missing for S4S Security Start Segment
		///		26 S4S Security Start Segment Missing for S4E Security End Segment
		/// </summary>
		public virtual string FunctionalGroupSyntaxErrorCode_02 { get; set; }

		/// <summary>
		/// AK907 716 Functional Group Syntax Error Code O ID 1/3
		///		1 Functional Group Not Supported
		///		2 Functional Group Version Not Supported
		///		3 Functional Group Trailer Missing
		///		4 Group Control Number in the Functional Group Header and Trailer Do Not Agree
		///		5 Number of Included Transaction Sets Does Not Match Actual Count
		///		6 Group Control Number Violates Syntax
		///		10 Authentication Key Name Unknown
		///		11 Encryption Key Name Unknown
		///		12 Requested Service(Authentication or Encryption) Not Available
		///		13 Unknown Security Recipient
		///		14 Unknown Security Originator
		///		15 Syntax Error in Decrypted Text
		///		16 Security Not Supported
		///		17 Incorrect Message Length(Encryption Only)
		///		18 Message Authentication Code Failed
		///		19 S1E Security End Segment Missing for S1S Security Start Segment
		///		20 S1S Security Start Segment Missing for S1E End Segment
		///		21 S2E Security End Segment Missing for S2S Security Start Segment
		///		22 S2S Security Start Segment Missing for S2E Security End Segment
		///		23 S3E Security End Segment Missing for S3S Security Start Segment
		///		24 S3S Security Start Segment Missing for S3E End Segment
		///		25 S4E Security End Segment Missing for S4S Security Start Segment
		///		26 S4S Security Start Segment Missing for S4E Security End Segment
		/// </summary>
		public virtual string FunctionalGroupSyntaxErrorCode_03 { get; set; }

		/// <summary>
		/// AK908 716 Functional Group Syntax Error Code O ID 1/3
		///		1 Functional Group Not Supported
		///		2 Functional Group Version Not Supported
		///		3 Functional Group Trailer Missing
		///		4 Group Control Number in the Functional Group Header and Trailer Do Not Agree
		///		5 Number of Included Transaction Sets Does Not Match Actual Count
		///		6 Group Control Number Violates Syntax
		///		10 Authentication Key Name Unknown
		///		11 Encryption Key Name Unknown
		///		12 Requested Service(Authentication or Encryption) Not Available
		///		13 Unknown Security Recipient
		///		14 Unknown Security Originator
		///		15 Syntax Error in Decrypted Text
		///		16 Security Not Supported
		///		17 Incorrect Message Length(Encryption Only)
		///		18 Message Authentication Code Failed
		///		19 S1E Security End Segment Missing for S1S Security Start Segment
		///		20 S1S Security Start Segment Missing for S1E End Segment
		///		21 S2E Security End Segment Missing for S2S Security Start Segment
		///		22 S2S Security Start Segment Missing for S2E Security End Segment
		///		23 S3E Security End Segment Missing for S3S Security Start Segment
		///		24 S3S Security Start Segment Missing for S3E End Segment
		///		25 S4E Security End Segment Missing for S4S Security Start Segment
		///		26 S4S Security Start Segment Missing for S4E Security End Segment
		/// </summary>
		public virtual string FunctionalGroupSyntaxErrorCode_04 { get; set; }

		/// <summary>
		///	AK909 716 Functional Group Syntax Error Code O ID 1/3
		///		1 Functional Group Not Supported
		///		2 Functional Group Version Not Supported
		///		3 Functional Group Trailer Missing
		///		4 Group Control Number in the Functional Group Header and Trailer Do Not Agree
		///		5 Number of Included Transaction Sets Does Not Match Actual Count
		///		6 Group Control Number Violates Syntax
		///		10 Authentication Key Name Unknown
		///		11 Encryption Key Name Unknown
		///		12 Requested Service(Authentication or Encryption) Not Available
		///		13 Unknown Security Recipient
		///		14 Unknown Security Originator
		///		15 Syntax Error in Decrypted Text
		///		16 Security Not Supported
		///		17 Incorrect Message Length(Encryption Only)
		///		18 Message Authentication Code Failed
		///		19 S1E Security End Segment Missing for S1S Security Start Segment
		///		20 S1S Security Start Segment Missing for S1E End Segment
		///		21 S2E Security End Segment Missing for S2S Security Start Segment
		///		22 S2S Security Start Segment Missing for S2E Security End Segment
		///		23 S3E Security End Segment Missing for S3S Security Start Segment
		///		24 S3S Security Start Segment Missing for S3E End Segment
		///		25 S4E Security End Segment Missing for S4S Security Start Segment
		///		26 S4S Security Start Segment Missing for S4E Security End Segment
		/// </summary>
		public virtual string FunctionalGroupSyntaxErrorCode_05 { get; set; }	
	}
}
