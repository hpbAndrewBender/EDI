CREATE TABLE [importX12].[TagCUR] (
    [CURId]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [EntityIdentifierCode]     VARCHAR (2)  NULL,
    [CurrencyCode]             VARCHAR (3)  NULL,
    CONSTRAINT [PK_importEDI_CUR] PRIMARY KEY CLUSTERED ([CURId] ASC),
    CONSTRAINT [FK_importEDI_CUR~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

