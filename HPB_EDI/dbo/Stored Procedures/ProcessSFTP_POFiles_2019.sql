---- =============================================
---- Author:		<Joey B.>
---- Create date: <1/24/2015>
--				2019-02-11  Updated script to be more efficient
---- Description:	<Builds a list of PO's to be exported to SFPT folders thru EDI.....>
---- =============================================
CREATE PROCEDURE [dbo].[ProcessSFTP_POFiles_2019]
AS

--BEGIN

	SET NOCOUNT ON;

	--ISA*00*850BK3060 *00*          *ZZ*760985X        *ZZ*7214119        *130904*1312*U*00306*000145888*1*T*>~
	--GS*Test0002*760985X*7214119*20130904*1312*000000002*X*003060~
	--ST*850*000000003~
	--BEG*00*NE*Test0002**130904**AC~
	--DTM*037*130904*2013~
	
	--N1*BT**15*7609876~
	--N1*ST**15*1506951~
	--N1*VN**15*7214119~
	
	--PO1*1*24*EA*7.475*NT*EN*9780062024046*UP*07863569142~
	--IT8*N**~
	--PO1*2*48*EA*5.975*NT*EN*9780553593716*UP*73145140152~
	--IT8*N**~
	--PO1*3*48*EA*8.475*NT*EN*9780142410707*UP*74041707882~
	--IT8*N**~
	
	--CTT*3*120~
	--SE*14*000000003~
	--GE*1*000000002~
	--IEA*1*000145888~

	--SE total = 8 + (TotalLines*2).......	

	DECLARE	@curVend VARCHAR(20)
			,@LineFeed CHAR(2) = CHAR(13)+CHAR(10)
	
	CREATE TABLE #ords
	(
		 PONumber VARCHAR(20)
		,ParentFolder VARCHAR(20)
		,FileText VARCHAR(MAX)
	)	

	CREATE TABLE #vends 
	(
		 RowID INT IDENTITY(1,1)
		,VendorID VARCHAR(20)
		,VendProcessed BIT DEFAULT(0)
	)

	CREATE TABLE #dataset
	(
		 id INT IDENTITY(1,1)
		,[VendorID] VARCHAR(10)
		,[Binary] bit
		,EDIVersion NVARCHAR(10)
		,PONumber VARCHAR(20)
		,ParentFolder VARCHAR(20)
		,ShipFromSAN NVARCHAR(12)
		,IssueDate DATETIME
		,InsertDateTime DATETIME
		,BillToSAN NVARCHAR(12)
		,ShipToSAN NVARCHAR(12)
		,PODetails VARCHAR(max)
		,TotalLines INT
		,TotalQty INT
	)
	
	CREATE NONCLUSTERED INDEX IX_tempDataSet_VendorID ON #dataset (VendorID)
	CREATE NONCLUSTERED INDEX IX_tempVends_VendorID ON #vends (VendorID)


	INSERT INTO #vends (VendorID, VendProcessed)
		SELECT h.VendorID, 0
		FROM HPB_EDI.dbo.[850_PO_Hdr] h
			INNER JOIN HPB_EDI.dbo.[850_PO_Dtl] d
				ON h.OrdID=d.OrdID
			INNER JOIN HPB_EDI.dbo.Vendor_SAN_Codes v
				ON h.VendorID=v.VendorID
					AND v.Processor ='SFTP'
		WHERE h.Processed=0
		GROUP BY h.VendorID

	INSERT INTO #dataset ([Binary],VendorID,EDIVersion,PONumber,ParentFolder,ShipFromSAN,IssueDate,InsertDateTime,BillToSAN,ShipToSAN
						 ,PODetails,TotalLines,TotalQty)
		SELECT	 v.[Binary],v.VendorID,v.EDIVersion,h.PONumber,v.ParentFolder,h.ShipFromSAN,h.IssueDate,h.InsertDateTime,h.BillToSAN,h.ShipToSAN
				,dbo.EDIfn_GetPODetails(h.PONumber),h.TotalLines,h.TotalLines
		FROM HPB_EDI.dbo.[850_PO_Hdr] h 
			INNER JOIN HPB_EDI.dbo.[850_PO_Dtl] d 
				ON h.OrdID=d.OrdID
			INNER JOIN HPB_EDI.dbo.Vendor_SAN_Codes v 
				ON h.VendorID=v.VendorID
					AND v.Processor='SFTP'
		WHERE h.Processed=0 

	WHILE (SELECT COUNT(1) FROM #vends WHERE VendProcessed=0) > 0
	BEGIN

		SELECT TOP 1 @curVend = v.[VendorID]
		FROM #vends v
		WHERE v.[VendProcessed]=0
		ORDER BY v.[VendorID]

		INSERT INTO #ords
			SELECT	 ds.ponumber
					,ds.ParentFolder
					,CASE WHEN ds.[Binary]=0 
							THEN	'ISA*00*850BK3060 *00*          *ZZ*760985X        *ZZ*'
									+ CAST(ds.ShipFromSAN as CHAR(15)) 
									+'*'+CONVERT(VARCHAR(6),ds.[IssueDate],12)+'*'+REPLACE(CONVERT(VARCHAR(5),ds.[InsertDateTime],108),':','')
									+CASE WHEN ds.[ShipFromSAN] in ('8600023') 
										THEN '*U*00200*'+RIGHT('000000000'+CAST(DATEPART(dy, GETDATE()) AS VARCHAR(5)) + CAST(ds.[PONumber] AS VARCHAR(10)),9)  
										ELSE '*U*00200*'+RIGHT('0000000000'+ds.[PONumber],9) 
									 END +'*0*P*>~'
									+@LineFeed
									+'GS*PO*760985X*'+ds.[ShipFromSAN]+'*'+CONVERT(VARCHAR(6),ds.[IssueDate],12)+'*'+REPLACE(CONVERT(VARCHAR(5),ds.[InsertDateTime],108),':','')+'*000000002*X*003060~'
									+@LineFeed
									+'ST*850*000000003~'
									+@LineFeed
									+'BEG*00*NE*'+ds.[PONumber]+'**'+CONVERT(VARCHAR(6),ds.[IssueDate],12)+'**AC~'
									+@LineFeed
									+'DTM*037*'+CONVERT(VARCHAR(6),ds.[IssueDate],12)+'***'+LEFT(CONVERT(VARCHAR(4),YEAR(ds.[IssueDate])),2)+'~'
									+@LineFeed
									+'N1*BT**15*'+REPLACE(ds.[BillToSAN],'-','')+'~'
									+@LineFeed
									+'N1*ST**15*'+REPLACE(ds.[ShipToSAN],'-','')+'~'
									+@LineFeed
									+'N1*VN**15*'+REPLACE(ds.[ShipFromSAN],'-','')+'~'
									+@LineFeed
									+ds.[PODetails]
									+'CTT*'+CONVERT(VARCHAR(4),ds.[TotalLines])+'*'+CONVERT(VARCHAR(10),ds.[TotalQty])+'~'
									+@LineFeed
									+'SE*'+CONVERT(VARCHAR(10),(8+(CASE WHEN ds.[EDIVersion]='3060' THEN ds.[TotalLines]*2 ELSE ds.[TotalLines] END)))+'*000000003~'
									+@LineFeed
									+'GE*1*000000002~'
									+@LineFeed
									+'IEA*1*'
									+CASE WHEN ds.[ShipFromSAN] in ('8600023') 
											THEN RIGHT('000000000'+CAST(DATEPART(dy, GETDATE()) AS VARCHAR(5)) + CAST(ds.[PONumber] as varchar(10)),9) 
											ELSE RIGHT('0000000000'+ds.[PONumber],9) 
									 END +'~'  
							ELSE	CONVERT(VARCHAR(MAX),CONVERT(VARBINARY(MAX),CONVERT(VARCHAR(MAX),
									'ISA*00*850BK3060 *00*          *ZZ*760985X        *ZZ*'
									+CAST(ds.[ShipFromSAN] AS CHAR(15))
									+'*'+CONVERT(VARCHAR(6),ds.[IssueDate],12)+'*'+REPLACE(CONVERT(VARCHAR(5),ds.[InsertDateTime],108),':','')
									+CASE WHEN ds.[ShipFromSAN] IN ('8600023') 
											THEN '*U*00200*'+RIGHT('000000000'+CAST(DATEPART(dy, GETDATE()) AS VARCHAR(5)) + CAST(ds.[PONumber] AS VARCHAR(10)),9) 
											ELSE '*U*00200*'+RIGHT('0000000000'+ds.[PONumber],9) 
									 END +'*0*P*>~'
									+@LineFeed
									+'GS*PO*760985X*'+ds.[ShipFromSAN]+'*'+CONVERT(VARCHAR(6),ds.[IssueDate],12)+'*'+REPLACE(CONVERT(VARCHAR(5),ds.[InsertDateTime],108),':','')+'*000000002*X*003060~'
									+@LineFeed
									+'ST*850*000000003~'
									+@LineFeed
									+'BEG*00*NE*'+ds.[PONumber]+'**'+CONVERT(VARCHAR(6),ds.[IssueDate],12)+'**AC~'
									+@LineFeed
									+'DTM*037*'+CONVERT(VARCHAR(6),ds.[IssueDate],12)+'***'+LEFT(CONVERT(VARCHAR(4),YEAR(ds.[IssueDate])),2)+'~'
									+@LineFeed
									+'N1*BT**15*'+REPLACE(ds.[BillToSAN],'-','')+'~'
									+@LineFeed
									+'N1*ST**15*'+REPLACE(ds.[ShipToSAN],'-','')+'~'
									+@LineFeed
									+'N1*VN**15*'+REPLACE(ds.[ShipFromSAN],'-','')+'~'
									+@LineFeed
									+ds.[PODetails]
									+'CTT*'+convert(varchar(4),ds.[TotalLines])+'*'+convert(varchar(10),ds.[TotalQty])+'~'
									+@LineFeed
									+'SE*'+CONVERT(VARCHAR(10),(8+(CASE WHEN ds.[EDIVersion]='3060' THEN ds.[TotalLines]*2 ELSE ds.[TotalLines] END)))+'*000000003~'
									+@LineFeed
									+'GE*1*000000002~'
									+@LineFeed
									+'IEA*1*'+
									CASE WHEN ds.ShipFromSAN in ('8600023') 
										THEN RIGHT('000000000'+CAST(DATEPART(dy, GETDATE()) AS VARCHAR(5)) + CAST(ds.[PONumber] AS VARCHAR(10)),9) 
										ELSE RIGHT('0000000000'+ds.[PONumber],9) 
									END +'~')),1)
						END [FileText]
			FROM #dataset ds
				LEFT JOIN #ords o
					ON ds.[PONumber] = o.[PONumber]
						AND ds.[VendorID]=@curVend
						AND o.[PONumber] IS NULL

		UPDATE #vends
		SET VendProcessed=1
		WHERE VendorID=@curVend
	END
	
	----get the results
	SELECT	 PONumber
			,ParentFolder
			,FileText
	FROM #ords
	GROUP BY PONumber, ParentFolder, FileText
		
	--clean up........
	DROP TABLE #vends
	DROP TABLE #ords
	DROP TABLE #dataset
--END