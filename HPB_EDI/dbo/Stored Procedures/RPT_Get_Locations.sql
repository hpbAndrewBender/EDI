-- =============================================
-- Author:		<Joey B.>
-- Create date: <4/8/14>
-- Description:	<Get EDI locations for reporting....>
-- =============================================
CREATE PROCEDURE [dbo].[RPT_Get_Locations] 
	@VendorID varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	----get locations
	select distinct l.LocationNo,l.Name,right(l.locationno,3)+ ' - ' + l.Name [Store]
	from HPB_Prime..Locations l inner join HPB_EDI..HPB_SAN_Codes s on l.LocationNo=s.LocationNo
		inner join HPB_EDI..[810_Inv_Hdr] h on l.LocationNo=h.ShipToLoc
	where ISNUMERIC(s.LocationNo)=1 and (CAST(s.LocationNo as int)< 200 or s.LocationNo='00944') and h.VendorID=@VendorID
	order by l.LocationNo,l.Name 
			
END
