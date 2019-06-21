-- =============================================
-- Author:		<Joey B.>
-- Create date: <10/4/2013>
-- Description:	<Reads and updates EDI DB with imported files.....>
-- =============================================
CREATE PROCEDURE [dbo].[ProcessReceivedFiles]
	@FileName varchar(100), @FileText varchar(max) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

----read the text and split into a table for processing....
declare @FileType varchar(20)
declare @Listtring varchar(max)  
declare @ediVersion char(4)	
declare @fileNo varchar(30)

--declare @FileText varchar(max) 
--declare @FileName varchar(100)
--set @FileName='855_000069812.txt'
------PO string........................................................
----set @Listtring = 'ISA~GS~ST*850*00001~BEG*00*NE*104824**20130311~DTM**20130311~N1*ST*Half Price Books #001*15*00ST~N1*BT*Half Price Books Corporate Office*15*00BT~N1*VN*Baker & Taylor Distribution*15*00VN~N2*Crystal Sweeney~N2*AccountingOffice~N3*5803 E. Northwest Hwy.~N3*5803 E. Northwest Hwy.~N3*PO Box 277938~N4*Dallas*TX*75231*USA~N4*Dallas*TX*75231~N4*Atlanta*GA*30384~PO1*1*3*EA*11.3900*EN*9781451627299*UP*~IT8*N~PO1*2*12*EA*16.5200*EN*9780446583978*UP*~IT8*N~PO1*3*12*EA*17.1000*EN*9780316036313*UP*~IT8*N~PO1*4*15*EA*8.5500*EN*9780425263907*UP*~IT8*N~PO1*5*15*EA*19.9500*EN*9780307464873*UP*~IT8*N~PO1*6*7*EA*17.0900*EN*9781401233792*UP*~IT8*N~PO1*7*12*EA*16.5000*EN*9780399157561*UP*~IT8*N~PO1*8*25*EA*9.0900*EN*9780345803498*UP*~IT8*N~PO1*9*25*EA*9.0900*EN*9780345803504*UP*~IT8*N~PO1*10*25*EA*9.0900*EN*9780345803481*UP*~IT8*N~PO1*11*12*EA*5.1200*EN*9780553579901*UP*~IT8*N~PO1*12*10*EA*14.2400*EN*9781401235413*UP*~IT8*N~PO1*13*5*EA*8.5500*EN*9780375507250*UP*~IT8*N~PO1*14*2*EA*19.9500*EN*9780553801477*UP*~IT8*N~CTT*14*180~SE*44*00001~'
------Acknowledge string..............................................
--set @FileText = ''
------Invoice string.....................................................
----set @Listtring = 'ISA|00|810BK3060 |00|          |ZZ|7214119        |ZZ|760985X        |131015|1132|U|00300|013113257|0|P|>GS|IN|7214119|760985X|131015|1132|013113257|X|003060ST|810|0001BIG|131015|TESTINV-1132|131015|TESTPO-111057CUR|SE|USDN1|ST||15|760985XN1|BT||15|760985XN1|VN||15|7214119ITD|01|3|||||30DTM|011|131015|||20IT1|1|1|EA|590.00|NT|IB|0835247414|PO|TESTPO-111057CTP||SLP|590.00|||DIS|1PID|F||||SUBJECT GUIDE TO BIP 2005-2006TDS|59000CAD|M||||USPSSAC|C|G830|||0|||||||06CTT|1|1SE|16|0001GE|1|013113257IEA|1|013113257'



set @Listtring = ltrim(rtrim(@FileText))
if right(ltrim(rtrim(@Listtring)),1)='|'  begin set @Listtring = ltrim(rtrim(replace(@Listtring,'|',''))) end
set @Listtring = replace(@Listtring,'*','|') ----run replace to account for both 3060 and 4010 versions......

set @FileType = ltrim(rtrim(SUBSTRING(replace(@FileName,'HPB',''),1,3)))
if @FileType not in ('855','856','810') or upper(right(@FileName,5)) like 'XX%'
	begin
		set @FileType = ltrim(rtrim(right(replace(@FileName,'HPB',''),3)))
		set @fileNo = replace(right(rtrim(@Listtring),9),'~','')
		set @ediVersion='4010'
	end
else
	begin
		set @fileNo = case when left(@FileName,3)='HPB' then replace(right(rtrim(@Listtring),9),'~','') else right(replace(@FileName,'.txt',''),9) end
		set @ediVersion='3060'
	end
--add replace string to add tilde for parsing.....
if @FileType ='855'
	begin
		set @Listtring = replace(@Listtring,'|B5|','|B5|^')
		set @Listtring = replace(@Listtring,'|B6|','^|B6|')
	end
set @Listtring = replace(@Listtring,'GS|','~GS|')
set @Listtring = replace(@Listtring,'ST|856','~ST|856')
set @Listtring = replace(@Listtring,'ST|855','~ST|855')
set @Listtring = replace(@Listtring,'ST|810','~ST|810')
set @Listtring = replace(@Listtring,'BAK|','~BAK|')
if @FileType ='856'
	begin
		set @Listtring = replace(@Listtring,'BSN|','~BSN|')
		set @Listtring = replace(@Listtring,'PRF|','~PRF|')
		set @Listtring = replace(@Listtring,'REF|BM','~REF|BM')
		set @Listtring = replace(@Listtring,'REF|PK','~PEF|PK')
		set @Listtring = replace(@Listtring,'REF|CN','~RRE|CN')
		set @Listtring = replace(@Listtring,'REF|MA','~PEF|MA')
		set @Listtring = replace(@Listtring,'REF|IV','~PIV|IV')
		set @Listtring = replace(@Listtring,'TD1|','~TD1|')
		set @Listtring = replace(@Listtring,'TD5|','~TD5|')
		set @Listtring = replace(@Listtring,'LIN|','~LIN|')
		set @Listtring = replace(@Listtring,'MEA|','~MEA|')
		set @Listtring = replace(@Listtring,'MAN|GM','~MAN|GM')
		set @Listtring = replace(@Listtring,'HL|','~HL|')
		set @Listtring = replace(@Listtring,'FOB|PO','~FOB|PO')
		set @Listtring = replace(@Listtring,'~LIN||EN|','~LIN||IB|0|EN|')
		set @Listtring = replace(@Listtring,'~LIN||B5||B6||EN|','~LIN||IB|0|B5||B6||EN|')
	end
if @FileType ='810'
	begin
		set @Listtring = replace(@Listtring,'BIG|','~BIG|')
		set @Listtring = replace(@Listtring,'TDS|','~TDS|')
		set @Listtring = replace(@Listtring,'SAC|','~SAC|')
		set @Listtring = replace(@Listtring,'IT1|','~IT1|')
		set @Listtring = replace(@Listtring,'|NT|EN|','|NT|IB||EN|')
		set @Listtring = replace(@Listtring,'|NT|B5||B6||EN|','|NT|IB||B5||B6||EN|')
		set @Listtring = replace(@Listtring,'CUR|SE|','~CUR|S:E|')
	end
set @Listtring = replace(@Listtring,'SE|','~SE|')
set @Listtring = replace(@Listtring,'SN1|','~SN1|')
set @Listtring = replace(@Listtring,'N1|','~N1|')
set @Listtring = replace(@Listtring,'~S~N1|','~SN1|')
set @Listtring = replace(@Listtring,'PO1|','~PO1|')
set @Listtring = replace(@Listtring,'CTP|','~CTP|')
set @Listtring = replace(@Listtring,'PID|','~PID|')
set @Listtring = replace(@Listtring,'DTM|017','~DDTM|017')
set @Listtring = replace(@Listtring,'DTM|011','~DTM|011')
set @Listtring = replace(@Listtring,'ACK|IA','~ACK|IA')
set @Listtring = replace(@Listtring,'ACK|IQ','~ACK|IQ')
set @Listtring = replace(@Listtring,'ACK|IR','~ACK|IR')
set @Listtring = replace(@Listtring,'ACK|IB','~ACK|IB')
set @Listtring = replace(@Listtring,'CAD|','~CAD|')
set @Listtring = replace(@Listtring,'CUR|','~CUR|')
set @Listtring = replace(@Listtring,'~~CUR|','~CUR|')
set @Listtring = replace(@Listtring,'CTT|','~CTT|')
set @Listtring = replace(@Listtring,'IEA|1|','~IEA|1|')
set @Listtring = replace(@Listtring,CHAR(13),'')
set @Listtring = replace(@Listtring,CHAR(10),'')
set @Listtring = replace(@Listtring,'~~','~')

declare @rVal int
declare @err int
set @rVal = 0
set @err = 0
declare @Sender varchar(15)
declare @Receiver varchar(15)
declare @filePO varchar(20)
declare @fileInv varchar(20)
declare @fileASN varchar(20)
declare @_FileType varchar(6)
declare @issueDate varchar(12)
declare @amtCode varchar(4)
declare @LineSts char(2)
declare @LineCode char(2)
declare @LineQty int
declare @curID varchar(20)
declare @DisPct varchar(6)
declare @RetAmt varchar(8)
declare @ToPay varchar(10)
declare @addChrg varchar(10)
declare @chrgCode varchar(10)
declare @lastID varchar(20)
declare @lastTracking varchar(30)
declare @UOM varchar(6)
declare @pkgNo varchar(30)
declare @trkNo varchar(30)
declare @InvRef varchar(15)
declare @ASNRef varchar(15)
declare @ACKRef varchar(15)
declare @carrier varchar(50)
declare @STINVNo varchar(10)
declare @STASNNo varchar(10)
declare @STACKNo varchar(10)
declare @GSNo varchar(10)
declare @ACKHdrs table(RowID int identity(1,1),TypeCode varchar(12),Sender varchar(15),Receiver varchar(15),FileType varchar(20),IssueDate varchar(12),FilePO varchar(20),STIDNo varchar(10), GSNo varchar(10))
declare @ASNHdrs table(RowID int identity(1,1),TypeCode varchar(12),Sender varchar(15),Receiver varchar(15),FileType varchar(20),IssueDate varchar(12),FilePO varchar(20),FileASN varchar(20),AmtCode varchar(4),Carrier varchar(50),STIDNo varchar(10), GSNo varchar(10))
declare @INVHdrs table(RowID int identity(1,1),TypeCode varchar(12),Sender varchar(15),Receiver varchar(15),FileType varchar(20),IssueDate varchar(12),FilePO varchar(20),FileINV varchar(20),AmtCode varchar(4),DisPct varchar(6), STIDNo varchar(10), GSNo varchar(10))
declare @ACKDtl table(PONumber varchar(20),LineNum varchar(6),Qty varchar(6),UOM varchar(3),UnitPrice varchar(10),PriceCode varchar(4),ItemIDCode varchar(4),ItemID varchar(15),AckQty int,ShipQty int,CanQty int,BakQty int,LineSts char(2),LineCode char(2))
declare @ASNDtl table(PONumber varchar(20),LineNum varchar(6),Qty varchar(6),UOM varchar(3),UnitPrice varchar(10),PriceCode varchar(4),ItemIDCode varchar(4),ItemID varchar(15),AckQty int,ShipQty int,CanQty int,BakQty int,LineSts char(2),LineCode char(2),PkgNo varchar(30),TrkNo varchar(30))
declare @INVDtl table(PONumber varchar(20),LineNum varchar(6),Qty varchar(6),UOM varchar(3),UnitPrice varchar(10),PriceCode varchar(4),ItemIDCode varchar(4),ItemID varchar(15),FileINV varchar(20),RetAmt varchar(8))
declare @INVAdds table(PONumber varchar(20),FileINV varchar(20),ChargeCode varchar(10),ChargeAmt varchar(10))

declare @listTable TABLE(RowID int identity (1,1),[Type] varchar(6),LineNum varchar(6),Qty varchar(6),[Key] varchar(20), Data VARCHAR(250))
DECLARE @tmpString VARCHAR(250)

if (left(right(replace(@Listtring,'~',''),15),3)='IEA' or left(right(replace(@Listtring,'~',''),16),3)='IEA') and @fileNo=replace(right(@Listtring,9),'~','')	----check to ensure there is a complete file......
	begin

	if ltrim(rtrim(@fileType)) = '855'	----Read in Acknowledge File....................................................................................
		begin
		----------------------------------Read input file and build temp table.........................................................................
		 WHILE LEN(@Listtring) > 0
		 BEGIN
		  set @err = @@ERROR
		  SET @tmpString = LEFT(@Listtring, ISNULL(NULLIF(CHARINDEX('~', @Listtring) - 1, -1),LEN(@Listtring)))
		  SET @Listtring = SUBSTRING(@Listtring,ISNULL(NULLIF(CHARINDEX('~', @Listtring), 0),LEN(@Listtring)) + 1, LEN(@Listtring))

			if LEFT(@tmpstring,2) in ('GS') --File data
			begin
			  --select replace(LEFT(@tmpString,CHARINDEX('|',@tmpString,1)-1),'|',''), 
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1)),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1))),
					--ltrim(rtrim(@tmpString))
			  set @Sender = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
			  set @Receiver = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)))
			  set @issueDate = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)))
			  set @ediVersion=isnull((select EDIVersion from HPB_EDI..Vendor_SAN_Codes where SANCode=@Sender),@ediVersion)
			  set @GSNo=SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)))
			  
			  if @err = 0 begin set @err = @@ERROR end	
			end
			else if LEFT(@tmpstring,2) in ('ST') --File data
			begin
			  --select replace(LEFT(@tmpString,CHARINDEX('|',@tmpString,1)-1),'|',''), 
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1)),
					--ltrim(rtrim(@tmpString))
			  set @_FileType = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1)
			--set @issueDate = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)))
			  set @STACKNo = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
			  
			  if @err = 0 begin set @err = @@ERROR end	
			end
			else if LEFT(@tmpstring,3) in ('BAK') --PO Hdr data
			begin
			  --select replace(LEFT(@tmpString,CHARINDEX('|',@tmpString,1)-1),'|',''), 
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1)),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1))),
					--ltrim(rtrim(@tmpString))
			  set @filePO = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)))
			  set @filePO = ltrim(rtrim(REPLACE(REPLACE(@filePO,'-',''),'reship','')))
			  set @issueDate = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)))
		      if @err = 0 begin set @err = @@ERROR end	
			end
			else if LEFT(@tmpstring,3) in ('ACK') --PO Dtl data
			begin
				set @LineSts = ''
				set @LineQty = 0 
				if LEN(@tmpstring)>=10
				begin
				--select replace(LEFT(@tmpString,CHARINDEX('|',@tmpString,1)-1),'|',''), 
				--	SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1),
				--	SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1)),
				--	SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1))),
				--	SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))),
				--	SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1))),
				--	SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1))),
				--	SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1))),
				--	SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1))),
					--ltrim(rtrim(@tmpString))
					
					set @curID = @lastID -- SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)))
					set @LineQty = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
					set @LineSts = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1)
					set @LineCode = right(replace(replace(@tmpString,CHAR(13),''),CHAR(10),''),2)
									
					update @ACKDtl
					set AckQty = @LineQty, ShipQty = @LineQty, LineSts=@LineSts, LineCode = @LineCode
					where ItemID=@curID
					
					if @err = 0 begin set @err = @@ERROR end	
				end
				else if LEN(@tmpstring)<10
				begin
					set @LineCode = ''
					--select replace(LEFT(@tmpString,CHARINDEX('|',@tmpString,1)-0),'|',''), replace(Right(@tmpString,CHARINDEX('|',@tmpString,1)-1),'|',''),replace(Right(@tmpString,CHARINDEX('|',@tmpString,1)-1),'|','')
					
					set @LineCode = replace(Right(@tmpString,CHARINDEX('|',@tmpString,1)-1),'|','')
					update @ACKDtl
					set LineCode = @LineCode
					where ItemID=@curID
					
					if @err = 0 begin set @err = @@ERROR end	
				end		 
			end
			else if LEFT(@tmpstring,2) in ('PO') --PO Dtl data
			begin
			  --select replace(LEFT(@tmpString,CHARINDEX('|',@tmpString,1)-1),'|',''), 
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1)),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1))),
					--ltrim(rtrim(@tmpString))
				
				if exists(select POnumber from HPB_EDI..[850_PO_Hdr] where ponumber=@filePO)
					begin
					  insert into @ACKHdrs
					  select 'ACK',@Sender[Sender],@Receiver[Receiver],@fileType[FileType],@issueDate[IssueDate],@filePO[FilePO],@STACKNo[STIDNo],@GSNo[GSNo]
					  where @filePO not in (select distinct FilePO from @ACKHdrs)
					 
					  insert into @ACKDtl
					  select @FilePO, right(SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1),4),
							SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1)),
							SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1))),
							SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))),
							SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1))),
							case when SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1))) ='EN'
								then SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)))
								else SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1))) end,
							case when SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1))) ='EN'
								then SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)))
								else SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1))) end,
							0[AckQty],0[ShipQty],0[CanQty],0[BakQty],''[LineSTS],''[LineCode]
							
							set @lastID = case when SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1))) ='EN'
								then SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)+1)))
								else SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1))) end
							
						
						if @err = 0 begin set @err = @@ERROR end
					end
			end
			else if LEFT(@tmpstring,3) in ('IEA') --PO Hdr data
			begin
			  set @ACKRef = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)
			end	
		 END
		end	
	else if ltrim(rtrim(@fileType)) = '856'	----Read in ASN File....................................................................................
		begin
		----------------------------------Read input file and build temp table.........................................................................
		 WHILE LEN(@Listtring) > 0
		 BEGIN
		  SET @tmpString = LEFT(@Listtring, ISNULL(NULLIF(CHARINDEX('~', @Listtring) - 1, -1),LEN(@Listtring)))
		  SET @Listtring = SUBSTRING(@Listtring,ISNULL(NULLIF(CHARINDEX('~', @Listtring), 0),LEN(@Listtring)) + 1, LEN(@Listtring))

			if LEFT(@tmpstring,2) in ('GS') --File data
			begin
			  set @Sender = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
			  set @Receiver = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)))
			  set @ediVersion=isnull((select EDIVersion from HPB_EDI..Vendor_SAN_Codes where SANCode=@Sender),@ediVersion)
			  set @GSNo=SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)))
			  
			  if @err = 0 begin set @err = @@ERROR end
			end
			else if LEFT(@tmpstring,2) in ('ST') --File data
			begin
			  set @_FileType = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1)
			  set @STASNNo = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
			  
			  if @err = 0 begin set @err = @@ERROR end
			end
			else if LEFT(@tmpstring,3) in ('TD5') --File data
			begin
			  set @carrier = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+50-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)))
		  
			  if @ediVersion='3060' and @Sender='8600023'----Scholastic
				begin
					set @carrier = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)))
		 		end
			  if @ediVersion='3060' and @Sender='2002086'----HarperCollins
					begin
						set @carrier = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)))
		 			end
			end
			else if LEFT(@tmpstring,3) in ('PRF') --PO Hdr data
			begin
			   if @ediVersion='3060' and @Sender<>'2153793'
					begin
						set @filePO = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1)
						set @filePO = ltrim(rtrim(REPLACE(REPLACE(@filePO,'-',''),'reship','')))
					end
				else if @ediVersion='3060' and @Sender='2153793'
					begin
						set @filePO=SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,6)
						set @filePO = ltrim(rtrim(REPLACE(REPLACE(@filePO,'-',''),'reship','')))
					end
				else if @ediVersion='4010'
					begin
						set @filePO=SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,6)
						set @filePO = ltrim(rtrim(REPLACE(REPLACE(@filePO,'-',''),'reship','')))
					end
				  
			  if @err = 0 begin set @err = @@ERROR end
			end
			else if LEFT(@tmpstring,3) in ('REF') --PO Hdr data  
			begin
			  if @ediVersion='3060' or @Sender in ('6315011','2002442') --IDMACMDIST & IDS&SDISTR
				begin
					set @fileASN = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1+1+1))
				end
			  if @err = 0 begin set @err = @@ERROR end
			end
			else if LEFT(@tmpstring,3) in ('PEF') ----RandomHouse
			begin
			  if @ediVersion='4010'
					begin
						set @fileASN = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1+1+1))
					end
			end
			else if LEFT(@tmpstring,3) in ('RRE') ----HarperCollins
			begin
			  if @ediVersion='3060'
					begin
						 set @trkNo = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1+15))
					end
				else
					begin
						set @trkNo = ''
					end
			end
		else if LEFT(@tmpstring,3) in ('DTM') --File data
		begin
		  set @issueDate = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
		
		end
		else if LEFT(@tmpstring,3) in ('CUR') --PO Hdr data
		begin
		  set @amtCode = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
		
		  if @err = 0 begin set @err = @@ERROR end
		end
		else if LEFT(@tmpstring,3) in ('MAN') --PO Hdr data
		begin
			 			    
				if @ediVersion='3060' and @Sender not in ('2002086','8600023') ----Not HarperCollins or Scholastic
				begin
					 set @pkgNo = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
					 set @trkNo = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)))
					
					 if @pkgNo=@trkNo
						begin
							set @pkgNo =SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1+15))
			 				set @trkNo = ''
						end	
				end	
				else if @ediVersion='3060' and @Sender in ('2002086','8600023')	----HarperCollins & Scholastic
				begin
					 set @pkgNo = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1+15))
				end	
				else if @ediVersion='4010'
				begin
					 set @pkgNo = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
					 set @trkNo = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)))
					
					 if @pkgNo=@trkNo
						begin
							set @trkNo =SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1+15))
		 					set @pkgNo = ''
						end	
				end	
					
			  if @err = 0 begin set @err = @@ERROR end
		end
		else if LEFT(@tmpstring,3) in ('LIN') --PO Dtl data
		begin
				  insert into @ASNHdrs
				  select 'ASN',@Sender[Sender],@Receiver[Receiver],@fileType[FileType],@issueDate[IssueDate],@filePO[FilePO],@fileASN[FileASN],@amtCode[AmtCode],@carrier[Carrier],@STASNNo[STIDNo],@GSNo[GSNo]
				  where @filePO not in (select distinct FilePO from @ASNHdrs) --and @filePO not in (select distinct FilePO from @ASNHdrs)
		  
				  insert into @ASNDtl
				  select @FilePO,'','','','','',
						case when SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))) ='EN'
							then SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)))
							else SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1)) end,
						case when SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))) ='EN'
							then SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)))
							else SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))) end,
						0[AckQty],0[ShipQty],0[CanQty],0[BakQty],''[LineSTS],''[LineCode],@pkgNo,@trkNo
					
					set @lastID = case when SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))) ='EN'
							then SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)))
							else SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))) end
					
					set @lastTracking = case when @pkgNo=''then @trkNo else @pkgNo end
					
					if @err = 0 begin set @err = @@ERROR end

			end
			else if LEFT(@tmpstring,3) in ('SN1') --PO Dtl data
			begin
				set @LineSts = ''
				set @LineQty = 0 
					
					set @curID = @lastID -- SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)))
					set @LineQty = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
					set @UOM = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)))
					
					
					update @ASNDtl
					set Qty = @LineQty, ShipQty = @LineQty, UOM = case when len(@UOM)>2 then left(@UOM,2) else @UOM end
					where ItemID=@curID and PONumber=@filePO and @lastTracking in (PkgNo,TrkNo)
					
					if @err = 0 begin set @err = @@ERROR end
			end
			else if LEFT(@tmpstring,3) in ('IEA') --PO Hdr data
			begin
			  set @ASNRef = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)
			  --select @ASNRef
			end	
		 END
		end
	else if ltrim(rtrim(@fileType)) = '810'	----Read in Invoice File....................................................................................
			begin
		----------------------------------Read input file and build temp table.........................................................................
		 WHILE LEN(@Listtring) > 0
		 BEGIN
		  SET @tmpString = LEFT(@Listtring, ISNULL(NULLIF(CHARINDEX('~', @Listtring) - 1, -1),LEN(@Listtring)))
		  SET @Listtring = SUBSTRING(@Listtring,ISNULL(NULLIF(CHARINDEX('~', @Listtring), 0),LEN(@Listtring)) + 1, LEN(@Listtring))
		  --select @tmpstring
			if LEFT(@tmpstring,2) in ('GS') --File data
			begin
			  set @Sender = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
			  set @Receiver = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)))
			  set @ediVersion=isnull((select EDIVersion from HPB_EDI..Vendor_SAN_Codes where SANCode=@Sender),@ediVersion)
			  set @GSNo=SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)))
			  
			  if @err = 0 begin set @err = @@ERROR end
			end
			else if LEFT(@tmpstring,2) in ('ST') --File data
			begin
			  set @_FileType = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1)
			  set @STINVNo = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
		end
			else if LEFT(@tmpstring,3) in ('BIG') --PO Hdr data
			begin
			  set @fileInv = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
			  set @filePO = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)))
			  set @filePO = ltrim(rtrim(REPLACE(REPLACE(@filePO,'-',''),'reship','')))
			  
			  if @ediVersion='4010'
				begin
					set @issueDate = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1)
				end
			
			  if @err = 0 begin set @err = @@ERROR end
			end
			else if LEFT(@tmpstring,3) in ('DTM') --File data
			begin
			 if @ediVersion='3060'
				begin
					set @issueDate = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
				end
			end
			else if LEFT(@tmpstring,3) in ('CUR') --PO Hdr data
			begin
				  if @ediVersion='3060'
					begin
						set @amtCode = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
					end
				  else if @ediVersion='4010'
					begin
						set @amtCode = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
					end
			  if @err = 0 begin set @err = @@ERROR end
			end
			else if LEFT(@tmpstring,3) in ('CTP') --PO Hdr data
			begin
			    set @DisPct = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)))
				set @RetAmt = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)))

				update @INVHdrs
				set AmtCode=@amtCode,DisPct=@DisPct
				where FilePO=@filePO
				
				update @INVDtl
				set RetAmt=@RetAmt
				where ItemID=@lastID

			  if @err = 0 begin set @err = @@ERROR end
			end	
			else if LEFT(@tmpstring,3) in ('SAC') --File data
			begin
				set @chrgCode = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1))
			    set @addChrg = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)))
			    set @addChrg = case LEN(@addChrg) when 1 then '000'+@addChrg when 2 then '00'+@addChrg when 3 then '0'+@addChrg else @addChrg end
			
				if not exists(select PONumber from @INVAdds where PONumber=@filePO and FileINV=@fileInv and ChargeCode=@chrgCode) and cast(@addChrg as int) <> 0
					begin
						insert into @INVAdds
						select @filePO,@fileInv,@chrgCode,@addChrg
					end
			
			end
			else if LEFT(@tmpstring,3) in ('TDS') --PO Hdr data
			begin
			  --select replace(LEFT(@tmpString,CHARINDEX('|',@tmpString,1)-1),'|',''), replace(right(@tmpString,CHARINDEX('|',@tmpString,1)+1),'|','')
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1)
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1)),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1))),
					--SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1))),
					--ltrim(rtrim(@tmpString))
			  
			  if @err = 0 begin set @err = @@ERROR end
			end			
			else if LEFT(@tmpstring,3) in ('IT1') --PO Dtl data
			begin

			 --if exists(select POnumber from HPB_EDI..[850_PO_Hdr] where ponumber=@filePO)
				--	begin
						  insert into @INVHdrs
						  select 'INV',@Sender[Sender],@Receiver[Receiver],@fileType[FileType],@issueDate[IssueDate],@filePO[FilePO],@fileINV[FileINV],@amtCode[AmtCode],@DisPct[DisPct],@STINVNo[STIDNo],@GSNo[GSNo]
						  where @fileInv not in (select distinct FileINV from @INVHdrs) --and @filePO not in (select distinct FilePO from @INVHdrs)
					
						  insert into @INVDtl
						  select @FilePO, SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,1)+1,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)-CHARINDEX('|',@tmpString,1)-1),
								SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-1)),
								SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1))),
								SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1))),
								SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1))),
								case when SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1))) ='EN'
									then SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)))
									else SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1))) end,
								case when SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1))) ='EN'
									then SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)))
									else SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1))) end,
									@fileInv,@RetAmt
											
							set @lastID = case when SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1))) ='EN'
									then SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1)+1)+1)))
									else SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)+1)+1)+1))) end
									
							if @err = 0 begin set @err = @@ERROR end
					--end
			end
			else if LEFT(@tmpstring,3) in ('IEA') --PO Hdr data
			begin
			  set @InvRef = SUBSTRING(@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1,abs(CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1-CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,CHARINDEX('|',@tmpString,1)+1)+1)+1)+1)
			  --select @InvRef
			end	
		 END
		end
	----------------------------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------------------------------------------------------------------------------------------------------------
	----------------------------------------------------------------------------------------------------------------------------------------------------------
	-------------------------Insert into DB from temp table.................................................................................
		
		declare @id int
		set @id = 0
			
		if ltrim(rtrim(@fileType)) = '855'	and ltrim(rtrim(@_FileType)) = '855'
			begin
		--------ACK...................................................................................................................................................
				declare @ACKloop int
				select @ACKloop = COUNT(distinct FilePO) from @ACKHdrs
				while @ACKloop > 0
					begin
						declare @curACKPO varchar(12) 
						declare @curACKSend varchar(20)
						declare @curACKRecv varchar(20)
						declare @curACKIssueDtm varchar(20)
						declare @curACKamtCode varchar(6)
						declare @curACKSTNo varchar(10)
						declare @curACKGSNo varchar(10)
						select @curACKPO=FilePO,@curACKSend=Sender,@curACKRecv=Receiver,@curACKIssueDtm=IssueDate,@curACKSTNo=STIDNo,@curACKGSNo=GSNo from @ACKHdrs where RowID=@ACKloop
				
						----set @ACKDtl quantities.....
						update p
						set p.CanQty=case when isnull(p.Qty,0)-isnull(p.AckQty,0)< 0 then 0 else isnull(p.Qty,0)-isnull(p.AckQty,0) end
						from @ACKDtl p left outer join HPB_EDI..[850_PO_Hdr] ph on p.PONumber=ph.PONumber
							left outer join HPB_EDI..[850_PO_Dtl] pd on ph.OrdID=pd.OrdID and p.ItemID=pd.ItemIdentifier
						where p.PONumber=@curACKPO
						
						if @err = 0 begin set @err = @@ERROR end
											
						begin tran
						--insert header info and get identity...
						insert into HPB_EDI..[855_Ack_Hdr](PONumber,IssueDate,VendorID,ReferenceNo,ShipToLoc,ShipToSAN,BillToLoc,BillToSAN,ShipFromLoc,ShipFromSAN,TotalLines,TotalQty,CurrencyCode,InsertDateTime,Processed,ProcessedDateTime,ResponseACKSent,ResponseAckNo,GSNo)
						select ph.PONumber,@curACKIssueDtm,ph.VendorID,@ACKRef,ph.ShipToLoc,ph.ShipToSAN,ph.BillToLoc,ph.BillToSAN,ph.ShipFromLoc,ph.ShipFromSAN,
							(select count(LineNum) from @ACKDtl where PONumber=@curACKPO),(select sum(AckQty) from @ACKDtl where PONumber=@curACKPO),@curACKamtCode,getdate(),0,null,0,@curACKSTNo,@curACKGSNo
						from HPB_EDI..[850_PO_Hdr] ph 
						where ph.ponumber=@curACKPO and replace(ph.ShipFromSAN,'-','')=replace(@curACKSend,'-','') --and replace(ph.ShipToSAN,'-','')=replace(@Receiver,'-','')
						
						if @err = 0 begin set @err = @@ERROR end
						set @id = @@identity
						
						----insert detail info..................
						if isnull(@id,0)<>0 and @err=0
							begin
								insert into HPB_EDI..[855_Ack_Dtl] (AckID,[LineNo],LineStatusCode,ItemStatusCode,UOM,OrdQty,ShipQty,CanceledQty,BackOrdQty,UnitPrice,PriceCode,CurrencyCode,ItemIDCode,ItemIdentifier)
								select @id,p.LineNum,p.LineSts,p.LineCode,p.UOM,p.AckQty,p.ShipQty,--p.CanQty,p.BakQty, 
								case when p.LineCode like 'B%' or p.LineCode ='IB' then 0 else p.CanQty end [CanQty],
								case when p.LineCode like 'B%' or p.LineCode ='IB' then p.CanQty else p.BakQty end [BakQty], 
									p.UnitPrice,p.PriceCode,@amtCode,p.ItemIDCode,p.ItemID
								from @ACKDtl p 
								where p.PONumber=@curACKPO

								if @err = 0 begin set @err = @@ERROR end
							end
							
						if @err=0
							begin
								Commit Transaction VX_ReqSubmit
							end
						else
							begin
								ROLLBACK  Transaction VX_ReqSubmit
							end
							
						set @ACKloop = @ACKloop-1
					end
			end
		----------------------------------------------------------------------------------------------------------------------------------------------------------
		else if ltrim(rtrim(@fileType)) = '856'	and ltrim(rtrim(@_FileType)) = '856'
			begin
		--------ASN...................................................................................................................................................
				declare @ASNloop int
				select @ASNloop = COUNT(distinct FileASN) from @ASNHdrs
				while @ASNloop > 0
					begin
						declare @curASNPO varchar(12) 
						declare @curASNSend varchar(20)
						declare @curASNRecv varchar(20)
						declare @curASNIssueDtm varchar(20)
						declare @curASNamtCode varchar(6)
						declare @curASN varchar(20)
						declare @curCar varchar(20)
						declare @curASNSTNo varchar(10)
						declare @curASNGSNo varchar(10)
						select @curASNPO=FilePO,@curASN=FileASN,@curASNSend=Sender,@curASNRecv=Receiver,@curASNIssueDtm=IssueDate,@curASNamtCode=AmtCode,@curCar=LTRIM(RTRIM(Replace(carrier,' ',''))),@curASNSTNo=STIDNo,@curASNGSNo=GSNo from @ASNHdrs where RowID=@ASNloop
						
						begin tran
						
						if exists (select PONumber from HPB_EDI..[850_PO_Hdr] where PONumber=@curASNPO)
							begin
								----set @ACKDtl quantities.....
								update p
								set p.LineNum=pd.[LineNo],p.UnitPrice=pd.UnitPrice,p.PriceCode=pd.PriceCode
								from @ASNDtl p left outer join HPB_EDI..[850_PO_Hdr] ph on p.PONumber=ph.PONumber
								left outer join HPB_EDI..[850_PO_Dtl] pd on ph.OrdID=pd.OrdID and p.ItemID=pd.ItemIdentifier
								where p.PONumber=@curASNPO
						
								if @err = 0 begin set @err = @@ERROR end
								
								--insert header info and get identity...
								insert into HPB_EDI..[856_ASN_Hdr](PONumber,ASNNo,IssueDate,VendorID,ReferenceNo,ShipToLoc,ShipToSAN,BillToLoc,BillToSAN,ShipFromLoc,ShipFromSAN,Carrier,TotalLines,TotalQty,CurrencyCode,InsertDateTime,Processed,ProcessedDateTime,ASNACKSent,ASNAckNo,GSNo)
								select ph.PONumber,@curASN,@curASNIssueDtm,ph.VendorID,@ASNRef,ph.ShipToLoc,ph.ShipToSAN,ph.BillToLoc,ph.BillToSAN,ph.ShipFromLoc,ph.ShipFromSAN,
									left(@curCar,20),(select count(LineNum) from @ASNDtl where PONumber=@curASNPO),(select sum(ShipQty) from @ASNDtl where PONumber=@curASNPO),@curASNamtCode,getdate(),0,null,0,@curASNSTNo,@curASNGSNo
								from HPB_EDI..[850_PO_Hdr] ph 
								where ph.ponumber=@curASNPO and replace(ph.ShipFromSAN,'-','')=replace(@curASNSend,'-','') --and replace(ph.ShipToSAN,'-','')=replace(@Receiver,'-','')
								
								if @err = 0 begin set @err = @@ERROR end
							end
						else if not exists (select PONumber from HPB_EDI..[850_PO_Hdr] where PONumber=@curASNPO) and LEN(@curASNPO)>6
							begin
								insert into HPB_EDI..[856_ASN_Hdr](PONumber,ASNNo,IssueDate,VendorID,ReferenceNo,ShipToLoc,ShipToSAN,BillToLoc,BillToSAN,ShipFromLoc,ShipFromSAN,Carrier,TotalLines,TotalQty,CurrencyCode,InsertDateTime,Processed,ProcessedDateTime,ASNACKSent,ASNAckNo,GSNo)
								select 'F'+right(@ASNRef,5),@curASN,@curASNIssueDtm,v.VendorID,@ASNRef,s1.LocationNo,s1.SANCode,s2.LocationNo,s2.SANCode,'VEND',v.SANCode,
									left(@curCar,20),(select count(LineNum) from @ASNDtl where PONumber=@curASNPO),(select sum(ShipQty) from @ASNDtl where PONumber=@curASNPO),@curASNamtCode,getdate(),0,null,0,@curASNSTNo,@curASNGSNo
								from @ASNHdrs h inner join HPB_EDI..Vendor_SAN_Codes v on replace(h.Sender,'-','')=replace(v.SANCode,'-','')
									inner join HPB_EDI..HPB_SAN_Codes s1 on replace(h.Receiver,'-','')=replace(s1.SANCode,'-','')
									inner join HPB_EDI..HPB_SAN_Codes s2 on s2.LocationNo='HPBCA'
								where h.FilePO=@curASNPO and replace(h.Sender,'-','')=replace(@curASNSend,'-','')
									and h.FileASN not in (select distinct ReferenceNo from HPB_EDI..[856_ASN_Hdr])
								
								if @err = 0 begin set @err = @@ERROR end
							end
						else
							begin
								insert into HPB_EDI..[856_ASN_Hdr](PONumber,ASNNo,IssueDate,VendorID,ReferenceNo,ShipToLoc,ShipToSAN,BillToLoc,BillToSAN,ShipFromLoc,ShipFromSAN,Carrier,TotalLines,TotalQty,CurrencyCode,InsertDateTime,Processed,ProcessedDateTime,ASNACKSent,ASNAckNo,GSNo)
								select h.FilePO,@curASN,@curASNIssueDtm,v.VendorID,@ASNRef,s1.LocationNo,s1.SANCode,s2.LocationNo,s2.SANCode,'VEND',v.SANCode,
									left(@curCar,20),(select count(LineNum) from @ASNDtl where PONumber=@curASNPO),(select sum(ShipQty) from @ASNDtl where PONumber=@curASNPO),@curASNamtCode,getdate(),0,null,0,@curASNSTNo,@curASNGSNo
								from @ASNHdrs h inner join HPB_EDI..Vendor_SAN_Codes v on replace(h.Sender,'-','')=replace(v.SANCode,'-','')
									inner join HPB_EDI..HPB_SAN_Codes s1 on replace(h.Receiver,'-','')=replace(s1.SANCode,'-','')
									inner join HPB_EDI..HPB_SAN_Codes s2 on s2.LocationNo='HPBCA'
								where h.FilePO=@curASNPO and replace(h.Sender,'-','')=replace(@curASNSend,'-','')
									and h.FileASN not in (select distinct ReferenceNo from HPB_EDI..[856_ASN_Hdr])
								
								if @err = 0 begin set @err = @@ERROR end
							end
							
						set @id = @@identity
						
						--insert detail info..................
						if isnull(@id,0)<>0 and @err=0
							begin
								insert into HPB_EDI..[856_ASN_Dtl] (ShipID,[LineNo],ItemIDCode,ItemIdentifier,ShipQty,PackageNo,TrackingNo)
								select @id,case when ltrim(rtrim(isnull(p.LineNum,'')))='' then isnull(ROW_NUMBER() OVER(PARTITION BY [PONumber] ORDER BY [PONumber]),'') else p.LineNum end,
									p.ItemIDCode,p.ItemID,p.ShipQty,p.PkgNo,p.TrkNo
								from @ASNDtl p
								where p.POnumber=@curASNPO

								if @err = 0 begin set @err = @@ERROR end
							end
							
						if @err=0
							begin
								Commit Transaction VX_ReqSubmit
							end
						else
							begin
								ROLLBACK  Transaction VX_ReqSubmit
							end
							
						set @ASNloop = @ASNloop-1
					end
					
					----Update any invoices that the order originated in DIPS.........
					if exists (select i.PONumber from HPB_EDI..[856_ASN_Hdr] i inner join (select PONumber,LocationNo FROM OPENDATASOURCE('SQLOLEDB','Data Source=sequoia;User ID=stocuser;Password=Xst0c5').HPB_db.dbo.requisitionheader) r on i.PONumber=r.PONumber
								inner join HPB_EDI..HPB_SAN_Codes s on s.LocationNo=r.LocationNo where i.ShipToLoc='00944' and i.Processed=0 and ISNUMERIC(i.PONumber)=1)
						begin  
							update i
							set i.ShipToLoc=r.LocationNo,i.ShipToSAN=s.SANCode
							from HPB_EDI..[856_ASN_Hdr] i inner join (select PONumber,LocationNo FROM OPENDATASOURCE('SQLOLEDB','Data Source=sequoia;User ID=stocuser;Password=Xst0c5').HPB_db.dbo.requisitionheader) r on i.PONumber=r.PONumber
								inner join HPB_EDI..HPB_SAN_Codes s on s.LocationNo=r.LocationNo
							where i.ShipToLoc='00944' and i.Processed=0	and ISNUMERIC(i.PONumber)=1
						end
			end
		----------------------------------------------------------------------------------------------------------------------------------------------------------
		else if ltrim(rtrim(@fileType)) = '810'	and ltrim(rtrim(@_FileType)) = '810'
			begin
		--------INV...................................................................................................................................................
				declare @INVloop int
				select @INVloop = COUNT(distinct FileINV) from @INVHdrs
				while @INVloop > 0
					begin
						declare @curINVPO varchar(12) 
						declare @curINVSend varchar(20)
						declare @curINVRecv varchar(20)
						declare @curINVIssueDtm varchar(20)
						declare @curINVamtCode varchar(6)
						declare @curINV varchar(20)
						declare @curINVDisPct varchar(6)
						declare @curINVSTNo varchar(10)
						declare @curGSNo varchar(10)
						select @curINVPO=FilePO,@curINV=FileINV,@curINVSend=Sender,@curINVRecv=Receiver,@curINVIssueDtm=IssueDate,@curINVamtCode=isnull(AmtCode,'USD'),@curINVDisPct=DisPct,@curINVSTNo=STIDNo,@curGSNo=GSNo from @INVHdrs where RowID=@INVloop
				
						----update unit price for HMH since they are sending full retail price in files...........
						if @curINVSend='2153793'
							begin
								update @INVDtl
								set UnitPrice = cast(cast(cast(UnitPrice as money)*cast(@curINVDisPct as decimal(8,2)) as decimal(12,4))as varchar(10))
								where PONumber=@curINVPO
							end

						if exists(select a.PONumber from HPB_EDI..[810_Inv_Charges] a inner join @INVAdds b on a.PONumber=b.PONumber and a.InvoiceNo=b.FileINV and a.ChargeCode=b.ChargeCode where a.PONumber=@curINVPO)
							begin
								 update b
								 set ChargeAmt=cast(isnull(left(a.ChargeAmt,LEN(a.ChargeAmt)-2)+'.'+RIGHT(a.ChargeAmt,2),0)as decimal(10,2))
								 from HPB_EDI..[810_Inv_Charges] b inner join @INVAdds a on a.PONumber=b.PONumber and b.InvoiceNo=a.FileINV and a.ChargeCode=b.ChargeCode 
								 where b.PONumber=@curINVPO and b.InvoiceNo=@curINV and b.ChargeCode=a.ChargeCode
							end
						else
							begin
								insert into HPB_EDI..[810_Inv_Charges]
								select a.PONumber,@curINV,a.ChargeCode,sum(cast(isnull(left(a.ChargeAmt,LEN(a.ChargeAmt)-2)+'.'+RIGHT(a.ChargeAmt,2),0)as decimal(10,2)))
								from @INVAdds a
								where a.PONumber=@curINVPO and not exists(select PONumber from HPB_EDI..[810_Inv_Charges] where PONumber=@curINVPO and InvoiceNo=@curINV and ChargeCode=a.ChargeCode)
								group by a.PONumber,a.ChargeCode
							end	
						
						set @ToPay = (select SUM(cast(Qty as int)*cast(UnitPrice as money)) from @INVDtl where PONumber=@filePO and FileINV=@curINV)
						if @curINVDisPct is null begin set @curINVDisPct=(select top 1 DisPct from @INVHdrs where DisPct is not null)  end
				
						begin tran
						--insert header info and get identity...check if PO exists and do insert.........................................					
						if exists(select PONumber from HPB_EDI..[850_PO_Hdr] where PONumber=@curINVPO)
							begin
								insert into HPB_EDI..[810_Inv_Hdr] (InvoiceNo,IssueDate,VendorID,PONumber,ReferenceNo,ShipToLoc,ShipToSAN,BillToLoc,BillToSAN,ShipFromLoc,ShipFromSAN,TotalLines,TotalQty,TotalPayable,CurrencyCode,InsertDateTime,Processed,ProcessedDateTime,InvoiceAckSent,InvoiceAckNo,GSNo)
								select @curINV,@curINVIssueDtm,ph.VendorID,ph.PONumber,@InvRef,ph.ShipToLoc,ph.ShipToSAN,ph.BillToLoc,ph.BillToSAN,ph.ShipFromLoc,ph.ShipFromSAN,
									(select count(LineNum) from @INVDtl where PONumber=@curINVPO and FileINV=@curINV),(select sum(cast(Qty as int)) from @INVDtl where PONumber=@curINVPO and FileINV=@curINV),(select cast(sum(cast(UnitPrice as decimal(12,4))*cast(Qty as int))as decimal(12,4)) from @INVDtl where PONumber=@curINVPO and FileINV=@curINV)+isnull((select SUM(ChargeAmt) from HPB_EDI..[810_Inv_Charges] where PONumber=@curINVPO and InvoiceNo=@curINV),0),@curINVamtCode,getdate(),0,null,0,@curINVSTNo,@curGSNo
								from HPB_EDI..[850_PO_Hdr] ph 
								where ph.ponumber=@curINVPO and replace(ph.ShipFromSAN,'-','')=replace(@curINVSend,'-','')
									and not exists (select distinct invoiceno from HPB_EDI..[810_Inv_Hdr] where InvoiceNo=@curINV)
							end
						else  ----if PO does not exist then pull from table variables......................................................
							begin
								insert into HPB_EDI..[810_Inv_Hdr] (InvoiceNo,IssueDate,VendorID,PONumber,ReferenceNo,ShipToLoc,ShipToSAN,BillToLoc,BillToSAN,ShipFromLoc,ShipFromSAN,TotalLines,TotalQty,TotalPayable,CurrencyCode,InsertDateTime,Processed,ProcessedDateTime,InvoiceAckSent,InvoiceAckNo,GSNo)
								select h.FileINV,h.IssueDate,v.VendorID,h.FilePO,@InvRef,s1.LocationNo,s1.SANCode,s2.LocationNo,s2.SANCode,'VEND',v.SANCode,
									(select count(LineNum) from @INVDtl where PONumber=@curINVPO and FileINV=@curINV),(select sum(cast(Qty as int)) from @INVDtl where PONumber=@curINVPO and FileINV=@curINV),(select cast(sum(cast(UnitPrice as decimal(12,4))*cast(Qty as int))as decimal(12,4)) from @INVDtl where PONumber=@curINVPO and FileINV=@curINV)+isnull((select SUM(ChargeAmt) from HPB_EDI..[810_Inv_Charges] where PONumber=@curINVPO and InvoiceNo=@curINV),0),@curINVamtCode,getdate(),0,null,0,@curINVSTNo,@curGSNo
								from @INVHdrs h inner join HPB_EDI..Vendor_SAN_Codes v on replace(h.Sender,'-','')=replace(v.SANCode,'-','')
									inner join HPB_EDI..HPB_SAN_Codes s1 on replace(h.Receiver,'-','')=replace(s1.SANCode,'-','')
									inner join HPB_EDI..HPB_SAN_Codes s2 on s2.LocationNo='HPBCA'
								where h.FilePO=@curINVPO and h.FileINV=@curINV and replace(h.Sender,'-','')=replace(@curINVSend,'-','')	
									and not exists (select distinct invoiceno from HPB_EDI..[810_Inv_Hdr] where InvoiceNo=@curINV)
							end
							
						set @id = @@identity

						if isnull(@id,0)<>0 and @err=0
							begin
								----insert detail info..................
								insert into HPB_EDI..[810_Inv_Dtl] (InvoiceID,[LineNo],ItemIDCode,ItemIdentifier,ItemDesc,InvoiceQty,UnitPrice,DiscountPrice,DiscountCode,DiscountPct,RetailPrice)
								select @id,p.LineNum,p.ItemIDCode,p.ItemID,'',p.Qty,cast(cast(p.UnitPrice as decimal(12,2))as varchar(6)),'','',@curINVDisPct,p.RetAmt
								from @INVDtl p
								where p.PONumber=@curINVPO and p.FileINV=@curINV
						
								if @err = 0 begin set @err = @@ERROR end
							end
							
						if @err=0
							begin
								Commit Transaction VX_ReqSubmit
							end
						else
							begin
								ROLLBACK  Transaction VX_ReqSubmit
							end
							
						set @INVloop = @INVloop-1
					end	
					
					----Update any invoices that the order originated in DIPS.........
					if exists (select i.PONumber from HPB_EDI..[810_Inv_Hdr] i inner join (select PONumber,LocationNo FROM OPENDATASOURCE('SQLOLEDB','Data Source=sequoia;User ID=stocuser;Password=Xst0c5').HPB_db.dbo.requisitionheader) r on i.PONumber=r.PONumber
								inner join HPB_EDI..HPB_SAN_Codes s on s.LocationNo=r.LocationNo where i.ShipToLoc='00944' and i.Processed=0 and ISNUMERIC(i.PONumber)=1)
						begin  
							update i
							set i.ShipToLoc=r.LocationNo,i.ShipToSAN=s.SANCode
							from HPB_EDI..[810_Inv_Hdr] i inner join (select PONumber,LocationNo FROM OPENDATASOURCE('SQLOLEDB','Data Source=sequoia;User ID=stocuser;Password=Xst0c5').HPB_db.dbo.requisitionheader) r on i.PONumber=r.PONumber
								inner join HPB_EDI..HPB_SAN_Codes s on s.LocationNo=r.LocationNo
							where i.ShipToLoc='00944' and i.Processed=0	and ISNUMERIC(i.PONumber)=1
						end
			end
		-----------------------------------------------------------------------------------------------------------------------------------------------------------
	
		set @rVal = @err
		select @rVal
	end
else
	begin		----if the file is not complete then send a false back to app......
		set @err=1
		set @rVal = @err
		select @rVal	
	end

END
