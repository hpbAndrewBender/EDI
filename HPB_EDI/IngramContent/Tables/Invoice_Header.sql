CREATE TABLE [IngramContent].[Invoice_Header] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [FileID]                    INT            NOT NULL,
    [Head_InvoiceNumber]        VARCHAR (8)    NULL,
    [Head_CompanyAccountID]     VARCHAR (7)    NULL,
    [Head_WarehouseSAN]         VARCHAR (7)    NULL,
    [Head_InvoiceDate]          DATE           NULL,
    [Totals_InvoiceRecordCount] SMALLINT       NULL,
    [Totals_NumberOfTitles]     SMALLINT       NULL,
    [Totals_TotalNumberUnits]   SMALLINT       NULL,
    [Totals_BillOfLading]       VARCHAR (10)   NULL,
    [Totals_TotalInvoiceWeight] NUMERIC (7, 2) NULL,
    [Foot_TotalNetPrice]        NUMERIC (9, 2) NULL,
    [Foot_TotalShipping]        NUMERIC (7, 2) NULL,
    [Foot_TotalHandling]        NUMERIC (7, 2) NULL,
    [Foot_TotalGiftWrap]        NUMERIC (6, 2) NULL,
    [Foot_TotalInvoice]         NUMERIC (9, 2) NULL,
    CONSTRAINT [PK_Invoice_Heder] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Invoice_File~Invoice_Header] FOREIGN KEY ([FileID]) REFERENCES [IngramContent].[Invoice_File] ([Id])
);

