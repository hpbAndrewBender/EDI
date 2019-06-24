CREATE TABLE [importCDFL].[PurchaseOrder_R24_CustomerCost] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [BatchId]           INT            NULL,
    [RecordCode]        TINYINT        NOT NULL,
    [SequenceNumber]    SMALLINT       NOT NULL,
    [PONumber]          VARCHAR (22)   NOT NULL,
    [SalesTaxPercent]   DECIMAL (7, 4) NULL,
    [FreightTaxPercent] DECIMAL (6, 3) NULL,
    [FreightAmount]     DECIMAL (7, 2) NULL,
    CONSTRAINT [PK_PurchaseOrder_R24_CustomerCost] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R24_CustomerCost.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R24_CustomerCost]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R24_CustomerCost.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R24_CustomerCost]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

