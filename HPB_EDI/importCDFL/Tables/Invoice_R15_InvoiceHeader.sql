CREATE TABLE [importCDFL].[Invoice_R15_InvoiceHeader] (
    [Id]                     INT         IDENTITY (1, 1) NOT NULL,
    [InvoiceHeader]          VARCHAR (2) NOT NULL,
    [InvoiceNumber]          VARCHAR (8) NOT NULL,
    [CompanyAccountIDNumber] VARCHAR (7) NOT NULL,
    [WarehouseSAN]           VARCHAR (7) NOT NULL,
    [InvoiceDate]            DATE        NOT NULL,
    CONSTRAINT [PK_Invoice_R15_InvoiceHeader] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Invoice_R15_InvoiceHeader.InvHeaderInvNumber]
    ON [importCDFL].[Invoice_R15_InvoiceHeader]([InvoiceHeader] ASC, [InvoiceNumber] ASC);

