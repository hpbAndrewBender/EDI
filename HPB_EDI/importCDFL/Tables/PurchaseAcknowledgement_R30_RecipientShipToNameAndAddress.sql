CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R30_RecipientShipToNameAndAddress] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]     TINYINT      NOT NULL,
    [SequenceNumber] SMALLINT     NOT NULL,
    [PONumber]       VARCHAR (22) NOT NULL,
    [RecipientName]  VARCHAR (35) NOT NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R30_RecipientShipToNameAndAddress] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R30_RecipientShipToNameAndAddress.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R30_RecipientShipToNameAndAddress]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R30_RecipientShipToNameAndAddress.RecordSequencePO]
    ON [importCDFL].[PurchaseAcknowledgement_R30_RecipientShipToNameAndAddress]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

