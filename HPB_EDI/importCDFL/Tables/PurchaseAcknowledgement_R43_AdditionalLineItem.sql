CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R43_AdditionalLineItem] (
    [Id]                             INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                        INT          NULL,
    [RecordCode]                     TINYINT      NOT NULL,
    [SequenceNumber]                 SMALLINT     NOT NULL,
    [PONumber]                       VARCHAR (22) NOT NULL,
    [PublisherName]                  VARCHAR (20) NULL,
    [PublicationOrReleaseDate]       DATE         NULL,
    [OriginalSeqNumber]              VARCHAR (5)  NOT NULL,
    [TotalQtyPredictedtoShipPrimary] VARCHAR (7)  NOT NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R43_AdditionalLineItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R43_AdditionalLineItem.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R43_AdditionalLineItem]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R43_AdditionalLineItem.RecordSequencePO]
    ON [importCDFL].[PurchaseAcknowledgement_R43_AdditionalLineItem]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

