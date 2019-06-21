CREATE TABLE [importCDFL].[PurchaseOrder_R37_MArketingMessage] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]       TINYINT      NOT NULL,
    [SequenceNumber]   SMALLINT     NOT NULL,
    [PONumber]         VARCHAR (22) NOT NULL,
    [MarketingMessage] VARCHAR (51) NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R37_MArketingMessage] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R37_MArketingMessage.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R37_MArketingMessage]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R37_MArketingMessage.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R37_MArketingMessage]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

