CREATE TABLE [importCDFL].[Invoice_R45_InvoiceDetail] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [BatchId]             INT            NULL,
    [DetailRecord]        VARCHAR (2)    NOT NULL,
    [RecordSequence]      SMALLINT       NOT NULL,
    [InvoiceNumber]       VARCHAR (8)    NOT NULL,
    [ISBN10Shipped]       VARCHAR (10)   NOT NULL,
    [QuantityShipped]     SMALLINT       NOT NULL,
    [IngramItemListPrice] DECIMAL (7, 2) NOT NULL,
    [Discount]            DECIMAL (4, 2) NOT NULL,
    [NetPriceOrCost]      DECIMAL (8, 2) NOT NULL,
    [MeteredDate]         DATE           NOT NULL,
    CONSTRAINT [PK_Invoice_R45_InvoiceDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_Invoice_R45_InvoiceDetail.RecordSequence]
    ON [importCDFL].[Invoice_R45_InvoiceDetail]([RecordSequence] ASC);

