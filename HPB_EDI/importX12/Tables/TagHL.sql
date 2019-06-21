CREATE TABLE [importX12].[TagHL] (
    [HLId]                       BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                  INT          NOT NULL,
    [LineNumber]                 INT          NOT NULL,
    [ControlNumberGroup]         VARCHAR (25) NULL,
    [ControlNumberTransaction]   VARCHAR (25) NULL,
    [HierarchicalIDNumber]       VARCHAR (12) NULL,
    [HierarchicalParentIDNumber] VARCHAR (12) NULL,
    [HierarchicalLevelCode]      VARCHAR (2)  NULL,
    [HierarchicalChildCode]      VARCHAR (1)  NULL,
    CONSTRAINT [PK_importEDI_HL] PRIMARY KEY CLUSTERED ([HLId] ASC),
    CONSTRAINT [FK_importEDI_HL~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

