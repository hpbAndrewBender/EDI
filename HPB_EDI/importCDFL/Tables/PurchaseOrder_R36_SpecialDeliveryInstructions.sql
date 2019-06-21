CREATE TABLE [importCDFL].[PurchaseOrder_R36_SpecialDeliveryInstructions] (
    [Id]                          INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]                  TINYINT      NOT NULL,
    [SequenceNumber]              SMALLINT     NOT NULL,
    [PONumber]                    VARCHAR (22) NOT NULL,
    [SpecialDeliveryInstructions] VARCHAR (51) NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R36_SpecialDeliveryInstructions] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R36_SpecialDeliveryInstructions.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R36_SpecialDeliveryInstructions]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R36_SpecialDeliveryInstructions.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R36_SpecialDeliveryInstructions]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

