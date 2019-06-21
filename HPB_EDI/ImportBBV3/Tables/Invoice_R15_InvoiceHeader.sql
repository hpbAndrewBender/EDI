CREATE TABLE [ImportBBV3].[Invoice_R15_InvoiceHeader] (
    [Id]                        INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                   INT          NULL,
    [InvoiceHeader]             VARCHAR (2)  NULL,
    [RecordSequenceNumber]      SMALLINT     NULL,
    [InvoiceNumber]             INT          NULL,
    [PurchaseOrderNumber]       VARCHAR (22) NULL,
    [IngramShipToAccountNumber] VARCHAR (7)  NULL,
    [StoreNumber]               VARCHAR (5)  NULL,
    [DCSAN]                     VARCHAR (7)  NULL,
    [InvoiceDate]               DATE         NULL,
    CONSTRAINT [PK_Invoice_R15_InvoiceHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);



