-- =============================================
-- Author:		<Joey B.>
-- Create date: <5/8/2015>
-- Description:	<Update PO processed flag and date......>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProcessedASNACK]
	@asnNo varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		
	declare @asn varchar(20)
	declare @po varchar(10)
	set @asn=replace(SUBSTRING(@asnNo,1,CHARINDEX('-',@asnNo,0)-1),'-','')
	set @po=replace(SUBSTRING(@asnNo,CHARINDEX('-',@asnNo,0),LEN(@asnNo)-CHARINDEX('-',@asnNo,0)+1),'-','')

    update HPB_EDI..[856_ASN_Hdr]
    set asnacksent=1
    where ASNNo = @asn and PONumber = @po
		or (GSNo in (select distinct GSNo from HPB_EDI..[856_ASN_Hdr] where ASNNo=@asnNo and PONumber=@po)
			and VendorID in ('IDSCHOLDIS'))
    
END
