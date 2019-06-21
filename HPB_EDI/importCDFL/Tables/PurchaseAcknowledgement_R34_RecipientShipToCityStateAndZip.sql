CREATE TABLE [importCDFL].[PurchaseAcknowledgement_R34_RecipientShipToCityStateAndZip] (
    [Id]                       INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]               TINYINT      NOT NULL,
    [SequenceNumber]           SMALLINT     NOT NULL,
    [PONumber]                 VARCHAR (22) NOT NULL,
    [RecipientCity]            VARCHAR (25) NOT NULL,
    [RecipientStateOrProvince] VARCHAR (3)  NOT NULL,
    [ZipOrPostalCode]          VARCHAR (11) NOT NULL,
    [Country]                  VARCHAR (3)  NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R34_RecipientShipToCityStateAndZip] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R34_RecipientShipToCityStateAndZip.RecordSequence]
    ON [importCDFL].[PurchaseAcknowledgement_R34_RecipientShipToCityStateAndZip]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseAcknowledgement_R34_RecipientShipToCityStateAndZip.RecordSequencePO]
    ON [importCDFL].[PurchaseAcknowledgement_R34_RecipientShipToCityStateAndZip]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

