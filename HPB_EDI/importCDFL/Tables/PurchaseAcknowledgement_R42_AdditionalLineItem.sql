CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R42_AdditionalLineItem] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]     TINYINT      NOT NULL,
    [SequenceNumber] SMALLINT     NOT NULL,
    [PONumber]       VARCHAR (22) NOT NULL,
    [Title]          VARCHAR (30) NOT NULL,
    [Author]         VARCHAR (20) NOT NULL,
    [BindingCode]    CHAR (1)     NOT NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R42_AdditionalLineItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R42_AdditionalLineItem.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R42_AdditionalLineItem]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R42_AdditionalLineItem.RecordSequencePO]
    ON [importCDFL].[PurchaseAcknowledgement_R42_AdditionalLineItem]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

