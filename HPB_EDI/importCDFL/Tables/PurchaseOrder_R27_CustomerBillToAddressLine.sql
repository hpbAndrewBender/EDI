CREATE TABLE [importCDFL].[PurchaseOrder_R27_CustomerBillToAddressLine] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]           TINYINT      NOT NULL,
    [SequenceNumber]       SMALLINT     NOT NULL,
    [PONumber]             VARCHAR (22) NOT NULL,
    [PurchaserAddressLine] VARCHAR (35) NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R27_CustomerBillToAddressLine] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R27_CustomerBillToAddressLine.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R27_CustomerBillToAddressLine]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R27_CustomerBillToAddressLine.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R27_CustomerBillToAddressLine]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

