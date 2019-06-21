-- =============================================
-- Author:		<Joey B.>
-- Create date: <10/9/2013>
-- Description:	<Update PO processed flag and date......>
-- =============================================
CREATE PROCEDURE dbo.UpdateProcessedPO
	@PONumber char(6)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update HPB_EDI..[850_PO_Hdr]
    set Processed = 1, ProcessedDateTime = GETDATE()
    where PONumber = @PONumber
    
END
