CREATE TABLE [importX12].[TagSE] (
    [SEId]                        BIGINT       IDENTITY (1, 1) NOT NULL,
    [EDIFileId]                   INT          NOT NULL,
    [LineNumber]                  INT          NOT NULL,
    [ControlNumberGroup]          VARCHAR (25) NULL,
    [ControlNumberTransaction]    VARCHAR (25) NULL,
    [NumberOfIncludedSegments]    VARCHAR (10) NULL,
    [TransactionSetControlNumber] VARCHAR (9)  NULL,
    CONSTRAINT [PK_importEDI_SE] PRIMARY KEY CLUSTERED ([SEId] ASC),
    CONSTRAINT [FK_importEDI_SE~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId])
);

