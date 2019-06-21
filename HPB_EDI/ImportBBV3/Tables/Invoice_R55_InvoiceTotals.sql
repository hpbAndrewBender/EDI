CREATE TABLE [ImportBBV3].[Invoice_R55_InvoiceTotals] (
    [Id]                   INT         IDENTITY (1, 1) NOT NULL,
    [BatchId]              INT         NULL,
    [InvoiceTotal]         VARCHAR (2) NULL,
    [RecordSequenceNumber] SMALLINT    NULL,
    [InvoiceNumber]        INT         NULL,
    [InvoiceRecordCount]   SMALLINT    NULL,
    [NumberofItems]        SMALLINT    NULL,
    [TotalNumberofUnits]   SMALLINT    NULL,
    CONSTRAINT [PK_Invoice_R55_InvoiceTotals] PRIMARY KEY CLUSTERED ([Id] ASC)
);



