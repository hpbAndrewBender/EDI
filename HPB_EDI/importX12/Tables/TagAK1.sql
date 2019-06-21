CREATE TABLE [importX12].[TagAK1] (
    [AK1Id]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileID]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [FunctionalIdentifierCode] VARCHAR (2)  NULL,
    [GroupControlNumber]       VARCHAR (25) NULL,
    CONSTRAINT [PK_importEDI_AK1] PRIMARY KEY CLUSTERED ([AK1Id] ASC),
    CONSTRAINT [FK_importEDI_AK1~importEDIFiles] FOREIGN KEY ([EDIFileID]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

