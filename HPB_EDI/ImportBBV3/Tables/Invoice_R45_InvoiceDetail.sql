CREATE TABLE [ImportBBV3].[Invoice_R45_InvoiceDetail] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [BatchId]              INT            NULL,
    [InvoiceDetail]        VARCHAR (2)    NULL,
    [RecordSequenceNumber] SMALLINT       NULL,
    [InvoiceNumber]        INT            NULL,
    [PONumber]             VARCHAR (22)   NULL,
    [QuantityShipped]      SMALLINT       NULL,
    [IngramItemListPrice]  SMALLINT       NULL,
    [DiscountPercent]      NUMERIC (4, 2) NULL,
    [NetPriceOrCost]       NUMERIC (8, 2) NULL,
    CONSTRAINT [PK_Invoice_R45_InvoiceDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);



