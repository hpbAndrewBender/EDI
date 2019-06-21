CREATE TABLE [importCDFL].[PurchaseOrder_R25_CustomerBillToName] (
    [Id]                     INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]             TINYINT      NOT NULL,
    [SequenceNumber]         SMALLINT     NOT NULL,
    [PONumber]               VARCHAR (22) NOT NULL,
    [PurchasingConsumerName] VARCHAR (35) NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R25_CustomerBillToName] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R25_CustomerBillToName.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R25_CustomerBillToName]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R25_CustomerBillToName.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R25_CustomerBillToName]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

