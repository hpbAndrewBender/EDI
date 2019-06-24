CREATE TABLE [importCDFL].[PurchaseOrder_R26_CustomerBillToPhoneNumber] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]              INT          NULL,
    [RecordCode]           TINYINT      NOT NULL,
    [SequenceNumber]       SMALLINT     NOT NULL,
    [PONumber]             VARCHAR (22) NOT NULL,
    [PurchaserPhonenumber] VARCHAR (25) NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R26_CustomerBillToPhoneNumber] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R26_CustomerBillToPhoneNumber.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R26_CustomerBillToPhoneNumber]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R26_CustomerBillToPhoneNumber.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R26_CustomerBillToPhoneNumber]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

