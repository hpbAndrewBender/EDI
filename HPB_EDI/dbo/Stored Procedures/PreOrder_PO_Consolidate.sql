-- =============================================
-- Author:		<Joey B.>
-- Create date: <3/28/2016>
-- Description:	<Consolidate PreOrders onto store POs...>
-- =============================================
CREATE PROCEDURE [dbo].[PreOrder_PO_Consolidate]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @rVal int
set @rVal = 0
declare @err int
set @err=0
			
----get orders pending consolidation for stores.......................................................
	create table #asnTmp (rowid int identity(1,1), ordNo varchar(20), locNo char(5),PoNo char(6))
	insert into #asnTmp
	select t.OrderNumber,san.LocationNo,CAST('' as CHAR(6))
	from HPB_EDI..EDI_Process_Log pl inner join HPB_EDI..EDI_Transactions t on pl.LogID=t.LogID
		inner join BakerTaylor..codes_SAN san on t.SellerID=san.SAN+san.Suffix
	where pl.Processed=0 and t.TransType='ASN' and t.SourceApp='BW_PRE' and ltrim(rtrim(t.Message))=''
	order by san.LocationNo,t.OrderNumber

----loop through each location and get a new PO......................................................
	declare @sRetPO char(6)
	declare @newPONo char(6)
	
	if (select COUNT(*) from #asnTmp)>0
		begin
			declare @loop int
			set @loop = (select count(distinct locNo) from #asnTmp)
			
			while @loop > 0
				begin 
					declare @curLoc char(5)
					select top 1 @curLoc = locNo from #asnTmp where ltrim(rtrim(PoNo))=''

					-----get next PO number....
					exec OPENDATASOURCE('SQLOLEDB','Data Source=sequoia;User ID=stocuser;Password=Xst0c5').HPB_db.dbo.STOC_GetNextPONo @sRetPO = @newPONo output
					
					update #asnTmp
					set PoNo = @newPONo
					where locNo = @curLoc
			
					set @loop = @loop - 1
					set @sRetPO=''
					set @newPONo=''
				end	

		----run a transaction to update each order with the selected PO.............................................
		Begin Transaction Pre_UpdatePO		
			declare @upd int
			set @upd = (select MAX(rowID) from #asnTmp)
			
			while @upd > 0
					begin 
						declare @updOrd varchar(20)
						select @updOrd = ordNo from #asnTmp where rowid = @upd
						
						----update transaction table with PO number.....................................
						update t
						set t.Message=a.PoNo
						from HPB_EDI..EDI_Transactions t inner join #asnTmp a on t.OrderNumber=a.ordNo
						where t.OrderNumber=@updOrd and t.TransType='ASN' and t.SourceApp='BW_PRE'
					
						if @err=0 begin set @err=@@ERROR end
										
						set @upd = @upd - 1
					end

		----create temp table to hold dropshipment details................................
			create table #drpTmp (rowid int identity(1,1),PoNo char(6),ordNo varchar(20),locNo char(5),storeNo char(5),lineNum varchar(10),itemcode varchar(20),shipQty int,cost money)
			insert into #drpTmp (PoNo,ordNo,locNo,storeNo,lineNum,itemcode,shipQty,cost)
			select t.Message[PoNumber],t.OrderNumber,'00944',a.locNo,t.LineNumber,right(p.ItemCode,8),t.ShippedQuantity,p.Cost
			from HPB_EDI..EDI_Process_Log pl inner join HPB_EDI..EDI_Transactions t on pl.LogID=t.LogID
				inner join #asnTmp a on t.OrderNumber=a.ordNo
				left outer join (select distinct po.ItemCode,pm.ISBN,pmd.UPC,pm.Cost from HPB_Prime..ProductMaster pm 
								inner join HPB_Prime..ProductMasterDist pmd on pm.ItemCode=pmd.ItemCode
								inner join HPB_Prime..ProductPreOrder po on pm.ItemCode=po.ItemCode) p
					on t.ProductID=case when t.ProductIDType='UPC' then p.UPC else p.ISBN end
			where pl.Processed=0 and t.TransType='ASN' and t.SourceApp='BW_PRE'

			if @err=0 begin set @err=@@ERROR end
			
		----insert records into Dropshipments table for Store Receiving................
			insert into HPB_Logistics..Dropshipments (POnumber,ReqNo,FromLocation,StoreNo,LineItemNo,ItemCode,Quantity,Cost,CreateDate,Processed)
			select distinct d.PoNo,d.PoNo,d.locNo,d.storeNo,min(d.rowid),d.itemcode,sum(d.shipQty),d.cost,GETDATE(),0
			from #drpTmp d
			group by d.PoNo,d.PoNo,d.locNo,d.storeNo,d.itemcode,d.cost
			
			if @err=0 begin set @err=@@ERROR end
			
			drop table #drpTmp
			
		set @rVal = @err
		if @rVal=0
			begin
				Commit Transaction Pre_UpdatePO
				return @rVal
			end
		else
			begin
				ROLLBACK  Transaction Pre_UpdatePO
				return @rVal
			end
	end		
	drop table #asnTmp
END
