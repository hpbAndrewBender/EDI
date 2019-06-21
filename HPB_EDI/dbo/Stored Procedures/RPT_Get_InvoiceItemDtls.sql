-- =============================================
-- Author:		<Joey B.>
-- Create date: <4/8/14>
-- Description:	<Get EDI invoice item details for reporting....>
-- =============================================
create PROCEDURE [dbo].[RPT_Get_InvoiceItemDtls] 
	@ParamString varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
------testing.............................
--declare @ParamString varchar(50)
--set @ParamString = '0000151631 | %' 
---------------------------------------------

declare @PO varchar(10)
declare @Item varchar(20)

set @PO = LTRIM(RTRIM(LEFT(@ParamString,charindex('|',@ParamString,0)-1)))
set @Item = LTRIM(RTRIM(RIGHT(@ParamString,len(@ParamString)-charindex('|',@ParamString,0))))
if @Item = '' set @Item = '%'

select right(sh.ShipmentNo,6) [PONumber],right(ss.ItemCode,8)[ItemCode],ss.Quantity,ss.ScanTime,ss.IP,ss.ReceivingUser,ss.ReceivingVersion
from StoreReceiving..SR_Header sh with(nolock) inner join StoreReceiving..SR_Item_Scan ss with(nolock)
	on sh.BatchID=ss.BatchID
where sh.ShipmentNo = @PO and ss.ItemCode like @Item
union
select right(sh.ShipmentNo,6) [PONumber],right(ss.ItemCode,8)[ItemCode],ss.Quantity,ss.ScanTime,ss.IP,ss.ReceivingUser,ss.ReceivingVersion
from StoreReceiving..SR_Header sh with(nolock) inner join StoreReceiving..SR_Item_Scan_History ss with(nolock)
	on sh.BatchID=ss.BatchID
where sh.ShipmentNo = @PO and ss.ItemCode like @Item
order by right(ss.ItemCode,8),ss.ScanTime


END
