CREATE TABLE [importX12].[TagAK4] (
    [AK4Id]                      BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileID]                  INT          NOT NULL,
    [LineNumber]                 INT          NOT NULL,
    [ControlNumberGroup]         VARCHAR (25) NULL,
    [ControlNumberTransaction]   VARCHAR (25) NULL,
    [PositionInSegment]          VARCHAR (3)  NULL,
    [DataElementReferenceNumber] VARCHAR (4)  NULL,
    [DataElementSyntaxErrorCode] VARCHAR (3)  NULL,
    [CopyOfBadDataElement]       VARCHAR (99) NULL,
    CONSTRAINT [PK_importEDI_AK4] PRIMARY KEY CLUSTERED ([AK4Id] ASC),
    CONSTRAINT [FK_importEDI_AK4~importEDIFiles] FOREIGN KEY ([EDIFileID]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

