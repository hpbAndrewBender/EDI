-- =============================================
-- Author:		<Joey B.>
-- Create date: <5/8/2015>
-- Description:	<Update PO processed flag and date......>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProcessedInvACK]
	@invoiceno varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update HPB_EDI..[810_Inv_Hdr]
    set invoiceacksent=1
    where InvoiceNo = @invoiceno or 
		(ReferenceNo in (select distinct ReferenceNo from HPB_EDI..[810_Inv_Hdr] where InvoiceNo=@invoiceno)
		and 
		VendorID in (select distinct VendorID from HPB_EDI..[810_Inv_Hdr] where InvoiceNo=@invoiceno))
    
END
