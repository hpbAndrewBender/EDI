CREATE TABLE [ImportBBV3].[Invoice_R16_InvoiceVendorDetail] (
    [Id]                     INT         IDENTITY (1, 1) NOT NULL,
    [BatchId]                INT         NULL,
    [RecordType]             VARCHAR (2) NULL,
    [RecordSequencenumber]   SMALLINT    NULL,
    [InvoiceNumber]          INT         NULL,
    [DCCode]                 CHAR (1)    NULL,
    [IngramOrderEntryNumber] VARCHAR (5) NULL,
    CONSTRAINT [PK_Invoice_R16_InvoiceVendorDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);



