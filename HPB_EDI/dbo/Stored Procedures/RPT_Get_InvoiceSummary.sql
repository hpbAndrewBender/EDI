-- =============================================
-- Author:		<Joey B.>
-- Create date: <4/8/14>
-- Description:	<Get EDI invoice summary by date range....>
-- =============================================
CREATE PROCEDURE [dbo].[RPT_Get_InvoiceSummary] 
	@startdate datetime, @enddate datetime, @VendorID varchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	------testing.....
		--declare @startdate datetime
		--declare @enddate datetime
		--declare @VendorID varchar(30)
		--set @startdate = '9/20/2016'
		--set @enddate = '9/30/2016'
		--set @VendorID = 'IDRANDOMDI'
	------------------
	
	
	select distinct h.VendorID, h.PONumber [PO], h.InvoiceNo
	into #POs
	from HPB_EDI..[810_Inv_Hdr] h with(nolock) inner join HPB_EDI..[810_Inv_Dtl] d with(nolock) on h.InvoiceID=d.InvoiceID
	where h.IssueDate between @startdate and @enddate and h.VendorID=@VendorID
	group by h.VendorID,h.InvoiceNo,h.PONumber
	
	----get received items for PO....
	select srh.ShipmentNo,srh.LocationNo,srd.ItemCode,srd.Qty,pm.ISBN
	into #sr
	from StoreReceiving..SR_Header srh inner join StoreReceiving..SR_Detail srd with(nolock) on srh.BatchID=srd.BatchID
		inner join HPB_Prime..ProductMaster pm with(nolock) on srd.ItemCode=pm.ItemCode
	where srh.ShipmentNo in (select distinct right('0000000000'+PO,10) from #POs)
	order by srh.ShipmentNo,srh.LocationNo,srd.ItemCode

	----get the EDI invoice.....
	select h.VendorID,h.InvoiceNo,convert(varchar(12), cast(h.IssueDate as datetime), 107)[IssueDateTime],h.ReferenceNo,h.ShipToSAN,h.TotalPayable,isnull(sr.ShipmentNo,'Not Rcvd')[SR_ShipmentNo],
		h.PONumber,h.ShipToLoc,isnull(sr.ItemCode,'NA')[ItemCode],ISNULL(pm2.Title,pm.Title)[ItemDescription],d.ItemIdentifier,d.InvoiceQty,isnull(sr.Qty,0)[ReceivedQuantity],
		cast(isnull(d.UnitPrice,rd.Cost)as money)[UnitPrice],d.DiscountCode,d.DiscountPct,cast(isnull(d.UnitPrice,rd.Cost) as money)*cast(isnull(d.InvoiceQty,0) as int) [ExtendedPrice],l.Name,l.MailToAddress1,l.MailToAddress2,l.MailToAddress3
	into #edi
	from HPB_EDI..[810_Inv_Hdr] h with(nolock) inner join HPB_EDI..[810_Inv_Dtl] d with(nolock) on h.InvoiceID=d.InvoiceID
		inner join HPB_EDI..HPB_SAN_Codes st with(nolock) on st.SANCode=h.ShipToSAN
		inner join HPB_Prime..Locations l with(nolock) on l.LocationNo=st.LocationNo
		left outer join #sr sr on sr.ShipmentNo=right('0000000000'+h.PONumber,10) and sr.ISBN=d.ItemIdentifier and sr.LocationNo=st.LocationNo
		left outer join HPB_Prime..ProductMaster pm with(nolock) on pm.ItemCode=sr.ItemCode
		left outer join HPB_Logistics..VX_Requisition_Dtl rd with(nolock) on rd.PONumber=h.PONumber and rd.VendorItem=d.ItemIdentifier
		left outer join HPB_Prime..ProductMaster pm2 with(nolock) on pm2.ItemCode=rd.ItemCode
	where h.InvoiceNo in (select distinct InvoiceNo from #POs)
	order by d.[LineNo]
	
	----added this section to include any items received that were not part of the actual order. 
	insert into #edi
	select h.VendorID,h.InvoiceNo,convert(varchar(12), cast(h.IssueDate as datetime), 107)[IssueDateTime],h.ReferenceNo,h.ShipToSAN,h.TotalPayable,isnull(sr.ShipmentNo,'Not Rcvd')[SR_ShipmentNo],
		h.PONumber,h.ShipToLoc,isnull(sr.ItemCode,'NA')[ItemCode],ISNULL(pm2.Title,pm.Title)[ItemDescription],isnull(sr.isbn,d.ItemIdentifier)[ItemIdentifier],0,isnull(sr.Qty,0)[ReceivedQuantity],
		cast(isnull(pm.Cost,rd.Cost)as money)[UnitPrice],d.DiscountCode,d.DiscountPct,cast(isnull(pm.Cost,rd.Cost) as money)*cast(isnull(sr.Qty,0) as int) [ExtendedPrice],l.Name,l.MailToAddress1,l.MailToAddress2,l.MailToAddress3
	from HPB_EDI..[810_Inv_Hdr] h with(nolock) inner join HPB_EDI..[810_Inv_Dtl] d with(nolock) on h.InvoiceID=d.InvoiceID
		inner join HPB_EDI..HPB_SAN_Codes st with(nolock) on st.SANCode=h.ShipToSAN
		inner join HPB_Prime..Locations l with(nolock) on l.LocationNo=st.LocationNo
		left outer join HPB_Logistics..VX_Requisition_Dtl rd with(nolock) on rd.PONumber=h.PONumber and rd.VendorItem=d.ItemIdentifier
		left outer join HPB_Logistics..VX_Vendor_Kits vk with(nolock) on vk.ParentItem = rd.ItemCode
		left outer join #sr sr on sr.ShipmentNo=right('0000000000'+h.PONumber,10) and sr.LocationNo=st.LocationNo and sr.ItemCode=isnull(vk.KitItem,rd.ItemCode)
		left outer join HPB_Prime..ProductMaster pm with(nolock) on pm.ItemCode=sr.ItemCode
		left outer join HPB_Prime..ProductMaster pm2 with(nolock) on pm2.ItemCode=rd.ItemCode
	where h.InvoiceNo in (select distinct InvoiceNo from #POs) and sr.ItemCode not in (select distinct ItemCode from #edi where SR_ShipmentNo=sr.ShipmentNo)
	order by d.[LineNo]

	----get first run of groupings......
	select b.VendorID,b.PONumber [PONumber], b.ShipToLoc [Store],convert(varchar(12),cast(b.IssueDateTime as datetime),107)[InvoiceDate],b.InvoiceNo,
		cast(b.TotalPayable as decimal(12,4))[TotalPayable],cast(0 as money)[ChargeAmountExcludingTax],
		sum(cast(isnull(b.InvoiceQty,0) as int))[InvoicedQuantity],sum(cast(isnull(b.ReceivedQuantity,0) as int))[ReceivedQuantity],
		sum(cast(isnull(b.InvoiceQty,0) as int))*cast(isnull(b.UnitPrice,0) as money)[InvoiceAmt],
		sum(cast(isnull(b.ReceivedQuantity,0) as int))*cast(isnull(b.UnitPrice,0) as money)[ReceivedAmt],
		sum(cast(isnull(b.InvoiceQty,0) as int))-sum(cast(isnull(b.ReceivedQuantity,0) as int)) [CountVariance],
		cast(isnull(b.UnitPrice,0) as money)*(sum(cast(isnull(b.InvoiceQty,0) as int))-sum(cast(isnull(b.ReceivedQuantity,0) as int)))[CostVariance]
	into #final
	from #edi b 
	group by b.VendorID,b.ShipToLoc,convert(varchar(12),cast(b.IssueDateTime as datetime),107),b.InvoiceNo,
		cast(b.TotalPayable as decimal(12,4)),cast(isnull(b.UnitPrice,0) as money),b.PONumber 
	order by b.VendorID,b.ShipToLoc,ponumber
	
	----do final groupings for report results......
	select f.VendorID,f.PONumber[PONumber],f.Store,f.InvoiceDate,f.InvoiceNo,f.TotalPayable,
		isnull((select SUM(chargeamt) from  HPB_EDI..[810_Inv_Charges] where f.PONumber=PONumber and f.InvoiceNo=InvoiceNo),0)[AdditionalCharges],
		sum(f.InvoiceAmt)[InvoiceAmt],sum(cast(isnull(f.InvoicedQuantity,0) as int))[InvoicedQuantity],
		sum(f.ReceivedAmt)[ReceivedAmt],sum(cast(isnull(f.ReceivedQuantity,0) as int))[ReceivedQuantity],
		sum(f.CountVariance)[CountVariance],cast(sum(f.CostVariance)as money)[CostVariance],
		max(f.PONumber)+' | '+f.InvoiceNo [ParamString]
	from #final f
	group by f.VendorID,f.Store,f.InvoiceDate,f.InvoiceNo,f.TotalPayable,f.PONumber
	order by f.VendorID,cast(f.InvoiceDate as DATE),f.Store,f.PONumber,f.InvoiceNo

	drop table #final
	drop table #sr
	drop table #edi
	drop table #POs



END
