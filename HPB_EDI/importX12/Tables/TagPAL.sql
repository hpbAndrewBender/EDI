CREATE TABLE [importX12].[TagPAL] (
    [PALId]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [PalletTypeCode]           VARCHAR (2)  NULL,
    CONSTRAINT [PK_importEDI_PAL] PRIMARY KEY CLUSTERED ([PALId] ASC),
    CONSTRAINT [FK_importEDI_PAL~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

