-- =============================================
-- Author:		<Joey B.>
-- Create date: <4/8/2014>
-- Description:	<Get EDI invoices by location for reporting....>
-- =============================================
CREATE PROCEDURE [dbo].[RPT_Get_Loc_Invoices] 
	@Location char(5), @VendorID varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	--declare @Location char(5),@VendorID varchar(30)
	--set @Location='00944'
	--set @VendorID='IDHACHDIST'
	

	----get location invoices
	select distinct h.PONumber[PONumber],h.InvoiceNo,convert(varchar(12), cast(h.IssueDate as datetime), 107)[IssueDateTime],
		ltrim(rtrim(cast(max(h.PONumber)as varchar(10))))+' | '+ltrim(rtrim(cast(h.InvoiceNo as varchar(20)))) [Params],
		'PONumber: ' + max(h.PONumber) + ' - InvoiceNo: ' + h.InvoiceNo + ' - InvoiceDate: ' + convert(varchar(12), cast(h.IssueDate as datetime), 107)[InvoiceLabel]
	from HPB_EDI..[810_Inv_Hdr] h with(nolock) inner join HPB_EDI..[810_Inv_Dtl] d with(nolock) on h.InvoiceID=d.InvoiceID
		inner join HPB_EDI..HPB_SAN_Codes c on c.SANCode=h.ShipToSAN
		inner join HPB_EDI..Vendor_SAN_Codes v on v.SANCode=h.ShipFromSAN
	where h.ShipToLoc = @Location and h.VendorID = @VendorID
	group by h.InvoiceNo,convert(varchar(12), cast(h.IssueDate as datetime), 107),h.PONumber
	order by h.InvoiceNo desc,h.PONumber
		
	
END
