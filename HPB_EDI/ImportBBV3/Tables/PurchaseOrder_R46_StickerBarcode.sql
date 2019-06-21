CREATE TABLE [ImportBBV3].[PurchaseOrder_R46_StickerBarcode] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [RecordCode]       VARCHAR (2)  NULL,
    [SequenceNumber]   SMALLINT     NULL,
    [PONumber]         VARCHAR (22) NULL,
    [BarcodeTypeCode]  CHAR (2)     NULL,
    [StringforBarcode] VARCHAR (18) NULL,
    CONSTRAINT [PK_PurchaesOrder_R46_StickerBarcode] PRIMARY KEY CLUSTERED ([Id] ASC)
);

