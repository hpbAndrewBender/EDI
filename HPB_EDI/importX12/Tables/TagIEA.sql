CREATE TABLE [importX12].[TagIEA] (
    [IEAId]                            BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                        INT          NOT NULL,
    [LineNumber]                       INT          NOT NULL,
    [NumberOfIncludedFunctionalGroups] VARCHAR (99) NULL,
    [InterchangeControlNumber]         VARCHAR (99) NULL,
    CONSTRAINT [PK_importEDI_IEA] PRIMARY KEY CLUSTERED ([IEAId] ASC),
    CONSTRAINT [FK_importEDI_IEA~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

