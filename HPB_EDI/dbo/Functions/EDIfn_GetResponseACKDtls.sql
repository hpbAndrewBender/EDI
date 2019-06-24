-- =============================================
-- Author:		<Joey B.>
-- Create date: <5/8/2015>
-- Description:	<Return PO details in single string.....>
-- =============================================
CREATE FUNCTION [dbo].[EDIfn_GetResponseACKDtls]
(
	@ponum varchar(10)
)
RETURNS varchar(max)
AS
BEGIN

	----testing.....
	--declare @ponum varchar(20)
	--set @ponum = '218000'
	--declare @refno varchar(20)
	--set @refno='000000002'

	declare @lines varchar(max)
	declare @version varchar(10)
	set @version = isnull((select distinct c.EDIVersion from HPB_EDI..[855_Ack_Hdr] h inner join HPB_EDI..Vendor_SAN_Codes c on h.VendorID=c.VendorID where h.PONumber=@ponum),'')

	if @version = '3060' 
		begin
			select @lines = coalesce(@lines + '', '') + 'AK2*855*'+ case when h.VendorID='IDSCHOLDIS' then right((convert(varchar(6),h.ResponseAckNo)),4) else right((convert(varchar(6),d.[LineNo])),4) end
				+'~'+ CHAR(13) + CHAR(10) + 'AK5*A~' + CHAR(13) + CHAR(10)
			from HPB_EDI..[855_Ack_Hdr] h with(nolock) inner join HPB_EDI..[855_Ack_Dtl] d with(nolock) on h.AckID=d.AckID
			where h.ResponseACKSent=0 and h.PONumber=@ponum
			order by case when h.VendorID!='IDSCHOLDIS' then cast(d.[LineNo] as int) else right((convert(varchar(6),h.ResponseAckNo)),4) end
		end
	else if @version = '4010'
		begin
			select @lines = coalesce(@lines + '', '') + 'AK2*855*'+(convert(varchar(10),h.PONumber))+'~'+ CHAR(13) + CHAR(10) + 'AK5*A~' + CHAR(13) + CHAR(10)
			from HPB_EDI..[855_Ack_Hdr] h with(nolock) --inner join HPB_EDI..[810_Inv_Dtl] d with(nolock) on h.InvoiceID=d.InvoiceID
			where h.ResponseACKSent=0 and h.PONumber=@ponum
			--order by d.[LineNo] 
		end
		
	--select @lines
	---- Return the result of the function
	RETURN @lines
END