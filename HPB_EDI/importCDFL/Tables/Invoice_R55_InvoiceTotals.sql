CREATE TABLE [importCDFL].[Invoice_R55_InvoiceTotals] (
    [Id]                           INT          IDENTITY (1, 1) NOT NULL,
    [InvoiceControlShippingRecord] VARCHAR (2)  NOT NULL,
    [RecordSequence]               TINYINT      NOT NULL,
    [InvoiceNumber]                VARCHAR (8)  NOT NULL,
    [InvoiceRecordCount]           SMALLINT     NOT NULL,
    [NumberofTitles]               SMALLINT     NOT NULL,
    [TotalNumberofUnits]           SMALLINT     NOT NULL,
    [BillofLadingNumber]           VARCHAR (10) NOT NULL,
    [TotalInvoiceWeight]           SMALLINT     NOT NULL,
    CONSTRAINT [PK_Invoice_R55_InvoiceTotals] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Invoice_R55_InvoiceTotals.RecordSequence]
    ON [importCDFL].[Invoice_R55_InvoiceTotals]([RecordSequence] ASC);

