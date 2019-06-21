CREATE TABLE [importX12].[TagN2] (
    [N2Id]                     BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [Name_01]                  VARCHAR (35) NULL,
    [Name_02]                  VARCHAR (35) NULL,
    CONSTRAINT [PK_importEDI_N2] PRIMARY KEY CLUSTERED ([N2Id] ASC),
    CONSTRAINT [FK_importEDI_N2~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

