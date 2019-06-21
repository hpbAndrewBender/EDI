CREATE TABLE [ImportBBV3].[Invoice_R95_InvoiceFileTrailer] (
    [Id]                   INT         IDENTITY (1, 1) NOT NULL,
    [BatchId]              INT         NULL,
    [InvoiceFileTrailer]   VARCHAR (2) NULL,
    [RecordSequenceNumber] SMALLINT    NULL,
    [TotalItems]           SMALLINT    NULL,
    [TotalInvoices]        SMALLINT    NULL,
    [TotalUnits]           SMALLINT    NULL,
    CONSTRAINT [PK_Invoice_R95_InvoiceFileTrailer] PRIMARY KEY CLUSTERED ([Id] ASC)
);



