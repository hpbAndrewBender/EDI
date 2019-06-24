CREATE TABLE [importCDFL].[PurchaseOrder_R50_PurchaseOrderControl] (
    [Id]                        INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                   INT          NULL,
    [RecordCode]                TINYINT      NOT NULL,
    [SequenceNumber]            SMALLINT     NOT NULL,
    [PONumber]                  VARCHAR (22) NOT NULL,
    [TotalPurchaseOrderRecords] SMALLINT     NOT NULL,
    [TotalLineItemsinfile]      SMALLINT     NOT NULL,
    [TotalUnitsOrdered]         SMALLINT     NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R50_PurchaseOrderControl] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R50_PurchaseOrderControl.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R50_PurchaseOrderControl]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R50_PurchaseOrderControl.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R50_PurchaseOrderControl]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

