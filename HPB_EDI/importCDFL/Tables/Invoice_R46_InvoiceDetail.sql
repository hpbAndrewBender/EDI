CREATE TABLE [importCDFL].[Invoice_R46_InvoiceDetail] (
    [Id]                 INT          IDENTITY (1, 1) NOT NULL,
    [TitleRecord]        VARCHAR (2)  NOT NULL,
    [RecordSequence]     TINYINT      NOT NULL,
    [InvoiceNumber]      VARCHAR (8)  NOT NULL,
    [ISBN13OrEANShipped] VARCHAR (14) NOT NULL,
    CONSTRAINT [PK_Invoice_R46_InvoiceDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Invoice_R46_InvoiceDetail.RecordSequence]
    ON [importCDFL].[Invoice_R46_InvoiceDetail]([RecordSequence] ASC);

