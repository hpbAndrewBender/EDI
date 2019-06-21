CREATE TABLE [ImportBBV3].[PurchaseOrder_R46_StickerTextLines] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]      VARCHAR (2)  NULL,
    [SequenceNumber]  SMALLINT     NULL,
    [PONumber]        VARCHAR (22) NULL,
    [StickerTextLine] VARCHAR (30) NULL,
    CONSTRAINT [PK_PurchaseOrder_R46_StickerTextLines] PRIMARY KEY CLUSTERED ([Id] ASC)
);

