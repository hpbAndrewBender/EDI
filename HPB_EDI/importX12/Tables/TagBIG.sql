CREATE TABLE [importX12].[TagBIG] (
    [BIGId]                     BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                 INT          NOT NULL,
    [LineNumber]                INT          NOT NULL,
    [ControlNumberGroup]        VARCHAR (25) NULL,
    [ControlNumberTransaction]  VARCHAR (25) NULL,
    [Date_01]                   VARCHAR (8)  NULL,
    [InvoiceNumber]             VARCHAR (22) NULL,
    [Date_02]                   VARCHAR (8)  NULL,
    [PurchaseOrderNumber]       VARCHAR (22) NULL,
    [ReleaseNumber]             VARCHAR (30) NULL,
    [ChangeOrderSequenceNumber] VARCHAR (8)  NULL,
    [TransactionTypeCode]       VARCHAR (2)  NULL,
    [TransactionSetPurposeCode] VARCHAR (2)  NULL,
    CONSTRAINT [PK_importEDI_BIG] PRIMARY KEY CLUSTERED ([BIGId] ASC),
    CONSTRAINT [FK_importEDI_BIG~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

