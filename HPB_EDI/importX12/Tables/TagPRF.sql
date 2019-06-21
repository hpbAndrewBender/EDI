CREATE TABLE [importX12].[TagPRF] (
    [PRFId]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [PurchaseOrderNumber]      VARCHAR (22) NULL,
    [ReleaseNumber]            VARCHAR (30) NULL,
    [Date]                     VARCHAR (8)  NULL,
    [AssignedIdentification]   VARCHAR (20) NULL,
    [ContractNumber]           VARCHAR (30) NULL,
    [PurchaseOrderTypeCode]    VARCHAR (2)  NULL,
    CONSTRAINT [PK_importEDI_PRF] PRIMARY KEY CLUSTERED ([PRFId] ASC),
    CONSTRAINT [FK_importEDI_PRF~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

