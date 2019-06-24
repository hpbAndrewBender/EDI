CREATE TABLE [importCDFL].[PurchaseOrder_R32_ShippingRecordRecipientAddressLine] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]              INT          NULL,
    [RecordCode]           TINYINT      NOT NULL,
    [SequenceNumber]       SMALLINT     NOT NULL,
    [PONumber]             VARCHAR (22) NOT NULL,
    [RecipientAddressLine] VARCHAR (35) NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R32_ShippingRecordRecipientAddressLine] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R32_ShippingRecordRecipientAddressLine.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R32_ShippingRecordRecipientAddressLine]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R32_ShippingRecordRecipientAddressLine.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R32_ShippingRecordRecipientAddressLine]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

