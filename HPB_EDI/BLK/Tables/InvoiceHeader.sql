CREATE TABLE [BLK].[InvoiceHeader] (
    [InvoiceId]         INT           IDENTITY (1, 1) NOT NULL,
    [PONumber]          VARCHAR (22)  NULL,
    [InvoiceNo]         VARCHAR (20)  NULL,
    [IssueDate]         DATETIME      NULL,
    [VendorId]          VARCHAR (20)  NULL,
    [ReferenceNo]       VARCHAR (20)  NULL,
    [ShipToLoc]         VARCHAR (5)   NULL,
    [ShipToSAN]         VARCHAR (12)  NULL,
    [BillToLoc]         VARCHAR (5)   NULL,
    [BillToSAN]         VARCHAR (12)  NULL,
    [ShipFromLoc]       VARCHAR (5)   NULL,
    [ShipFromSAN]       VARCHAR (12)  NULL,
    [TotalLines]        SMALLINT      NULL,
    [TotalQuantity]     INT           NULL,
    [TotalPayable]      MONEY         NULL,
    [CurrencyCode]      VARCHAR (5)   NULL,
    [InsertDateTime]    DATETIME      CONSTRAINT [DF_InvoiceHeader_InsertDateTime] DEFAULT (getutcdate()) NULL,
    [Processed]         BIT           CONSTRAINT [DF_InvoiceHeader_Processed] DEFAULT ((0)) NOT NULL,
    [ProcessedDateTime] DATETIME2 (7) NULL,
    [InvoiceACKSent]    BIT           NULL,
    [InvoiceAckNo]      VARCHAR (10)  NULL,
    [GSNo]              VARCHAR (10)  NULL,
    [EDISourceTypeId]   TINYINT       NULL,
    CONSTRAINT [PK_InvoiceHeader] PRIMARY KEY CLUSTERED ([InvoiceId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_InvoiceHeader_PONumber]
    ON [BLK].[InvoiceHeader]([PONumber] ASC);

