CREATE TABLE [importX12].[EDISummary] (
    [EDISummaryID]         INT      IDENTITY (1, 1) NOT NULL,
    [EDIFileId]            INT      NOT NULL,
    [EDITransactionCodeId] SMALLINT NOT NULL,
    [LineCount]            INT      NULL,
    CONSTRAINT [PK_importEDISummary] PRIMARY KEY CLUSTERED ([EDISummaryID] ASC),
    CONSTRAINT [FK_importEDISummary~importEDIFiles] FOREIGN KEY ([EDIFileId]) REFERENCES [importX12].[EDIFiles] ([EDIFileId]),
    CONSTRAINT [FK_importEDISummary~importEDITransactionCodes] FOREIGN KEY ([EDITransactionCodeId]) REFERENCES [importX12].[EDITransactionCodes] ([EDITransactionCodeId])
);

