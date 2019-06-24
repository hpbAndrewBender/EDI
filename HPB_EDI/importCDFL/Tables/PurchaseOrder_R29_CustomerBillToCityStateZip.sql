CREATE TABLE [importCDFL].[PurchaseOrder_R29_CustomerBillToCityStateZip] (
    [Id]                       INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                  INT          NULL,
    [RecordCode]               TINYINT      NOT NULL,
    [SequenceNumber]           SMALLINT     NOT NULL,
    [PONumber]                 VARCHAR (22) NOT NULL,
    [PurchaserCity]            VARCHAR (25) NOT NULL,
    [PurchaserStateOrProvince] VARCHAR (3)  NOT NULL,
    [PurchaserPostalCode]      VARCHAR (11) NOT NULL,
    [PurchaserCountry]         VARCHAR (3)  NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R29_CustomerBillToCityStateZip] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R29_CustomerBillToCityStateZip.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R29_CustomerBillToCityStateZip]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R29_CustomerBillToCityStateZip.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R29_CustomerBillToCityStateZip]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

