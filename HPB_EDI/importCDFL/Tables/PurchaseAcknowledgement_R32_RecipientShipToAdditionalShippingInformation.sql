CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R32_RecipientShipToAdditionalShippingInformation] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]              INT          NULL,
    [RecordCode]           TINYINT      NOT NULL,
    [SequenceNumber]       SMALLINT     NOT NULL,
    [PONumber]             VARCHAR (22) NOT NULL,
    [RecipientAddressLine] VARCHAR (35) NOT NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R32_RecipientShipToAdditionalShippingInformation] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R32_RecipientShipToAdditionalShippingInformation.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R32_RecipientShipToAdditionalShippingInformation]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R32_RecipientShipToAdditionalShippingInformation.RecordSequencePO]
    ON [importCDFL].[PurchaseAcknowledgement_R32_RecipientShipToAdditionalShippingInformation]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

