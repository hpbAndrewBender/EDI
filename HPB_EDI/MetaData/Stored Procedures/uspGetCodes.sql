CREATE PROCEDURE [MetaData].[uspGetCodes]
(
	 @VendorID varchar(20)  = null
	,@FileFormat VARCHAR(50) = null
	,@Vers VARCHAR(10) = null
	,@AssocColumn VARCHAR(100) = NULL
)
AS
BEGIN
	IF @VendorID IS NULL
		BEGIN
			SELECT	 ff.id as FileFormatId, ct.Id as CodeTypeId,  c.Id as CodesId
					,ff.FileFormat, ff.Vers, ff.Active
					,ct.VendorID, ct.CodeType, ct.AssociatedColumn, ct.MaxChars
					,c.Code, c.CodeName, c.CodeDescription
			FROM MetaData.Codes c
				INNER JOIN MetaData.CodeTypes ct
					ON c.CodeTypeId = ct.Id
				INNER JOIN MetaData.FileFormats ff
					ON ct.FileFormatId = ff.Id
			ORDER BY ct.VendorID, ff.FileFormat, ff.Vers, ct.CodeType, c.CodeName
		END
	ELSE IF @VendorID IS NOT NULL AND @FileFormat IS NULL AND @Vers IS NULL AND @AssocColumn IS NULL
		BEGIN
			SELECT	 ff.id as FileFormatId, ct.Id as CodeTypeId,  c.Id as CodesId
					,ff.FileFormat, ff.Vers, ff.Active
					,ct.VendorID, ct.CodeType, ct.AssociatedColumn, ct.MaxChars
					,c.Code, c.CodeName, c.CodeDescription
			FROM MetaData.Codes c
				INNER JOIN MetaData.CodeTypes ct
					ON c.CodeTypeId = ct.Id
				INNER JOIN MetaData.FileFormats ff
					ON ct.FileFormatId = ff.Id
			WHERE @VendorID = @VendorID
			ORDER BY ff.FileFormat, ff.Vers, ct.CodeType, c.CodeName
		END	
	ELSE IF @VendorID IS NOT NULL AND @FileFormat IS NOT NULL AND @Vers IS NOT NULL AND @AssocColumn IS NULL
		SELECT	 ff.id as FileFormatId, ct.Id as CodeTypeId,  c.Id as CodesId
				,ff.FileFormat, ff.Vers, ff.Active
				,ct.VendorID, ct.CodeType, ct.AssociatedColumn, ct.MaxChars
				,c.Code, c.CodeName, c.CodeDescription
		FROM MetaData.Codes c
			INNER JOIN MetaData.CodeTypes ct
				ON c.CodeTypeId = ct.Id
			INNER JOIN MetaData.FileFormats ff
				ON ct.FileFormatId = ff.Id
		WHERE ct.VendorID = @VendorID
			AND FileFormat = @FileFormat	
			AND Vers = @Vers
		ORDER BY ct.CodeType, c.CodeName
	ELSE IF @VendorID IS NOT NULL AND @FileFormat IS NOT NULL AND @Vers IS NOT NULL AND @AssocColumn IS NOT NULL
		SELECT	 ff.id as FileFormatId, ct.Id as CodeTypeId,  c.Id as CodesId
				,ff.FileFormat, ff.Vers, ff.Active
				,ct.VendorID, ct.CodeType, ct.AssociatedColumn, ct.MaxChars
				,c.Code, c.CodeName, c.CodeDescription
		FROM MetaData.Codes c
			INNER JOIN MetaData.CodeTypes ct
				ON c.CodeTypeId = ct.Id
			INNER JOIN MetaData.FileFormats ff
				ON ct.FileFormatId = ff.Id
		WHERE ct.VendorID = @VendorID
			AND FileFormat = @FileFormat
			AND Vers = @Vers
			AND AssociatedColumn= @AssocColumn
		ORDER BY ct.CodeType, c.CodeName
END