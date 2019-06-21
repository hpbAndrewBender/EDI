CREATE TABLE [importX12].[TagDTM] (
    [DTMId]                    BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                INT          NOT NULL,
    [LineNumber]               INT          NOT NULL,
    [ControlNumberGroup]       VARCHAR (25) NULL,
    [ControlNumberTransaction] VARCHAR (25) NULL,
    [DateTimeQualifier]        VARCHAR (3)  NULL,
    [Date]                     VARCHAR (8)  NULL,
    [Century]                  VARCHAR (2)  NULL,
    CONSTRAINT [PK_importEDI_DTM] PRIMARY KEY CLUSTERED ([DTMId] ASC),
    CONSTRAINT [FK_importEDI_DTM~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

