CREATE TABLE [ImportBBV3].[Invoice_R48_DetailTotal] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]              INT          NULL,
    [DetailTotal]          VARCHAR (2)  NULL,
    [RecordSequenceNumber] SMALLINT     NULL,
    [InvoiceNumber]        INT          NULL,
    [Title]                VARCHAR (25) NULL,
    [CustomerPONumber]     VARCHAR (22) NULL,
    CONSTRAINT [PK_Invoice_R48_DetailTotal] PRIMARY KEY CLUSTERED ([Id] ASC)
);



