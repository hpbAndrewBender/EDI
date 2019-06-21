-- =============================================
-- Author:		<Joey B.>
-- Create date: <4/8/14>
-- Description:	<Get EDI invoices details for reporting....>
-- =============================================
CREATE PROCEDURE [dbo].[RPT_Get_InvoiceDtls] 
	@ParamString varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	--------testing.....
	--declare @ParamString varchar(50)
	--set @ParamString = '215993 | 0952543566'
	--------------------

	declare @PONo varchar(8)
	declare @InvoiceNo varchar(12)

	set @PONo = LTRIM(RTRIM(LEFT(@ParamString,charindex('|',@ParamString,0)-1)))
	set @InvoiceNo = LTRIM(RTRIM(RIGHT(@ParamString,len(@ParamString)-charindex('|',@ParamString,0))))
	
	
	
	--select h.InvoiceNo,convert(varchar(12), cast(h.IssueDate as datetime), 107)[IssueDateTime],h.ReferenceNo,h.ShipToSAN,h.TotalPayable,isnull('000000000000','Not Rcvd')[SR_ShipmentNo],
	--	h.PONumber,h.ShipToLoc,isnull('00000000000000000000','NA')[ItemCode],ISNULL('','')[ItemDescription],d.ItemIdentifier,d.InvoiceQty,isnull(2,0)[ReceivedQuantity],
	--	cast(isnull(d.UnitPrice,rd.Cost)as money)[UnitPrice],d.DiscountCode,d.DiscountPct,cast(isnull(d.UnitPrice,rd.Cost) as money)*cast(isnull(d.InvoiceQty,0) as int) [ExtendedPrice],l.Name,l.MailToAddress1,l.MailToAddress2,l.MailToAddress3
	--	,'000000000000'+' | %' [ParamPO],'000000000000'+' | '+'00000000000000000000' [ParamItem],isnull((select SUM(chargeamt) from  HPB_EDI..[810_Inv_Charges] where h.PONumber=PONumber and h.InvoiceNo=InvoiceNo),0)[AddCharges]
	--from HPB_EDI..[810_Inv_Hdr] h with(nolock) inner join HPB_EDI..[810_Inv_Dtl] d with(nolock) on h.InvoiceID=d.InvoiceID
	--	inner join HPB_EDI..HPB_SAN_Codes st with(nolock) on st.SANCode=h.ShipToSAN
	--	inner join HPB_Prime..Locations l with(nolock) on l.LocationNo=st.LocationNo
	--	--left outer join HPB_Prime..ProductMaster pm with(nolock) on pm.ItemCode=sr.ItemCode
	--	left outer join HPB_Logistics..VX_Requisition_Dtl rd with(nolock) on rd.PONumber=h.PONumber and rd.VendorItem=d.ItemIdentifier
	--	--left outer join HPB_Prime..ProductMaster pm2 with(nolock) on pm2.ItemCode=rd.ItemCode
	--where h.InvoiceNo = @InvoiceNo
	--order by d.[LineNo]





	----get received items for PO....
	select srh.ShipmentNo,srh.LocationNo,srd.ItemCode,srd.Qty,pm.ISBN 
	into #sr
	from StoreReceiving..SR_Header srh inner join StoreReceiving..SR_Detail srd with(nolock) on srh.BatchID=srd.BatchID
		inner join HPB_Prime..ProductMaster pm with(nolock) on srd.ItemCode=pm.ItemCode
	where srh.ShipmentNo=RIGHT('0000000000'+@PONo,10)
	order by srh.ShipmentNo,srh.LocationNo,srd.ItemCode

	----get the EDI invoice.....
	select h.InvoiceNo,convert(varchar(12), cast(h.IssueDate as datetime), 107)[IssueDateTime],h.ReferenceNo,h.ShipToSAN,h.TotalPayable,isnull(sr.ShipmentNo,'Not Rcvd')[SR_ShipmentNo],
		h.PONumber,h.ShipToLoc,isnull(sr.ItemCode,'NA')[ItemCode],ISNULL(pm2.Title,pm.Title)[ItemDescription],d.ItemIdentifier,d.InvoiceQty,isnull(sr.Qty,0)[ReceivedQuantity],
		cast(isnull(d.UnitPrice,rd.Cost)as money)[UnitPrice],d.DiscountCode,d.DiscountPct,cast(isnull(d.UnitPrice,rd.Cost) as money)*cast(isnull(d.InvoiceQty,0) as int) [ExtendedPrice],l.Name,l.MailToAddress1,l.MailToAddress2,l.MailToAddress3
	into #edi
	from HPB_EDI..[810_Inv_Hdr] h with(nolock) inner join HPB_EDI..[810_Inv_Dtl] d with(nolock) on h.InvoiceID=d.InvoiceID
		inner join HPB_EDI..HPB_SAN_Codes st with(nolock) on st.SANCode=h.ShipToSAN
		inner join HPB_Prime..Locations l with(nolock) on l.LocationNo=st.LocationNo
		left outer join #sr sr on sr.ShipmentNo=right('0000000000'+h.PONumber,10) and sr.LocationNo=st.LocationNo and sr.ISBN=d.ItemIdentifier 
		left outer join HPB_Prime..ProductMaster pm with(nolock) on pm.ItemCode=sr.ItemCode
		left outer join HPB_Logistics..VX_Requisition_Dtl rd with(nolock) on rd.PONumber=h.PONumber and rd.VendorItem=d.ItemIdentifier
		left outer join HPB_Prime..ProductMaster pm2 with(nolock) on pm2.ItemCode=rd.ItemCode
	where h.InvoiceNo = @InvoiceNo and h.PONumber=@PONo
	order by d.[LineNo]

	----added this section to include any items received that were not part of the actual order.  
	insert into #edi
	select h.InvoiceNo,convert(varchar(12), cast(h.IssueDate as datetime), 107)[IssueDateTime],h.ReferenceNo,h.ShipToSAN,h.TotalPayable,isnull(sr.ShipmentNo,'Not Rcvd')[SR_ShipmentNo],
		h.PONumber,h.ShipToLoc,isnull(sr.ItemCode,'NA')[ItemCode],ISNULL(pm2.Title,pm.Title)[ItemDescription],isnull(sr.isbn,d.ItemIdentifier),d.InvoiceQty,isnull(sr.Qty,0)[ReceivedQuantity],
		cast(isnull(d.UnitPrice,rd.Cost)as money)[UnitPrice],d.DiscountCode,d.DiscountPct,cast(isnull(d.UnitPrice,rd.Cost) as money)*cast(isnull(d.InvoiceQty,0) as int) [ExtendedPrice],l.Name,l.MailToAddress1,l.MailToAddress2,l.MailToAddress3
	from HPB_EDI..[810_Inv_Hdr] h with(nolock) inner join HPB_EDI..[810_Inv_Dtl] d with(nolock) on h.InvoiceID=d.InvoiceID
		inner join HPB_EDI..HPB_SAN_Codes st with(nolock) on st.SANCode=h.ShipToSAN
		inner join HPB_Prime..Locations l with(nolock) on l.LocationNo=st.LocationNo
		left outer join HPB_Logistics..VX_Requisition_Dtl rd with(nolock) on rd.PONumber=h.PONumber and rd.VendorItem=d.ItemIdentifier
		left outer join HPB_Logistics..VX_Vendor_Kits vk with(nolock) on vk.ParentItem = rd.ItemCode
		left outer join #sr sr on sr.ShipmentNo=right('0000000000'+h.PONumber,10) and sr.LocationNo=st.LocationNo and sr.ItemCode=isnull(vk.KitItem,rd.ItemCode)
		left outer join HPB_Prime..ProductMaster pm with(nolock) on pm.ItemCode=sr.ItemCode
		left outer join HPB_Prime..ProductMaster pm2 with(nolock) on pm2.ItemCode=rd.ItemCode
	where h.InvoiceNo = @InvoiceNo and h.PONumber=@PONo and sr.ItemCode not in (select distinct ItemCode from #edi where SR_ShipmentNo=sr.ShipmentNo)
	order by d.[LineNo]
	
	----get any duplicate items from backorders....
	create table #ediItems(ID int identity(1,1),POnumber varchar(10),Item varchar(20),Qty bigint)
	insert into #ediItems
	select b.PONumber,b.itemcode,b.InvoiceQty
	from #edi b
	where b.sr_shipmentno<>'Not Rcvd' and b.PONumber<>@PONo and b.itemcode=(select itemcode from #edi where PONumber=@PONo and itemcode=b.itemcode)
	group by b.PONumber,b.itemcode,b.InvoiceQty
	order by b.itemcode,b.PONumber desc

	----loop thru back-ordered items and sync received quantities....
	declare @loop int
	set @loop = (select MAX(ID) from #ediItems)
	declare @lastQty bigint
	set @lastQty = 0
	declare @lastItem varchar(20)

	while isnull(@loop,0) > 0
		begin
			declare @curPO varchar(10)
			declare @itemcode varchar(20)
			declare @invQty bigint
			select @curPO=POnumber,@itemcode=Item,@invQty=Qty from #ediItems where ID=@loop
			declare @rctQty bigint
			select @rctQty=Qty from #sr where itemcode=@itemcode
			if @lastItem<>@itemcode begin set @lastQty=0 end

			if @rctQty-@lastQty>@invQty
				begin
					update #edi 
					set receivedquantity = @invQty
					where PONumber=@curPO and itemcode=@itemcode
					
					update #edi 
					set receivedquantity = receivedquantity-@invQty
					where PONumber=@PONo and itemcode=@itemcode 
				end
			if @rctQty-@lastQty<=@invQty
				begin
					update #edi 
					set receivedquantity = case when @rctQty-@lastQty < 0 then 0 else @rctQty-@lastQty end
					where PONumber=@curPO and itemcode=@itemcode
					
					update #edi 
					set receivedquantity = 0
					where PONumber=@PONo and itemcode=@itemcode 
				end
			
			set @lastQty=@invQty
			set @loop = @loop - 1
		end

	select distinct b.InvoiceNo,convert(varchar(12),cast(b.IssueDateTime as datetime),107)[IssueDateTime],b.ReferenceNo,b.ShipToSAN,
		cast(b.TotalPayable as decimal(12,4))[TotalPayable],b.sr_ShipmentNo [SR_ShipmentNo],
		b.PONumber,b.ShipToLoc,isnull(right(b.ItemCode,8),'NA') [ItemCode],
		b.ItemDescription,b.ItemIdentifier,b.InvoiceQty,isnull(b.ReceivedQuantity,0)[ReceivedQuantity],
		cast(b.UnitPrice as decimal(12,2))[UnitPrice],cast(b.DiscountPct as decimal(12,2))[DiscountPercentage],
		cast(b.ExtendedPrice as decimal(12,2))[ExtendedPrice],
		b.Name,b.MailToAddress1,b.MailToAddress2,b.MailToAddress3,
		b.sr_ShipmentNo+' | %' [ParamPO],b.sr_ShipmentNo+' | '+b.ItemCode [ParamItem],
		isnull((select SUM(chargeamt) from  HPB_EDI..[810_Inv_Charges] where b.PONumber=PONumber and b.InvoiceNo=InvoiceNo),0)[AddCharges]
	from #edi b 
	order by b.itemdescription,b.PONumber

	drop table #sr
	drop table #edi
	drop table #ediItems

END
