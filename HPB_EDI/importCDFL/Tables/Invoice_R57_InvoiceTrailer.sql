CREATE TABLE [importCDFL].[Invoice_R57_InvoiceTrailer] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [InvoiceTrailer] VARCHAR (2)    NOT NULL,
    [RecordSequence] SMALLINT       NOT NULL,
    [InvoiceNumber]  VARCHAR (8)    NOT NULL,
    [TotalNetPrice]  DECIMAL (9, 2) NOT NULL,
    [TotalShipping]  DECIMAL (7, 2) NOT NULL,
    [TotalHandling]  DECIMAL (7, 2) NOT NULL,
    [TotalGiftWrap]  DECIMAL (6, 2) NOT NULL,
    [TotalInvoice]   DECIMAL (9, 2) NOT NULL,
    CONSTRAINT [PK_Invoice_R57_InvoiceTrailer] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Invoice_R57_InvoiceTrailer.RecordSequence]
    ON [importCDFL].[Invoice_R57_InvoiceTrailer]([RecordSequence] ASC);

