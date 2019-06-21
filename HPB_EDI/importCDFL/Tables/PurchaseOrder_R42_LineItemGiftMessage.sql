CREATE TABLE [importCDFL].[PurchaseOrder_R42_LineItemGiftMessage] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]           TINYINT      NOT NULL,
    [SequenceNumber]       SMALLINT     NOT NULL,
    [PONumber]             VARCHAR (22) NOT NULL,
    [LineLevelGiftMessage] VARCHAR (51) NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R42_LineItemGiftMessage] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R42_LineItemGiftMessage.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R42_LineItemGiftMessage]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R42_LineItemGiftMessage.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R42_LineItemGiftMessage]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

