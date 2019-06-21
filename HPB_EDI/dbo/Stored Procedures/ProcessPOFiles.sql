-- =============================================
-- Author:		<Joey B.>
-- Create date: <10/4/2013>
-- Description:	<Builds a list of PO's to be exported to PUBNET thru EDI.....>
-- =============================================
CREATE PROCEDURE [dbo].[ProcessPOFiles]
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

	---- add outer loop for vendor to keep from crashing when tons of orders come through	
	create table #ords(ponumber varchar(20),FileText varchar(max))
	create table #vends (RowID int identity(1,1) ,VendorID varchar(20))
	insert into #vends
	select distinct h.VendorID
	from HPB_EDI..[850_PO_Hdr] h with(nolock) inner join HPB_EDI..[850_PO_Dtl] d with(nolock) on h.OrdID=d.OrdID
		inner join HPB_EDI..Vendor_SAN_Codes v with(nolock) on h.VendorID=v.VendorID
	where  h.Processed=0 and v.processor='PUBNET' 

	declare @vendcnt int, @curloop int
	select @vendcnt=isnull(max(RowID),0),@curloop=1
	from #vends

	while @curloop<=@vendcnt
	begin
	--build order string....
		declare @curVend varchar(20)
		select @curVend=VendorId from #vends where RowID=@curloop
			
		insert into #ords
		select distinct top 20 h.ponumber, 
			case when v.Binary=0 then 
				case when v.VendorID!='IDHMHDISTR' then 
					'ISA*00*850BK3060 *00*          *ZZ*760985X        *ZZ*'+ cast(h.ShipFromSAN as CHAR(15)) +'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*U*00200*'+RIGHT('0000000000'+h.PONumber,9)+'*0*P*>~'	
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
					+'SE*'+convert(varchar(10),(8+(h.TotalLines*2)))+'*000000003~'
					+CHAR(13) + CHAR(10)
					+'GE*1*000000002~'
					+CHAR(13) + CHAR(10)
					+'IEA*1*'+RIGHT('0000000000'+h.PONumber,9)+'~'
				else 
					'ISA|00|850BK3060 |00|          |ZZ|760985X        |ZZ|'+ cast(h.ShipFromSAN as CHAR(15)) +'|'+convert(varchar(6),h.IssueDate,12)+'|'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'|U|00200|'+RIGHT('0000000000'+h.PONumber,9)+'|0|P|>'	
					+CHAR(13) + CHAR(10)
					+'GS|PO|760985X|'+h.ShipFromSAN+'|'+convert(varchar(6),h.IssueDate,12)+'|'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'|000000002|X|003060'
					+CHAR(13) + CHAR(10)
					+'ST|850|000000003'
					+CHAR(13) + CHAR(10)
					+'BEG|00|NE|'+h.PONumber+'||'+convert(varchar(6),h.IssueDate,12)+'||AC'
					+CHAR(13) + CHAR(10)
					+'DTM|037|'+convert(varchar(6),h.IssueDate,12)+'|||'+left(convert(varchar(4),year(h.IssueDate)),2)+''
					+CHAR(13) + CHAR(10)
					+'N1|BT||15|'+replace(h.BillToSAN,'-','')+''
					+CHAR(13) + CHAR(10)
					+'N1|ST||15|'+replace(h.ShipToSAN,'-','')+''
					+CHAR(13) + CHAR(10)
					+'N1|VN||15|'+replace(h.ShipFromSAN,'-','')+''
					+CHAR(13) + CHAR(10)
					+ dbo.EDIfn_GetPODetails(h.PONumber)
					+'CTT|'+convert(varchar(4),h.TotalLines)+'|'+convert(varchar(10),h.TotalQty)+''
					+CHAR(13) + CHAR(10)
					+'SE|'+convert(varchar(10),(8+(h.TotalLines*2)))+'|000000003'
					+CHAR(13) + CHAR(10)
					+'GE|1|000000002'
					+CHAR(13) + CHAR(10)
					+'IEA|1|'+RIGHT('0000000000'+h.PONumber,9)+''
				end
			else
			CONVERT(varchar(max),CONVERT(varbinary(max),CONVERT(varchar(max),
			'ISA*00*850BK3060 *00*          *ZZ*760985X        *ZZ*'+ cast(h.ShipFromSAN as CHAR(15)) +'*'+convert(varchar(6),h.IssueDate,12)+'*'+replace(convert(varchar(5),h.InsertDateTime,108),':','')+'*U*00200*'+RIGHT('0000000000'+h.PONumber,9)+'*0*P*>~'	
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
			+'SE*'+convert(varchar(10),(8+(h.TotalLines*2)))+'*000000003~'
			+CHAR(13) + CHAR(10)
			+'GE*1*000000002~'
			+CHAR(13) + CHAR(10)
			+'IEA*1*'+RIGHT('0000000000'+h.PONumber,9)+'~')),1) 
			end [FileText]
		from HPB_EDI..[850_PO_Hdr] h with(nolock) inner join HPB_EDI..[850_PO_Dtl] d with(nolock) on h.OrdID=d.OrdID
			inner join HPB_EDI..Vendor_SAN_Codes v with(nolock) on h.VendorID=v.VendorID
		where h.Processed=0 and v.processor='PUBNET' and h.VendorID=@curVend and h.PONumber not in (select distinct PONumber from #ords)
		
		----update next
		if (select count(distinct POnumber) from HPB_EDI..[850_PO_Hdr] where Processed=0 and VendorID=@curVend and PONumber not in (select distinct PONumber from #ords))=0
			begin
				set @curloop = @curloop+1
			end
	end
	----get the results
	select distinct PONumber,FileText from #ords

	--clean up........
	drop table #vends
	drop table #ords

END

