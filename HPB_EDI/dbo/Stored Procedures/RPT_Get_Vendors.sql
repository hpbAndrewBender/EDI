-- =============================================
-- Author:		<Joey B.>
-- Create date: <4/8/14>
-- Description:	<Get EDI Vendors for reporting....>
-- =============================================
CREATE PROCEDURE [dbo].[RPT_Get_Vendors] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	----get vendors
	select distinct v.VendorID,v.VendorName, v.VendorID + '  -  ' + v.VendorName [VendorLabel]
	from HPB_EDI..Vendor_SAN_Codes v inner join HPB_Prime..VendorMaster vm on v.VendorID=vm.VendorID
		inner join HPB_EDI..[810_Inv_Hdr] h on h.ShipFromSAN=v.SANCode
	order by v.VendorID	
			
END
