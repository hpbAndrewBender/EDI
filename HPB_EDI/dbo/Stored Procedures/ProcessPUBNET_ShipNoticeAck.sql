-- =============================================
-- Author:		<Joey B.>
-- Create date: <5/8/2015>
-- Description:	<Builds a list of Invoice ACKs to be exported to PUBNET folders thru EDI.....>
-- =============================================
CREATE PROCEDURE [dbo].[ProcessPUBNET_ShipNoticeAck]
AS

BEGIN

	SET NOCOUNT ON;

	
select distinct h.ShipID,h.ASNNo+'-'+h.PONumber,v.ParentFolder, 
		case when v.Binary=0 then 
		'ISA*00*997       *00*          *ZZ*760985X        *ZZ*'+ cast(h.ShipFromSAN as CHAR(15)) +'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*:*00200*'+RIGHT('0000000000'+h.PONumber,9)+'*0*P*>~'	
		+CHAR(13) + CHAR(10)
		+'GS*FA*760985X*'+h.ShipFromSAN+'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*000000002*X*003060~'
		+CHAR(13) + CHAR(10)
		+'ST*997*000000001~'
		+CHAR(13) + CHAR(10)
		+'AK1*SH*'+CONVERT(varchar(12),h.ASNNo)+'~'
		+CHAR(13) + CHAR(10)
		+ dbo.EDIfn_GetShipNoticeACKDtls(h.PONumber,h.ASNNo)
		+'AK9*A*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'~'
		+CHAR(13) + CHAR(10)
		+'SE*'+convert(varchar(10),(('6')))+'*000000001~'
		+CHAR(13) + CHAR(10)
		+'GE*1*000000002~'
		+CHAR(13) + CHAR(10)
		+'IEA*1*'+RIGHT('0000000000'+h.PONumber,9)+'~'
		else
		CONVERT(varchar(max),CONVERT(varbinary(max),CONVERT(varchar(max),
		'ISA*00*997       *00*          *ZZ*760985X        *ZZ*'+ cast(h.ShipFromSAN as CHAR(15)) +'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*:*00200*'+RIGHT('0000000000'+h.PONumber,9)+'*0*P*>~'	
		+CHAR(13) + CHAR(10)
		+'GS*FA*760985X*'+h.ShipFromSAN+'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*000000002*X*003060~'
		+CHAR(13) + CHAR(10)
		+'ST*997*000000001~'
		+CHAR(13) + CHAR(10)
		+'AK1*IN*'+CONVERT(varchar(12),h.ASNNo)+'~'
		+CHAR(13) + CHAR(10)
		+ dbo.EDIfn_GetShipNoticeACKDtls(h.PONumber,h.ASNNo)
		+'AK9*A*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'~'
		+CHAR(13) + CHAR(10)
		+'SE*'+convert(varchar(10),(('6')))+'*000000001~'
		+CHAR(13) + CHAR(10)
		+'GE*1*000000002~'
		+CHAR(13) + CHAR(10)
		+'IEA*1*'+RIGHT('0000000000'+h.PONumber,9)+'~')),1)
		end [FileText]
from [856_ASN_Hdr] h with(nolock) 
	inner join [856_ASN_Dtl] d with(nolock) 
		on h.ShipID=d.ShipID
	inner join Vendor_SAN_Codes v with(nolock) 
		on h.VendorID=v.VendorID
where h.ASNACKSent=0 
	and v.processor='PUBNET' 
	and h.VendorID in (select VendorID from Vendor_SAN_Codes where ASN997=1)
END


