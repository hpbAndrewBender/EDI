CREATE TABLE [ImportBBV3].[Invoice_R57_InvoiceTrailer] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [BatchId]              INT            NULL,
    [InvoiceTrailer]       VARCHAR (2)    NULL,
    [RecordSequenceNumber] SMALLINT       NULL,
    [InvoiceNumber]        INT            NULL,
    [TotalNetPrice]        NUMERIC (9, 2) NULL,
    [TotalTaxes]           NUMERIC (7, 2) NULL,
    [TotalShipping]        NUMERIC (6, 2) NULL,
    [TotalVAT]             NUMERIC (7, 2) NULL,
    [TotalDuty]            NUMERIC (7, 2) NULL,
    [TotalInvoiceAmount]   NUMERIC (9, 2) NULL,
    CONSTRAINT [PK_Invoice_R57_InvoiceTrailer] PRIMARY KEY CLUSTERED ([Id] ASC)
);



