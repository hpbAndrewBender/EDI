-- =============================================
-- Author:		<Joey B.>
-- Create date: <5/8/2015>
-- Description:	<Builds a list of Invoice ACKs to be exported to SFPT folders thru EDI.....>
-- =============================================
CREATE PROCEDURE [dbo].[ProcessSFTP_ResponseAck_2019]
AS
BEGIN
	SET NOCOUNT ON;

	declare @linefeed VARCHAR(2) = CHAR(13) + CHAR(10)

	;with dataset AS
	(
		SELECT	 h.ShipFromSAN 
				,h.IssueDate
				,h.InsertDateTime
				,h.PONumber
				,h.AckID
				,v.ParentFolder
				,v.[Binary]
				,h.ReferenceNo
				,h.GSNo
				,dbo.EDIfn_GetResponseACKDtls(PONumber) AS ResponseACKDtls
		FROM HPB_EDI..[855_Ack_Hdr] h 
			INNER JOIN HPB_EDI..[855_Ack_Dtl] d 
				ON h.AckID = d.AckID
			INNER JOIN HPB_EDI..Vendor_SAN_Codes v
				ON h.VendorID = v.VendorID
					AND v.Processor = 'SFTP'
					AND v.ACK997=1
		WHERE h.ResponseACKSent = 0
	)
	SELECT DISTINCT AckID
		,PONumber
		,ParentFolder
		,CASE 
			WHEN [BINARY] = 0
				THEN 
					'ISA*00*          *00*          *ZZ*760985X        *ZZ*' 
					+ CAST(ShipFromSAN AS CHAR(15)) + '*' + CONVERT(VARCHAR(6), IssueDate, 12) + '*' + REPLACE(CONVERT(VARCHAR(5), InsertDateTime, 108), ':', '') 
					+ CASE WHEN ShipFromSAN IN ('8600023')
								THEN '*:*00200*' + RIGHT('000000000' + CAST(DATEPART(DY, GETDATE()) AS VARCHAR(5)) + CAST(PONumber AS VARCHAR(10)), 9)
								ELSE '*:*00200*' + RIGHT('0000000000' + PONumber, 9)
							END + '*0*P*>~' 
					+ @linefeed 
					+ 'GS*FA*760985X*' + ShipFromSAN + '*' + CONVERT(VARCHAR(6), IssueDate, 12) + '*' + REPLACE(CONVERT(VARCHAR(5), InsertDateTime, 108), ':', '') + '*000000002*X*003060~' 
					+ @linefeed 
					+ 'ST*997*000000001~' 
					+ @linefeed 
					+ 'AK1*PR*' + CONVERT(VARCHAR(12), CASE ShipFromSAN  WHEN '2002442'  THEN ReferenceNo WHEN '8600023' THEN ISNULL(GSNo, '') ELSE PONumber END) + '~' 
					+ @linefeed 
					+ CASE WHEN ShipFromSAN NOT IN ('2002442')
							THEN ResponseACKDtls
							ELSE ''
					 END + 'AK9*A*' + CONVERT(VARCHAR(10), (('1'))) + '*' + CONVERT(VARCHAR(10), (('1'))) + '*' + CONVERT(VARCHAR(10), (('1'))) + '~' 
					+ @linefeed
					+ 'SE*' 
					+ CASE  WHEN ShipFromSAN NOT IN ('2002442')
							THEN CONVERT(VARCHAR(10), (('6')))
							ELSE CONVERT(VARCHAR(10), (('4')))
						END + '*000000001~' 
					+ @linefeed 
					+ 'GE*1*000000002~' 
					+ @linefeed 
					+ 'IEA*1*' 
					+ CASE  WHEN ShipFromSAN IN ('8600023')
							THEN RIGHT('000000000' + CAST(DATEPART(DY, GETDATE()) AS VARCHAR(5)) + CAST(PONumber AS VARCHAR(10)), 9)
							ELSE RIGHT('0000000000' + PONumber, 9)
					END + '~'
			ELSE 
					CONVERT(VARCHAR(max), CONVERT(VARBINARY(max), CONVERT(VARCHAR(max), 'ISA*00*          *00*          *ZZ*760985X        *ZZ*' + CAST(ShipFromSAN AS CHAR(15)) + '*' + CONVERT(VARCHAR(6), IssueDate, 12) + '*' + REPLACE(CONVERT(VARCHAR(5), InsertDateTime, 108), ':', '') 
					+ CASE WHEN ShipFromSAN IN ('8600023')
							THEN '*:*00200*' + RIGHT('000000000' + CAST(DATEPART(DY, GETDATE()) AS VARCHAR(5)) + CAST(PONumber AS VARCHAR(10)), 9)
							ELSE '*:*00200*' + RIGHT('0000000000' + PONumber, 9)
					   END + '*0*P*>~' 
					+ @linefeed 
					+ 'GS*FA*760985X*' + ShipFromSAN + '*' + CONVERT(VARCHAR(6), IssueDate, 12) + '*' + REPLACE(CONVERT(VARCHAR(5), InsertDateTime, 108), ':', '') + '*000000002*X*003060~' 
					+ @linefeed 
					+ 'ST*997*000000001~' 
					+ @linefeed 
					+ 'AK1*PR*' + CONVERT(VARCHAR(12), CASE ShipFromSAN WHEN '2002442' THEN ReferenceNo WHEN '8600023' THEN ISNULL(GSNo, '') ELSE PONumber END) + '~' 
					+ @linefeed 
					+ CASE  WHEN ShipFromSAN NOT IN ('2002442')
							THEN ResponseACKDtls
							ELSE ''
							END + 'AK9*A*' 
					+ CONVERT(VARCHAR(10), (('1'))) + '*' + CONVERT(VARCHAR(10), (('1'))) + '*' + CONVERT(VARCHAR(10), (('1'))) + '~' 
					+ @linefeed 
					+ 'SE*' 
					+ CASE  WHEN ShipFromSAN NOT IN ('2002442')
						THEN CONVERT(VARCHAR(10), (('6')))
						ELSE CONVERT(VARCHAR(10), (('4')))
					 END + '*000000001~' 
					+ @linefeed 
					+ 'GE*1*000000002~' 
					+ @linefeed 
					+ 'IEA*1*' 
					+ CASE  WHEN ShipFromSAN IN ('8600023')
									THEN RIGHT('000000000' + CAST(DATEPART(DY, GETDATE()) AS VARCHAR(5)) + CAST(PONumber AS VARCHAR(10)), 9)
									ELSE RIGHT('0000000000' + PONumber, 9)
					   END + '~')), 1)
			END [FileText]
	FROM dataset
END
