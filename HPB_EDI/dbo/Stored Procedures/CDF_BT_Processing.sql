-- =============================================
-- Author:		<Joey B.>
-- Create date: <11/4/2014>
-- Description:	<Process CDF orders to BT through EDI....>
-- =============================================
CREATE PROCEDURE [dbo].[CDF_BT_Processing]
AS
BEGIN
	SET NOCOUNT ON;

-------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------------
----Order select...................................................................................................................................
if exists(select LogID from HPB_EDI..EDI_Process_Log where Processed=0 and TransType='ORD' 
			and OrderNumber not in (select OrderNumber from HPB_EDI..EDI_Process_Log where TransType='ORD' and processed=1)
			and LogID in (select LogID from HPB_EDI..EDI_Transactions where ProcessorApp='BT' and SourceApp='HPB.com'))
	begin
		declare @rVal int
		set @rVal = 0
		Begin Transaction CDF_trans

		select distinct pl.LogID,pl.TransType,t.ProcessorApp,t.SourceApp,t.LineNumber,t.VendorID,t.OrderNumber,t.ResponseNumber,t.ASNNumber,t.InvoiceNumber,t.IssueDateTime,t.PurposeCode,
			t.CurrencyCode,t.CountryCode,t.FillTermsCode,t.TotalPayable,t.OrderStatus,t.BuyerIDType,t.BuyerID,t.SourceIDType,t.SourceID,t.SellerIDType,t.SellerID,
			t.ShipToName,t.ShipToAddress1,t.ShipToAddress2,t.ShipToCity,t.ShipToState,t.ShipToZip,t.ShipToCountryCode,t.BillToName,t.BillToAddress1,t.BillToAddress2,t.BillToCity,t.BillToState,t.BillToZip,t.BillToCountryCode,
			t.TransportIDType,t.TransportID,t.Message,t.ProductIDType,t.ProductID,t.ItemDescription,t.UnitPrice,t.OrderQuantity,t.ConfirmQuantity,t.BackOrderQuantity,t.CancelQuantity,t.ShippedQuantity,t.InvoiceQuantity,
			t.OrderLineStatus,t.LineStatusDescription,t.ShipDateStatus,t.ShipNoticeDate,t.CarrierNamdCodeType,t.CarrierNameCode,t.CustomerOrderReference,t.PackageNumber,t.PackageMarkTypeCode,t.PackageMarkValue,
			t.ChargeTypeCode,t.ChargeTypeDescription,t.ChargeAmount,t.InsertDateTime
		into #ords
		from HPB_EDI..EDI_Process_Log pl inner join HPB_EDI..EDI_Transactions t on pl.LogID=t.LogID
		where pl.Processed=0 and pl.TransType='ORD' and t.ProcessorApp='BT' and t.SourceApp='HPB.com'
		order by t.OrderNumber,t.InsertDateTime

		set @rVal = @@ERROR

		insert into BakerTaylor..order_Header
		select distinct oh.OrderNumber,oh.IssueDateTime,oh.PurposeCode,oh.CurrencyCode,oh.FillTermsCode,oh.BuyerIDType,oh.BuyerID,oh.SourceIDType,oh.SourceID,oh.SellerIDType,oh.SellerID,
			oh.ShipToName,oh.ShipToAddress1,oh.ShipToAddress2,oh.ShipToCity,oh.ShipToState,oh.ShipToZip,oh.ShipToCountryCode,oh.BillToName,oh.BillToAddress1,oh.BillToAddress2,oh.BillToCity,oh.BillToState,oh.BillToZip,oh.BillToCountryCode,
			oh.TransportIDType,oh.TransportID,oh.Message,getdate(),0,null
		from #ords oh

		if @rVal = 0 begin set @rVal = @@ERROR end

		insert into BakerTaylor..order_ItemDetail
		select distinct ord.OrderID,oh.LineNumber,oh.ProductIDType,oh.ProductID,oh.OrderQuantity,'BuyersOrderLineReference'[LineReferenceTypeCode],oh.LineNumber[LineReferenceNum]
		from #ords oh inner join BakerTaylor..order_Header ord on oh.OrderNumber=ord.OrderNumber
		order by ord.OrderID,oh.LineNumber

		if @rVal = 0 begin set @rVal = @@ERROR end

		--update process log.....
		update HPB_EDI..EDI_Process_Log
		set Processed=1,ProcessedDateTime=getdate()
		where Processed=0 and LogID in (select distinct LogID from #ords)

		if @rVal = 0 begin set @rVal = @@ERROR end

		drop table #ords

		----Commit or Rollback trans...........
		if @rVal=0
			begin
				Commit Transaction CDF_trans
			end
		else
			begin
				Rollback  Transaction CDF_trans
			end
	end
-------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------------
----Response inserts...................................................................................................................................
if exists(select distinct rh.DocReferenceNumber	from BakerTaylor..order_response_Header rh inner join BakerTaylor..order_response_ItemDetail rd on rh.ResponseID=rd.ResponseID
			where rh.DocReferenceNumber not in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='RES')
				and rh.DocReferenceNumber in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='ORD'))
	begin
		declare @rValRep int
		set @rValRep = 0
		Begin Transaction CDF_trans_Rep
		
		declare @res table (OrderNumber varchar(20))

		insert into @res
		select distinct rh.DocReferenceNumber
		from BakerTaylor..order_response_Header rh inner join BakerTaylor..order_response_ItemDetail rd on rh.ResponseID=rd.ResponseID
		where rh.DocReferenceNumber not in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='RES')
			and rh.DocReferenceNumber in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='ORD')

		insert into HPB_EDI..EDI_Process_Log
		select distinct 'RES'[TransType],rh.DocReferenceNumber[OrderNumber],0[Processed],null [ProcessedDateTime]
		from BakerTaylor..order_response_Header rh inner join BakerTaylor..order_response_ItemDetail rd on rh.ResponseID=rd.ResponseID
			inner join @res r on r.OrderNumber=rh.DocReferenceNumber
		where rh.DocReferenceNumber not in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='RES')
		
		set @rValRep = @@ERROR
		
		insert into HPB_EDI..EDI_Transactions
		select distinct pl.TransType[TransType],pl.LogID[LogID],t.ProcessorApp[ProcessorApp],t.SourceApp[SourceApp],rd.LineNumber[LineNumber],t.VendorID[VendorID],rh.DocReferenceNumber[OrderNumber],rh.OrderResponseNumber[ResponseNumber],
			t.ASNNumber[ASNNumber],t.InvoiceNumber[InvoiceNumber],rh.IssueDateTime[IssueDateTime],rh.PurposeCode[PurposeCode],rh.CurrencyCode[CurrencyCode],rh.CountryCode[CountryCode],
			t.FillTermsCode[FillTermsCode],''[TotalPayable],'Acknowledged'[OrderStatus],rh.BuyerPartyIDType[BuyerIDType],rh.BuyerPartyIdentifier[BuyerID],t.SourceIDType[SourceIDType],
			t.SourceID[SourceID],rh.SellerPartyIDType[SellerIDType],rh.SellerPartyIdentifier[SellerID],rh.ShipToName[ShipToName],rh.ShipToAddress1[ShipToAddress1],isnull(rh.ShipToAddress2,'')[ShipToAddress2],
			rh.ShipToCity[ShipToCity],rh.ShipToState[ShipToState],rh.ShipToPostalCode[ShipToZip],rh.ShipToCountryCode[ShipToCountryCode],t.BillToName[BillToName],t.BillToAddress1[BillToAddress1],
			t.BillToAddress2[BillToAddress2],t.BillToCity[BillToCity],t.BillToState[BillToState],t.BillToZip[BillToZip],t.BillToCountryCode[BillToCountryCode],t.TransportIDType[TransportIDType],
			t.TransportID[TransportID],''[Message],t.ProductIDType[ProductIDType],rd.ProductIdentifier [ProductID],rd.ItemDescription[ItemDescription],t.UnitPrice[UnitPrice],
			rd.OrderQuantity[OrderQuantity],rd.OrderQuantity [ConfirmQuantity],rd.QuantityBackordered [BackOrderQuantity],rd.QuantityCanceled[CancelQuantity],rd.QuantityShipping[ShippedQuantity],
			''[InvoiceQuantity],rd.OrderLineStatus[OrderLineStatus],rd.LineStatusDescription[LineStatusDescription],''[ShipDateStatus],''[ShipNoticeDate],''[CarrierNameCodeType],
			''[CarrierNameCode],''[CustomerOrderReference],''[PackageNumber],''[PackageMarkTypeCode],''[PackageMarkValue],''[ChargeTypeCode],''[ChargeTypeDescription],''[ChargeAmount],getdate()[InsertDateTime] 
		from BakerTaylor..order_response_Header rh inner join BakerTaylor..order_response_ItemDetail rd on rh.ResponseID=rd.ResponseID
			inner join HPB_EDI..EDI_Process_Log pl on rh.OrderResponseNumber=pl.OrderNumber and pl.TransType='RES' 
			inner join @res r on r.OrderNumber=rh.DocReferenceNumber
			inner join HPB_EDI..EDI_Transactions t on t.OrderNumber=r.OrderNumber and t.TransType='ORD'
		where pl.Processed=0
		
		if @rValRep = 0 begin set @rValRep = @@ERROR end
		
		insert into HPB_EDI..Email_Audit_Log
		select distinct pl.TransType[EmailType],pl.LogID[LogID],0[Processed],null [ProcessedDateTime]
		from HPB_EDI..EDI_Process_Log pl inner join @res r on r.OrderNumber=pl.OrderNumber
		where pl.TransType='RES'
		
		if @rValRep = 0 begin set @rValRep = @@ERROR end
		
		----Commit or Rollback trans...........
		if @rValRep=0
			begin
				Commit Transaction CDF_trans_Rep
			end
		else
			begin
				Rollback  Transaction CDF_trans_Rep
			end
	end
-------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------------
----ASN inserts...................................................................................................................................
if exists(select distinct sd.BuyersOrderReference from BakerTaylor..order_shipnotice_Header sh inner join BakerTaylor..order_shipnotice_ItemDetail sd on sh.ShipID=sd.ShipID
				inner join BakerTaylor..order_shipnotice_PackageDetail sp on sh.ShipID=sp.ShipID
				inner join BakerTaylor..order_shipnotice_Summary ss on sh.ShipID=ss.ShipID
			where sd.BuyersOrderReference not in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='ASN')
				and sd.BuyersOrderReference in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='RES'))
	begin
		declare @rValASN int
		set @rValASN = 0
		Begin Transaction CDF_trans_ASN
		
		declare @asn table (OrderNumber varchar(20))

		insert into @asn
		select distinct sd.BuyersOrderReference
		from BakerTaylor..order_shipnotice_Header sh inner join BakerTaylor..order_shipnotice_ItemDetail sd on sh.ShipID=sd.ShipID
			inner join BakerTaylor..order_shipnotice_PackageDetail sp on sh.ShipID=sp.ShipID
			inner join BakerTaylor..order_shipnotice_Summary ss on sh.ShipID=ss.ShipID
		where sd.BuyersOrderReference not in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='ASN')
			and sd.BuyersOrderReference in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='RES')
		
		insert into HPB_EDI..EDI_Process_Log
		select distinct 'ASN'[TransType],sd.BuyersOrderReference[OrderNumber],0[Processed],null [ProcessedDateTime]
		from  BakerTaylor..order_shipnotice_Header sh inner join BakerTaylor..order_shipnotice_ItemDetail sd on sh.ShipID=sd.ShipID
			inner join BakerTaylor..order_shipnotice_PackageDetail sp on sh.ShipID=sp.ShipID
			inner join BakerTaylor..order_shipnotice_Summary ss on sh.ShipID=ss.ShipID
			inner join @asn a on a.OrderNumber=sd.BuyersOrderReference
		where sd.BuyersOrderReference not in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='ASN')
		
		set @rValASN = @@ERROR
		
		select distinct sp.ShipID,sp.PackageMarkTypeCode,sp.PackageMarkValue
		into #pkgDtl
		from BakerTaylor..order_shipnotice_Header sh inner join BakerTaylor..order_shipnotice_ItemDetail sd on sh.ShipID=sd.ShipID
			inner join BakerTaylor..order_shipnotice_PackageDetail sp on sh.ShipID=sp.ShipID
			inner join @asn a on a.OrderNumber=sd.BuyersOrderReference
		where sp.PackageMarkTypeCode='CarrierTrackingNumber'
		
		insert into #pkgDtl
		select distinct sp.ShipID,sp.PackageMarkTypeCode,sp.PackageMarkValue
		from BakerTaylor..order_shipnotice_Header sh inner join BakerTaylor..order_shipnotice_ItemDetail sd on sh.ShipID=sd.ShipID
			inner join BakerTaylor..order_shipnotice_PackageDetail sp on sh.ShipID=sp.ShipID
			inner join @asn a on a.OrderNumber=sd.BuyersOrderReference
		where sp.PackageMarkTypeCode='SSCC-18' and sp.ShipID not in (select ShipID from #pkgDtl)
		
		set @rValASN = @@ERROR
		
		insert into HPB_EDI..EDI_Transactions
		select distinct pl.TransType[TransType],pl.LogID[LogID],t.ProcessorApp[ProcessorApp],t.SourceApp[SourceApp],sd.LineNumber[LineNumber],t.VendorID[VendorID],sd.BuyersOrderReference[OrderNumber],''[ResponseNumber],
			sh.ASNNumber[ASNNumber],t.InvoiceNumber[InvoiceNumber],sh.IssueDateTime[IssueDateTime],sh.PurposeCode[PurposeCode],sh.CurrencyCode[CurrencyCode],sh.CountryCode[CountryCode],
			t.FillTermsCode[FillTermsCode],''[TotalPayable],'Shipped'[OrderStatus],sh.BuyerPartyIDType[BuyerIDType],sh.BuyerPartyIdentifier[BuyerID],t.SourceIDType[SourceIDType],
			t.SourceID[SourceID],sh.SellerPartyIDType[SellerIDType],sh.SellerPartyIdentifier[SellerID],sh.ShipToName[ShipToName],sh.ShipToAddress1[ShipToAddress1],isnull(sh.ShipToAddress2,'')[ShipToAddress2],
			sh.ShipToCity[ShipToCity],sh.ShipToState[ShipToState],sh.ShipToPostalCode[ShipToZip],t.ShipToCountryCode[ShipToCountryCode],t.BillToName[BillToName],t.BillToAddress1[BillToAddress1],
			t.BillToAddress2[BillToAddress2],t.BillToCity[BillToCity],t.BillToState[BillToState],t.BillToZip[BillToZip],t.BillToCountryCode[BillToCountryCode],t.TransportIDType[TransportIDType],
			t.TransportID[TransportID],''[Message],t.ProductIDType[ProductIDType],sd.ProductIdentifier [ProductID],sd.ItemDescription[ItemDescription],t.UnitPrice[UnitPrice],
			t.OrderQuantity[OrderQuantity],t.ConfirmQuantity[ConfirmQuantity],t.BackOrderQuantity[BackOrderQuantity],t.CancelQuantity [CancelQuantity],sd.ShippedQuantity[ShippedQuantity],
			''[InvoiceQuantity],''[OrderLineStatus],''[LineStatusDescription],sh.ShipDateQualifierCode[ShipDateStatus],sh.ShipNoticeDate[ShipNoticeDate],sh.CarrierNameCodeType[CarrierNameCodeType],
			sh.CarrierNameCode[CarrierNameCode],sd.CustomerOrderReference[CustomerOrderReference],sd.PackageNumber[PackageNumber],sp.PackageMarkTypeCode[PackageMarkTypeCode],sp.PackageMarkValue[PackageMarkValue],''[ChargeTypeCode],''[ChargeTypeDescription],''[ChargeAmount],getdate()[InsertDateTime] 
		from BakerTaylor..order_shipnotice_Header sh inner join BakerTaylor..order_shipnotice_ItemDetail sd on sh.ShipID=sd.ShipID
			inner join #pkgDtl sp on sh.ShipID=sp.ShipID  
			inner join BakerTaylor..order_shipnotice_Summary ss on sh.ShipID=ss.ShipID
			inner join HPB_EDI..EDI_Process_Log pl on sd.BuyersOrderReference=pl.OrderNumber and pl.TransType='ASN'
			inner join @asn a on a.OrderNumber=sd.BuyersOrderReference
			inner join HPB_EDI..EDI_Transactions t on t.OrderNumber=sd.BuyersOrderReference and t.TransType='RES'
		where pl.Processed=0
		
		if @rValASN = 0 begin set @rValASN = @@ERROR end
		drop table #pkgDtl
		
		insert into HPB_EDI..Email_Audit_Log
		select distinct pl.TransType[EmailType],pl.LogID[LogID],0[Processed],null [ProcessedDateTime]
		from HPB_EDI..EDI_Process_Log pl inner join @asn a on a.OrderNumber=pl.OrderNumber
		where pl.TransType='ASN'
		
		if @rValASN = 0 begin set @rValASN = @@ERROR end
		
		----Commit or Rollback trans...........
		if @rValASN=0
			begin
				Commit Transaction CDF_trans_ASN
			end
		else
			begin
				Rollback  Transaction CDF_trans_ASN
			end
	end
-------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------------
----Invoice inserts...................................................................................................................................
if exists(select distinct ih.BuyerOrderReference from BakerTaylor..order_invoice_Header ih inner join BakerTaylor..order_invoice_ItemDetail id on ih.InvoiceID=id.InvoiceID
				left outer join BakerTaylor..order_invoice_AdditionalCharges ic on ih.InvoiceID=ic.InvoiceID
			where ih.BuyerOrderReference not in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='INV')
				and ih.BuyerOrderReference in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='ASN'))
	begin
		declare @rValInv int
		set @rValInv = 0
		Begin Transaction CDF_trans_Inv
		
		declare @inv table (OrderNumber varchar(20))

		insert into @inv
		select distinct ih.BuyerOrderReference
		from BakerTaylor..order_invoice_Header ih inner join BakerTaylor..order_invoice_ItemDetail id on ih.InvoiceID=id.InvoiceID
			left outer join BakerTaylor..order_invoice_AdditionalCharges ic on ih.InvoiceID=ic.InvoiceID
		where ih.BuyerOrderReference not in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='INV')
			and ih.BuyerOrderReference in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='ASN')

		insert into HPB_EDI..EDI_Process_Log
		select distinct 'INV'[TransType],ih.BuyerOrderReference[OrderNumber],0[Processed],null [ProcessedDateTime]
		from  BakerTaylor..order_invoice_Header ih inner join BakerTaylor..order_invoice_ItemDetail id on ih.InvoiceID=id.InvoiceID
			left outer join BakerTaylor..order_invoice_AdditionalCharges ic on ih.InvoiceID=ic.InvoiceID
			inner join @inv i on i.OrderNumber=ih.BuyerOrderReference
		where ih.BuyerOrderReference not in (select distinct OrderNumber from HPB_EDI..EDI_Process_Log where TransType='INV')

		set @rValInv = @@ERROR
		
		insert into HPB_EDI..EDI_Transactions
		select distinct pl.TransType[TransType],pl.LogID[LogID],t.ProcessorApp[ProcessorApp],t.SourceApp[SourceApp],id.LineNumber[LineNumber],t.VendorID[VendorID],ih.BuyerOrderReference[OrderNumber],''[ResponseNumber],
			ih.ASNRefNumber[ASNNumber],ih.InvoiceNumber[InvoiceNumber],ih.IssueDateTime[IssueDateTime],ih.PurposeCode[PurposeCode],ih.CurrencyCode[CurrencyCode],ih.CountryCode[CountryCode],
			t.FillTermsCode[FillTermsCode],ih.TotalPayable[TotalPayable],'Invoiced'[OrderStatus],ih.BuyerPartyIDType[BuyerIDType],ih.BuyerPartyIdentifier[BuyerID],t.SourceIDType[SourceIDType],
			t.SourceID[SourceID],t.SellerIDType[SellerIDType],t.SellerID[SellerID],ih.ShipToName[ShipToName],ih.ShipToAddress1[ShipToAddress1],isnull(ih.ShipToAddress2,'')[ShipToAddress2],
			ih.ShipToCity[ShipToCity],ih.ShipToState[ShipToState],ih.ShipToPostalCode[ShipToZip],t.ShipToCountryCode[ShipToCountryCode],t.BillToName[BillToName],t.BillToAddress1[BillToAddress1],
			t.BillToAddress2[BillToAddress2],t.BillToCity[BillToCity],t.BillToState[BillToState],t.BillToZip[BillToZip],t.BillToCountryCode[BillToCountryCode],t.TransportIDType[TransportIDType],
			t.TransportID[TransportID],''[Message],id.ProductIDType[ProductIDType],id.ProductIdentifier [ProductID],id.ItemDescription[ItemDescription],id.UnitPriceExcludingTax[UnitPrice],
			t.OrderQuantity[OrderQuantity],t.ConfirmQuantity[ConfirmQuantity],t.BackOrderQuantity[BackOrderQuantity],t.CancelQuantity [CancelQuantity],t.ShippedQuantity[ShippedQuantity],
			id.InvoicedQuantity[InvoiceQuantity],''[OrderLineStatus],''[LineStatusDescription],t.ShipDateStatus[ShipDateStatus],t.ShipNoticeDate[ShipNoticeDate],t.CarrierNamdCodeType[CarrierNameCodeType],
			t.CarrierNameCode[CarrierNameCode],ih.BuyerOrderReference[CustomerOrderReference],''[PackageNumber],''[PackageMarkTypeCode],''[PackageMarkValue],'Other'[ChargeTypeCode],BakerTaylor.dbo.BT_INV_Charge_Consol(ih.InvoiceID)[ChargeTypeDescription],sum(cast(ic.ChargeAmountExcludingTax as money))[ChargeAmount],getdate()[InsertDateTime] 
		from BakerTaylor..order_invoice_Header ih inner join BakerTaylor..order_invoice_ItemDetail id on ih.InvoiceID=id.InvoiceID
			left outer join BakerTaylor..order_invoice_AdditionalCharges ic on ih.InvoiceID=ic.InvoiceID
			inner join HPB_EDI..EDI_Process_Log pl on ih.BuyerOrderReference=pl.OrderNumber and pl.TransType='INV'
			inner join HPB_EDI..EDI_Transactions t on t.OrderNumber=ih.BuyerOrderReference and t.TransType='ASN'
			inner join @inv i on i.OrderNumber=ih.BuyerOrderReference
		where pl.Processed=0
		group by pl.TransType,pl.LogID,t.ProcessorApp,t.SourceApp,id.LineNumber,t.VendorID,ih.BuyerOrderReference,ih.ASNRefNumber,ih.InvoiceNumber,ih.IssueDateTime,ih.PurposeCode,ih.CurrencyCode,ih.CountryCode,
			t.FillTermsCode,ih.TotalPayable,ih.BuyerPartyIDType,ih.BuyerPartyIdentifier,t.SourceIDType,t.SourceID,t.SellerIDType,t.SellerID,ih.ShipToName,ih.ShipToAddress1,isnull(ih.ShipToAddress2,''),
			ih.ShipToCity,ih.ShipToState,ih.ShipToPostalCode,t.ShipToCountryCode,t.BillToName,t.BillToAddress1,t.BillToAddress2,t.BillToCity,t.BillToState,t.BillToZip,t.BillToCountryCode,t.TransportIDType,
			t.TransportID,id.ProductIDType,id.ProductIdentifier,id.ItemDescription,id.UnitPriceExcludingTax,t.OrderQuantity,t.ConfirmQuantity,t.BackOrderQuantity,t.CancelQuantity,t.ShippedQuantity,
			id.InvoicedQuantity,t.ShipDateStatus,t.ShipNoticeDate,t.CarrierNamdCodeType,t.CarrierNameCode,ih.BuyerOrderReference,BakerTaylor.dbo.BT_INV_Charge_Consol(ih.InvoiceID)
		
		if @rValInv = 0 begin set @rValInv = @@ERROR end
		
		insert into HPB_EDI..WEB_Invoice_Audit_Log
		select distinct t.InvoiceNumber,t.OrderNumber,0,null
		from HPB_EDI..EDI_Transactions t inner join @inv i on t.OrderNumber=i.OrderNumber
		where t.TransType='INV'
		
		if @rValInv = 0 begin set @rValInv = @@ERROR end

		insert into HPB_EDI..Email_Audit_Log
		select distinct pl.TransType[EmailType],pl.LogID[LogID],0[Processed],null [ProcessedDateTime]
		from HPB_EDI..EDI_Process_Log pl inner join @inv i on i.OrderNumber=pl.OrderNumber
		where pl.TransType='INV'
		
		if @rValInv = 0 begin set @rValInv = @@ERROR end
		
		----Commit or Rollback trans...........
		if @rValInv=0
			begin
				Commit Transaction CDF_trans_Inv
			end
		else
			begin
				Rollback  Transaction CDF_trans_Inv
			end
	end
-------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------------



END
