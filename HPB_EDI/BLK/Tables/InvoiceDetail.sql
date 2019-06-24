CREATE TABLE [BLK].[InvoiceDetail] (
    [InvoiceItemId]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [InvoiceId]       INT            NOT NULL,
    [LineNo]          VARCHAR (10)   NULL,
    [ItemIdCode]      VARCHAR (5)    NULL,
    [ItemIdentifier]  VARCHAR (20)   NULL,
    [ItemDesc]        VARCHAR (250)  NULL,
    [InvoiceQty]      INT            NULL,
    [UnitPrice]       MONEY          NULL,
    [DiscountPrice]   MONEY          NULL,
    [DiscountCode]    VARCHAR (10)   NULL,
    [DiscountPct]     DECIMAL (4, 2) NULL,
    [RetailPrice]     MONEY          NULL,
    [ReferenceNumber] VARCHAR (50)   NULL,
    CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED ([InvoiceItemId] ASC),
    CONSTRAINT [FK_InvoiceDetail~InvoiceHeader] FOREIGN KEY ([InvoiceId]) REFERENCES [BLK].[InvoiceHeader] ([InvoiceId])
);


GO
CREATE NONCLUSTERED INDEX [IX_InvoiceDetail_ItemIdentifier]
    ON [BLK].[InvoiceDetail]([ItemIdentifier] ASC);

