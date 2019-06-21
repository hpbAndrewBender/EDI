CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R44_ItemNumberOrPrice] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [RecordCode]          TINYINT        NOT NULL,
    [SequenceNumber]      SMALLINT       NOT NULL,
    [PONumber]            VARCHAR (22)   NOT NULL,
    [NetPrice]            DECIMAL (7, 2) NOT NULL,
    [ItemNumberType]      TINYINT        NOT NULL,
    [DiscountedListPrice] DECIMAL (7, 2) NOT NULL,
    [TotalLineOrderQty]   SMALLINT       NOT NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R44_ItemNumberOrPrice] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R44_ItemNumberOrPrice.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R44_ItemNumberOrPrice]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R44_ItemNumberOrPrice.RecordSequencePO]
    ON [importCDFL].[PurchaseAcknowledgement_R44_ItemNumberOrPrice]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

