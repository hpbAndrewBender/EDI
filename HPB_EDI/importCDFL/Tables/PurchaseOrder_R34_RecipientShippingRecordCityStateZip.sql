CREATE TABLE [importCDFL].[PurchaseOrder_R34_RecipientShippingRecordCityStateZip] (
    [Id]                       INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]               TINYINT      NOT NULL,
    [SequenceNumber]           SMALLINT     NOT NULL,
    [PONumber]                 VARCHAR (22) NOT NULL,
    [RecipientCity]            VARCHAR (25) NOT NULL,
    [RecipientStateOrProvince] VARCHAR (3)  NOT NULL,
    [RecipientPostalCode]      VARCHAR (11) NOT NULL,
    [Country]                  VARCHAR (3)  NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R34_RecipientShippingRecordCityStateZip] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R34_RecipientShippingRecordCityStateZip.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R34_RecipientShippingRecordCityStateZip]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R34_RecipientShippingRecordCityStateZip.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R34_RecipientShippingRecordCityStateZip]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

