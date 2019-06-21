CREATE TABLE [importCDFL].[PurchaseOrder_R35_DropShipDetail] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [RecordCode]              TINYINT        NOT NULL,
    [SequenceNumber]          SMALLINT       NOT NULL,
    [PONumber]                VARCHAR (22)   NOT NULL,
    [GiftWrapFeeAmount]       DECIMAL (6, 2) NULL,
    [SendConsumerEmail]       BIT            NOT NULL,
    [OrderLevelGiftIndicator] BIT            NOT NULL,
    [SuppressPriceIndicator]  BIT            NOT NULL,
    [OrderLevelGiftWrapCode]  VARCHAR (3)    NULL,
    CONSTRAINT [PK_PurchaseOrder_R35_DropShipDetail] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R35_DropShipDetail.RecordSequence]
    ON [importCDFL].[PurchaseOrder_R35_DropShipDetail]([RecordCode] ASC, [SequenceNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PurchaseOrder_R35_DropShipDetail.RecordSequencePO]
    ON [importCDFL].[PurchaseOrder_R35_DropShipDetail]([RecordCode] ASC, [SequenceNumber] ASC, [PONumber] ASC);

