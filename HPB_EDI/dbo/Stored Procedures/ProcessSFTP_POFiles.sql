-- =============================================
-- Author:		<Joey B.>
-- Create date: <1/24/2015>
-- Description:	<Builds a list of PO's to be exported to SFPT folders thru EDI.....>
-- =============================================
CREATE PROCEDURE [dbo].[ProcessSFTP_POFiles]
AS

BEGIN

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
	create table #ords(PONumber varchar(20),ParentFolder varchar(20),FileText varchar(max))	
	create table #vends (RowID int identity(1,1) ,VendorID varchar(20))
	insert into #vends
	select distinct h.VendorID
	from [850_PO_Hdr] h with(nolock) inner join [850_PO_Dtl] d with(nolock) on h.OrdID=d.OrdID
		inner join Vendor_SAN_Codes v with(nolock) on h.VendorID=v.VendorID
	where h.Processed=0 and v.processor='SFTP'  

	declare @vendcnt int, @curloop int
	select @vendcnt=isnull(max(RowID),0),@curloop=1
	from #vends

	while @curloop<=@vendcnt
	begin
	--build order string....
		declare @curVend varchar(20)
		select @curVend=VendorId from #vends where RowID=@curloop

		insert into #ords
		select distinct top 20 h.ponumber,v.ParentFolder, 
			case when v.Binary=0 then 
			'ISA*00*850BK3060 *00*          *ZZ*760985X        *ZZ*'+ cast(h.ShipFromSAN as CHAR(15)) +'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')
			+case when h.ShipFromSAN in ('8600023') then '*U*00200*'+right('000000000'+cast(datepart(dy, getdate()) as varchar(5)) + cast(h.PONumber as varchar(10)),9)  
				else '*U*00200*'+RIGHT('0000000000'+h.PONumber,9) end +'*0*P*>~'
			+CHAR(13) + CHAR(10)
			+'GS*PO*760985X*'+h.ShipFromSAN+'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*000000002*X*003060~'
			+CHAR(13) + CHAR(10)
			+'ST*850*000000003~'
			+CHAR(13) + CHAR(10)
			+'BEG*00*NE*'+h.PONumber+'**'+convert(varchar(6),h.IssueDate,12)+'**AC~'
			+CHAR(13) + CHAR(10)
			+'DTM*037*'+convert(varchar(6),h.IssueDate,12)+'***'+left(convert(varchar(4),year(h.IssueDate)),2)+'~'
			+CHAR(13) + CHAR(10)
			+'N1*BT**15*'+replace(h.BillToSAN,'-','')+'~'
			+CHAR(13) + CHAR(10)
			+'N1*ST**15*'+replace(h.ShipToSAN,'-','')+'~'
			+CHAR(13) + CHAR(10)
			+'N1*VN**15*'+replace(h.ShipFromSAN,'-','')+'~'
			+CHAR(13) + CHAR(10)
			+ dbo.EDIfn_GetPODetails(h.PONumber)
			+'CTT*'+convert(varchar(4),h.TotalLines)+'*'+convert(varchar(10),h.TotalQty)+'~'
			+CHAR(13) + CHAR(10)
			+'SE*'+convert(varchar(10),(8+(case when v.EDIVersion='3060' then h.TotalLines*2 else h.TotalLines end)))+'*000000003~'
			+CHAR(13) + CHAR(10)
			+'GE*1*000000002~'
			+CHAR(13) + CHAR(10)
			+'IEA*1*'+case when h.ShipFromSAN in ('8600023') then right('000000000'+cast(datepart(dy, getdate()) as varchar(5)) + cast(h.PONumber as varchar(10)),9) 
				else RIGHT('0000000000'+h.PONumber,9) end +'~'  
			else
			CONVERT(varchar(max),CONVERT(varbinary(max),CONVERT(varchar(max),
			'ISA*00*850BK3060 *00*          *ZZ*760985X        *ZZ*'+ cast(h.ShipFromSAN as CHAR(15)) +'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')
			+case when h.ShipFromSAN in ('8600023') then '*U*00200*'+right('000000000'+cast(datepart(dy, getdate()) as varchar(5)) + cast(h.PONumber as varchar(10)),9) 
				else '*U*00200*'+RIGHT('0000000000'+h.PONumber,9) end +'*0*P*>~'
			+CHAR(13) + CHAR(10)
			+'GS*PO*760985X*'+h.ShipFromSAN+'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*000000002*X*003060~'
			+CHAR(13) + CHAR(10)
			+'ST*850*000000003~'
			+CHAR(13) + CHAR(10)
			+'BEG*00*NE*'+h.PONumber+'**'+convert(varchar(6),h.IssueDate,12)+'**AC~'
			+CHAR(13) + CHAR(10)
			+'DTM*037*'+convert(varchar(6),h.IssueDate,12)+'***'+left(convert(varchar(4),year(h.IssueDate)),2)+'~'
			+CHAR(13) + CHAR(10)
			+'N1*BT**15*'+replace(h.BillToSAN,'-','')+'~'
			+CHAR(13) + CHAR(10)
			+'N1*ST**15*'+replace(h.ShipToSAN,'-','')+'~'
			+CHAR(13) + CHAR(10)
			+'N1*VN**15*'+replace(h.ShipFromSAN,'-','')+'~'
			+CHAR(13) + CHAR(10)
			+ dbo.EDIfn_GetPODetails(h.PONumber)
			+'CTT*'+convert(varchar(4),h.TotalLines)+'*'+convert(varchar(10),h.TotalQty)+'~'
			+CHAR(13) + CHAR(10)
			+'SE*'+convert(varchar(10),(8+(case when v.EDIVersion='3060' then h.TotalLines*2 else h.TotalLines end)))+'*000000003~'
			+CHAR(13) + CHAR(10)
			+'GE*1*000000002~'
			+CHAR(13) + CHAR(10)
			+'IEA*1*'+case when h.ShipFromSAN in ('8600023') then right('000000000'+cast(datepart(dy, getdate()) as varchar(5)) + cast(h.PONumber as varchar(10)),9) 
				else RIGHT('0000000000'+h.PONumber,9) end +'~')),1)
			end [FileText]
		from [850_PO_Hdr] h with(nolock) inner join [850_PO_Dtl] d with(nolock) on h.OrdID=d.OrdID
			inner join Vendor_SAN_Codes v with(nolock) on h.VendorID=v.VendorID
		where h.Processed=0 and v.processor='SFTP' and h.VendorID=@curVend and h.PONumber not in (select distinct PONumber from #ords)

		----update next
		if (select count(distinct POnumber) from [850_PO_Hdr] where Processed=0 and VendorID=@curVend and ProcessedDateTime is not null and PONumber not in (select distinct PONumber from #ords))=0
			begin
				set @curloop = @curloop+1
			end
	end
	----get the results
	select distinct PONumber,ParentFolder,FileText from #ords

	--clean up........
	drop table #vends
	drop table #ords

END

