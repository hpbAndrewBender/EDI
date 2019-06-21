CREATE TABLE [importX12].[TagBEG] (
    [BEGId]                     BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                 INT          NOT NULL,
    [LineNumber]                INT          NOT NULL,
    [ControlNumberGroup]        VARCHAR (25) NULL,
    [ControlNumberTransaction]  VARCHAR (25) NULL,
    [TransactionSetPurposeCode] VARCHAR (2)  NULL,
    [PurchaseOrderTypeCode]     VARCHAR (2)  NULL,
    [PurchaseOrderNumber]       VARCHAR (22) NULL,
    [Date]                      VARCHAR (8)  NULL,
    CONSTRAINT [PK_importEDI_BEG] PRIMARY KEY CLUSTERED ([BEGId] ASC),
    CONSTRAINT [FK_importEDI_BEG~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

