CREATE TABLE [importCDFL].[PurchaseOrder_R20_FixedSpecialHandlingInstructions] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]              INT          NULL,
    [RecordCode]           TINYINT      NOT NULL,
    [SequenceNumber]       INT          NOT NULL,
    [PONumber]             VARCHAR (22) NOT NULL,
    [SpecialHandlingCodes] VARCHAR (30) NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R20_FixedSpecialHandlingInstructions] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R20_FixedSpecialHandlingInstructions.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R20_FixedSpecialHandlingInstructions]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R20_FixedSpecialHandlingInstructions.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R20_FixedSpecialHandlingInstructions]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

