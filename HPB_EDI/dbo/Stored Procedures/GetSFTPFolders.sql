-- =============================================
-- Author:		<Joey B.>
-- Create date: <1/23/2015>
-- Description:	<Get SFTP folders to check/place files.....>
-- =============================================
CREATE PROCEDURE dbo.GetSFTPFolders
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select distinct parentfolder from HPB_EDI..Vendor_SAN_Codes where isnull(parentfolder,'')!=''


END
