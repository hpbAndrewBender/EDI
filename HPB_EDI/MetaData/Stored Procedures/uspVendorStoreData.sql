CREATE PROCEDURE [MetaData].[uspVendorStoreData]
(
	 @Vendor VARCHAR(20)
	,@locations AS TypeListString250 READONLY
)
AS 
BEGIN
	IF EXISTS(SELECT 1 FROM @locations)
		SELECT VendorId, LocationId, LocationNumber, VendorBillTo, VendorShipTo, SanAccount
		FROM MetaData.VendorLocations vl
			INNER JOIN @locations l
				ON vl.LocationNumber = LEFT(LTRIM(RTRIM(l.Strings)),5)
		WHERE vendorid = @Vendor
	ELSE
		SELECT VendorId, LocationId, LocationNumber, VendorBillTo, VendorShipTo, SanAccount
		FROM MetaData.VendorLocations vl
		WHERE vendorid = @Vendor


END