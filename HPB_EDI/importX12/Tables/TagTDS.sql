CREATE TABLE [importX12].[TagTDS] (
    [TDSId]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [Amount_01]                VARCHAR (15) NULL,
    [Amount_02]                VARCHAR (15) NULL,
    [Amount_03]                VARCHAR (15) NULL,
    CONSTRAINT [PK_importEDI_TDS] PRIMARY KEY CLUSTERED ([TDSId] ASC),
    CONSTRAINT [FK_importEDI_TDS~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

