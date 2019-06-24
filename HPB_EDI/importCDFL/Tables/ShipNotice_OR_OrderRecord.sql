CREATE TABLE [importCDFL].[ShipNotice_OR_OrderRecord] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [BatchId]               INT            NULL,
    [OrderRecordIdentifier] VARCHAR (2)    NOT NULL,
    [ClientOrderID]         VARCHAR (22)   NOT NULL,
    [OrderStatusCode]       VARCHAR (2)    NOT NULL,
    [OrderSubtotal]         DECIMAL (7, 2) NOT NULL,
    [OrderDiscountAmount]   DECIMAL (7, 2) NOT NULL,
    [SalesTax]              DECIMAL (7, 2) NOT NULL,
    [ShippingandHandling]   DECIMAL (7, 2) NOT NULL,
    [OrderTotal]            DECIMAL (7, 2) NOT NULL,
    [FreightCharge]         DECIMAL (7, 2) NOT NULL,
    [TotalItemDetailCount]  SMALLINT       NOT NULL,
    [ShipmentDate]          DATETIME       NOT NULL,
    [ConsumerPONumber]      VARCHAR (22)   NOT NULL,
    CONSTRAINT [PK_ShipNotice_OR_OrderRecord] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_ShipNotice_OR_OrderRecord.OrderRecordID]
    ON [importCDFL].[ShipNotice_OR_OrderRecord]([OrderRecordIdentifier] ASC);

