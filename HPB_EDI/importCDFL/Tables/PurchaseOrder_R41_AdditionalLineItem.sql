CREATE TABLE [importCDFL].[PurchaseOrder_R41_AdditionalLineItem] (
    [Id]                           INT            IDENTITY (1, 1) NOT NULL,
    [BatchId]                      INT            NULL,
    [RecordCode]                   TINYINT        NOT NULL,
    [SequenceNumber]               SMALLINT       NOT NULL,
    [PONumber]                     VARCHAR (22)   NOT NULL,
    [ClientItemListPrice]          DECIMAL (7, 2) NULL,
    [LineLevelBackorderCancelDate] DATE           NULL,
    [LineLevelGiftWrapCode]        VARCHAR (3)    NULL,
    [OrderQuantity]                SMALLINT       NOT NULL,
    CONSTRAINT [PK_PurchaseOrder_R41_AdditionalLineItem] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R41_AdditionalLineItem.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R41_AdditionalLineItem]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R41_AdditionalLineItem.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R41_AdditionalLineItem]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

