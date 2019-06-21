CREATE TABLE [importX12].[TagAK3] (
    [AK3Id]                           BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileID]                       INT          NOT NULL,
    [LineNumber]                      INT          NOT NULL,
    [ControlNumberGroup]              VARCHAR (25) NULL,
    [ControlNumberTransaction]        VARCHAR (25) NULL,
    [SegmentIDCode]                   VARCHAR (3)  NULL,
    [SegmentPositionInTransactionSet] VARCHAR (6)  NULL,
    [LoopIdentifierCode]              VARCHAR (6)  NULL,
    [SegmentSyntaxErrorCode]          VARCHAR (3)  NULL,
    CONSTRAINT [PK_importEDI_AK3] PRIMARY KEY CLUSTERED ([AK3Id] ASC),
    CONSTRAINT [FK_importEDI_AK3~importEDIFiles] FOREIGN KEY ([EDIFileID]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

