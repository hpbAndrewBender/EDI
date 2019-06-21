-- =============================================
-- Author:		<Joey B.>
-- Create date: <5/8/2015>
-- Description:	<Builds a list of Invoice ACKs to be exported to SFPT folders thru EDI.....>
-- =============================================
CREATE PROCEDURE [dbo].[ProcessPUBNET_InvAck]
AS

BEGIN

	SET NOCOUNT ON;

select distinct MAX(h.InvoiceID)[InvoiceID],max(h.InvoiceNo)[InvoiceNo],
		case when v.Binary=0 then 
		'ISA*00*997       *00*          *ZZ*760985X        *ZZ*'+ cast(max(h.ShipFromSAN) as CHAR(15)) +'*'+convert(varchar(6),max(h.IssueDate),12)+'*'+replace(convert(varchar(5),max(h.InsertDateTime),108),':','')+'*U*00200*'+RIGHT('0000000000'+h.ReferenceNo,9)+'*0*P*>~'	
		+CHAR(13) + CHAR(10)
		+'GS*FA*760985X*'+max(h.ShipFromSAN)+'*'+convert(varchar(6),max(h.IssueDate),12)+'*'+replace(convert(varchar(5),max(h.InsertDateTime),108),':','')+'*000000002*X*003060~'
		+CHAR(13) + CHAR(10)
		+'ST*997*000000001~'
		+CHAR(13) + CHAR(10)
		+'AK1*IN*'+CONVERT(varchar(12),right('000000000'+h.GSNo,9))+'~'
		+CHAR(13) + CHAR(10)
		--+ dbo.EDIfn_GetInvoiceACKDtls(h.InvoiceNo)
		+'AK9*A*'+convert(varchar(10),((COUNT(GSNo))))+'*'+convert(varchar(10),((COUNT(GSNo))))+'*'+convert(varchar(10),((COUNT(GSNo))))+'~'
		+CHAR(13) + CHAR(10)
		+'SE*'+convert(varchar(10),(('4')))+'*000000001~'
		+CHAR(13) + CHAR(10)
		+'GE*1*000000002~'
		+CHAR(13) + CHAR(10)
		+'IEA*1*'+RIGHT('0000000000'+h.ReferenceNo,9)+'~'
		else
		CONVERT(varchar(max),CONVERT(varbinary(max),CONVERT(varchar(max),
		'ISA*00*997       *00*          *ZZ*760985X        *ZZ*'+ cast(max(h.ShipFromSAN) as CHAR(15)) +'*'+convert(varchar(6),max(h.IssueDate),12)+'*'+replace(convert(varchar(5),max(h.InsertDateTime),108),':','')+'*U*00200*'+RIGHT('0000000000'+h.ReferenceNo,9)+'*0*P*>~'	
		+CHAR(13) + CHAR(10)
		+'GS*FA*760985X*'+max(h.ShipFromSAN)+'*'+convert(varchar(6),max(h.IssueDate),12)+'*'+replace(convert(varchar(5),max(h.InsertDateTime),108),':','')+'*000000002*X*003060~'
		+CHAR(13) + CHAR(10)
		+'ST*997*000000001~'
		+CHAR(13) + CHAR(10)
		+'AK1*IN*'+CONVERT(varchar(12),right('000000000'+h.GSNo,9))+'~'
		+CHAR(13) + CHAR(10)
		--+ dbo.EDIfn_GetInvoiceACKDtls(h.InvoiceNo)
		+'AK9*A*'+convert(varchar(10),((COUNT(GSNo))))+'*'+convert(varchar(10),((COUNT(GSNo))))+'*'+convert(varchar(10),((COUNT(GSNo))))+'~'
		+CHAR(13) + CHAR(10)
		+'SE*'+convert(varchar(10),(('4')))+'*000000001~'
		+CHAR(13) + CHAR(10)
		+'GE*1*000000002~'
		+CHAR(13) + CHAR(10)
		+'IEA*1*'+RIGHT('0000000000'+h.ReferenceNo,9)+'~')),1)
		end [FileText]
from HPB_EDI..[810_Inv_Hdr] h with(nolock) inner join HPB_EDI..[810_Inv_Dtl] d with(nolock) on h.InvoiceID=d.InvoiceID
		inner join HPB_EDI..Vendor_SAN_Codes v with(nolock) on h.VendorID=v.VendorID
where h.InvoiceACKSent=0 and v.processor='PUBNET' and h.VendorID in (select VendorID from HPB_EDI..Vendor_SAN_Codes where Invoice997=1)
group by h.ReferenceNo,h.GSNo,v.Binary


--select distinct h.InvoiceID,h.InvoiceNo, 
--		case when v.Binary=0 then 
--		'ISA*00*997       *00*          *ZZ*760985X        *ZZ*'+ cast(h.ShipFromSAN as CHAR(15)) +'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*:*00200*'+RIGHT('0000000000'+h.PONumber,9)+'*0*P*>~'	
--		+CHAR(13) + CHAR(10)
--		+'GS*FA*760985X*'+h.ShipFromSAN+'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*000000002*X*003060~'
--		+CHAR(13) + CHAR(10)
--		+'ST*997*000000001~'
--		+CHAR(13) + CHAR(10)
--		+'AK1*IN*'+CONVERT(varchar(12),h.ReferenceNo)+'~'
--		+CHAR(13) + CHAR(10)
--		+ dbo.EDIfn_GetInvoiceACKDtls(h.InvoiceNo)
--		+'AK9*A*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'~'
--		+CHAR(13) + CHAR(10)
--		+'SE*'+convert(varchar(10),(('6')))+'*000000001~'
--		+CHAR(13) + CHAR(10)
--		+'GE*1*000000002~'
--		+CHAR(13) + CHAR(10)
--		+'IEA*1*'+RIGHT('0000000000'+h.PONumber,9)+'~'
--		else
--		CONVERT(varchar(max),CONVERT(varbinary(max),CONVERT(varchar(max),
--		'ISA*00*997       *00*          *ZZ*760985X        *ZZ*'+ cast(h.ShipFromSAN as CHAR(15)) +'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*:*00200*'+RIGHT('0000000000'+h.PONumber,9)+'*0*P*>~'	
--		+CHAR(13) + CHAR(10)
--		+'GS*FA*760985X*'+h.ShipFromSAN+'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*000000002*X*003060~'
--		+CHAR(13) + CHAR(10)
--		+'ST*997*000000001~'
--		+CHAR(13) + CHAR(10)
--		+'AK1*IN*'+CONVERT(varchar(12),h.ReferenceNo)+'~'
--		+CHAR(13) + CHAR(10)
--		+ dbo.EDIfn_GetInvoiceACKDtls(h.InvoiceNo)
--		+'AK9*A*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'*'+convert(varchar(10),(('1')))+'~'
--		+CHAR(13) + CHAR(10)
--		+'SE*'+convert(varchar(10),(('6')))+'*000000001~'
--		+CHAR(13) + CHAR(10)
--		+'GE*1*000000002~'
--		+CHAR(13) + CHAR(10)
--		+'IEA*1*'+RIGHT('0000000000'+h.PONumber,9)+'~')),1)
--		end [FileText]
--from HPB_EDI..[810_Inv_Hdr] h with(nolock) inner join HPB_EDI..[810_Inv_Dtl] d with(nolock) on h.InvoiceID=d.InvoiceID
--		inner join HPB_EDI..Vendor_SAN_Codes v with(nolock) on h.VendorID=v.VendorID
--where h.InvoiceACKSent=0 and v.processor='PUBNET' and h.VendorID in (select VendorID from HPB_EDI..Vendor_SAN_Codes where Invoice997=1)


END


