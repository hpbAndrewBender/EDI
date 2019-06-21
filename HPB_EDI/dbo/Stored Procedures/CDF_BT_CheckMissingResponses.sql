-- =============================================
-- Author:		<Joey B.>
-- Create date: <8/25/2017>
-- Description:	<Send Missing BT CDF response Email.....>
-- =============================================
create PROCEDURE [dbo].[CDF_BT_CheckMissingResponses]
AS
BEGIN
	SET NOCOUNT ON;
	
	----testing......
	--declare @time int
	--set @time = -99999
	--------.........

	if exists (select oh.OrderNumber,oh.IssueDateTime,oh.ShipToName 
				from BakerTaylor..order_Header oh with(nolock)
				where oh.OrderNumber not like '%test%' and oh.OrderNumber in (select BuyersOrderReference from BakerTaylor..order_shipnotice_ItemDetail with(nolock) where BuyersOrderReference=oh.OrderNumber)
					and oh.OrderNumber not in (select OrderResponseNumber from BakerTaylor..order_response_Header with(nolock) where OrderResponseNumber=oh.OrderNumber))
		begin
			--select oh.OrderNumber,oh.IssueDateTime,oh.ShipToName 
			--from BakerTaylor..order_Header oh
			--where oh.OrderNumber not like '%test%' and oh.OrderNumber in (select BuyersOrderReference from BakerTaylor..order_shipnotice_ItemDetail where BuyersOrderReference=oh.OrderNumber)
			--	and oh.OrderNumber not in (select OrderResponseNumber from BakerTaylor..order_response_Header where OrderResponseNumber=oh.OrderNumber)
			--order by oh.OrderNumber
			
			
			----send the email................................
			declare @emailAddy varchar(1000)
			set @emailAddy = 'jblalock@hpb.com'
			declare @qry varchar(max)
			set @qry = ' SET NOCOUNT ON; select oh.OrderNumber,oh.IssueDateTime,oh.ShipToName from BakerTaylor..order_Header oh with(nolock)
						where oh.OrderNumber not like ''%test%'' and oh.OrderNumber in (select BuyersOrderReference from BakerTaylor..order_shipnotice_ItemDetail with(nolock) where BuyersOrderReference=oh.OrderNumber)
						and oh.OrderNumber not in (select OrderResponseNumber from BakerTaylor..order_response_Header with(nolock) where OrderResponseNumber=oh.OrderNumber)
					order by oh.OrderNumber'
			EXECUTE [msdb].[dbo].[sp_send_dbmail]
			        @profile_name='EDIMail',
			        @recipients=@emailAddy,
			        @subject     = 'BT CDF missed response',
					@body        = 'These order(s) did not receive a response, but have shipped.',
					@query = @qry 
			
		end  

END

