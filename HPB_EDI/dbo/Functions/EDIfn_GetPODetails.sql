-- =============================================
-- Author:		<Joey B.>
-- Create date: <10/9/2013>
-- Description:	<Return PO details in single string.....>
-- =============================================
CREATE FUNCTION [dbo].[EDIfn_GetPODetails]
(
	@PO varchar(10)
)
RETURNS varchar(max)
AS
BEGIN

	----testing.....
	--declare @PO varchar(20)
	--set @PO = '212999'

	declare @lines varchar(max)
	declare @version varchar(10)
	set @version = isnull((select distinct c.EDIVersion from HPB_EDI..[850_PO_Hdr] h inner join HPB_EDI..Vendor_SAN_Codes c on h.VendorID=c.VendorID where h.PONumber=@PO),'')
	declare @vendor varchar(30)
	set @vendor = (select distinct vendorid from HPB_EDI..[850_PO_Hdr] where PONumber=@PO)

	if (@version = '3060' and @vendor!='IDHMHDISTR') or @vendor='IDMACMDIST'
		begin
			select @lines = coalesce(@lines + '', '') + 'PO1*'+convert(varchar(3),d.[LineNo])+'*'+convert(varchar(6),d.Qty)+'*EA*'+d.UnitPrice+'*NT*'+d.ItemIDCode+'*'+d.ItemIdentifier+'~'+ CHAR(13) + CHAR(10)+'IT8*'+d.ItemFillTerms+'*0*'+cast(replace(d.Qty*cast(d.UnitPrice as money),'.','')as varchar(12))+'~' +CHAR(13) + CHAR(10)
			from HPB_EDI..[850_PO_Hdr] h with(nolock) inner join HPB_EDI..[850_PO_Dtl] d with(nolock) on h.OrdID=d.OrdID
			where h.Processed=0 and h.PONumber=@PO
			order by cast(d.[LineNo] as int)
		end
	else if @version = '3060' and @vendor = 'IDHMHDISTR'
		begin
			select @lines = coalesce(@lines + '', '') + 'PO1|'+convert(varchar(3),d.[LineNo])+'|'+convert(varchar(6),d.Qty)+'|EA|'+d.UnitPrice+'|NT|'+d.ItemIDCode+'|'+d.ItemIdentifier+''+ CHAR(13) + CHAR(10)+'IT8|'+d.ItemFillTerms+'|0|'+cast(replace(d.Qty*cast(d.UnitPrice as money),'.','')as varchar(12))+'' +CHAR(13) + CHAR(10)
			from HPB_EDI..[850_PO_Hdr] h with(nolock) inner join HPB_EDI..[850_PO_Dtl] d with(nolock) on h.OrdID=d.OrdID
			where h.Processed=0 and h.PONumber=@PO
			order by cast(d.[LineNo] as int)
		end
	else if @version = '4010'
		begin
			select @lines = coalesce(@lines + '', '') + 'PO1*'+convert(varchar(3),d.[LineNo])+'*'+convert(varchar(6),d.Qty)+'*EA*'+d.UnitPrice+'*NT*'+d.ItemIDCode+'*'+d.ItemIdentifier+'~'+ CHAR(13) + CHAR(10)
			from HPB_EDI..[850_PO_Hdr] h with(nolock) inner join HPB_EDI..[850_PO_Dtl] d with(nolock) on h.OrdID=d.OrdID
			where h.Processed=0 and h.PONumber=@PO
			order by cast(d.[LineNo] as int)
		end
		
	--select @lines
	-- Return the result of the function
	RETURN @lines
END





