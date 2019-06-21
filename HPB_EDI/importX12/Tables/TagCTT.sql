CREATE TABLE [importX12].[TagCTT] (
    [CTTId]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [NumberOfLineItems]        VARCHAR (6)  NULL,
    [HashTotal]                VARCHAR (10) NULL,
    CONSTRAINT [PK_importEDI_CTT] PRIMARY KEY CLUSTERED ([CTTId] ASC),
    CONSTRAINT [FK_importEDI_CTT~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

