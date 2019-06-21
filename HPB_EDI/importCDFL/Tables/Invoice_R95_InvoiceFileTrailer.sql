CREATE TABLE [importCDFL].[Invoice_R95_InvoiceFileTrailer] (
    [Id]                 INT         IDENTITY (1, 1) NOT NULL,
    [InvoiceFileTrailer] VARCHAR (2) NOT NULL,
    [RecordSequence]     SMALLINT    NOT NULL,
    [TotalTitles]        SMALLINT    NOT NULL,
    [TotalInvoices]      SMALLINT    NOT NULL,
    [TotalUnits]         SMALLINT    NOT NULL,
    CONSTRAINT [PK_Invoice_R95_InvoiceFileTrailer] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Invoice_R95_InvoiceFileTrailer.RecordSequence]
    ON [importCDFL].[Invoice_R95_InvoiceFileTrailer]([RecordSequence] ASC);

