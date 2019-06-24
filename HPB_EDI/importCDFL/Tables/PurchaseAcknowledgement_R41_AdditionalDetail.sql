CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R41_AdditionalDetail] (
    [Id]                     INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                INT          NULL,
    [RecordCode]             TINYINT      NOT NULL,
    [SequenceNumber]         SMALLINT     NOT NULL,
    [PONumber]               VARCHAR (22) NOT NULL,
    [AvailabilityDate]       DATE         NULL,
    [DCInventoryInformation] VARCHAR (40) NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R41_AdditionalDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R41_AdditionalDetail.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R41_AdditionalDetail]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R41_AdditionalDetail.RecordSequencePO]
    ON [importCDFL].[PurchaseAcknowledgement_R41_AdditionalDetail]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

