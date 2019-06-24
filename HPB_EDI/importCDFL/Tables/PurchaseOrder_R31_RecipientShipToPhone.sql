CREATE TABLE [importCDFL].[PurchaseOrder_R31_RecipientShipToPhone] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]         INT          NULL,
    [RecordCode]      TINYINT      NOT NULL,
    [SequenceNumber]  SMALLINT     NOT NULL,
    [PONumber]        VARCHAR (22) NOT NULL,
    [RecipientPhone#] VARCHAR (25) NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R31_RecipientShipToPhone] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R31_RecipientShipToPhone.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R31_RecipientShipToPhone]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R31_RecipientShipToPhone.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R31_RecipientShipToPhone]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

