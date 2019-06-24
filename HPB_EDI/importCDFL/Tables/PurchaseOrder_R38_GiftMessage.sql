CREATE TABLE [importCDFL].[PurchaseOrder_R38_GiftMessage] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]        INT          NULL,
    [RecordCode]     TINYINT      NOT NULL,
    [SequenceNumber] SMALLINT     NOT NULL,
    [PONumber]       VARCHAR (22) NOT NULL,
    [GiftMessage]    VARCHAR (51) NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R38_GiftMessage] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R38_GiftMessage.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R38_GiftMessage]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R38_GiftMessage.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R38_GiftMessage]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

