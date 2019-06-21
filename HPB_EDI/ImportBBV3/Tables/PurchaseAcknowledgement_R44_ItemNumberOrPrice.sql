CREATE TABLE [ImportBBV3].[PurchaseAcknowledgement_R44_ItemNumberOrPrice] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [BatchId]                INT            NULL,
    [RecordCode]             VARCHAR (2)    NULL,
    [SequenceNumber]         SMALLINT       NULL,
    [PONumber]               VARCHAR (22)   NULL,
    [ForwardedItemNumber]    VARCHAR (20)   NULL,
    [NetOrDiscountPrice]     NUMERIC (8, 2) NULL,
    [ItemNumberType]         VARCHAR (2)    NULL,
    [TotalLineOrderQuantity] SMALLINT       NULL,
    CONSTRAINT [PK_PurchaseAcknowledgement_R44_ItemNumberOrPrice] PRIMARY KEY CLUSTERED ([Id] ASC)
);



