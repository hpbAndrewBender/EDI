CREATE TABLE [importX12].[TagGE] (
    [GEId]                             BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                        INT          NOT NULL,
    [LineNumber]                       INT          NOT NULL,
    [NumberOfIncludedFunctionalGroups] VARCHAR (99) NULL,
    [ControlGroupNumber]               VARCHAR (99) NULL,
    [ControlNumberGroup]               VARCHAR (25) NULL,
    [ControlNumberTransaction]         VARCHAR (25) NULL,
    CONSTRAINT [PK_importEDI_GE] PRIMARY KEY CLUSTERED ([GEId] ASC),
    CONSTRAINT [FK_importEDI_GE~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

