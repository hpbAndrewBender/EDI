-- =============================================
-- Author:		<Joey B.>
-- Create date: <5/8/2015>
-- Description:	<Update PO processed flag and date......>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProcessedAckACK]
	@ponum varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update HPB_EDI..[855_Ack_Hdr]
    set responseacksent=1
    where PONumber = @ponum
		or (GSNo in (select distinct GSNo from HPB_EDI..[855_Ack_Hdr] where PONumber=@ponum)
			and VendorID in ('IDSCHOLDIS'))
    
END
