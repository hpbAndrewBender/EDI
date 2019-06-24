CREATE TABLE [importCDFL].[PurchaseOrder_R30_RecipientShipToName] (
    [Id]                    INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]               INT          NULL,
    [RecordCode]            TINYINT      NOT NULL,
    [SequenceNumber]        SMALLINT     NOT NULL,
    [PONumber]              VARCHAR (22) NOT NULL,
    [RecipientConsumerName] VARCHAR (35) NOT NULL,
    [AddressValidation]     CHAR (1)     NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R30_RecipientShipToName] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R30_RecipientShipToName.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R30_RecipientShipToName]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R30_RecipientShipToName.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R30_RecipientShipToName]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

