CREATE TABLE [importCDFL].[PurchaseOrder_R40_LineItem] (
    [Id]                     INT          IDENTITY (1, 1) NOT NULL,
    [BatchId]                INT          NULL,
    [RecordCode]             TINYINT      NOT NULL,
    [SequenceNumber]         SMALLINT     NOT NULL,
    [PONumber]               VARCHAR (22) NOT NULL,
    [LineItemPONumber]       VARCHAR (10) NOT NULL,
    [ItemNumber]             VARCHAR (20) NOT NULL,
    [LineLevelBackorderCode] CHAR (1)     NULL,
    [SpecialActionCode]      VARCHAR (2)  NULL,
    [ItemNumberType]         VARCHAR (2)  NULL,
    CONSTRAINT [PK_PurchaseOrder_R40_LineItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R40_LineItem.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R40_LineItem]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R40_LineItem.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R40_LineItem]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

