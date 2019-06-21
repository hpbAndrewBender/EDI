CREATE TABLE [EDI].[AcknowledgeDetail] (
    [AckItemId]           BIGINT        IDENTITY (1, 1) NOT NULL,
    [AckId]               INT           NOT NULL,
    [LineNo]              VARCHAR (10)  NULL,
    [LineStatusCode]      VARCHAR (10)  NULL,
    [ItemStatusCode]      VARCHAR (10)  NULL,
    [UnitOfMeasure]       VARCHAR (10)  NULL,
    [QuantityOrdered]     INT           NULL,
    [QuantityShipped]     INT           NULL,
    [QuantityCancelled]   INT           NULL,
    [QuantityBackordered] INT           NULL,
    [UnitPrice]           MONEY         NULL,
    [PriceCode]           VARCHAR (10)  NULL,
    [CurrencyCode]        VARCHAR (5)   NULL,
    [ItemIdCode]          VARCHAR (5)   NULL,
    [ItemIdentifier]      VARCHAR (20)  NULL,
    [ItemDesc]            VARCHAR (250) NULL,
    [EDIFileID]           INT           NULL,
    [EDILineNumber]       INT           NULL,
    [ReferenceNumber]     VARCHAR (20)  NULL,
    [VendorStatus]        VARCHAR (500) NULL,
    CONSTRAINT [PK_AcknowledgeDetail] PRIMARY KEY CLUSTERED ([AckItemId] ASC),
    CONSTRAINT [FK_AcknowledgeDetail~AcknowledgeHeader] FOREIGN KEY ([AckId]) REFERENCES [EDI].[AcknowledgeHeader] ([AckId])
);








GO
CREATE NONCLUSTERED INDEX [IX_AcknowledgeDetail_ItemIdentifier]
    ON [EDI].[AcknowledgeDetail]([ItemIdentifier] ASC);

