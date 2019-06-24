CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R59_PurchaseOrderControlTotals] (
    [Id]                     INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                INT          NULL,
    [RecordCode]             TINYINT      NOT NULL,
    [SequenceNumber]         SMALLINT     NOT NULL,
    [PONumber]               VARCHAR (22) NOT NULL,
    [RecordCount]            SMALLINT     NOT NULL,
    [TotalLineItemsinFile]   SMALLINT     NOT NULL,
    [TotalUnitsAcknowledged] SMALLINT     NOT NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R59_PurchaseOrderControlTotals] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R59_PurchaseOrderControlTotals.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R59_PurchaseOrderControlTotals]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R59_PurchaseOrderControlTotals.RecordSequencePO]
    ON [importCDFL].[PurchaseAcknowledgement_R59_PurchaseOrderControlTotals]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

