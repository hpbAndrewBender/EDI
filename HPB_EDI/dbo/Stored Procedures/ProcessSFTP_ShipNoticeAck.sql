-- =============================================
-- Author:		<Joey B.>
-- Create date: <5/8/2015>
-- Description:	<Builds a list of Invoice ACKs to be exported to SFPT folders thru EDI.....>
-- =============================================
CREATE PROCEDURE [dbo].[ProcessSFTP_ShipNoticeAck]
AS

BEGIN

	SET NOCOUNT ON;

	
select distinct h.ShipID,replace(h.ASNNo,'|','')+'-'+h.PONumber,v.ParentFolder, 
		case when v.Binary=0 then 
		'ISA*00*          *00*          *ZZ*760985X        *ZZ*'+ cast(h.ShipFromSAN as CHAR(15)) 
		+'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')
		+case when h.ShipFromSAN in ('8600023') then '*:*00200*'+right('000000000'+cast(datepart(dy, getdate()) as varchar(5)) + cast(h.PONumber as varchar(10)),9) 
			else '*:*00200*'+RIGHT('0000000000'+h.PONumber,9) end +'*0*P*>~'
		+CHAR(13) + CHAR(10)
		+'GS*FA*760985X*'+h.ShipFromSAN+'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*000000002*X*003060~'
		+CHAR(13) + CHAR(10)
		+'ST*997*000000001~'
		+CHAR(13) + CHAR(10)
		+'AK1*SH*'+CONVERT(varchar(12),case h.ShipFromSAN when '2002442' then h.ReferenceNo when '8600023' then isnull(h.GSNo,'') else h.ASNNo end)+'~'
		+CHAR(13) + CHAR(10)
		+case when h.ShipFromSAN not in ('2002442') then dbo.EDIfn_GetShipNoticeACKDtls(h.PONumber,h.ASNNo) else '' end
		+'AK9*A*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'~'
		+CHAR(13) + CHAR(10)
		+'SE*'+case when h.ShipFromSAN not in ('2002442') then convert(varchar(10),(('6'))) else convert(varchar(10),(('4'))) end+'*000000001~'
		+CHAR(13) + CHAR(10)
		+'GE*1*000000002~'
		+CHAR(13) + CHAR(10)
		+'IEA*1*'+case when h.ShipFromSAN in ('8600023') then right('000000000'+cast(datepart(dy, getdate()) as varchar(5)) + cast(h.PONumber as varchar(10)),9) 
			else RIGHT('0000000000'+h.PONumber,9) end +'~'
		else
		CONVERT(varchar(max),CONVERT(varbinary(max),CONVERT(varchar(max),
		'ISA*00*          *00*          *ZZ*760985X        *ZZ*'+ cast(h.ShipFromSAN as CHAR(15)) +'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')
		+case when h.ShipFromSAN in ('8600023') then '*:*00200*'+right('000000000'+cast(datepart(dy, getdate()) as varchar(5)) + cast(h.PONumber as varchar(10)),9) 
			else '*:*00200*'+RIGHT('0000000000'+h.PONumber,9) end +'*0*P*>~'
		+CHAR(13) + CHAR(10)
		+'GS*FA*760985X*'+h.ShipFromSAN+'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*000000002*X*003060~'
		+CHAR(13) + CHAR(10)
		+'ST*997*000000001~'
		+CHAR(13) + CHAR(10)
		+'AK1*SH*'+CONVERT(varchar(12),case h.ShipFromSAN when '2002442' then h.ReferenceNo when '8600023' then isnull(h.GSNo,'') else h.ASNNo end)+'~'
		+CHAR(13) + CHAR(10)
		+case when h.ShipFromSAN not in ('2002442') then dbo.EDIfn_GetShipNoticeACKDtls(h.PONumber,h.ASNNo) else '' end
		+'AK9*A*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'~'
		+CHAR(13) + CHAR(10)
		+'SE*'+case when h.ShipFromSAN not in ('2002442') then convert(varchar(10),(('6'))) else convert(varchar(10),(('4'))) end+'*000000001~'
		+CHAR(13) + CHAR(10)
		+'GE*1*000000002~'
		+CHAR(13) + CHAR(10)
		+'IEA*1*'+case when h.ShipFromSAN in ('8600023') then right('000000000'+cast(datepart(dy, getdate()) as varchar(5)) + cast(h.PONumber as varchar(10)),9) 
			else RIGHT('0000000000'+h.PONumber,9) end +'~')),1)		
		end [FileText]
from HPB_EDI..[856_ASN_Hdr] h with(nolock) inner join HPB_EDI..[856_ASN_Dtl] d with(nolock) on h.ShipID=d.ShipID
		inner join HPB_EDI..Vendor_SAN_Codes v with(nolock) on h.VendorID=v.VendorID
where h.ASNACKSent=0 and v.processor='SFTP' and h.VendorID in (select VendorID from HPB_EDI..Vendor_SAN_Codes where ASN997=1)


END


