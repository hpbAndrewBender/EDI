CREATE TABLE [importX12].[TagBAK] (
    [BAKId]                     BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                 INT          NOT NULL,
    [LineNumber]                INT          NOT NULL,
    [ControlNumberGroup]        VARCHAR (25) NULL,
    [ControlNumberTransaction]  VARCHAR (25) NULL,
    [TransactionSetPurposeCode] VARCHAR (2)  NULL,
    [AcknowledgmentType]        VARCHAR (2)  NULL,
    [PurchaseOrderNumber]       VARCHAR (22) NULL,
    [Date_01]                   VARCHAR (8)  NULL,
    [ReleaseNumber]             VARCHAR (30) NULL,
    [RequestReferenceNumber]    VARCHAR (45) NULL,
    [ContractNumber]            VARCHAR (30) NULL,
    [Date_02]                   VARCHAR (8)  NULL,
    CONSTRAINT [PK_importEDI_BAK] PRIMARY KEY CLUSTERED ([BAKId] ASC),
    CONSTRAINT [FK_importEDI_BAK~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

