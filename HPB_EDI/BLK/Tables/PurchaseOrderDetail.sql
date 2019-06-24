CREATE TABLE [BLK].[PurchaseOrderDetail] (
    [OrderItemId]    BIGINT       IDENTITY (1, 1) NOT NULL,
    [OrderId]        INT          NOT NULL,
    [LineNo]         VARCHAR (10) NULL,
    [Quantity]       SMALLINT     NULL,
    [UnitOfMeasure]  CHAR (3)     NULL,
    [UnitPrice]      MONEY        NULL,
    [PriceCode]      VARCHAR (10) NULL,
    [ItemIdCode]     VARCHAR (5)  NULL,
    [ItemIdentifier] VARCHAR (20) NULL,
    [ItemFillTerms]  VARCHAR (30) NULL,
    [XActionCode]    VARCHAR (10) NULL,
    [FillAmount]     VARCHAR (10) NULL,
    CONSTRAINT [PK_PurchaseOrderDetail] PRIMARY KEY CLUSTERED ([OrderItemId] ASC),
    CONSTRAINT [FK_PurchaseOrderDetail~PurchaseOrderHeader] FOREIGN KEY ([OrderId]) REFERENCES [BLK].[PurchaseOrderHeader] ([OrderId])
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrderDetail_ItemIdentifier]
    ON [BLK].[PurchaseOrderDetail]([ItemIdentifier] ASC);

